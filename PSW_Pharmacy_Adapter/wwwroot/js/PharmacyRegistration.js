$(document).ready(function () {
    $("#btnAddPharmacy").click(function () {
        let name = $("#txtName").val();
        let api = $("#txtApi").val();
        let url = $("#txtUrl").val();
        let sub = $('#chkSubscribe').is(':checked');

        let valid = true;

        if (!name) {
            valid = false;
            $("#txtName").css("border-width", "1");
            $("#invalidName").css("display", "block");
        } else {
            $("#txtName").css("border-width", "0");
            $("#invalidName").css("display", "none");
        }
        if (!api) {
            valid = false;
            $("#txtApi").css("border-width", "1");
            $("#invalidApi").css("display", "block");
        } else {
            $("#txtApi").css("border-width", "0");
            $("#invalidApi").css("display", "none");
        }
        if (!url) {
            valid = false;
            $("#txtUrl").css("border-width", "1");
            $("#invalidUrl").css("display", "block");
        } else {
            $("#txtUrl").css("border-width", "0");
            $("#invalidUrl").css("display", "none");
        }

        if (valid) {
            var jsonApi = JSON.stringify({
                NameOfPharmacy: name,
                ApiKey: api,
                Url: url,
                Subscribed: sub
            });
        }

        
        $.ajax({
            method: "POST",
            url: "../api/apikey/add",
            contentType: "application/json",
            data: jsonApi,
            success: function (data) {
                if (data) {
                    document.getElementById('write').innerHTML = 'Succesfully added to database.';
                    $("#regAction").show();
                    $("#btnOk").click(function () {
                        window.location.assign(window.location.origin += "/partnerPharmacies.html");
                    });
                }
            },
            error: function (e) {
                document.getElementById('write').innerHTML = 'Pharmacy already exists.';
                $("#regAction").show();
                if (name & api & url) {
                    $("#txtName").css("border-width", "1");
                    alert("Pharmacy with name " + name + " already exists!");
                }      
            }
        })
    })
})