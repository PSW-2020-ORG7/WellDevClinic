﻿$(document).ready(function () {
	//$("#viewMedication").empty();
	//for (let med of data) {                   // ajax za dobavljanje svih lekova te apoteke
        let content = '<a class="dropdown-item" href="#">';
        content += "Brufen";
        content += '</a >';
		
		$("#viewMedication").append(content);
	//}

    $("#btnSendMedication").click(function () {
        askPharmacy();
    });
});


function getAllMedicationFromPharmacy() {
    
}

function askPharmacy() {
    var name = "Anadol";                        // zameniti kad se doda ajax za dobijanje svih lekova
    $.ajax({
        method: "POST",
        url: "../api/grpc/" + name,             //trebalo bi i oznaku apoteke dodati
        contentType: "text/plain",
        success: function (data) {
            document.getElementById('write').innerHTML = "It's sent to pharmacy. Soon you will get response.";
            $("#stockAction").show();
            $("#btnOk").click(function () {
                document.getElementById("txtResponse").value = data;
            });
        },
    });
}