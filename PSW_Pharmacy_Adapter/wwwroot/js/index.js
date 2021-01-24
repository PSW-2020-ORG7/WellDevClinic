$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/sale/all",
		contentType: "application/json",
		success: function (sales) {
			viewNewSales(sales)
		},
		error: function () {
			pageInfo("An error has occured while trying to connect with hospital server. Try again later!");
		}
	});
})


function viewNewSales(sales) {
	$(".salesNotifications").empty();
	var num = 0;
	for (let sale of sales) {
		if (sale.status != 0)
			continue;
		let content = '<div class="card text-center"><div class="card-body">';
		content += '<h5 class="card-title">';
		content += sale.pharmacyName;
		content += '</h5>';
		content += '<p>' + sale.saleMessage + '</p>';
		content += '<button class="btn btn-danger" data-toggle="modal" data-target="#deleteActionModal" ';
		content += ' onclick="deleteSale(' + sale.id + ')"> Discard </button > ';
		content += '<button class="btn btn-success"';
		content += ' onclick="saveSale(' + sale.id + ')"> Save </button > ';
		content += '</div></div>';
		content += '</div>';

		num += 1;

		$(".salesNotifications").append(content);
	}
	$('#num').html(num);
}

function saveSale(id) {

	$.ajax({
		method: "PUT",
		url: "../api/sale/status/" + id + "/1",
		contentType: "application/json",
		success: function () {
			window.location.reload();
		},
		error: function (e) {
			pageInfo("An error has occured while trying to update actions status!");
		}
	});
}

function deleteSale(id) {
	$("#deleteAction").show();
	$("button#btnYes").click(function () {
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
				pageInfo("An error has occured while trying to delete action!");
			}
		});
	});
}

function pageInfo(text) {
	$("#message").text(text);
	$("#pageInfoModal").modal('toggle');
	$("#pageInfo").show();
}