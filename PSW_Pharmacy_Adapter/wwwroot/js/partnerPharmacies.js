$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "../api/apikey/all",
        contentType: "application/json",
        success: function (apiDb) {
            if (apiDb) {
                viewApis(apiDb)
                $(".loader").css("display", "none");
                $("#apiTable").css("display", "table");
            }
        },
    });
});

function viewApis(apiDb) {
    for (let api of apiDb) {
        let content = '<tr><td>';
        content += api.nameOfPharmacy;
        content += '</td><td>';
        content += api.apiKey;
        content += '</td><td>';
        content += api.url;
        content += '</td>';
        content += '<td><button class="btn btn-info"';
        content += ' onclick="getMedications(\'' + api.nameOfPharmacy + '\')"> Medication stock</button> ';
        content += '</td><td>';
        content += '<button class="btn btn-outline-danger" data-toggle="modal" data-target="#deletePharmacyModal"';
        content += ' onclick="deleteEntry(\'' + api.nameOfPharmacy + '\')"> &times; </button> ';
        content += '</td></tr>'
        $("#apiTable").append(content);
    }
}

function deleteEntry(id) {
    $("#nameToDelete").html(id);
    $("#deletePharmacy").show();
    $("button#btnYes").click(function () {
        $.ajax({
            method: "DELETE",
            url: "../api/apikey/delete/" + id,
            contentType: "application/json",
            success: function (data) {
                if (data) {
                    window.location.reload();
                }
            },
        });
    })
}

function getMedications(id) {
    $("#phName").html(id);
    $("#txtResponse").val("");
    $("#medModal").slideDown("fast");
}

function showDialog() {
    $("#modalUrgProcurement").html();
    $("#modalUrgProcurement").show();
}

function addInputText() {
    var max_fields = 5; 
    var wrapper = $(".input_fields_wrap"); 
    var add_button = $(".add_field_button"); 

    var x = 1; 
    $(add_button).click(function (e) { 
        e.preventDefault();
        if (x < max_fields) { 
            ++x; 
            $(wrapper).append('<div><input placeholder="Enter medicine name" type="text" name="medicineName[]"/>' +
                '<input placeholder="Enter quantity" type="text" name="quantity[]"/><a href="#" class="remove_field">Remove</a></div>'); 
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) {
        e.preventDefault(); $(this).parent('div').remove(); --x;
    })
}
