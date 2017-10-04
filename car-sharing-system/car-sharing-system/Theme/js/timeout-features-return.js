$(window).on('load', function () {
	setTimeout(function () {
		showUserAlert();
	}, 600000);
	setTimeout(function () {
		kickUser();
	}, 900000);
});

function showUserAlert() {
	$(".panel-title").prepend("<label id=\"warning\" style=\"font-size:14px; color:red; width:100%;\">You have been idle for more than 10 minutes. Please continue the booking or you will be redirected to the front page. </label>");
}

function kickUser() {
	alert("You have been idle for more than 15 minute");
	window.location.replace(document.location.origin);
}
