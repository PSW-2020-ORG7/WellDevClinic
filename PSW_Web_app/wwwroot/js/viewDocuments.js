function addPrescription(examination) {
	let tr = $('<tr id="tr"></tr>');
	let td = $('<td></td>');
	let form = $('<form id="form" class="form-horizontal"></form>');

	let doctor=examination.doctor;
	let date = examination.date;
	let drug="";
	for(let d of examination.prescription.drug){
		drug.concat(d).concat(";");
	}

	let doctorDiv = $('<div class="form-group row"><div class="col-sm-12"><input id="doctor" readonly class="form-control-plaintext" value="'+ doctor +'"></div></div>');
	let dateDiv = $('<div class="form-group row"><div class="col-sm-12"><input id="date" readonly class="form-control-plaintext" value="'+ date +'"></div></div>');
	let drugDiv = $('<div class="form-group row"><div class="col-sm-12"><input id="drug" readonly class="form-control-plaintext" value="'+ drug +'"></div></div>');

	form.append(doctorDiv).append(dateDiv).append(drugDiv);
	td.append(form);
	tr.append(td);
	$('#table tbody').append(tr);
}
function addReferral(examination) {
	let tr = $('<tr id="tr"></tr>');
	let td = $('<td></td>');
	let form = $('<form id="form" class="form-horizontal"></form>');

	let doctor=examination.doctor;
	let date = examination.date;
	let specialist=examination.referral.specialist;
	let text = examination.referral.text;

	let doctorDiv = $('<div class="form-group row"><div class="col-sm-12"><input id="doctor" readonly class="form-control-plaintext" value="'+ doctor +'"></div></div>');
	let dateDiv = $('<div class="form-group row"><div class="col-sm-12"><input id="date" readonly class="form-control-plaintext" value="'+ date +'"></div></div>');
	let specialistDiv = $('<div class="form-group row"><div class="col-sm-12"><input id="specialist" readonly class="form-control-plaintext" value="'+ specialist +'"></div></div>');
	let textDiv = $('<div class="form-group row"><div class="col-sm-12"><input id="text" readonly class="form-control-plaintext" value="'+ text +'"></div></div>');

	form.append(doctorDiv).append(dateDiv).append(specialistDiv).append(textDiv);
	td.append(form);
	tr.append(td);
	$('#table tbody').append(tr);
}
function deleteTable() {
	$('#table tbody').empty();
}


var examinations=[];


function showRow(id) {
	var row = document.getElementById(id);
	row.style.display = '';
}

function hideRow(id) {
	var row = document.getElementById(id);
	row.style.display = 'none';
}

function hideAll() {
	hideRow('Referral');
	hideRow('Prescription');
}

