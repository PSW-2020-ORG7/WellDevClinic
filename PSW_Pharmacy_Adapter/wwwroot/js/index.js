$(document).ready(function () {
    $("#testDugme").click(function () {
        $.ajax({
            method: "GET",
            url: "../api/medication",
            contentType: "application/json",
            //datatype: "application/json",
            success: function (data) {          
                alert(data[0].id);
            },
        });
    })

    $("#testDugmeRecepti").click(function () {
        $.ajax({
            method: "GET",
            url: "../api/prescription",
            contentType: "application/json",
            //dataType: "application/json",
            success: function (data) {
                alert(data[0].id);
            },
        });
   })

    
    
});

