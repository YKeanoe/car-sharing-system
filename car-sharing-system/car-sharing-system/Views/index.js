// Function to initialize google map and its marker
function initializeMap(position) {
  // Initialize cars (DUMMY DATA)
  // TO DO
  var car1 = { lat: -37.816261, lng: 144.970976 };
  var car2 = { lat: -37.815555, lng: 144.970107 };
  var car3 = { lat: -37.815539, lng: 144.966278 };

  // Get longitude and latitude from user's position
  var locLat = position.coords.latitude;
  var locLng = position.coords.longitude;
  var x = { lat: locLat, lng: locLng };

  var usericon = 'Images/marker-circle-small.png';
  var markers = [];
  var bounds = new google.maps.LatLngBounds();

  // Initialize map
  var map = new google.maps.Map(document.getElementById('map'), {
      zoom: 14,
      center: x
  });

  // Set markers for user and cars
  var markerUser = new google.maps.Marker({
    position: x,
    title: "User",
    icon: usericon
  });
  var markerCar1 = new google.maps.Marker({
      position: car1,
      title: "Car 1"
  });
  var markerCar2 = new google.maps.Marker({
    position: car2,
    title:"Car 2"
  });
  var markerCar3 = new google.maps.Marker({
    position: car3,
    title: "Car 3"
  });

  // Push all markers into array
  markers.push(markerCar1);
  markers.push(markerCar2);
  markers.push(markerCar3);
  markers.push(markerUser);

  // Set all markers into map
  markerUser.setMap(map);
  markerCar1.setMap(map);
  markerCar2.setMap(map);
  markerCar3.setMap(map);

  // Set boundary so that the map can fit all markers
  for (var i = 0; i < markers.length; i++) {
    bounds.extend(markers[i].getPosition());
  }
  bounds.extend(x);
  map.fitBounds(bounds);
}

// Function to get user's location
function getLocation() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(initializeMap);
  } else {
    x.innerHTML = "Geolocation is not supported by this browser.";
  }
}

// Get location of user after load is successful
window.onload = getLocation()