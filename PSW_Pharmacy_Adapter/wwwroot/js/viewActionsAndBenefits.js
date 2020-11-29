$(document).ready(function () {
	/*$.ajax({
		method: "GET",
		url: "../actionsAndBenefits/getAll",
		datatype: "application/json"
	}).done(function (data) {
		viewActionsAndBenefits(data);
	});*/

})


function viewActionsAndBenefits(data) {
	var i;
	for (i = 0; i < data.length; i++) {
		content = '<div class="card" id="';
		content += data[i].id;
		content += '">';
		content += '<p class="card-text">';
		content += data[i].messageFromPharmacy;
		content += '</p >';
		content += '<div class="card-body">';
		content += '<div class="data">';
		content += '<table style="margin:10px">';
		content += '<tr><td float="right">Pharmacy:</td><td>';
		content += data[i].idPharmacy;
		content += '</td></tr>';
		content += '<tr><td>Start date:</td><td>';
		content += data[i].startDate;
		content += '</td></tr>';
		content += '<tr><td>End date:</td><td>';
		content += data[i].endDate;
		content += '</td></tr>';
		content += '</table></div>';
		content += '</div></div>';
		content += '</div>';
		//DODATI DUGMICE
		$("#viewAction").append(content);
	}
}

