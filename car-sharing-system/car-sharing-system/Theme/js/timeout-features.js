$.idleTimer(420000);
	
$(document).on("idle.idleTimer", function (event, elem, obj) {
	window.onbeforeunload = null;
	window.location.replace(document.location.origin);
});

$(window).on('load', function () {
	setInterval(function () {
		var i = $(document).idleTimer("getRemainingTime");
		if (i <= 240000) {
			if ($('.panel-title label').length == 1) {
				$(".panel-title").prepend("<label id=\"warning\" style=\"font-size:14px; color:red; width:100%;\">You have been idle for more than 3 minutes. Please continue the booking or you will be redirected to the front page. </label>");
			}
		} else {
			$(".panel-title label").remove("#warning");
		}
		console.log($('.panel-title label').length);
		console.log(i);
	}, 30000)
});