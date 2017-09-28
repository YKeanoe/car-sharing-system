var timeout;

window.onbeforeunload = function () {
	cancel();
	timeout = setTimeout(function () {
		alert('Session is closed');
		window.onbeforeunload = null;
		window.location.href = "/";
	}, 1000);
	return "You haven't complete the booking.";
};
	
// 
$(".btn-primary").click(function () {
	window.onbeforeunload = null;
	// Return false so that no postback is called
	// return false;
});

function cancel() {
	$.ajax({
		type: "POST",
		url: "/Views/bookingconfirmation.aspx/cancelBooking",
		data: "{}",
		contentType: "application/json; charset=utf-8",
		dataType: "json"
	});
}

