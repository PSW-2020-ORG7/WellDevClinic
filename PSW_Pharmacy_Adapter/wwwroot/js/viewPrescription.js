$(document).ready(function () {
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

	$.ajax({
		method: "GET",
		url: "../api/qrcode",
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
		content += '<img id="qrcode" src="images/qrcode1.png"/>';
		content += '</td></tr>';
		content += '<tr></tr>';
		content += '<tr><td colspan="2">'
		content += '<button type="button" class="btn btn-info" onclick="sendToPharmacies(\'' + pre.id + '\')" id="' + pre.id + '" data-toggle="modal" data-target="#exampleModalCenter1">';
		content += 'Send it to pharmacy</button > ';
		content += '</td><td>';
		content += '<button type="button" class="btn btn-light" style="font-size:22px;color:red" onclick="generatePDF(' + pre.id + ')"><i class="fa fa-file-pdf-o"></i></button>';
		content += '</td></tr> ';
		content += '</table>';
		content += '</div></div></div>';
		content += '</div>';
		$("#viewPrescription").append(content);
	}
}

function sendToPharmacies(id) {
	var patientName1 = "Marko Markovic";
	var jmbg1 = 123456789;
	var startTime1 = "2020-12-20";
	var endTime1 = "2020-12-30";
	var medicines1 = [];
	//var medicines = { data.medicines.name: "Fiat", model: "500", color: "white" };
	//["Brufen", "Bromazepam", "Andol"];
	$.ajax({
		method: "GET",
		url: "../api/prescription/" + id,
		contentType: "application/json",
		success: function (pre) {
			console.log(pre);
			$.post({
				url: "../api/sftp/sendReport",
				contentType: "aplication/json",
				data: JSON.stringify({ patientName: patientName1, jmbg: jmbg1, startTime: startTime1, endTime: endTime1, medicines: medicines1 }),
				success: function (data) {
					//location.href = "../index.html";
					$("#sentAction").show();
				},
				error: function (message) {
				}
			});
		},
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

function generatePDF(id) {
	alert(id);
}