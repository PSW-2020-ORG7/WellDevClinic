function authorize() {
	let token = sessionStorage.getItem("token");
	let payload = parseJwt(token);
	userType = payload["type"];
	if (userType != "Patient") {
		alert("You are not authorized for this page!!!");
		window.location.replace(window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html");
	}
}

var userType = "";
function parseJwt(token) {
	var base64Url = token.split('.')[1];
	var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
	var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
		return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
	}).join(''));

	return JSON.parse(jsonPayload);
};

var examinations = [];
var copyExaminations = [];

function CheckDoctor(name, examination) {
	let doctorName = examination.doctor.toLowerCase();
	return doctorName.includes(name.toLowerCase());
}

function CheckDate(date, examination) {

	return examination.date === date;
}
function CheckSpecialist(specialistName, examination) {
	let specialist = examination.specialist.toLowerCase();
	return specialist.includes(specialistName.toLowerCase());
}
function CheckDrug(drugName, examination) {
	let check = false;
	for (let drug of examination.drug) {
		if (drug.toLowerCase().includes(drugName.toLowerCase())) {
			check = true;
		}
	}
	return check;
}

function SearchPreviousExamination(date, doctorName, drugName, specialistName) {
	let result = [];
	if (date != "") {
		for (let examination of examinations) {

			if (CheckDate(date, examination) && CheckDoctor(doctorName, examination) && CheckDrug(drugName, examination) && CheckSpecialist(specialistName, examination)) {
				result.push(examination);
			}
		}
	}
	else {
		for (let examination of examinations) {
			if (CheckDoctor(doctorName, examination) && CheckDrug(drugName, examination) && CheckSpecialist(specialistName, examination)) {
				result.push(examination);
			}
		}
	}
	return result;
}


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
	validDate()
	$.get({
		url: window.location.protocol + "//" + window.location.host + '/api/examination/getByUser/1',
		headers: { "Authorization": userType },
		success: function (list) {
			deleteTable();
			i = 1;
			for (let examination of list) {
				addPrescription(examination, i);
				addReferral(examination, i);
				examinations.push(examination);
				i++;
			}
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
		copyExaminations = [];

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
		if (type == "none") {
			copyExaminations = [];
			deleteTable();
			i = 1;
			for (let exam of SearchPreviousExamination(date, doctor, drug, specialist)) {
				addPrescription(exam, i);
				addReferral(exam, i);
				copyExaminations.push(exam);
				i++;
			}
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

			$('#tableR tbody').empty();
			i = 1;
			for (let exam of SearchPreviousExamination(date, doctor, drug, specialist)) {
				addReferral(exam, i);
				i++;
			}
		}
		if (type == "Prescription") {
			$('#tableP tbody').empty();
			i = 1;
			for (let exam of SearchPreviousExamination(date, doctor, drug, specialist)) {
				addPrescription(exam, i);
				i++;
			}


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