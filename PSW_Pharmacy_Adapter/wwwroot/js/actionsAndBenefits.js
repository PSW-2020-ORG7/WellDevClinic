var allSales;
var nameList = [];

$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/sale/all",
		contentType: "application/json",
		success: function (data) {
			allSales = data;
			viewSales(allSales);
			$(".loader").css("display", "none");
			$("#viewSales").css("display", "block");
		}
	});

	$(".btnFilter").click(function () {
		$("#divFilterTable").slideToggle();
	})
})


function viewSales(data) {
	$("#viewSales").empty();
	for (let sale of data) {
		let content = '<div class="card">';
		content += '<p class="card-text">';
		content += sale.saleMessage;
		content += '<span class="fa fa-star star';
		if (sale.status == 2)
			content += " checked";
		content += '" onClick="toggleFav(' + sale.id + ')"></span></p>';
		content += '<div class="card-body">';
		content += '<div class="data">';
		content += '<table style="margin:10px">';
		content += '<tr><td float="right">Pharmacy:</td><td>';
		content += sale.pharmacyName;
		content += '</td></tr>';
		content += '<tr><td>Start date:</td><td>';
		content += ISOtoShort(new Date(sale.valPeriod.startDate));
		content += '</td></tr>';
		content += '<tr><td>End date:</td><td>';
		content += ISOtoShort(new Date(sale.valPeriod.endDate));
		content += '</td></tr>';
		content += '</table>';
		content += '<button class="btn btn-danger" data-toggle="modal" data-target="#deleteSaleModal" ';
		content += ' onclick="deleteSale(' + sale.id + ')"> Discard </button > ';
		content += '<button class="btn btn-success" data-toggle="modal" data-target="#exampleModalCenter"';
		content += ' onclick="useAction(' + sale.id + ')"> Use it now </button > ';
		content += '</div></div></div>';
		content += '</div>';

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
		alert("Start date can't be greater than end date!")
		return;
    }

	for (let sale of allSales) {
		if (name != "all" && sale.pharmacyName != name)
			continue;
		if (startDate && sale.valPeriod.startDate < startDate)
			continue;
		if (endDate && sale.valPeriod.endDate > endDate)
			continue;
		if (sale.status != 2 && fav == true)
			continue;
		filtered.push(sale);
	}
	viewSales(filtered);
}

function deleteSale(id) {
	$("#deleteSale").show();
	$("button#btnYes1").click(function () {
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
		}
	});
}

function useAction(id) {
	$("#useAction").show();

	//$("#btnYes").click(function () {
		//ajax pozvati da obrise akciju iz baze
		//i da stavi lek/ove u bazu
		//obrisati iz isa baze
	//});
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