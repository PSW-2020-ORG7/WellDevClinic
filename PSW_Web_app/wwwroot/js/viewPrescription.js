var userType = "";
var token = "";
var userId = "";
function authorize() {
	token = sessionStorage.getItem("token");
	let payload = parseJwt(token);
	userType = payload["type"];
	userId = payload["Id"];
	if (userType != "Patient") {
		alert("You are not authorized for this page!!!");
		window.location.replace(window.location.protocol + "//" + window.location.host + "/html/viewFeedbackAdmin.html");
	}
}
function parseJwt(token) {
	var base64Url = token.split('.')[1];
	var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
	var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
		return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
	}).join(''));

	return JSON.parse(jsonPayload);
};

function addPrescription(prescription) {
	for (let drug of prescription.drug) {
		let base = $('#base');
		let strBegin = '';
		if (drug.alternative.length === 0) {
			 strBegin = ` <div class="col-md-8">
                        <div class="card mb-3">
                            <div class="card-body">
								<div class="row">
									<div class="col-sm-3">
										<h6 class="mb-0">Drug Name</h6>
									</div>
									<div class="col-sm-9 text-secondary">
										<label id="name">`+ drug.name + `</label>
									</div>
								</div>
								<hr>`;
			strBegin = strBegin + ` </ul></div></div><hr></div>`;

		}
		else {
			 strBegin = ` <div class="col-md-8">
                        <div class="card mb-3">
                            <div class="card-body">
								<div class="row">
									<div class="col-sm-3">
										<h6 class="mb-0">Drug Name</h6>
									</div>
									<div class="col-sm-9 text-secondary">
										<label id="name">`+ drug.name + `</label>
									</div>
								</div>
								<hr>
                                <div class="row">
                                    <div class="col-sm-3">
                                        <h6 class="mb-0">Alternatives</h6>
                                    </div>
                                    <div class="col-sm-9 text-secondary">
                                        <ul id="alternatives">`;

			for (let a of drug.alternative) {
				strBegin = strBegin + '<li>' + a.name + '</li>';
			}
			strBegin = strBegin + ` </ul></div></div><hr></div></div></div>`;

		}
		

		base.append(strBegin);		
	}
}


$(document).ready(function () {
	let searchParams = new URLSearchParams(window.location.search);
	let id = searchParams.get('id');

	$.get({
		url: window.location.protocol + "//" + window.location.host + '/api/examination/prescription/' + id,
		headers: { "Authorization": token },
		success: function (prescription) {
			let startDate = prescription.period.startDate;
			let start = startDate.split('T');
			let endDate = prescription.period.endDate;
			let end = endDate.split('T');
			$('label[id="period"]').text('from '+start[0]+' to '+end[0]);
			addPrescription(prescription);
		}
	});

});