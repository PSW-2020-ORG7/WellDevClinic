function authorize() {
	token = sessionStorage.getItem("token");
	let payload = parseJwt(token);
	userType = payload["type"];
	if (userType != "Patient") {
		alert("You are not authorized for this page!!!");
		window.location.replace(window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html");
	}
}
var token = "";
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
	if (name == "") {
		return false;
	}
	let doctorName = examination.doctor.toLowerCase();
	return doctorName.includes(name.toLowerCase());
}

function CheckDateAdvanced(date, date2, examination) {
	if (date == "" || date2 == "")
		return false;
	//console.log(date);
	//console.log(date2);
	console.log(examination.date);
	var exam_date = new Date(examination.date);
	console.log("exam datum u date formatu");
	console.log(exam_date);
	var date = new Date(date);
	console.log("datum u date formatu");
	console.log(date);
	var date2 = new Date(date2);
	console.log("datum2 u date formatu");
	console.log(date2);
	return exam_date >= date && exam_date <= date2;
}
function CheckSpecialist(specialistName, examination) {
	if (specialistName == "")
		return false;
	let specialist = examination.specialist.toLowerCase();
	return specialist.includes(specialistName.toLowerCase());
}

function CheckText( text,  examination)
{
	if (text == "") {
		return false;
	}
	let ref_text = examination.textReferral.toLowerCase();
	return ref_text.includes(text.toLowerCase());
}

function CheckDrug(drugName, examination) {
	let check = false;
	if (drugName == "")
		return check;
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

function SearchPreviousExaminations(date1, date2, doctorName, drugName, speacialistName, text, Radio1, Radio2, Radio3 = false)
{
	let result = [];
	for(examination of examinations)
	{
		var date_log = CheckDateAdvanced(date1, date2, examination);
		var doc_log = CheckDoctor(doctorName, examination);
		var spec_log = CheckSpecialist(speacialistName, examination);
		var text_log = CheckText(text, examination);
		var drug_log = CheckDrug(drugName, examination);
		var provera = true;

		if (drugName != "") {
			provera = drug_log;
		}
		else {
			provera = spec_log;
		}

		if (Radio1 && Radio2 && Radio3) {
			if (date_log && doc_log && provera && text_log) {
				result.push(examination);
			}
		}
		if (!Radio1 && Radio2 && Radio3) {
			if ((date_log || doc_log) && provera && text_log) {
				result.push(examination);
			}
		}
		if (Radio1 && !Radio2 && Radio3) {
			if ((date_log || provera) && doc_log && text_log) {
				result.push(examination);
			}
		}
		if (Radio1 && Radio2 && !Radio3) {
			if ((date_log || text_log) && doc_log && provera) {
				result.push(examination);
			}
		}
		if (!Radio1 && !Radio2 && Radio3) {
			if ((date_log || doc_log || provera) && text_log) {
				result.push(examination);
			}
		}
		if (!Radio1 && Radio2 && !Radio3) {
			if ((date_log || doc_log || text_log) && provera) {
				result.push(examination);
			}
		}
		if (Radio1 && !Radio2 && !Radio3) {
			if ((date_log || provera || text_log) && doc_log) {
				result.push(examination);
			}
		}
		if (!Radio1 && !Radio2 && !Radio3) {
			if (date_log || doc_log || provera || text_log) {
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
	document.getElementsByName("date2")[0].setAttribute('max', today);
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
	validDate()
	$.get({
		url: window.location.protocol + "//" + window.location.host + '/api/examination/getByUser/1',
		headers: { "Authorization": token },
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
			copyExaminations = [];
			deleteTable();
			i = 1;
			for (let exam of SearchPreviousExaminations(date, date2, doctor, drug, specialist, text, radio1, false)) {
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
			for (let exam of SearchPreviousExaminations(date, date2, doctor, drug, specialist, text, radio1, radio2, radio3)) {
				addReferral(exam, i);
				i++;
			}
		}
		if (type == "Prescription") {
			$('#tableP tbody').empty();
			i = 1;
			for (let exam of SearchPreviousExaminations(date, date2, doctor, drug, specialist, text, radio1, radio2, radio5)) {
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