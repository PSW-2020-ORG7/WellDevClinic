var allActions;
var nameList = [];

$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/actionsandbenefits/all",
		contentType: "application/json",
		success: function (data) {
			allActions = data;
			viewActionsAndBenefits(allActions);
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
		let content = '<div class="card">';
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

		// Filter name select fill
		if (nameList.includes(act.pharmacyName))
			continue;
		nameList.push(act.pharmacyName);
		let nameFilter = '<option value="' + act.pharmacyName + '">' + act.pharmacyName + '</option>';
		$("#selectname").append(nameFilter);
	}
}

function sortData() {
	let sort = $("#sort").val();
	let order = $("#order").val();
	sortCards(sort, order);
	viewActionsAndBenefits(allActions);
}

// Dates are in format : yyyy-MM-dd so we can compare them as strings
function sortCards(sort, order) {
	for (let i = 0; i < (allActions.length - 1); i++) {
		let minIdx = i;
		for (let j = i + 1; j < allActions.length; j++) {
			if (sort == "phName") {
				if (allActions[minIdx].pharmacyName.toLowerCase() > allActions[j].pharmacyName.toLowerCase())
					minIdx = j;
			} else if (sort == "start") {
				if (allActions[minIdx].startDate > allActions[j].startDate)
					minIdx = j;
			} else if (sort == "expire") {
				if (allActions[minIdx].endDate > allActions[j].endDate)
					minIdx = j;
			} else if (sort == "list") {
				if (allActions[minIdx].id > allActions[j].id)
					minIdx = j;
            }
		}
		let temp = allActions[i];
		allActions[i] = allActions[minIdx];
		allActions[minIdx] = temp;
	}
	if (order == 'desc')
		allActions.reverse();
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

	for (let act of allActions) {
		if (name != "all" && act.pharmacyName != name)
			continue;
		if (startDate && act.startDate < startDate)
			continue;
		if (endDate && act.endDate > endDate)
			continue;
		if (act.status != 2 && fav == true)
			continue;
		filtered.push(act);
	}
	viewActionsAndBenefits(filtered);
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
	for (let act of allActions)
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
			viewActionsAndBenefits(allActions);
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