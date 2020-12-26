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

    $("#btnUrgent").click(function (event) {
        event.preventDefault();
        $("#modalUrgProcurement").slideDown("fast");
    });

    $(".add_field_button").click(function (e) {
        e.preventDefault();
        if ($(".input_fields_wrap").children().length < 5) {
            $(".input_fields_wrap").append('<div><input placeholder="Enter medicine name" type="text" name="medicineName[]"/> ' +
                                                '<input placeholder="Enter amount" type="number" name="quantity[]"/> ' +
                                                '<button class="btn btn-outline-danger remove_field">&times;</button>' +
                                           '</div>');
        }
    });

    $(".input_fields_wrap").on('click', '.remove_field', function (e) {
        e.preventDefault();
        $(this).parent('div').remove();
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
        content += ' onclick="getMedications(\'' + api.nameOfPharmacy + '\')">Medication stock</button> ';
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