// Global variable to store user's position
var userPos = { lat: "", lng: "" };

// Function to initialize google map and its marker
function initializeMap(data) {
  var carLocs = JSON.parse(data.d);
  console.log(carLocs)
  var usericon = 'Images/marker-circle-small.png';
  var markers = [];
  var bounds = new google.maps.LatLngBounds();

  // Initialize map
  var map = new google.maps.Map(document.getElementById('map'), {
    zoom: 14,
    center: userPos
  });

  // Set markers for user
  var markerUser = new google.maps.Marker({
    position: userPos,
    title: "User",
    icon: usericon
  });
  markers.push(markerUser);
  markerUser.setMap(map);

  // Set markers for cars
  for (var i = 0; i < carLocs.length; i++) {
    if (i == 8) {
      break;
    }
    var markerCar = new google.maps.Marker({
      position: carLocs[i].loc,
      title: carLocs[i].carName
    });
    markers.push(markerCar);
    markerCar.setMap(map);
  }
  console.log(markers.length);

  // Set boundary so that the map can fit all markers
  for (var i = 0; i < markers.length; i++) {
    bounds.extend(markers[i].getPosition());
  }
  bounds.extend(userPos);
  map.fitBounds(bounds);
}

// Function to get user's location
function getLocation() {
  return new Promise(function (resolve, reject) {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(function (position) {
        setUserPosition(position);
        resolve();
      }, function () {
        reject();
      });
    } else {
      x.innerHTML = "Geolocation is not supported by this browser.";
      reject();
    }
  })
}

function sendRequestForCars() {
    $.ajax({
      type: "POST",
      url: "index.aspx/getCarsData",
      data: "{}",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (response) {
        initializeMap(response);
      },
      failure: function () {
        console.error("Car JSON error");
      }
    });
}

function test() {
  $.ajax({
    type: "POST",
    url: "/Controllers/FrontPageServices.asmx/HelloWorld",
    data: "{}",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (response) {
      console.log(response);
    },
    failure: function () {
      console.error("Car JSON error");
    }
  });
}

function setMap() {
  getLocation().then(sendRequestForCars);
}

function refreshMap() {
  // Use to find distance between current position and last position
  var x = google.maps.geometry.spherical.computeDistanceBetween(loc, loc2);
  getLocation().then(sendRequestForCars);
}

function setUserPosition(position) {
  console.log("user position is set");
  userPos = { lat: position.coords.latitude, lng: position.coords.longitude }
}

$('#brand-filter-dropdown li a  ').click(function () {
  $('#brand-filter').html($(this).html() + " <span class=\"caret\"></span>");
})

// Set windows onload not ready as it need to load
// googlemap apis before starting.
$(window).load(function () {
  test();
  setMap();
  
  setInterval(function () {
    setMap();
  }, 3000);
});

// Get location of user after load is successful
//window.onload = getLocation