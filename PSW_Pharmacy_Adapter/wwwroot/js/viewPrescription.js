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
		content += pre.period.startDate;
		content += '</td></tr>';
		content += '<tr><td float="right">End date:</td><td>';
		content += pre.period.endDate;
		content += '</td></tr>';
		//content += '<tr><td float="right">Prescription medicines:</td><td>';
		//var c;
		//for (c = 0; c < data.medication.length; c++) {
			//content += data.medication[c].name;
		//}
		//content += '</td></tr>';
		content += '</table>';
		content += '</div></div></div>';
		content += '</div>';
		$("#viewPrescription").append(content);
	}
}