var actions;

$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/actionsandbenefits/all",
		contentType: "application/json",
		success: function (data) {
			actions = data;
			viewActionsAndBenefits(actions);
			$(".loader").css("display", "none");
			$("#viewAction").css("display", "block");
		}
	});

	$(".btnFilter").click(function () {
		$("#divFilterTable").slideToggle();
	})
})


function viewActionsAndBenefits(data) {
	$("#viewAction").empty();
	for (let act of data) {
		let content = '<div class="card" id="' + act.id + '">';
		content += '<p class="card-text">';
		content += act.messageAboutAction;
		content += '<span class="fa fa-star star';
		if (act.status == 2)
			content += " checked";
		content += '" onClick="toggleFav(' + act.id + ')"></span></p>';
		content += '<div class="card-body">';
		content += '<div class="data">';
		content += '<table style="margin:10px">';
		content += '<tr><td float="right">Pharmacy:</td><td>';
		content += act.pharmacyName;
		content += '</td></tr>';
		content += '<tr><td>Start date:</td><td>';
		content += ISOtoShort(new Date(act.startDate));
		content += '</td></tr>';
		content += '<tr><td>End date:</td><td>';
		content += ISOtoShort(new Date(act.endDate));
		content += '</td></tr>';
		content += '</table>';
		content += '<button class="btn btn-danger" data-toggle="modal" data-target="#deleteActionModal" ';
		content += ' onclick="deleteAction(' + act.id + ')"> Discard </button > ';
		content += '<button class="btn btn-success" data-toggle="modal" data-target="#exampleModalCenter"';
		content += ' onclick="useAction(' + act.id + ')"> Use it now </button > ';
		content += '</div></div></div>';
		content += '</div>';


		$("#viewAction").append(content);
	}
}

function getSortData() {
	let sort = $("#sort").val();
	let order = $("#order").val();
	sortCards(sort, order);
	viewActionsAndBenefits(actions);
}

// Dates are in format : yyyy-MM-dd so we can compare them as strings
function sortCards(sort, order) {
	if (order == "asc") {
		for (let i = 0; i < (actions.length - 1); i++) {
			let minIdx = i;
			for (let j = i + 1; j < actions.length; j++) {
				if (sort == "phName") {
					if (actions[minIdx].pharmacyName.toLowerCase() > actions[j].pharmacyName.toLowerCase())
						minIdx = j;
				} else if (sort == "start") {
					if (actions[minIdx].startDate > actions[j].startDate)
						minIdx = j;
				} else if (sort == "expire") {
					if (actions[minIdx].endDate > actions[j].endDate)
						minIdx = j;
				} else if (sort == "list") {
					if (actions[minIdx].id > actions[j].id)
						minIdx = j;
                }
			}
			let temp = actions[i];
			actions[i] = actions[minIdx];
			actions[minIdx] = temp;
		}
	} else if (order == "desc") {
		for (let i = 0; i < (actions.length - 1); i++) {
			let maxIdx = i;
			for (let j = i + 1; j < actions.length; j++) {
				if (sort == "phName") {
					if (actions[maxIdx].pharmacyName.toLowerCase() < actions[j].pharmacyName.toLowerCase())
						maxIdx = j;
				} else if (sort == "start") {
					if (actions[maxIdx].startDate < actions[j].startDate)
						maxIdx = j;
				} else if (sort == "expire") {
					if (actions[maxIdx].endDate < actions[j].endDate)
						maxIdx = j;
				} else if (sort == "list") {
					if (actions[maxIdx].id < actions[j].id)
						maxIdx = j;
				}
			}
			let temp = actions[i];
			actions[i] = actions[maxIdx];
			actions[maxIdx] = temp;
		}
    }
}

function deleteAction(id) {
	$("#deleteAction").show();
	$("button#btnYes1").click(function () {
		$.ajax({
			method: "DELETE",
			url: "../api/actionsandbenefits/delete/" + id,
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
	for (let act of actions)
		if (act.id == id) {
			if (act.status != 2)
				newStatus = 2;
			else
				newStatus = 1;

			act.status = newStatus;
			break;
		}

	$.ajax({
		method: "PUT",
		url: "../api/actionsandbenefits/status/" + id + "/" + newStatus,
		contentType: "application/json",
		success: function (data) {
			viewActionsAndBenefits(actions);
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