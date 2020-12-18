var medications;

$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/medication",
        contentType: "application/json",
        success: function (data) {
			medications = data;
			viewAllMedications(medications);
			$(".loader").css("display", "none");
        },
    });
});

function viewAllMedications(meds) {
	$("#viewMedication").empty();
	for (let med of meds) {
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

function getSortData() {
	let sort = $("#sort").val();
	let order = $("#order").val();
	sortCards(sort, order);
	viewAllMedications(medications);
}

function sortCards(sort, order) {
	for (let i = 0; i < (medications.length - 1); i++) {
		let minIdx = i;
		for (let j = i + 1; j < medications.length; j++) {
			if (sort == "medName") {
				if (medications[minIdx].name.toLowerCase() > medications[j].name.toLowerCase())
					minIdx = j;
			} else if (sort == "amount") {
				if (medications[minIdx].amount > medications[j].amount)
					minIdx = j;
			} else if (sort == "list") {
				if (medications[minIdx].id > medications[j].id)
					minIdx = j;
			}
		}
		let temp = medications[i];
		medications[i] = medications[minIdx];
		medications[minIdx] = temp;
	}
	if (order == "desc")
		medications.reverse();
}