var allPrescriptions;

$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/prescription",
		contentType: "application/json",
		success: function (data) {
			allPrescriptions = data;
			$(".loader").css("display", "none");
			viewAllPrescriptions(allPrescriptions);
		},
	});

	$(".btnFilter").click(function () {
		$("#divFilterTable").slideToggle();
	})
});

function viewAllPrescriptions(prescriptions) {
	$("#viewPrescription").empty();
	for (let pre of prescriptions) {
		var content = '<div class="card" id="' + pre.id + '">';
		content += '<div class="card-body">';
		content += '<div class="data">';
		content += '<table style="margin:10px">';
		content += '<tr><td float="right">Id:</td><td>';
		content += pre.id;
		content += '</td></tr>';
		//content += '<tr><td>Patient name:</td>';
		//content += '<td>' + pre.currentPatient.name + '</td></tr>';
		content += '<tr><td float="right">Start date:</td><td>';
		content += ISOtoShort(new Date(pre.period.startDate));
		content += '</td></tr>';
		content += '<tr><td float="right">End date:</td><td>';
		content += ISOtoShort(new Date(pre.period.endDate));
		content += '</td></tr>';
		if (pre.medication != null) {
			content += '<tr><td float="right">Prescription medicines:</td>';
			content += '<td>';
			for (let med of pre.medication)
				content += med.name + '<br/>';
			content += '</td>';
		}
		content += '</tr>';
		content += '<tr><td colspan="2">';

		generateQR(pre);
		content += '<img src="images/qrCodes/pre' + pre.id + 'qr.png"/>';
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

function sortData() {
	let sort = $("#sort").val();
	let order = $("#order").val();
	sortCards(sort, order);
	viewAllPrescriptions(allPrescriptions);
}

// Dates are in format : yyyy-MM-dd so we can compare them as strings
function sortCards(sort, order) {
	for (let i = 0; i < (allPrescriptions.length - 1); i++) {
		let minIdx = i;
		for (let j = i + 1; j < allPrescriptions.length; j++) {
			if (sort == "patName") {
				if (allPrescriptions[minIdx].currentPatient.name.toLowerCase() > allPrescriptions[j].currentPatient.name.toLowerCase())
					minIdx = j;
			} else if (sort == "start") {
				if (allPrescriptions[minIdx].startDate > allPrescriptions[j].startDate)
					minIdx = j;
			} else if (sort == "expire") {
				if (allPrescriptions[minIdx].endDate > allPrescriptions[j].endDate)
					minIdx = j;
			} else if (sort == "list") {
				if (allPrescriptions[minIdx].id > allPrescriptions[j].id)
					minIdx = j;
			}
		}
		let temp = allPrescriptions[i];
		allPrescriptions[i] = allPrescriptions[minIdx];
		allPrescriptions[minIdx] = temp;
	}
	if (order == 'desc')
		allPrescriptions.reverse();
}

function filter() {
	filtered = [];
	let startDate = $("#start").val();
	let endDate = $("#end").val();

	if (startDate != "" && endDate != "" && startDate > endDate) {
		alert("Start date can't be greater than end date!")
		return;
	}

	for (let pre of allPrescriptions) {
		if (startDate && pre.startDate < startDate)
			continue;
		if (endDate && pre.endDate > endDate)
			continue;
		filtered.push(pre);
	}
	viewAllPrescriptions(filtered);
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
				url: "../api/sftp/sendPrescription",
				contentType: "aplication/json",
				dataType: "aplication/json",
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

function generateQR(pre) {
	$.ajax({
		url: 'images/qrCodes/pre' + pre.id + 'qr.png',
		type: 'HEAD',
		error: function () {
			$.ajax({
				method: "POST",
				url: "../api/qrcode/eprescription",
				dataType: "applocation/json",
				contentType: "application/json",
				data: JSON.stringify({
					id: pre.id,
					period: {
						startDate: pre.period.startDate,
						endDate: pre.period.endDate,
						id: pre.period.id
					},
					medication: pre.medication,		// TODO: ??
					patient: {
						jmbg: pre.currentPatient.jmbg,
						name: pre.currentPatient.name,
						lastName: pre.currentPatient.lastName,
						allergies: [],
					},
                })
			});
		},
	});
}