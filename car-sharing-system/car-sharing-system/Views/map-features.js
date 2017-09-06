// Global variable to store user's position
var userPos = { lat: "", lng: "" };

// Function to initialize google map and its marker
function initializeMap(data) {
  var carLocs = JSON.parse(data.d);
  console.log(carLocs)

  refreshList(carLocs);

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

$('#seat-filter-dropdown li a  ').click(function () {
  $('#seat-filter').html($(this).html() + " <span class=\"caret\"></span>");
})

$('#sortby-filter-dropdown li a  ').click(function () {
  $('#sortby-filter').html($(this).html() + " <span class=\"caret\"></span>");
})

$('#list-collapse-btn').click(function () {
  var brand = $('#brand-filter').text();
  var seat = $('#seat-filter').text();
  var sortby = $('#sortby-filter').text();
  console.log(brand + " | " + seat + " | " + sortby);
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
  $('#list-collapse').collapse('hide');
  setMap();
  $(this).prop(disabled, true);
  setTimeout(function () {
    $('#list-collapse').collapse('show');
    $(this).prop(disabled, false);
  }, 2000);
})


// Set windows onload not ready as it need to load
// googlemap apis before starting.
$(window).load(function () {
  test();
  setMap();
  /*
  setInterval(function () {
    setMap();
  }, 10000);*/
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
                      asdasd asdasd\
                    </div>\
                  </div>\
                </div>';
    html = html.replace(/\{0\}/g, "collapse_" + i);
    html = html.replace("{1}", carName);
    html = html.replace("{2}", range);

    $("#carlist").append(html);

  }




}
