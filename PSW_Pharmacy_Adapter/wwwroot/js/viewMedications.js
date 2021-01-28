var allMedications;

$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/medication",
        contentType: "application/json",
        success: function (data) {
			allMedications = data;
			if (data.length <= 0)
				$("#noContent").removeAttr("hidden");
			else
				viewAllMedications(allMedications);
			$("#pageLoader").hide();
		},
		error: function (e) {
			$("#pageLoader").hide();
			pageInfo("An error has occured while trying to connect with hospital server. Try again later!");
			$("#noContent").removeAttr("hidden");
        }
	});

	

	$(".btnFilter").click(function () {
		$("#divFilterTable").slideToggle();
	});

	$(".close").click(function () {
		$(".modalCustom").hide(200);
	});
});

function viewAllMedications(meds) {
	$("#viewMedication").empty();
	for (let med of meds) {
		let content = '<div class="card">';
		content += '<div class="card-body">';
		content += '<div class="data"> <h4 class="card-subtitle mb-2 text-muted">ID: ' + med.id + '</h4>';
		content += '<h4><table style="margin:10px">';
		content += '<tr style="background: transparent;"><td>';
		content += med.name + '</td><td> &nbsp;&nbsp;&nbsp;x' + med.amount + '</td></tr>';
		content += '</table></h4><hr color="#FFFF33">';
		if (med.ingredients.length != 0) {
			content += '<div style="color: gray;"><h5>Ingredients:</h5>';

			for (let ing of med.ingredients)
				content += ing.name + ', ';				
			content = content.slice(0, -2);
			content += '</div><br>';
		}
		content += '<button class="btn btn-info" data-target="#pageInfoModal" ';
		content += 'onClick="findMedicine(\'' + med.id + '\')">Check availability</button>';
		content += '</div></div></div>';
		$("#viewMedication").append(content);
	}
}

function findMedicine(medId) {
	$("#responseLoad").show();
	$.ajax({
		method: "GET",
		url: "../api/medication/hospital/" + medId,
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
					resetMedTable();
					if (pharmacies.length > 0) {
						showMedTable(pharmacies);
						$("#medAvailability").slideToggle("fast");
					} else {
						pageInfo("The medicaiton that you're looking for isn't available in any partner pharmacy.");
                    }
				},
				error: function (e) {
					$("#responseLoad").hide();
					pageInfo(e.responseText);
                }
			});
		},
		error: function (e) {
			pageInfo("An error has occured while trying to connect with hospital server. Try again later!");
        }
	});
}

function resetMedTable() {
	$("#phName").html("<option selected disabled>Select pharmacy..</option>");
	$("#amountToBuy").val("");
	$("#amountToBuy").css("border-color", "#ccc");
	$("#invalidAmount").css("display", "none");
	$("#phName").css("border-color", "#ccc");
	$("#invalidPharmacy").css("display", "none");
}

function showMedTable(pharmacies) {
	$("#txtMedName").text(pharmacies[0].medicine.name.charAt(0).toUpperCase() + pharmacies[0].medicine.name.slice(1));
	$("#medTable").find('tbody').empty();
	for (let ph of pharmacies) {
		let content = '<tr>';
		content += '<td>' + ph.medicine.name + '</td>';
		content += '<td>' + ph.medicine.amount + '</td>';
		content += '<td>' + ph.price + '</td>';
		content += '<td>' + ph.phName + '</td>';
		content += '</tr>';

		$("#medTable").find('tbody').append(content);

		$("#phName").append('<option value="' + ph.phName + '">' + ph.phName + '</option>');
		if ($('#amountToBuy').attr('max') < Number(ph.medicine.amount))
			$('#amountToBuy').attr('max', ph.medicine.amount);
    }
}

function purchase() {
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
		success: function (recievedMed) {
			if (recievedMed != null) {
				pageInfo('Order: ' + quantity + 'x ' + recievedMed.name + '. Expect your package soon.');
				$("#btnOk").click(function () {
					$("#medAvailability").hide();
				});
			}
		},
		error: function (e) {
			if (e.status == 400)
				pageInfo(e.responseText);
			else
				pageInfo('An unknown error has occured.');
		}
	});
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
		pageInfo("Parameter amount from can't be less than amount to!");
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

function pageInfo(text) {
	$("#message").text(text);
	$("#pageInfoModal").modal('toggle');
	$("#pageInfo").show();
}