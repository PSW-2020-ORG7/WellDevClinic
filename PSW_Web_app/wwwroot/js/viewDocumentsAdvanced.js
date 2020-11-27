$(document).ready(function () {
	$('select[name="type"]').change(function () {
		var value = $(this).val();
		if (value == "Refferal") {
			$("#Referral").show();
			$("#Prescription").hide();
			$('input[name="drug"]').val("");
		}
		if (value == "Prescription") {
			$("#Referral").hide();
			$("#Prescription").show();
			$('input[name="specialist"]').val("");
		}
		if (value == "none") {
			$("#Referral").hide();
			$("#Prescription").hide();
			$('input[name="specialist"]').val("");
			$('input[name="drug"]').val("");
		}
	});

	$('input[type="button"]').click(function (event) {
		$("Referral").hide();
		$("Prescription").hide();
		document.forms["form"].reset();
	});

	$.get({
		url: 'http://localhost:49153/api/examination/',
		success: function (documents) {
			for (doc in documents) {
				addDocument(doc);
            }
        }
	});

	let type = $('select[name="type"]').val();
	let date = $('input[name="date"]').val();
	let doctor = $('input[name="doctor"]').val();
	let specialist = $('input[name="specialist"]').val();
	let drug = $('input[name="drug"]').val();

	if (doctor != "") {
		$("#group1").show();
	}
	if (date != "") {
		$("#group2").shows();
	}
	if (drug != "") {
		$("#group3").show();
	}
	if (specialist != "") {
		$("#group1").show();
	}

	$('form#formParams').submit(function (event) {

		if (type == "none") {
			if (date == "") {
				if (doctor == "") {
					for (let examination of examinations) {
						addDocument(examination);
					}
				}
				else {
					$('input[name=group1]:checked', '#group1').val();
					for (let examination of examinations) {
						if (examination.doctor.toLowerCase().includes(doctor.toLowerCase())) {
							addDocument(examination);
						}
					}
				}
			}
			else {

				if (doctor == "") {
					$('input[name=group2]:checked', '#group2').val();
					for (let examination of examinations) {
						if (examination.date.getTime() === date.getTime()) {
							addDocument(examination);
						}
					}
				}
				else {
					for (let examination of examinations) {
						if (examination.doctor.toLowerCase().includes(doctor.toLowerCase()) && examination.date.getTime() === date.getTime()) {
							addDocument(examination);
						}
					}
				}
			}
		}
		if (type == "Referral") {
			if (date == "") {
				if (doctor == "") {
					if (specialist == "") {
						for (let examination of examinations) {
							addDocument(examination);
						}
					}
					else {
						for (let examination of examinations) {
							if (examination.referral.specialist.toLowerCase().includes(specialist.toLowerCase())) {
								addDocument(examination);
							}
						}
					}
				}
				else {
					if (specialist == "") {
						for (let examination of examinations) {
							if (examination.doctor.toLowerCase().includes(doctor.toLowerCase())) {
								addDocument(examination);
							}
						}
					}
					else {
						for (let examination of examinations) {
							if (examination.doctor.toLowerCase().includes(doctor.toLowerCase()) && examination.referral.specialist.toLowerCase().includes(specialist.toLowerCase())) {
								addDocument(examination);
							}
						}
					}
				}
			}
			else {
				if (doctor == "") {
					if (specialist == "") {
						for (let examination of examinations) {
							if (examination.date.getTime() === date.getTime()) {
								addDocument(examination);
							}
						}
					}
					else {
						for (let examination of examinations) {
							if (examination.date.getTime() === date.getTime() && examination.referral.specialist.toLowerCase().includes(specialist.toLowerCase())) {
								addDocument(examination);
							}
						}
					}
				}
				else {
					if (specialist == "") {
						for (let examination of examinations) {
							if (examination.date.getTime() === date.getTime() && examination.doctor.toLowerCase().includes(doctor.toLowerCase())) {
								addDocument(examination);
							}
						}
					}
					else {
						for (let examination of examinations) {
							if (examination.date.getTime() === date.getTime() && examination.doctor.toLowerCase().includes(doctor.toLowerCase()) && examination.referral.specialist.toLowerCase().includes(specialist.toLowerCase())) {
								addDocument(examination);
							}
						}
					}
				}

			}
		}
		if (type == "Prescription") {
			if (date == "") {
				if (doctor == "") {
					if (drug == "") {
						for (let examination of examinations) {
							addDocument(examination);
						}
					}
					else {
						for (let examination of examinations) {
							for (let d of examination.prescription.drug) {
								if (d.toLowerCase() == drug.toLowerCase()) {
									addDocument(examination);
								}
							}
						}
					}
				}
				else {
					if (drug == "") {
						for (let examination of examinations) {
							if (examination.doctor.toLowerCase().includes(doctor.toLowerCase())) {
								addDocument(examination);
							}
						}
					}
					else {
						for (let examination of examinations) {
							for (let d of examination.prescription.drug) {
								if (d.toLowerCase() == drug.toLowerCase() && examination.doctor.toLowerCase().includes(doctor.toLowerCase())) {
									addDocument(examination);
								}
							}
						}
					}
				}
			}
			else {
				if (doctor == "") {
					if (drug == "") {
						for (let examination of examinations) {
							if (examination.date.getTime() === date.getTime()) {
								addDocument(examination);
							}
						}
					}
					else {
						for (let examination of examinations) {
							for (let d of examination.prescription.drug) {
								if (d.toLowerCase() == drug.toLowerCase() && examination.date.getTime() === date.getTime()) {
									addDocument(examination);
								}
							}
						}
					}
				}
				else {
					if (drug == "") {
						for (let examination of examinations) {
							if (examination.date.getTime() === date.getTime() && examination.doctor.toLowerCase().includes(doctor.toLowerCase())) {
								addDocument(examination);
							}
						}
					}
					else {
						for (let examination of examinations) {
							for (let d of examination.prescription.drug) {
								if (d.toLowerCase() == drug.toLowerCase() && examination.date.getTime() === date.getTime() && examination.doctor.toLowerCase().includes(doctor.toLowerCase())) {
									addDocument(examination);
								}
							}
						}
					}
				}
			}

		}
	});

});
var examinations;
function addDocument(doc) {
	// doctor, date, drug, specialist, text
	let body = document.getElementById("tbody");
	let tr = $('<tr></tr>');
	let tdDoctor = $('<td>' + doc.doctor + '</td>');
	let tdDate = $('<td>' + doc.date + '</td>');
	let empty = $('<td>' + '</td>');
	if (doc.prescription) {
		let drug = "";
		for (let d of doc.prescription.drug) {
			drug.concat(d).concat(";");
		}
		let tdDrug = $('<td>' + drug + '</td>');
		tr.append(tdDoctor).append(tdDate).append(tdDrug).append(empty).append(empty);
	} else {
		let tdSpecialist = $('<td>' + doc.referral.specialist + '</td>');
		let tdText = $('<td>' + doc.referral.text + '</td>');
		tr.append(tdDoctor).append(tdDate).append(empty).append(tdSpecialist).append(tdText);
    }
	body.append(tr);
}