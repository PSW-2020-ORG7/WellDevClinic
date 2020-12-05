$(document).ready(function () {
	$.ajax({
		method: "GET",
		url: "../api/actionsandbenefits/all",
		contentType: "application/json",
		success: function (data) {
			viewActionsAndBenefits(data);
			$(".loader").css("display", "none");
			$("#viewAction").css("display", "block");
		}
	});

})


function viewActionsAndBenefits(data) {
	for (act of data) {
		content = '<div class="card" id="';
		content += act.id;
		content += '">';
		content += '<p class="card-text">';
		content += act.messageAboutAction;
		content += '</p >';
		content += '<div class="card-body">';
		content += '<div class="data">';
		content += '<table style="margin:10px">';
		content += '<tr><td float="right">Pharmacy:</td><td>';
		content += act.pharmacyName;
		content += '</td></tr>';
		content += '<tr><td>Start date:</td><td>';
		content += act.startDate;
		content += '</td></tr>';
		content += '<tr><td>End date:</td><td>';
		content += act.endDate;
		content += '</td></tr>';
		content += '</table>';
		content += '<button class="btn btn-danger" class="buttonDelete" data-toggle="modal" data-target="#exampleModalCenter1" id=';
		content += act.id;
		content += ' onclick="deleteAction(this)" class="buttonDeleteCard"> Reject </button > ';
		content += '<button id=';
		content += act.id;
		content += ' onclick="useAction(this)" class="btn btn-success" data-toggle="modal" data-target="#exampleModalCenter"> Use it now </button > ';
		content += '</div></div></div>';
		content += '</div>';

		$("#viewAction").append(content);
	}
}

function deleteAction(button) {
	$("#deleteAction").show();
	$("button#btnYes1").click(function () {
		$.ajax({
			method: "DELETE",
			url: "../api/actionsandbenefits/delete/" + button.id,
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

function useAction(data) {
	$("#useAction").show();

	//$("#btnYes").click(function () {
		//ajax pozvati da obrise akciju iz baze
		//i da stavi lek/ove u bazu
		//obrisati iz isa baze
	//});
}
