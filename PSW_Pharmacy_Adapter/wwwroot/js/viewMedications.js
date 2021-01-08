var allMedications;

$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/medication",
        contentType: "application/json",
        success: function (data) {
			allMedications = data;
			viewAllMedications(allMedications);
			$("#pageLoader").css("display", "none");
			for (let inp of document.getElementsByName('medicineName'))
				autocomplete(inp, allMedications.map(x => x.name));
        },
	});

	

	$(".btnFilter").click(function () {
		$("#divFilterTable").slideToggle();
	});

	$(".close").click(function () {
		$(".modalCustom").hide(200);
	});

	$("#purchase").click(function () {
		let pharmacyName = $("#phName").val();
		let quantity = Number($("#amountToBuy").val());
		let med = $("#txtMedName").text();

		let valid = true;

		if (!pharmacyName) {
			valid = false;
			$("#phName").css("border-color", "red");
			$("#invalidPharmacy").css("display", "inline-block");
		} else {
			$("#phName").css("border-color", "#ccc");
			$("#invalidPharmacy").css("display", "none");
		}
		if (!quantity || quantity < 1) {
			valid = false;
			$("#amountToBuy").css("border-color", "red");
			$("#invalidAmount").css("display", "inline-block");
		} else {
			$("#amountToBuy").css("border-color", "#ccc");
			$("#invalidAmount").css("display", "none");
        }

		if (!valid)
			return;

		$.ajax({
			method: "GET",
			url: "../api/medication/orderMedicine",
			contentType: "application/json",
			data: {
				phName: pharmacyName,
				amount: quantity,
				medName: med,
			},
			success: function (data) {
				if (data != null) {
					$("#message").text("Medications succesfuly ordered! Expect your package soon.");
					$("#pageInfoModal").modal('toggle');
					$("#pageInfo").show();
					$("#btnOk").click(function () {
						$("#medAvailability").hide();
					});
				}
			},
			error: function (e) {
				alert("ERROR: " + e.status);
			}
		});
	});
});

function viewAllMedications(meds) {
	$("#viewMedication").empty();
	for (let med of meds) {
		let content = '<div class="card">';
		content += '<div class="card-body">';
		content += '<table>';
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
		content += '<button class="btn btn-info" data-target="#pageInfoModal" ';
		content += 'onClick="findMedicine(\'' + med.id + '\')">Check availability</button>';
		content += '</div></div>';
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

function findMedicine(name) {
	$("#responseLoad").show();
	$.ajax({
		method: "GET",
		url: "../api/medication/" + name,
		contentType: "application/json",
		success: function (med) {
			$.ajax({
				method: "POST",
				url: "../api/medication/findMedPh",
				contentType: "application/json",
				data: JSON.stringify({
					Id: med.id,
					Name: med.name,
					Amount: med.amount,
					Approved: med.approved,
					Ingredients: med.ingredients,
					Alternative: med.alternative,
				}),
				success: function (pharmacies) {
					$("#responseLoad").hide();
					resetResultTableState();
					if (pharmacies.length > 0) {
						showResultTable(pharmacies);
						$("#medAvailability").slideToggle("fast");
					} else {
						$("#message").text("The medicaiton that you're looking for isn't available in any partner pharmacy.");
						$("#pageInfoModal").modal('toggle');
						$("#pageInfo").show();
                    }
				},
				error: function (e) {
					alert("No pharmacy responded to request!");
                }
			});
		},
	});
}

function resetResultTableState() {
	$("#phName").html("<option selected disabled>Select pharmacy..</option>");
	$("#amountToBuy").val("");
	$("#amountToBuy").css("border-color", "#ccc");
	$("#invalidAmount").css("display", "none");
	$("#phName").css("border-color", "#ccc");
	$("#invalidPharmacy").css("display", "none");
}

function showResultTable(pharmacies) {
	$("#txtMedName").text(pharmacies[0].medicine.name.charAt(0).toUpperCase() + pharmacies[0].medicine.name.slice(1));
	$("#medTableData").find('tbody').empty();
	for (let ph of pharmacies) {
		let content = '<tr>';
		content += '<td>' + ph.medicine.name + '</td>';
		content += '<td>' + ph.medicine.amount + '</td>';
		content += '<td>' + ph.price + '</td>';
		content += '<td>' + ph.phName + '</td>';
		content += '</tr>';

		$("#medTableData").find('tbody').append(content);

		$("#phName").append('<option value="' + ph.phName + '">' + ph.phName + '</option>');
		if ($('#amountToBuy').attr('max') < Number(ph.medicine.amount))
			$('#amountToBuy').attr('max', ph.medicine.amount);
    }
}