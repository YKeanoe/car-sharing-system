$(window).on('load', function () {
	var promise = sendPageRequest(1);
	promise.then(sendPageCountRequest).done(function () {
		console.log("filter done");
	})
});

function sendPageRequest(pagenum) {
	var jsonObj = { page: pagenum };
	var dfd = $.Deferred();
	$.ajax({
		type: "POST",
		url: "/Views/admincar.aspx/getCarPage",
		data: JSON.stringify(jsonObj),
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (response) {
			setList(response);
			dfd.resolve();
		},
		failure: function () {
			console.error("Car JSON error");
			dfd.reject();
		}
	});
	return dfd.promise();
}

function sendPageCountRequest() {
	var dfd = $.Deferred();
	$.ajax({
		type: "POST",
		url: "/Views/admincar.aspx/getCarPageCount",
		data: "{}",
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (response) {
			setListPage(response);
			dfd.resolve();
		},
		failure: function () {
			console.error("Car JSON error");
			dfd.reject();
		}
	});
	return dfd.promise();
}

function setListPage(count) {
	console.log(count);
	$('#car-page').twbsPagination({
		totalPages: count.d,
		visiblePages: 18,
		onPageClick: function (event, page) {
			sendPageRequest(page);
		}
	});
}

function setList(data) {
	// Empty the carlist first.
	$(".table > tbody").empty();
	var carData = JSON.parse(data.d);
	for (var i = 0; i < carData.length; i++) {
		$(".table > tbody").append(carData[i]);
	}
}