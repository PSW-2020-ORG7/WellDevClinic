$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/medication",
        contentType: "application/json",
        success: function (data) {
            console.log(data);
			getAllMedications(data);
			$(".loader").css("display", "none");
        },
    });
});

function getAllMedications(data) {
	$("#viewMedication").empty();
	for (let med of data) {
		let content = '<div class="card" id="' + med.id + '">';
		content += '<div class="card-body">';
		content += '<div class="data">';
		content += '<table style="margin:10px">';
		content += '<tr><td float="right">Id:</td><td>';
		content += med.id;
		content += '</td></tr>';
		content += '<tr><td float="right">Name:</td><td>';
		content += med.name;
		content += '</td></tr>';
		content += '<tr><td float="right">Amount:</td><td>';
		content += med.amount;
		content += '</td></tr>';
		content += '</table>';
		content += '</div></div></div>';
		content += '</div>';
		$("#viewMedication").append(content);
	}
}