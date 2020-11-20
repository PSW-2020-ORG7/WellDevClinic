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

	$.get({
		url: 'http://localhost:49153/api/examination/',
		success: function (documents) {
			for (doc in documents) {
				addDocument(doc);
            }
        }
	});

});

function addDocument(doc) {
	let body = document.getElementById("tbody");
	let tr = $('<tr></tr>');
	let tdDoctor = $('<td>' + doc.doctor + '</td>');
	let tdDate = $('<td>' + doc.date + '</td>');

	tr.append(tdDoctor).append(tdDate);
	body.append(tr);
}