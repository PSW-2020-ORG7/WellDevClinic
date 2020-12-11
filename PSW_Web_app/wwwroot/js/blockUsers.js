
function addPatient(patient) {
	let tr = $('<tr></tr>');
	let tdId = $('<td>' + patient.id + '</td>');
	let tdName = $('<td>' + patient.fullName + '</td>');
	let tdUsername = $('<td>' + patient.username + '</td>');
	let tdBlock = $('<td></td>');
	if (!patient.blocked) {
		let button = $('<button> Block user </button>');
		button.attr('class', 'block');
		tdBlock.append(button);
		tr.append(tdId).append(tdName).append(tdUsername).append(tdBlock);
		$('#table_for_blocking tbody').append(tr);
	}
	else {
		tr.append(tdId).append(tdName).append(tdUsername);
		$('#table_blocked tbody').append(tr);
	}
}

$(document).ready(function () {

	$.get({
		url: 'http://localhost:49153/api/patient/patients_for_blocking',
		success: function (patients) {
			for (let patient of patients) {
				addPatient(patient);
			}
		}
	});

	$.get({
		url: 'http://localhost:49153/api/patient/blocked_patients',
		success: function (patients) {
			for (let patient of patients) {
				addPatient(patient);
			}
		}
	});

	$("#table_for_blocking tbody").on("click", ".block", function () {

		let Tr = $(this).closest('tr');
		let dataId = Tr.find("td:eq(0)").html();

		$.ajax({
			url: "http://localhost:49153/api/patient/" + dataId,
			type: 'PUT',
			success: function () {
				alert("Uspesno blokiran pacijent")
				location.reload();
			},
			contentType: "application/json; charset=utf-8"
		})

	});

	$('#quit').click(function (event) {
		var origin = window.location.origin;
		window.location.href = origin + "/html/feedback.html"
	});
});