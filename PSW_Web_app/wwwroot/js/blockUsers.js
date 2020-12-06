
function addPatient(patient) {
	let tr = $('<tr></tr>');
	let tdId = $('<td>' + patient.id + '</td>');
	let tdName = $('<td>' + patient.fullName + '</td>');
	let tdUsername = $('<td>' + patient.username + '</td>');
	let tdBlock = $('<td></td>');
	if (patient.blocked) {
		let button = $('<button> Block user </button>');
		button.attr('class', 'block');
		tdBlock.append(button);
		tr.append(tdId).append(tdName).append(tdUsername).append(tdBlock);
		$('#table_for_blocking tbody').append(tr);
    }
	tr.append(tdId).append(tdName).append(tdUsername);
	$('#table_blocked tbody').append(tr);
}

$(document).ready(function () {

	$.get({
		url: 'http://localhost:49153/api/patientsForBlocking',
		success: function (patients) {
			for (let patient of patients) {
				addPatient(patient);
			}
		}
	});

	$.get({
		url: 'http://localhost:49153/api/blockedPatients',
		success: function (patients) {
			for (let patient of patients) {
				addPatient(patient);
			}
		}
	});

	$("#tabela tbody").on("click", ".block", function () {
		let Tr = $(this).closest('tr');


		let dataId = Tr.find("td:eq(0)").html();

	});
});