var allSales;
var nameList = [];

$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/sale/all",
		contentType: "application/json",
		success: function (data) {
			allSales = data;
			if (data.length <= 0)
				$("#noContent").removeAttr("hidden");
			else
				viewSales(allSales);
			$(".loader").css("display", "none");
			$("#viewSales").css("display", "block");
		},
		error: function (e) {
			pageInfo("An error has occured while trying to load sales!");
		}
	});

	$(".btnFilter").click(function () {
		$("#divFilterTable").slideToggle();
	})
})


function viewSales(data) {
	$("#viewSales").empty();
	for (let sale of data) {
		let content = '<div class="card"><div class="card-body">';
		content += '<h4 class="card-text card-subtitle mb-2">';
		content += sale.pharmacyName;
		content += '<span class="fa fa-star star';
		if (sale.status == 2)
			content += " checked";
		content += '" onClick="toggleFav(' + sale.id + ')"></span></h4>';
		content += '<hr color="#FFFF33">';
		content += sale.saleMessage;
		content += '<hr color="#FFFF33">';
		content += '<table style="margin:10px">';
		let currDate = new Date(sale.valPeriod.startDate).getTime();
		if (currDate > new Date().getTime()) {
			content += '<tr><td class="text-muted">Starts at:</td><td>';
			content += ISOtoShort(new Date(sale.valPeriod.startDate));
		} else {
			content += '<tr><td class="text-muted">Expires at:</td><td>';
			content += ISOtoShort(new Date(sale.valPeriod.endDate));
        }
		content += '</td></tr>';
		content += '</table>';
		content += '<button class="btn btn-danger" data-toggle="modal" data-target="#deleteSaleModal" ';
		content += ' onclick="deleteSale(' + sale.id + ')"> Discard </button > ';
		content += '<button class="btn btn-success" data-toggle="modal" data-target="#useSaleModal"';
		content += ' onclick="useAction(' + sale.id + ')"> Use it now </button > ';
		content += '</div></div>';

		$("#viewSales").append(content);

		// Filter name select fill
		if (nameList.includes(sale.pharmacyName))
			continue;
		nameList.push(sale.pharmacyName);
		let nameFilter = '<option value="' + sale.pharmacyName + '">' + sale.pharmacyName + '</option>';
		$("#selectname").append(nameFilter);
	}
}

function sortData() {
	let sort = $("#sort").val();
	let order = $("#order").val();
	sortCards(sort, order);
	viewSales(allSales);
}

// Dates are in format : yyyy-MM-dd so we can compare them as strings
function sortCards(sort, order) {
	for (let i = 0; i < (allSales.length - 1); i++) {
		let minIdx = i;
		for (let j = i + 1; j < allSales.length; j++) {
			if (sort == "phName") {
				if (allSales[minIdx].pharmacyName.toLowerCase() > allSales[j].pharmacyName.toLowerCase())
					minIdx = j;
			} else if (sort == "start") {
				if (allSales[minIdx].valPeriod.startDate > allSales[j].valPeriod.startDate)
					minIdx = j;
			} else if (sort == "expire") {
				if (allSales[minIdx].valPeriod.endDate > allSales[j].valPeriod.endDate)
					minIdx = j;
			} else if (sort == "list") {
				if (allSales[minIdx].id > allSales[j].id)
					minIdx = j;
            }
		}
		let temp = allSales[i];
		allSales[i] = allSales[minIdx];
		allSales[minIdx] = temp;
	}
	if (order == 'desc')
		allSales.reverse();
}

function filter() {
	let filtered = [];
	let name = $("#selectname").val();
	let startDate = $("#start").val();
	let endDate = $("#end").val();
	let fav = $("#fav").is(":checked");

	if (startDate != "" && endDate != "" && startDate > endDate) {
		pageInfo("Start date can't be greater than end date!")
		return;
    }

	for (let sale of allSales) {
		if (name != "all" && sale.pharmacyName != name)	continue;
		if (startDate && sale.valPeriod.startDate < startDate)	continue;
		if (endDate && sale.valPeriod.endDate > endDate)	continue;
		if (sale.status != 2 && fav == true)	continue;
		filtered.push(sale);
	}
	viewSales(filtered);
}

function deleteSale(id) {
	$("#deleteSale").show();
	$("button#btnYesDelete").click(function () {
		$.ajax({
			method: "DELETE",
			url: "../api/sale/delete/" + id,
			contentType: "application/json",
			success: function (data) {
				if (data) {
					alert("Successfully deleted");
					window.location.reload();
				}
			},
			error: function (e) {
				pageInfo("An unknown error has occurred while trynig to delete sale");
			}
		});
	});
}

function toggleFav(id) {
	let newStatus;
	for (let sale of allSales)
		if (sale.id == id) {
			if (sale.status != 2)
				newStatus = 2;
			else
				newStatus = 1;
			sale.status = newStatus;
			break;
		}

	$.ajax({
		method: "PUT",
		url: "../api/sale/status/" + id + "/" + newStatus,
		contentType: "application/json",
		success: function (data) {
			viewSales(allSales);
		},
		error: function (e) {
			pageInfo("An unknown error has occured while trying to update action!");
		}
	});
}

function useSale(id) {
	$("#useSale").show();
}

function pageInfo(text) {
	$("#message").text(text);
	$("#pageInfoModal").modal('toggle');
	$("#pageInfo").show();
}