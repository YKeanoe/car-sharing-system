var userPos = {lat:"", lng:""};

function setMap(data) {
	var carLocs = JSON.parse(data.d);
	carPos = carLocs;
}

function getLocation() {
	var dfd = $.Deferred();
	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(function (position) {
			userPos = { lat: position.coords.latitude, lng: position.coords.longitude }
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

function sendRequestForCarLocation() {
	var dfd = $.Deferred();
	$.ajax({
		type: "POST",
		url: "/Views/bookingconfirmation.aspx/getCarLocation",
		data: "{}",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (response) {
			setMap(response);
			dfd.resolve();
		},
		failure: function () {
			console.error("Car JSON error");
			dfd.reject();
		}
	});
	return dfd.promise();
}

function sendUserLoc() {
	console.log("send u");
	console.log(userPos);
	var dfd = $.Deferred();
	$.ajax({
		type: "POST",
		url: "/Views/bookingconfirmation.aspx/setLoc",
		data: JSON.stringify(userPos),
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function () {
			console.log("Location send succ");
			dfd.resolve();
		},
		failure: function () {
			console.error("Location send error");
			dfd.reject();
		}
	});
	console.log("send u2");

	return dfd.promise();
}


$(window).on('load', function () {
	console.log("setting map");
	var dfd = $.Deferred();
	var getLocationStatus = getLocation();
	getLocationStatus.then(sendUserLoc).then(sendRequestForCarLocation).done(function () {
		dfd.resolve();
		var googleurl = "https://maps.googleapis.com/maps/api/staticmap?"
						+ "&size=500x500"
						+ "&markers=color:red%7Clabel:C%7C" + carPos.lat + "," + carPos.lng
						+ "&markers=color:blue%7Clabel:U%7C" + userPos.lat + "," + userPos.lng
						+ "&key=AIzaSyA7zQh6CSIAHNX4fJdw0sY5GPL2wjemyHY"
		console.log(googleurl);
		$('#googlemap').attr('src', googleurl);
		console.log("setmap done");
	})
});