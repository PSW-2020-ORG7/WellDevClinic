$(document).ready(function () {
    $("#testDugme").click(function () {
        $.ajax({
            method: "GET",
            url: "../api/medication",
            dataType: "application/json",
            success: function (data) {
                alert(data.id);
            },
        });
    })
    
});