$(document).ready(function () {
    $("#btnAddPharmacy").click(function () {
        let name = $("#txtName").val();
        let api = $("#txtApi").val();
        let url = $("#txtUrl").val();

        let valid = true;

        if (!name) {
            valid = false;
            $("#txtName").css("border-color", "red");
            $("#invalidName").css("display", "block");
        } else {
            $("#txtName").css("border-color", "#ccc");
            $("#invalidName").css("display", "none");
        }
        if (!api) {
            valid = false;
            $("#txtApi").css("border-color", "red");
            $("#invalidApi").css("display", "block");
        } else {
            $("#txtApi").css("border-color", "#ccc");
            $("#invalidApi").css("display", "none");
        }
        if (!url) {
            valid = false;
            $("#txtUrl").css("border-color", "red");
            $("#invalidUrl").css("display", "block");
        } else {
            $("#txtUrl").css("border-color", "#ccc");
            $("#invalidUrl").css("display", "none");
        }

        if (!valid)
            return;
        
        $.ajax({
            method: "POST",
            url: "../api/apikey/add",
            contentType: "application/json",
            data: JSON.stringify({
                NameOfPharmacy: name,
                ApiKey: api,
                Url: url
            }),
            success: function (data) {
                if (data) {
                    $('#message').html('Succesfully added to database.');
                    $("#regActionModal").modal('toggle');
                    $("#regAction").show();
                    $("#btnOk").click(function () {
                        window.location.assign(window.location.origin += "/partnerPharmacies.html");
                    });
                }
            },
            error: function (e) {
                $("#message").empty();
                if (api != "" & name != "" & url != "") {
                    $("#txtName").css("border-color", "red");
                    $('#message').html("Pharmacy with name " + name + " already exists!");
                    $("#regActionModal").modal('toggle');
                    $("#regAction").show();
                }
            }
        })
    })
})