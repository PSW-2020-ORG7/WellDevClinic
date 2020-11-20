$(document).ready(function () {

	let type = $('select[name="type"]').val();
	$('input[name="specialist"]').attr('disabled', true);
	$('input[name="drug"]').attr('disabled', true);
	$('select[name="type"]').change(function () {
		var value = $(this).val();
		if (value == "Refferal") {
			$(('input[name="specialist"]')).attr('disabled', false);
			$('input[name="drug"]').attr('disabled', true);
			$('input[name="drug"]').val("");
		}
		if (value == "Prescription") {
			$('input[name="drug"]').attr('disabled', false);
			$('input[name="specialist"]').attr('disabled', true);
			$('input[name="specialist"]').val("");
		}
		if (value == "none") {
			$('input[name="specialist"]').attr('disabled', true);
			$('input[name="drug"]').attr('disabled', true);
			$('input[name="specialist"]').val("");
			$('input[name="drug"]').val("");
		}
	});

	$('input[type="button"]').click(function (event) {
		$('input[name="specialist"]').attr('disabled', true);
		$('input[name="drug"]').attr('disabled', true);
		document.forms["form"].reset();
	});
});