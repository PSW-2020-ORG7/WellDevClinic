var allPrescriptions;

$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/prescription/all",
		contentType: "application/json",
		success: function (data) {
			allPrescriptions = data;
			if (data.length <= 0)
				$("#noContent").removeAttr("hidden");
			else
				viewAllPrescriptions(allPrescriptions);
			$(".loader").css("display", "none");	
		},
		error: function (e) {
			pageInfo("An error has occurred while trying to connect with hospital server. Try again later!");
		}
	});

	$(".btnFilter").click(function () {
		$("#divFilterTable").slideToggle();
	})
});

function viewAllPrescriptions(prescriptions) {
	$("#viewPrescription").empty();
	for (let pre of prescriptions) {
		var content = '<div class="card">';
		content += '<div class="card-body">';
		content += '<h4 class="card-subtitle mb-2 text-muted">ID: ' + pre.id + '</h4>';
		content += '<table style="margin:10px">';
		content += '<tr><td>Patient:</td>';
		content += '<td>' + pre.patFirstName + ' ' + pre.patLastName + '</td></tr>';
		content += '<tr><td>Start date:</td><td>';
		content += ISOtoShort(new Date(pre.timePeriod.startDate));
		content += '</td></tr>';
		content += '<tr><td>End date:</td><td>';
		content += ISOtoShort(new Date(pre.timePeriod.endDate));
		content += '</td></tr></table>';
		content += '<hr color="#FFFF33">';
		if (pre.medications != null) {
			content += '<div style="color: gray;"><h5><b>Prescribed medicines:</b></h5>';
			for (let med of pre.medications)
				content += med.name + ', ';
			content = content.slice(0, -2);
			content += '</div><br>';
		}
		content += '<table><tr><td colspan=2>';

		generateQR(pre);
		content += '<img src="images/qrCodes/pre' + pre.id + 'qr.png" style="width:200px"/>';
		content += '</td></tr>';
		content += '<tr><td>'
		content += '<button type="button" class="btn btn-info" onclick="sendToPharmacies(\'' + pre.id + '\')">';
		content += 'Send it to pharmacy</button > ';
		content += '</td><td>';
		content += '<button type="button" class="btn" style="font-size:35px;color:red" onclick="generatePDF(' + pre.id + ')"><i class="fa fa-file-pdf-o"></i></button>';
		content += '</td></tr> ';
		content += '</table>';
		content += '</div></div>';
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
				if (allPrescriptions[minIdx].patFirstName.toLowerCase() > allPrescriptions[j].patFirstName.toLowerCase())
					minIdx = j;
			} else if (sort == "patLastName") {
				if (allPrescriptions[minIdx].patLastName.toLowerCase() > allPrescriptions[j].patLastName.toLowerCase())
					minIdx = j;
			} else if (sort == "start") {
				if (allPrescriptions[minIdx].timePeriod.startDate > allPrescriptions[j].timePeriod.startDate)
					minIdx = j;
			} else if (sort == "expire") {
				if (allPrescriptions[minIdx].timePeriod.endDate > allPrescriptions[j].timePeriod.endDate)
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
	let filtered = [];
	let startDate = $("#start").val();
	let endDate = $("#end").val();

	if (startDate != "" && endDate != "" && startDate > endDate) {
		pageInfo("Start date can't be greater than end date!")
		return;
	}

	for (let pre of allPrescriptions) {
		if (startDate && pre.timePeriod.startDate < startDate)
			continue;
		if (endDate && pre.timePeriod.endDate > endDate)
			continue;
		filtered.push(pre);
	}
	viewAllPrescriptions(filtered);
}

function sendToPharmacies(id) {
	$.ajax({
		method: "GET",
		url: "../api/prescription/" + id,
		contentType: "application/json",
		success: function (pre) {
			let medications = [];
			for (let med of pre.medications) {
				let item = {
					Id: med.id,
					Name: med.name,
					Amount: Number(med.amount),
					Ingredients: med.ingredients.map(x => x.name),
					Alternative: med.alternative.map(x => x.name)
				}
				medications.push(item);
            }
			$.ajax({
				method: "POST",
				url: "../api/prescription/sendPrescription",
				contentType: "application/json",
				data: JSON.stringify({
					PatientName: pre.patFirstName + " " + pre.patLastName,
					Jmbg: pre.patJmbg,
					StartTime: pre.timePeriod.startDate,
					Medicines: medications
				}),
				success: function () {
					pageInfo(" File is succesfully sent. ");
				},
				error: function (e) {
					if (e.status == 503)
						pageInfo(e.responseText);
					else
						pageInfo('An unknown error has occured.');
				}
			});
		},
	});
}

function generateQR(pre) {
	$.ajax({
		url: 'images/qrCodes/pre' + pre.id + 'qr.png',
		type: 'HEAD',
		error: function () {
			$.ajax({
				method: "POST",
				url: "../api/prescription/eprescription",
				dataType: "applocation/json",
				contentType: "application/json",
				data: JSON.stringify({
					Id: pre.id,
					TimePeriod: {
						StartDate: pre.timePeriod.startDate,
						EndDate: pre.timePeriod.endDate,
						Id: pre.timePeriod.id
					},
					Medications: pre.medications,
					PatJmbg: pre.patJmbg,
					PatFirstName: pre.patFirstName,
					PatLastName: pre.patLastName,
                })
			});
		},
	});
}


function generatePDF(id) {
	pageInfo("Feature isn't available. Coming soon!");
}

function pageInfo(text) {
	$("#message").text(text);
	$("#pageInfoModal").modal('toggle');
	$("#pageInfo").show();
}