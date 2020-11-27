$(document).ready(function () {
    $("#btnAddPharmacy").click(function () {
        let name = $("#TxtName").val();
        let url = $("#TxtUrl").val();
        let api = $("#TxtApi").val();

        let valid = true;

        if (!name) {
            valid = false;
        }
        if (!url) {
            valid = false;
        }
        if (!api) {
            valid = false;
        }

        if (valid) {
            var jsonApi = JSON.stringify({
                NameOfPharmacy: name,
                ApiKey: api,
                Url: url
            });
        }

        $.ajax({
            method: "POST",
            url: "../api/apikey/add",
            contentType: "application/json",
            data: jsonApi,
            success: function (data) {
                if (data) {
                    alert("Succesfully added to database");
                }
            },
        })
    })
})