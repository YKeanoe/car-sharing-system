
function setMap(data) {
	var carLocs = JSON.parse(data.d);
	console.log(carLocs);
	carPos = carLocs;
}

function getLocation() {
	var dfd = $.Deferred();
	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(function (position) {
			userPos = { lat: position.coords.latitude, lng: position.coords.longitude }
			console.log(userPos);
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

$(window).on('load', function () {
	console.log("setting map");
	var dfd = $.Deferred();
	var getLocationStatus = getLocation();
	getLocationStatus.then(sendRequestForCarLocation).done(function () {
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