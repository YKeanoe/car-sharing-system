# AceRentalBooking
# ------------------
# Run the python script using all packages included.
# Click the stop button before closing the window, ensuring all bookings is finished before closed
# ----------------------------------------------------------
# HOW TO USE
# Just input the amount of bookings you want, the program will
# automatically pick a random spot around melbourne to book from
# and pick the couple first available car and user ids available to
# book with and just watch the car move.
import sys
import requests
import json
import ast
import time
from random import uniform
from mpl_toolkits.basemap import Basemap
import urllib
import threading
import thread
import Tkinter
from Tkinter import *


# Initialize urls and thread list.
url = "http://localhost:13433/"
car_param = "api/car/"
car_param_loc = "api/car/id/"
user_param = "api/user/"
booking_param = "api/booking/"
booking_param_finish = "finish"
threads = []

# Recursion limit for py2exe
sys.setrecursionlimit(5000)

# make_booking method is used to make booking. Method take user_amount as for choosing how many bookings to be made.
def make_booking(user_amount):
    # Request available user ids
    response = requests.get(url + user_param + user_amount)
    data = response.json()
    # Convert retrieved unicode user ids to list
    user_ids = ast.literal_eval(data)

    # Request available nearby cars
    response = requests.get(url + car_param + user_amount)
    data = response.json()
    # Convert retrieved unicode car number plates to list
    number_plates = ast.literal_eval(data)

    # Store user ids and car ids to be returned
    uid_and_cid = []

    # Create booking for each user and car id.
    for id in range(0, len(user_ids)):
        loc = get_lat_long_near_melbourne()
        now = round(time.time()) + 1
        end = now + 7200
        booking = {
            'book': {'accountID': user_ids[id],
                     'numberPlate': number_plates[id],
                     'bookingDate': now,
                     'startDate': now,
                     'estEndDate': end
                     },
            'location': {
                       'lat': loc['lat'],
                       'lng': loc['lng']
                   }
                   }
        requests.post(url + booking_param, json=booking)
        uid_and_cid.append({'uid': user_ids[id], 'cid': number_plates[id]})
    # Return user and car ids for threads.
    return uid_and_cid


# return landed lat long within range of map (melbourne)
def get_lat_long_near_melbourne():
    # llcrnr means lower left corner of the map
    # urcrnr means upper right corner of the map
    bm = Basemap(llcrnrlon=144.793017,
                  llcrnrlat=-37.833566,
                  urcrnrlon=145.503432,
                  urcrnrlat=-37.487905,
                  projection='cyl',
                  resolution='i')
    # get random value for lat long
    x, y = uniform(-37.478, -37.883), uniform(144.793, 145.503)
    mlon, mlat = bm(y, x)  # convert to projection map
    while not bm.is_land(mlon,mlat):
        x, y = uniform(-37.478, -37.883), uniform(144.793, 145.503)
        mlon, mlat = bm(y, x)  # convert to projection map
    return {'lat':x, 'lng':y}


