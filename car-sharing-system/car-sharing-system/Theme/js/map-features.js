// Global variable to store user's position
var userPos = { lat: "", lng: "" };

// Function to initialize google map and its marker
function initializeMap(data) {
  var carLocs = JSON.parse(data.d);
  console.log("initializing map with data");
  console.log(carLocs)

  refreshList(carLocs);

  var usericon = '/Theme/Images/marker-circle-small.png';
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
  // Set boundary so that the map can fit all markers
  for (var i = 0; i < markers.length; i++) {
    bounds.extend(markers[i].getPosition());
  }
  bounds.extend(userPos);
  map.fitBounds(bounds);
  console.log("map initialized and done");
}

// Function to get user's location
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
    x.innerHTML = "Geolocation is not supported by this browser.";
    reject();
  }
  console.log("getlocation done");
  return dfd.promise();
}

function sendRequestForCars() {
  var dfd = $.Deferred();
  $.ajax({
    type: "POST",
    url: "/Views/index.aspx/getCarsData",
    data: "{}",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (response) {
      initializeMap(response);
      dfd.resolve();
    },
    failure: function () {
      console.error("Car JSON error");
      dfd.reject();
    }
  });
  return dfd.promise();
}

function setMap() {
  console.log("setting map");
  var dfd = $.Deferred();
  var getLocationStatus = getLocation();
  getLocationStatus.then(sendRequestForCars).done(function () {
    dfd.resolve();
    console.log("setmap done");
  })
  return dfd.promise();

  //getLocation().then(sendRequestForCars);
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

$('#seat-filter-dropdown li a  ').click(function () {
  $('#seat-filter').html($(this).html() + " <span class=\"caret\"></span>");
})

$('#sortby-filter-dropdown li a  ').click(function () {
  $('#sortby-filter').html($(this).html() + " <span class=\"caret\"></span>");
})

$('#list-collapse-btn').click(function () {
  var promise = sendFilterRequest();
  promise.then(setMap).done(function () {
    console.log("filter done");
    $('#list-collapse').collapse('toggle');
    $('#list-collapse-btn').prop("disabled", false);

  })
})


function sendFilterRequest() {
  var dfd = $.Deferred();
  var brand = $('#brand-filter').text();
  var seat = $('#seat-filter').text();
  var sortby = $('#sortby-filter').text();
  // Remove all spaces. Careful if the car's brand contain 2 words.
  brand = brand.replace(/\s+/g, '');
  // Remove spaces and 'seats'. returns only the number of seats.
  seat = seat.charAt(0);
  // Convert sortby options to interger.
  if (sortby == "Sort by ") {
    sortby = 0; // 0 represent default or sort by distance
  } else if (sortby == "Distance (Lowest) ") {
    sortby = 0;
  } else if (sortby == "Distance (Highest) ") {
    sortby = 1; // 1 represent sort by furthest distance
  } else if (sortby == "Rate (Lowest) ") {
    sortby = 2; // 2 represent sort by lowest rate
  } else {
    sortby = 3; // 3 represent sort by highest rate
  }
  console.log(brand + " | " + seat + " | " + sortby);
  $('#list-collapse-btn').prop("disabled", true);
  $('#list-collapse').collapse('toggle');
  $('#list-collapse').on('hidden.bs.collapse', function () {
    dfd.resolve('done');

  })

  console.log("sendfilter done");
  return dfd.promise();
}

// Set windows onload not ready as it need to load
// googlemap apis before starting.
$(window).on('load', function () {
  setMap();

  /*
  setInterval(function () {
    setMap();
  }, 5000);
  */
});

// Get location of user after load is successful
//window.onload = getLocation

function refreshList(data) {
  console.log("refreshing list");
  $("#carlist").empty();

  for (var i = 0; i < data.length; i++) {
    var carName = data[i].carName;
    var range = data[i].dist;
    var html = '<div class="panel-default car-panel">\
                  <div class="panel-heading">\
                    <a data-toggle="collapse" href="#{0}" class="car-panel-title">\
                      {1}\
                      <span style="float:right;">{2}m away</span>\
                    </a>\
                  </div>\
                  <div id="{0}" class="panel-collapse collapse">\
                    <div class="panel-body">\
                      <a class="btn" href="/dashboard/confirmation?id=aaaaa" role="button">Register</a>\
                      asdasd asdasd\
                    </div>\
                  </div>\
                </div>';
    html = html.replace(/\{0\}/g, "collapse_" + i);
    html = html.replace(/\{1\}/g, carName);
    html = html.replace(/\{2\}/g, range);

    $("#carlist").append(html);
  }
  console.log("list refreshed");
}
