
function addregistration() {
   
    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);
   
    if (validatorResult.valid) {
        
        _Val = {
            reg_username: $("#frm_username").val(),
            reg_usertype: 1,
            reg_emailid: $("#frm_emailid").val(),
            reg_password: $("#frm_password").val(),
            reg_active: "Y",
        };

        $.ajax({
            url: "/Registration/RegInsert",
            data: { Registration: _Val },
            cache: false,
            type: "POSt",
            datatype: "json",
            success: function (data) {

                alert("Successfully Registered!");


            }
        });
    }
    //else {
       // alert("Registration Failed!");
    //}
}


$(function () {
    $("#frm_username").change(function () {

        var username = $("#frm_username").val();

        $.ajax({
            url: "/Registration/usernameget",
            data: { user_name: username },
            cache: false,
            type: "POSt",
            datatype: "json",
            success: function (data) {

                if (data[0].reg_userid != 0) {

                    $("#frm_username").val("Entered User Name already existing!!");
                }

            },
            error: function (reponse) {

                alert("Error");
            }
        });



    });
});

$(function () {
    $("#frm_emailid").change(function () {

        var email = $("#frm_emailid").val();

        $.ajax({
            url: "/Registration/emailget",
            data: { email_id: email },
            cache: false,
            type: "POSt",
            datatype: "json",
            success: function (data) {

                if (data[0].reg_userid != 0) {

                    $("#frm_emailid").val("Entered Email Address already existing!!");
                }

            },
            error: function (reponse) {

                alert("Error");
            }
        });



    });
});

$(function () {
    $("#frm_confrmpasswrd").change(function () {

        var passwrd = $("#frm_password").val();
        var cnpasswrd = $("#frm_confrmpasswrd").val();

        if (cnpasswrd != passwrd) {

            alert("Both Passwords need to be same");
            $("#frm_confrmpasswrd").val("");

        }



    });
});