$(document).ready(function () {
	
	$('select[name="type"]').change(function () {
		var value = $(this).val();
		if (value == "Referral") {
			showRow("Referral");
			hideRow("Prescription");
			$('input[name="drug"]').val("");
		}
		if (value == "Prescription") {
			showRow("Prescription");
			hideRow("Referral");
			$('input[name="specialist"]').val("");
		}
		if (value == "none") {
			hideAll();
			$('input[name="specialist"]').val("");
			$('input[name="drug"]').val("");
		}
	});

	$('input[type="button"]').click(function (event) {
		hideAll();
		document.forms["formParams"].reset();
	});

	let type = $('select[name="type"]').val();
	let date = $('input[name="date"]').val();
	let doctor = $('input[name="doctor"]').val();
	let specialist = $('input[name="specialist"]').val();
	let drug = $('input[name="drug"]').val();

	$('form#formParams').submit(function (event) {
		deleteTable();
		if(type == "none"){
			if(date==""){
				if(doctor==""){
					for(let examination of examinations){
						addPrescription(examination);
						addReferral(examination);
					}
				}
				else{
					for(let examination of examinations){
						if(examination.doctor.toLowerCase().includes(doctor.toLowerCase())){
							addPrescription(examination);
							addReferral(examination);
						}
					}
				}
			}
			else{
				if(doctor==""){
					for(let examination of examinations){
						if(examination.date.getTime() === date.getTime()){
							addPrescription(examination);
							addReferral(examination);
						}
					}
				}
				else{
					for(let examination of examinations){
						if(examination.doctor.toLowerCase().includes(doctor.toLowerCase()) && examination.date.getTime() === date.getTime()){
							addPrescription(examination);
							addReferral(examination);
						}
					}
				}
			}
		}
		if(type=="Referral"){
			if(date==""){
				if(doctor==""){
					if(specialist==""){
						for(let examination of examinations){
							addReferral(examination);
						}
					}
					else{
						for(let examination of examinations){
							if(examination.referral.specialist.toLowerCase().includes(specialist.toLowerCase())){
								addReferral(examination);
							}
						}
					}
				}
				else{
					if(specialist==""){
						for(let examination of examinations){
							if(examination.doctor.toLowerCase().includes(doctor.toLowerCase())){
								addReferral(examination);
							}
						}
					}
					else{
						for(let examination of examinations){
							if(examination.doctor.toLowerCase().includes(doctor.toLowerCase()) && examination.referral.specialist.toLowerCase().includes(specialist.toLowerCase())){
								addReferral(examination);
							}
						}
					}
				}
			}
			else{
				if(doctor==""){
					if(specialist==""){
						for(let examination of examinations){
							if(examination.date.getTime() === date.getTime()){
								addReferral(examination);
							}
						}
					}
					else{
						for(let examination of examinations){
							if(examination.date.getTime() === date.getTime() && examination.referral.specialist.toLowerCase().includes(specialist.toLowerCase())){
								addReferral(examination);
							}
						}
					}
				}
				else{
					if(specialist==""){
						for(let examination of examinations){
							if(examination.date.getTime() === date.getTime() && examination.doctor.toLowerCase().includes(doctor.toLowerCase())){
								addReferral(examination);
							}
						}
					}
					else{
						for(let examination of examinations){
							if(examination.date.getTime() === date.getTime() && examination.doctor.toLowerCase().includes(doctor.toLowerCase()) &&  examination.referral.specialist.toLowerCase().includes(specialist.toLowerCase())){
								addReferral(examination);
							}
						}
					}
				}
				
			}
		}
		if(type=="Prescription"){
			//pretrazi samo po date i doctor i drug
			if(date==""){
				if(doctor==""){
					if(drug==""){
						for(let examination of examinations){
							addPrescription(examination);
						}
					}
					else{
						for(let examination of examinations){
							for(let d of examination.prescription.drug){
								if(d.toLowerCase()==drug.toLowerCase()){
									addPrescription(examination);
								}
							}
						}
					}
				}
				else{
					if(drug==""){
						for(let examination of examinations){
							if(examination.doctor.toLowerCase().includes(doctor.toLowerCase())){
								addPrescription(examination);
							}
						}
					}
					else{
						for(let examination of examinations){
							for(let d of examination.prescription.drug){
								if(d.toLowerCase()==drug.toLowerCase() && examination.doctor.toLowerCase().includes(doctor.toLowerCase())){
									addPrescription(examination);
								}
							}
						}
					}
				}
			}
			else{
				if(doctor==""){
					if(drug==""){
						for(let examination of examinations){
							if(examination.date.getTime() === date.getTime()){
								addPrescription(examination);
							}
						}
					}
					else{
						for(let examination of examinations){
							for(let d of examination.prescription.drug){
								if(d.toLowerCase()==drug.toLowerCase() && examination.date.getTime() === date.getTime()){
									addPrescription(examination);
								}
							}
						}
					}
				}
				else{
					if(drug==""){
						for(let examination of examinations){
							if(examination.date.getTime() === date.getTime() && examination.doctor.toLowerCase().includes(doctor.toLowerCase())){
								addPrescription(examination);
							}
						}
					}
					else{
						for(let examination of examinations){
							for(let d of examination.prescription.drug){
								if(d.toLowerCase()==drug.toLowerCase() && examination.date.getTime() === date.getTime() && examination.doctor.toLowerCase().includes(doctor.toLowerCase())){
									addPrescription(examination);
								}
							}
						}	
					}
				}
			}
		
		}
	});



	

});