var examinations = [];//komentar
var copyExaminations = [];

function addPrescription(examination, i) {
	tr = $('<tr id="tr"></tr>');
	let row = $('<th scope="row">' + i + '</th>');
	let doctor = $('<td>' + examination.doctor + '</td>');
	let date = $('<td>' + examination.date + '</td>');
	let drugList = $('<td>' + examination.drug + '</td>');
	tr.append(row).append(doctor).append(date).append(drugList);
	$('#tableP tbody').append(tr);
}
function addReferral(examination, i) {
	tr = $('<tr id="tr"></tr>');
	let row = $('<th scope="row">' + i + '</th>');
	let doctor = $('<td>' + examination.doctor + '</td>');
	let date = $('<td>' + examination.date + '</td>');
	let specialist = $('<td>' + examination.specialist + '</td>');
	tr.append(row).append(doctor).append(date).append(specialist);
	$('#tableR tbody').append(tr);
}

function deleteTable() {
	$('#tableP tbody').empty();
	$('#tableR tbody').empty();
}

function validDate() {
	var today = new Date().toISOString().split('T')[0];
	document.getElementsByName("date")[0].setAttribute('max', today);
}
function showRow(id) {
	var row = document.getElementById(id);
	row.style.display = '';
}

function hideRow(id) {
	var row = document.getElementById(id);
	row.style.display = 'none';
}

function hideAll() {
	hideRow('Referral');
	hideRow('Prescription');
}

$(document).ready(function () {
	validDate();
	$.get({
		url: 'http://localhost:49153/api/patient/1/',
		success: function (user) {
			$.post({
				url: 'http://localhost:49153/api/examination/getByUser',
				data: JSON.stringify(user),
				contentType: 'application/json',
				success: function (list) {
					deleteTable();
					i = 1;
					for (let examination of list) {
						addPrescription(examination, i);
						addReferral(examination, i);
						examinations.push(examination);
						i++;
					}
				},
			});
		}
	});

	$('select[name="type"]').change(function () {
		var value = $(this).val();
		if (value == "Referral") {
			showRow("Referral");
			hideRow("Prescription");
			$('input[name="drug"]').val("");
		}
		if (value == "Prescription") {
			showRow("Prescription");
			hideRow("Referral");
			$('input[name="specialist"]').val("");
		}
		if (value == "none") {
			hideAll();
			$('input[name="specialist"]').val("");
			$('input[name="drug"]').val("");
		}
	});

	$('input[type="button"]').click(function (event) {
		hideAll();
		document.forms["formParams"].reset();
		deleteTable();
		copyExaminations.pop();
		i = 1;
		for (let e of examinations) {
			addPrescription(e, i);
			addReferral(e, i);
			i++;
		}

	});

	$('form#formParams').submit(function (event) {
		event.preventDefault();

		let type = $('select[name="type"]').val();
		let date = $('input[name="date"]').val();
		let doctor = $('input[name="doctor"]').val();
		let specialist = $('input[name="specialist"]').val();
		let drug = $('input[name="drug"]').val();
		$.get({
			url: 'http://localhost:49153/api/patient/1',
			success: function (user) {
				if (type == "none") {
					copyExaminations.pop();
					$.post({
						url: 'http://localhost:49153/api/examination',
						data: JSON.stringify({ date: date, doctor: doctor, drug: drug, specialist: specialist, user: user }),
						contentType: 'application/json',
						success: function (list) {
							deleteTable();
							i = 1;
							for (let exam of list) {
								addPrescription(exam, i);
								addReferral(exam, i);
								copyExaminations.push(exam);
								i++;
							}
						},
					});
				}

				if (type == "Referral") {

					$('#tableP tbody').empty();

					if (!copyExaminations.length) {
						i = 1;
						for (let exam of examinations) {
							addPrescription(exam, i);
							i++;
						}
					}
					else {
						i = 1;
						for (let exam of copyExaminations) {
							addPrescription(exam, i);
							i++;
						}
					}

					$.post({
						url: 'http://localhost:49153/api/examination',
						data: JSON.stringify({ date: date, doctor: doctor, drug: drug, specialist: specialist, user: user }),
						contentType: 'application/json',
						success: function (list) {
							$('#tableR tbody').empty();
							i = 1;
							for (let exam of list) {
								addReferral(exam, i);
								i++;
							}
						},
					});
				}

				if (type == "Prescription") {
					$.post({
						url: 'http://localhost:49153/api/examination',
						data: JSON.stringify({ date: date, doctor: doctor, drug: drug, specialist: specialist, user: user }),
						contentType: 'application/json',
						success: function (list) {
							$('#tableP tbody').empty();
							i = 1;
							for (let exam of list) {
								addPrescription(exam, i);
								i++;
							}
						},
					});

					$('#tableR tbody').empty();

					if (!copyExaminations.length) {
						i = 1;
						for (let exam of examinations) {
							addReferral(exam, i);
							i++;
						}
					}
					else {
						i = 1;
						for (let exam of copyExaminations) {
							addReferral(exam, i);
							i++;
						}
					}
				}
			}
		});
	});

});