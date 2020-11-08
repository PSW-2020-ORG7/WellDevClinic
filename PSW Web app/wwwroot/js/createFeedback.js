$(document).ready(function () {

    let form = $("#feedbackForm");
    form.submit(function (event) {

        event.preventDefault();
        let comment = $("#comment");
        let anonymous = $("#anonymous");
        let private = $("#private");
        let comment2 = document.getElementById('comment');
        let anonymous2 = document.getElementById('anonymous');
        let private2 = document.getElementById('private');
        console.log(comment.val().trim.length)
        console.log(anonymous2.checked)
        console.log(private2.checked)

        if (jQuery.trim(comment.val()) != '') {
            let anonymousBool = false;
            if (anonymous2.checked) {
                anonymousBool = true;
            }

            let privateBool = false;
            if (private2.checked) {
                privateBool = true;
            }


            $.post({
                url: "http://localhost:49153/api/feedback",
                data: JSON.stringify({ content: comment.val(), isAnonymous: anonymousBool, isPrivate: privateBool }),
                success: function () {
                    alert("Uspesno ste poslali komentar")
                },
                contentType: "application/json; charset=utf-8"
            })
        }
        else {
            alert("Unesite komentar u odgovarajuce polje")
            comment.css("border-width","5px")
            comment.css("borderColor", "red")
        }

    })
})