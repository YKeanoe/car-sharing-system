// Run check if new password or re enter new password input is inserted.
$('#rnpInput :input, #npInput :input').on('keyup', function () {
	// If both new password and re enter new password is the same, continue
	if ($('#npInput :input').val() == $('#rnpInput :input').val()) {
		$('#unmatch-error').css('display', 'none');
		if ($('#cpInput :input').val().length > 0 && $('#npInput :input').val().length > 0 && $('#rnpInput :input').val().length > 0) {
			$(':input[type="submit"]').prop('disabled', false);
		}
	} else {
		// Else, show an error message and disable confirm button
		$('#unmatch-error').css('display', 'inline-block');
		$(':input[type="submit"]').prop('disabled', true);
	}
});


$(':input[type="submit"]').prop('disabled', true);