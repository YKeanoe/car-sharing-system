// Global variable to store user's position
var userPos = { lat: "", lng: "" };
// Global variable to store map's marker
var markers = [];
// Global variable for icons location
var usericon = '/Theme/Images/user42.png';
var caricon = '/Theme/Images/caricon48.png';
var cariconglow = '/Theme/Images/caricon-glow.png';

// Global variable for map
var map;

// Function to initialize google map and its marker
function initializeMap(data) {
	// Parse data into json object
	var carLocs = JSON.parse(data.d);
	// remove all markers
	markers = [];
	
	// Initialize map
	map = new google.maps.Map(document.getElementById('map'), {
		zoom: 15,
		center: userPos,
		styles: [
		  {
		  	"featureType": "poi.business",
		  	"stylers": [
			  {
			  	"visibility": "off"
			  }
		  	]
		  },
		  {
		  	"featureType": "poi.park",
		  	"elementType": "labels.text",
		  	"stylers": [
			  {
			  	"visibility": "off"
			  }
		  	]
		  }
		]
	});

	// Set markers for user
	var markerUser = new google.maps.Marker({
		position: userPos,
		title: "User",
		icon: usericon,
		carid: "User"
	});
	markers.push(markerUser);
	markerUser.setMap(map);

	// Set markers for cars
	// If carlocs exits (not null), then set markers for all car's locations
	if (carLocs) {
		var carname;
	    for (var i = 0; i < carLocs.length; i++) {
	        carname = carLocs[i].carName;
	        var markerCar = new google.maps.Marker({
	        	position: carLocs[i].loc,
	        	title: carname,
	        	icon: caricon,
	        	carid: carname.match(/\(([^)]+)\)/)[1]
	        });
	        markers.push(markerCar);
	        markerCar.setMap(map);

	    	// Create a private function for each marker
	    	(function (marker) {
	    		// Add listener to marker click to collapse all panel and
				// show the selected car panel
	    		google.maps.event.addListener(marker, "click", function (e) {
	    			var id = marker.get('carid');
	    			console.log(marker.get('carid'));
				});
	        })(markerCar);
	    }
	}

	// Add listener to map onclick to close all panel
	google.maps.event.addListener(map, "click", function (e) {
		//$('#carlist-accordion .panel .panel-collapse').collapse('hide');
	});
}


// Function to refresh the map's marker
// APPROACH 1:
// Check if marker exists
// If a marker reappear, update the location and remove the markers data
// If a marker didn't reappear, remove from map and markers array
// When all markers in markers array is checked, if there's more in markers data,
// add them to the markers array.
function refreshMap(data) {
	// Parse data into json object
	var carLocs = JSON.parse(data.d);

	// Set markers for cars
	// If carlocs exits (not null), then set markers for all car's locations
	if (carLocs) {

		console.log(carLocs);

		// Check if the marker reappear
		var found = false;
		for (var i = 0; i < markers.length; i++) {
			found = false;
			// For each marker, traverse new car data
			for (var j = 0; i < carLocs.length; i++) {
				var carid = carLocs[j].carName.match(/\(([^)]+)\)/)[1];
				// If found, set the marker new position, delete the new car data and break from loop.
				if (markers[i].get('carid') == carid) {
					// Setting position
					markers[i].setPosition(new google.maps.LatLng(carLocs[j].loc.lat, carLocs[j].loc.lng))
					// Remove markers data
					carLocs.splice(j, 1);
					found = true;
					break;
				}
			}
			// If marker doesn't reappear
			if (!found) {
				// Remove marker from map
				markers[i].setMap(null);
				// Remove marker from markers array.
				markers.splice(i, 1);
			}
		}

		// If there are still more new car data, add them.
		if (carLocs.length > 0) {
			for (var i = 0; i < carLocs.length; i++) {
				var carname = carLocs[i].carName;
				var carid = carname.match(/\(([^)]+)\)/)[1];
				var markerCar = new google.maps.Marker({
					position: carLocs[i].loc,
					title: carname,
					icon: caricon,
					carid: carid
				});
				markers.push(markerCar);
				markerCar.setMap(map);

				// Create a private function for each marker
				(function (marker) {
					// Add listener to marker click to collapse all panel and
					// show the selected car panel
					google.maps.event.addListener(marker, "click", function (e) {
						var id = marker.get('carid');
						console.log(marker.get('carid'));
					});
				})(markerCar);
			}
		}
	}
}

// Function to get user's location
// Function will call setUserPosition to set user's position global variable
function getLocation() {
	var dfd = $.Deferred();
	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(function (position) {
			setUserPosition(position);
			dfd.resolve();
		}, function () {
			dfd.reject();
		});
	} else {
		console.log("Geolocation is not supported by this browser.");
		reject();
	}
	return dfd.promise();
}

// Function to send request to server for cars.
// Takes 2 parameter, data is useless and used just so the function is called
// asynchronously, type is to detect if it is a refresh or initialization.
// Call initializeMap function or refreshMap when successful.
function sendRequestForCars(data, type) {
	console.log(type);
	var dfd = $.Deferred();
	$.ajax({
		type: "POST",
		url: "/Views/adminmap.aspx/getCarsData",
		data: "{}",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (response) {
			if (type == 1) {
				initializeMap(response);
			} else {
				refreshMap(response);
			}
			dfd.resolve();
		},
		failure: function () {
			console.error("Car JSON error");
			dfd.reject();
		}
	});
	return dfd.promise();
}


// Function to set map asynchronously so that user position is set first and then
// a request to the server is called.
function setMap() {
	var dfd = $.Deferred();
	var getLocationStatus = getLocation();
	getLocationStatus.then(function (data) { sendRequestForCars(data, 1) }).done(function () {
		dfd.resolve();
		console.log("setmap done");
	})
	return dfd.promise();
}

// Function to set user's position
function setUserPosition(position) {
	userPos = { lat: position.coords.latitude, lng: position.coords.longitude }
}

// Set windows onload not ready as it need to load
// googlemap apis before starting.
$(window).on('load', function () {
	// Initialize map
	setMap();
	
	// Set map to refresh every 5 seconds
	setInterval(function () {
		sendRequestForCars(2);
	}, 5000);
});
