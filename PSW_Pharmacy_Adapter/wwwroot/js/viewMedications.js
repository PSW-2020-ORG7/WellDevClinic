var allMedications;

$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/medication",
        contentType: "application/json",
        success: function (data) {
			allMedications = data;
			viewAllMedications(allMedications);
			$(".loader").css("display", "none");
        },
	});

	$(".btnFilter").click(function () {
		$("#divFilterTable").slideToggle();
	})
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

function sortData() {
	let sort = $("#sort").val();
	let order = $("#order").val();
	sortCards(sort, order);
	viewAllMedications(allMedications);
}

function sortCards(sort, order) {
	for (let i = 0; i < (allMedications.length - 1); i++) {
		let minIdx = i;
		for (let j = i + 1; j < allMedications.length; j++) {
			if (sort == "medName") {
				if (allMedications[minIdx].name.toLowerCase() > allMedications[j].name.toLowerCase())
					minIdx = j;
			} else if (sort == "amount") {
				if (allMedications[minIdx].amount > allMedications[j].amount)
					minIdx = j;
			} else if (sort == "list") {
				if (allMedications[minIdx].id > allMedications[j].id)
					minIdx = j;
			}
		}
		let temp = allMedications[i];
		allMedications[i] = allMedications[minIdx];
		allMedications[minIdx] = temp;
	}
	if (order == "desc")
		allMedications.reverse();
}

function filter() {
	let amountFrom = $("#amountFrom").val();
	let amountTo = $("#amountTo").val();
	if (amountFrom != "" && amountTo != "" && amountFrom > amountTo) {
		alert("Parameter amount from can't be less than amount to!");
		return;
    }

	let filter = [];
	for (let med of allMedications) {
		if (amountFrom != "" && med.amount < amountFrom)
			continue;
		if (amountTo != "" && med.amount > amountTo)
			continue;
		filter.push(med);
	}
	viewAllMedications(filter);
}