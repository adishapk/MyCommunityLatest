
function checklogin() {
   
    var emuser = $("#frm_logemailuser").val();
    var logpass = $("#frm_logpassword").val();
    var _Val = {
        user_name: emuser,
        user_password: logpass,
    };
    $.ajax({
        url: "/Login/getlogin",
        data: { userdetailsDomain: _Val },       
        type: "POSt",
        datatype: "json",
        success: function (data) {
          //  window.location.href = "/Home/Index";
            if (data[0].user_id == -1) {

                alert("Entered User Name or Password is Wrong!");

                $("#frm_logemailuser").val("");
                $("#frm_logpassword").val("");
            }
            else {
                location.href = "/Home/Home";
            }

        }
    });

}


jQuery.extend(jQuery.expr[':'], {
    focusable: function (el, index, selector) {
        return $(el).is('a, button, :input, [tabindex]');
    }
});


$(document).on('keypress', 'input,select', function (e) {
    if (e.keyCode == 13 || e.which == 13) {
        e.preventDefault();
        // Get all focusable elements on the page
        var $canfocus = $(':focusable');
        var index = $canfocus.index(this) + 1;
        if (index >= $canfocus.length) index = 0;
        $canfocus.eq(index).focus();
    }
});

$(function () {

    //press enter on pswd..

    $('#User_Password').keypress(function (e) {
        var key = e.which;
        if (key == 13)  // the enter key code
        {
            checklogin();
            return false;
        }
    });

});