# Inner class for threads.
class CarThread(threading.Thread):
    # Return a list of intermediate points with nb_points as length
    def intermediates(self, p1, p2, nb_points):
        x_spacing = (p2[0] - p1[0]) / (nb_points + 1)
        y_spacing = (p2[1] - p1[1]) / (nb_points + 1)

        return [[p1[0] + i * x_spacing, p1[1] + i * y_spacing]
                for i in range(1, nb_points + 1)]

    # Get randomized point around the car location
    def get_lat_long_near_location(self, latlong):
        upper_right = {'lat': latlong['lat'] + 0.1, 'lng': latlong['lng'] + 0.1}
        lower_left = {'lat': latlong['lat'] - 0.1, 'lng': latlong['lng'] - 0.1}
        # llcrnr means lower left corner of the map
        # urcrnr means upper right corner of the map
        bm = Basemap(llcrnrlon=lower_left['lng'],
                     llcrnrlat=lower_left['lat'],
                     urcrnrlon=upper_right['lng'],
                     urcrnrlat=upper_right['lat'],
                     projection='cyl',
                     resolution='i')

        # get random value for lat long
        x, y = uniform(lower_left['lat'], upper_right['lat']), uniform(lower_left['lng'], upper_right['lng'])
        mlon, mlat = bm(y, x)  # convert to projection map
        while not bm.is_land(mlon, mlat):
            x, y = uniform(lower_left['lat'], upper_right['lat']), uniform(lower_left['lng'], upper_right['lng'])
            mlon, mlat = bm(y, x)  # convert to projection map
        return {'lat': x, 'lng': y}

    # Return list of coordinates for the car's route
    def google_travel(self, start, dest):
        google_url = ("https://maps.googleapis.com/maps/api/directions/json"
                      "?origin={},{}"
                      "&destination={},{}"
                      "&mode=driving"
                      "&key=AIzaSyCVtkFkAt7qjm3egiu1VL8sHI-IJKtE5x8"
                      .format(start['lat'], start['lng'], dest['lat'], dest['lng']))
        # print google_url
        # Open url and grab json
        ur = urllib.urlopen(google_url)
        result = json.load(ur)
        # Set final distance and endtimes.
        self.distance = result['routes'][0]['legs'][0]['distance']['value']
        self.endTime = result['routes'][0]['legs'][0]['duration']['value']
        # Store the steps from google api to be returned
        steps = []
        for i in range(0, len(result['routes'][0]['legs'][0]['steps'])):
            step_start = result['routes'][0]['legs'][0]['steps'][i]['start_location']
            step_end = result['routes'][0]['legs'][0]['steps'][i]['end_location']
            # converting the google api to an easier format.
            step_start_list = [step_start['lat'], step_start['lng']]
            step_end_list = [step_end['lat'], step_end['lng']]
            # steps duration value returns seconds needed for this steps,
            # therefore, if the map refresh 1/sec, then nb_points = refresh
            refresh = result['routes'][0]['legs'][0]['steps'][i]['duration']['value']
            # set refresh value to every 3 seconds. So the amount of steps should be
            # result / 3
            refresh = refresh/3
            steps.extend(self.intermediates(step_start_list, step_end_list, refresh))
        return steps

    # Send post method to web api
    def send_post_car_location(self, steps):
        loc = {}
        for i in range(0, len(steps)):
            if self.running:
                output = "Move car {} to {},{}".format(self.thread_name, steps[i][0], steps[i][1])
                self.print_output(output)
                loc = {'lat': steps[i][0], 'lng': steps[i][1]}
                requests.post(url + car_param_loc + self.car_id, json=loc)
                time.sleep(3)
            else:
                break
        # Check if the loc is empty. empty loc means that the method didn't even run once.
        if loc:
            self.last_loc = loc
            self.stop()
        else:
            self.last_loc = {'lat': steps[0][0], 'lng': steps[0][0]}
            self.stop()

    def run(self):
        output = "%s thread start" % self.thread_name
        self.print_output(output)
        # Get car's location
        response = requests.get(url + car_param_loc + self.car_id)
        data = response.json()
        latlong = ast.literal_eval(data)
        # Get randomized destination location
        dest_latlong = self.get_lat_long_near_location(latlong)
        # Run method
        steps = self.google_travel(latlong, dest_latlong)
        self.send_post_car_location(steps)
        output = "Thread %s is ending" % self.thread_name
        self.print_output(output)

    def thread_stopper(self):
        self.running = False

    def stop(self):
        output = "%s stopping" % self.thread_name
        self.print_output(output)
        self.stop_booking()
        output = "%s stopped" % self.thread_name
        self.print_output(output)
        thread.exit()

    def stop_booking(self):
        data = {
            'user_id': self.user_id,
            'distance': self.distance,
            'lat': self.last_loc['lat'],
            'lng': self.last_loc['lng'],
            'timeToEnd': self.endTime
        }
        requests.post(url + booking_param + booking_param_finish, json=data)

    def print_output(self, output):
        self.debugText.config(state=NORMAL)
        self.debugText.insert(END, output + "\n")
        self.debugText.config(state=DISABLED)

    def __init__(self, thread_name, car_id, user_id, debugText):
        threading.Thread.__init__(self)
        self.thread_name = thread_name
        self.car_id = car_id
        self.user_id = user_id
        self.running = True
        self.endTime = None
        self.distance = None
        self.last_loc = None
        self.debugText = debugText


# Confirm Button method
def confirm(amount, btn, input, debugText):
    btn.config(state="disable")
    input.config(state="disabled")
    users_and_cars = make_booking(amount)
    # Run a thread for each booking
    for id in users_and_cars:
        thread_name = "thread-" + id['cid']
        try:
            cthread = CarThread(thread_name, id['cid'], id['uid'], debugText)
            cthread.start()
            # Store threads for early stop
            threads.append(cthread)
        except:
            print "Error trying to start %s" % thread_name

# # listener. Press x to stop properly (finishing the booking)
def cancel(cancelBtn, window):
    cancelBtn.config(state="disable")
    for t in threads:
        t.thread_stopper()


# Main function
def main():
    # Create booking and store user and car ids
    users_and_cars = []

    # Create window
    window = Tkinter.Tk()
    window.geometry("600x800")
    window.title("Ace Rentals GPS API")

    # Set top label
    inputLabel = StringVar()
    inputLabel.set("Input Booking amount")
    label = Label(window, textvariable=inputLabel, height=2)
    label.pack()

    # Set booking amount entry
    inputAmount = Entry()
    inputAmount.pack(pady=20)

    # Set button frame for 1 line buttons
    buttonFrame = Frame(window)
    buttonFrame.grid(row=2, column=0, columnspan=2)
    # Set buttons
    inputButton = Button(buttonFrame, text="Confirm", command=lambda: confirm(inputAmount.get(), buttonFrame.winfo_children()[0], inputAmount, debugText)).grid(row=0, column=0)
    cancelButton = Button(buttonFrame, text="Stop", command=lambda: cancel(buttonFrame.winfo_children()[1], window)).grid(row=0, column=1)
    buttonFrame.pack(pady=20)

    # Set debug text box
    debugText = Text(window, height=1, width=5)
    debugText.config(state=DISABLED)
    debugText.pack(fill=BOTH, expand=1)

    # Run window
    window.mainloop()


if __name__ == "__main__":
    main()

