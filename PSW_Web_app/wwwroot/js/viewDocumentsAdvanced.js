var examinations = [];
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
	let text = $('<td>' + examination.textReferral + '</td>');
	tr.append(row).append(doctor).append(date).append(specialist).append(text);
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
	hideRow('Referral2');
	hideRow('Prescription');
}

$(document).ready(function () {
	validDate();
		$.get({
			url: window.location.protocol + "//" + window.location.host + '/api/examination/getAll',
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

	$('select[name="type"]').change(function () {
		var value = $(this).val();
		if (value == "Referral") {
			showRow("Referral");
			showRow("Referral2");
			hideRow("Prescription");
			$('input[name="drug"]').val("");
		}
		if (value == "Prescription") {
			showRow("Prescription");
			hideRow("Referral");
			hideRow("Referral2");
			$('input[name="specialist"]').val("");
			$('input[name="text"]').val("");
		}
		if (value == "none") {
			hideAll();
			$('input[name="specialist"]').val("");
			$('input[name="text"]').val("");
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
		let date2 = $('input[name="date2"]').val();
		let doctor = $('input[name="doctor"]').val();
		let specialist = $('input[name="specialist"]').val();
		let text = $('input[name="text"]').val();
		let drug = $('input[name="drug"]').val();
		let group1_value = $('input[name=group1]:checked', '#group1').val();
		let group2_value = $('input[name=group2]:checked', '#group2').val();
		let group3_value = $('input[name=group3]:checked', '#group3').val();
		let group5_value = $('input[name=group5]:checked', '#group5').val();
		let radio1, radio2, radio3, radio5;
		if (group1_value == 'and')
			radio1 = true;
		else
			radio1 = false;

		if (group2_value == 'and')
			radio2 = true;
		else
			radio2 = false;

		if (group3_value == 'and')
			radio3 = true;
		else
			radio3 = false;

		if (group5_value == 'and')
			radio5 = true;
		else
			radio5 = false;

		console.log(radio1);
		console.log(radio2);
		console.log(radio3);
		console.log(radio5);

		if (type == "none") {
			copyExaminations.pop();
			$.post({
				url: window.location.protocol + "//" + window.location.host + '/api/examination/search',
				data: JSON.stringify({ date: date, date2: date2, doctor: doctor, drug: drug, specialist: specialist, text: text, Radio1: radio1, Radio2: false }),
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
				url: window.location.protocol + "//" + window.location.host + '/api/examination/search',
				data: JSON.stringify({ date: date, date2: date2, doctor: doctor, drug: drug, specialist: specialist, text: text, Radio1: radio1, Radio2: radio2, Radio3: radio3}),
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
				url: window.location.protocol + "//" + window.location.host + '/api/examination/search',
				data: JSON.stringify({ date: date, date2: date2, doctor: doctor, drug: drug, specialist: specialist, text: text, Radio1: radio1, Radio2: radio5}),
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
	});

});