
$(document).ready(function () {

    let form = $("#registrationForm");
    form.submit(function (event) {

        event.preventDefault();

        let name = $("#nameInput"); //document.getElementById('nameInput'); 
        let middleName = $("#middleNameInput"); //document.getElementById('middleNameInput');
        let surname = $("#surnameInput"); //document.getElementById('surnameInput');
        let country = $("#patientCountry"); //document.getElementById('patientCountry');
        let city = $("#patientCity"); //document.getElementById('patientCity');
        let address = $("#patientAddress"); //document.getElementById('patientAddress');
        let id = $("#patientID"); //document.getElementById('patientID');
        let dateOfBirth = $("#patientDateOfBirth"); //document.getElementById('patientDateOfBirth');
        let email = $("#patientEmail"); //document.getElementById('patientEmail');
        let emailConfirm = $("#patientEmailConfirm"); //document.getElementById('patientEmailConfirm');
        let phone = $("#patientPhone"); //document.getElementById('patientPhone');
        let username = $("#patientUsername"); //document.getElementById('patientUsername');
        let password = $("#patientPassword"); //document.getElementById('patientPassword');
        let passwordConfirm = $("#patientPasswordConfirm"); //document.getElementById('patientPasswordConfirm')
        //let passwordConfirm = $("#patientPasswordConfirm"); //document.getElementById('patientPasswordConfirm')
        let img = $("#patientImg"); //document.getElementById('patientImg');
        let gender = $("#patientGender"); //document.getElementById('patientGender');
        let race = $("#patientRace"); //document.getElementById('patientRace');

        console.log(name.val());
        console.log(city.val());
        console.log(middleName.val())
        console.log(surname.val())
        console.log(country.val())
        console.log(address.val())
        console.log(id.val())
        console.log(dateOfBirth.val())
        console.log(email.val())
        console.log(emailConfirm.val())
        console.log(phone.val())
        console.log(username.val())
        console.log(password.val())
        console.log(passwordConfirm.val())
        console.log(img.val())
        console.log(gender.val())
        console.log(race.val())


        let state = [{Id:0, Name: country.val(), Code: null, town:null}]
        let town = [{Id:0, Name:city.val(), PostalNumber: null, State: state}]
        let address1 = [{Id:0, Street:address.val(), Number:null, FullAddress:null,Town:town}]
        var start = new Date();
        var data1 = { Id:0, FirstName:name.val(), MiddleName:middleName.val(),LastName:surname.val(), Jmbg:id.val(),Email: email.val(),Phone: phone.val(),DateOfBirth:start,
            Address:address1,Username:username.val(),Password:password.val(),
            Gender: gender.val(), Race: race.val(), validation: false 
        }
        $.ajax({
            url: "http://localhost:49153/registration/new",
            type:'POST',
            data: JSON.stringify(data1),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                alert("Uspesno ste poslali mejl");
            }
        }) 
    })
})