﻿$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/prescription",
		contentType: "application/json",
		success: function (data) {
			console.log(data);
			$(".loader").css("display", "none");
			getAllPrescriptions(data);
		},
	});
});

function getAllPrescriptions(data) {
	$("#viewPrescription").empty();
	for (let pre of data) {
		var content = '<div class="card" id="' + pre.id + '">';
		content += '<div class="card-body">';
		content += '<div class="data">';
		content += '<table style="margin:10px">';
		content += '<tr><td float="right">Id:</td><td>';
		content += pre.id;
		content += '</td></tr>';
		content += '<tr><td float="right">Start date:</td><td>';
		content += ISOtoShort(new Date(pre.period.startDate));
		content += '</td></tr>';
		content += '<tr><td float="right">End date:</td><td>';
		content += ISOtoShort(new Date(pre.period.endDate));
		content += '</td></tr>';
		//content += '<tr><td float="right">Prescription medicines:</td><td>';
		//var c;
		//for (c = 0; c < data.medication.length; c++) {
			//content += data.medication[c].name;
		//}
		//content += '</td></tr>';
		content += '<tr><td colspan="2">';
		content += '<button type="button" class="btn btn-info" onclick="sendToPharmacies(this)" id="' + pre.id + '" data-toggle="modal" data-target="#exampleModalCenter1">';
		content += 'Send to pharmacies</button > ';
		content += '</td></tr>';
		content += '</table>';
		content += '</div></div></div>';
		content += '</div>';
		$("#viewPrescription").append(content);
	}
}

function sendToPharmacies(data) {
	var patientName1 = "Marko Markovic";
	var jmbg1 = 123456789;
	var startTime1 = data.startDate;
	var endTime1 = data.endDate;
	var medicines1 = {};
	//var medicines = { data.medicines.name: "Fiat", model: "500", color: "white" };
	//["Brufen", "Bromazepam", "Andol"];
	$.post({
		url: "../api/sftp/sendReport",
		contentType: "aplication/json",
		data: JSON.stringify({ patientName: patientName1, jmbg: jmbg1, startDate: startTime1, endDate: endTime1, medicines: medicines1 }),
		success: function (data) {
			//location.href = "../index.html";
			$("#sentAction").show();
		},
		error: function (message) {
		}
	});
}

function ISOtoShort(date) {
	let day = date.getDate();
	let month = (date.getMonth() + 1);
	let year = date.getFullYear();

	if (day < 10)
		day = '0' + day;
	if (month < 10)
		month = '0' + month;

	return String(day + '-' + month + '-' + year);
}