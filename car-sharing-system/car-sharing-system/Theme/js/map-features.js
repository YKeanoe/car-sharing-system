// Global variable to store user's position
var userPos = { lat: "", lng: "" };

// Function to initialize google map and its marker
function initializeMap(data) {
	// Parse data into json object
	var carLocs = JSON.parse(data.d);
	// Refresh the html lists
	refreshList(carLocs);

	var usericon = '/Theme/Images/user42.png';
	var caricon = '/Theme/Images/caricon48.png';
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

	var carname = null;
	// Set markers for cars
	// If carlocs exits (not null), then set markers for all car's locations
	if (carLocs) {
	    for (var i = 0; i < carLocs.length; i++) {
	        carname = carLocs[i].carName;
	        var markerCar = new google.maps.Marker({
	            position: carLocs[i].loc,
	            title: carname,
	            icon: caricon
	        });
	        markers.push(markerCar);
	        markerCar.setMap(map);
	    }
	}
	// Set boundary so that the map can fit all markers
	for (var i = 0; i < markers.length; i++) {
		bounds.extend(markers[i].getPosition());
	}
	bounds.extend(userPos);
	// Extend map's boundary to fit all markers
	map.fitBounds(bounds);
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
// Call initializeMap function when successfull
function sendRequestForCars() {
	var path = window.location.pathname;
	var wmurl;
	if (path == "/") {
		wmurl = "/Views/index.aspx/getCarsData"
	} else {
		wmurl = "/Views/dashboard.aspx/getCarsData"
	}

	var dfd = $.Deferred();
	$.ajax({
		type: "POST",
		url: wmurl,
		data: JSON.stringify(userPos),
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

// Function to send request to server for cars with filters
// Call initializeMap function when successfull
function sendRequestForCarsWithFilter(filter) {
	// Combine filter data and user position
	var result = {};
	for (var key in userPos) result[key] = userPos[key];
	for (var key in filter) result[key] = filter[key];

	var path = window.location.pathname;
	var wmurl;
	if (path == "/") {
		wmurl = "/Views/index.aspx/getCarsDataFiltered"
	} else {
		wmurl = "/Views/dashboard.aspx/getCarsDataFiltered"
	}

	var dfd = $.Deferred();
	$.ajax({
		type: "POST",
		url: wmurl,
		data: JSON.stringify(result),
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

// Function to set map asynchronously so that user position is set first and then
// a request to the server is called.
function setMap() {
	var dfd = $.Deferred();
	var getLocationStatus = getLocation();
	getLocationStatus.then(sendRequestForCars).done(function () {
		dfd.resolve();
		console.log("setmap done");
	})
	return dfd.promise();
}

// Function to set map with filters asynchronously so that user position
// is set first and then a request to the server is called.
function setMapWithFilters(filter) {
	var dfd = $.Deferred();
	var getLocationStatus = getLocation();
	getLocationStatus.then(sendRequestForCarsWithFilter(filter)).done(function () {
		// Refresh the pagination page number
		$('#car-page .active').removeClass("active");
		$('#car-page li a').filter(function () { return $.text([this]) === '1'; }).parent('li').addClass("active");
		dfd.resolve();
	})
	return dfd.promise();
}

// Function to set user's position
function setUserPosition(position) {
	userPos = { lat: position.coords.latitude, lng: position.coords.longitude }
}

function filterClickfunctions() {
	$('#brand-filter-dropdown li a  ').click(function () {
		$('#brand-filter').html($(this).html() + " <span class=\"caret\"></span>");
	})
	$('#seat-filter-dropdown li a  ').click(function () {
		$('#seat-filter').html($(this).html() + " <span class=\"caret\"></span>");
	})
	$('#sortby-filter-dropdown li a  ').click(function () {
		$('#sortby-filter').html($(this).html() + " <span class=\"caret\"></span>");
	})
	$('#type-filter-dropdown li a  ').click(function () {
		$('#type-filter').html($(this).html() + " <span class=\"caret\"></span>");
	})
	$('#transmission-filter-dropdown li a  ').click(function () {
		$('#transmission-filter').html($(this).html() + " <span class=\"caret\"></span>");
	})
	// Filter button function
	$('#list-collapse-btn').click(function () {
		var promise = sendFilterRequest();
		promise.then(setMapWithFilters).done(function () {
			console.log("filter done");
			$('#list-collapse').collapse('toggle');
			$('#list-collapse-btn').prop("disabled", false);
		})
	})
	// Set pagination to be activated when clicked.
	$('#car-page li a').click(function () {
		$('#car-page .active').removeClass("active");
		$(this).parent('li').addClass("active");
		loadPage($('#car-page .active').text())
	})
	// Set advance filter's swap color function
	$(".flat-butt").click(function () {
		$(this).toggleClass('flat-danger-butt flat-primary-butt');
	});
}


function setDatetimePickerFunction() {
	// Set the start and end date datetimepicker
	//var now = moment().endOf('hour').add(1, 'seconds').startOf('hour').toDate();
	// Round date to the next nearest 5 minute
	var round = Math.ceil((moment().get('minute')) / 5) * 5;
	var now = moment().set('minute', round).set('second', 0).set('millisecond', 0).toDate();

	var startMax = moment().set('minute', round).set('second', 0).set('millisecond', 0).add(12,'hours').toDate();
	$('#start-date-picker').datetimepicker({
		date: now,
		stepping:5,
		minDate: now,
		maxDate: startMax,
		format: 'DD/MM/YYYY HH:mm'
	});
	var next = moment().set('minute', round).set('second', 0).set('millisecond', 0).add(1, 'hours').toDate();
	$('#end-date-picker').datetimepicker({
		date: next,
		stepping:5,
		minDate: next,
		useCurrent: false, //Important! See issue #1075
		format: 'DD/MM/YYYY HH:mm'
	});
	$("#start-date-picker").on("dp.change", function (e) {
		$('#end-date-picker').data("DateTimePicker").minDate(e.date.add(1, 'hours'));
		var startmoment = $("#start-date-picker").data("DateTimePicker").date();
		var endmoment = $("#end-date-picker").data("DateTimePicker").date();
		if (startmoment > endmoment) {
			$("#end-date-picker").data("DateTimePicker").date(e.date);
		}
	});
}

function loadPage(pagenum) {
	sendPageRequest(pagenum);
}

function sendPageRequest(pagenum) {
	var path = window.location.pathname;
	var wmurl;
	if (path == "/") {
		wmurl = "/Views/index.aspx/getCarPage"
	} else {
		wmurl = "/Views/dashboard.aspx/getCarPage"
	}
	var jsonObj = { page: pagenum };
	var dfd = $.Deferred();
	$.ajax({
		type: "POST",
		url: wmurl,
		data: JSON.stringify(jsonObj),
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

function sendFilterRequest() {
	var dfd = $.Deferred();
	var filterObj;
	var startdate = $("#start-date-picker").data("DateTimePicker").date().format('X');
	var endate = $("#end-date-picker").data("DateTimePicker").date().format('X');
	var brand = $('#brand-filter').text();
	var seat = $('#seat-filter').text();
	var sortby = $('#sortby-filter').text();
	var transmission = $('#transmission-filter').text();
	var type = $('#type-filter').text();
	var adv = $('#x-filter').attr('aria-expanded');
	var cd = ($('#cd-btn').hasClass("flat-primary-butt"));
	var bt = ($('#bt-btn').hasClass("flat-primary-butt"));
	var gps = ($('#gps-btn').hasClass("flat-primary-butt"));
	var cc = ($('#cc-btn').hasClass("flat-primary-butt"));
	var rad = ($('#rad-btn').hasClass("flat-primary-butt"));
	var revcam = ($('#rev-btn').hasClass("flat-primary-butt"));

	// Remove all spaces. Careful if the car's brand contain 2 words.
	// brand = brand.replace(/\s+/g, '');
	// Remove all spaces at the start or end of the string.
	// Swap brand to any if no specific brand is filtered.
	brand = brand.trim();
	if (brand == "Brand") {
		brand = "Any";
	}
	// Remove spaces and 'seats' and returns only the number of seats if 
	// it's specified.
	seat = seat.trim();
	if (seat == "Any" || seat == "Seats") {
		seat = "Any"
	} else {
		seat = seat.charAt(0);
	}
	// Convert sortby options to interger.
	sortby = sortby.trim();
	if (sortby == "Sort by") {
	sortby = 0; // 0 represent default or sort by distance
	} else if (sortby == "Distance (Lowest) (Default)") {
	sortby = 0;
	} else if (sortby == "Distance (Highest)") {
	sortby = 1; // 1 represent sort by furthest distance
	} else if (sortby == "Rate (Lowest)") {
	sortby = 2; // 2 represent sort by lowest rate
	} else {
	sortby = 3; // 3 represent sort by highest rate
	}
	// Convert transmission to char. N to identify none.
	transmission = transmission.trim();
	if (transmission == "Automatic") {
		transmission = "Auto";
	} else if (transmission == "Manual") {
		transmission = "Manual";
	} else {
		transmission = "Any";
	}
	// Trim type of unneccessary spaces.
	type = type.trim();
	if (type == "Type") {
		type = "Any";
	}
	// For some reason adv is set as 'undefined' if its not initialized manually.
	if (adv) {
		adv = true;
	} else {
		adv = false;
	}
	// Object to send as JSON
	filterObj = {
		sdate: startdate, edate: endate,
		brand: brand,
		seat: seat,
		sortby: sortby,
		transmission: transmission,
		type: type,
		adv: adv,
		cd: cd,
		bt: bt,
		gps: gps,
		cc: cc,
		rad: rad,
		revcam: revcam
	};
	// Set animation where the list is hid when retrieving data and 
	// extended when the data is received and done.
	$('#list-collapse-btn').prop("disabled", true);
	$('#list-collapse').collapse('toggle');
	$('#list-collapse').on('hidden.bs.collapse', function () {
		dfd.resolve(filterObj);
	})
	return dfd.promise();
}

// Function for refreshing the car's list. 
function refreshList(data) {
	// Empty the carlist first.
	$("#carlist-accordion").empty();
	// Check if data exist.
	if (data) {
		for (var i = 0; i < data.length; i++) {
			var carName = data[i].carName;
			var range = data[i].dist;
			re = /\((.*)\)/i;
			var carId = data[i].carName.match(re)[1];
			var html = "<div class=\"panel panel-default car-panel\">"
						+	"<div class=\"panel-heading\">"
						+		"<a data-toggle=\"collapse\" href=\"#{0}\" data-parent=\"#carlist-accordion\" class=\"car-panel-title\">"
						+			"{1}"
						+			"<span style=\"float:right;\">{2}m away</span>"
						+		"</a>"
						+	"</div>"
						+	"<div id=\"{0}\" class=\"panel-collapse collapse\">"
						+		"<div class=\"panel-body\">"
						+			"<a class=\"btn\" onclick=\"toBookingPage('{3}')\" role=\"button\">Book</a>"
						+			"asdasd asdasd"
						+		"</div>"
						+	"</div>"
						+"</div>";
			html = html.replace(/\{0\}/g, "collapse_" + i);
			html = html.replace(/\{1\}/g, carName);
			html = html.replace(/\{2\}/g, range);
			html = html.replace(/\{3\}/g, carId);
			$("#carlist-accordion").append(html);
		}
	}
}

function toBookingPage(id) {
	var startdate = $("#start-date-picker").data("DateTimePicker").date().format('X');
	var endate = $("#end-date-picker").data("DateTimePicker").date().format('X');
	location.href = "/dashboard/confirmation?id=" + id + "&sdate=" + startdate + "&edate=" + endate;
}


// Set windows onload not ready as it need to load
// googlemap apis before starting.
$(window).on('load', function () {
	filterClickfunctions();
	setDatetimePickerFunction();
	setMap();

	/*
	setInterval(function () {
	setMap();
	}, 5000);
	*/
});
