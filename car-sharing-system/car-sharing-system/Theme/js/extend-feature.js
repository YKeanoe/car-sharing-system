// Function to set DateTimePicker restrictions and functionality.
function setDatetimePickerFunction() {
	// Set the datetimepicker
	// Grab current end date from page
	var eDate = $("form > label > span:contains('To')").text();
	// Manipulate date string for easy conversion
	eDate = eDate.split(',')[1].trim();
	// Convert date string to moment object
	var endDate = moment(eDate, "DD MMMM yyyy HH:mm");
	var endDateMax = moment(endDate).add(48, 'hours').toDate();
	$('#new-end-date-picker').datetimepicker({
		date: endDate.toDate(),
		stepping: 5,
		minDate: endDate.toDate(),
		maxDate: endDateMax,
		format: 'DD/MM/YYYY HH:mm'
	});
	// Calculate cost and set confirm button to able on change.
	$("#new-end-date-picker").on("dp.change", function (e) {
		var newEndate = $("#new-end-date-picker").data("DateTimePicker").date().format('X');
		calculateCost(newEndate);
	});
}

// Send request to the server for calculation (Server-side Calculation)
function calculateCost(date) {
	var dateObj = {newEndDate:date}
	$.ajax({
		type: "POST",
		url: "/Views/bookingextend.aspx/calCost",
		data: JSON.stringify(dateObj),
		contentType: "application/json; charset=utf-8",
		dataType: "json",
		success: function (response) {
			changeCost(response);
		},
		failure: function () {
			console.error("Cost error");
		}
	});
}

// Change the new estimated cost from the received response and set the 
// confirm button active.
function changeCost(data){
	$('#newPrice').text(data.d);
	$('.btn.btn-primary').prop('disabled', false);
}

$(window).on('load', function () {
	$('.btn.btn-primary').prop('disabled', true);
	setDatetimePickerFunction();
});