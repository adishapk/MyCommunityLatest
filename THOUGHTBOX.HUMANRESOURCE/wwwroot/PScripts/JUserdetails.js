$(document).ready(function () {
    GetUserType();
    getselectemployee();
    getAlluserdetails();
    
   
});


function GetUserType() {

    $.ajax({
        url: "/CreateUserTypePrivilege/GetUserType",
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            var markup = '';
            if (data != null) {

                markup = "<option value=''>--select--</option>";

                if (data != null) {
                    for (var x = 0; x < data.length; x++) {
                        markup += "<option value=" + data[x].userTypeId + ">" + data[x].userTypeName + "</option>";

                    }
                }
                $("#userType").html(markup).show();
            }
            else {
                markup = "<option value=''>--select--</option>";
                $("#userType").html(markup).show();
            }

        },
        error: function (reponse) {
            markup = "<option value=''>--select--</option>";
            $("#userType").html(markup).show();
        }
    });
}


function Deleteuserdetails(user_passvalue) {

    $.ajax({
        type: "POST",
        url: "/Userdetails/Deletinguservalues",
        data: { Iduservalues: user_passvalue },
        datatype: "json",
        success: function (data) {
            alert('Deleted successfully!!');
            getAlluserdetails();



        },
        error: function (reponse) {

            alert("Error");
        }
    });

}

function clearall() {
    
    $("#frm_slctusertype").val("select");
    $("#frm_slctemployee").val("select");
    $("#frm_slctassociate").val("select");
    $("#userType").val("select");
    $("#userType").val("select");
    
    $("#frm_username").val("");
    $("#frm_usrpassword").val("");
    $("#frm_emphidden").hide();
    $("#frm_usertypehidden").hide();
    $("#frm_assoctehidden").hide();
    
}
 
function Updateuserdetails(user_id, user_name, user_password, employee_id, user_status, userTypeId, user_category) {

         $("#btn_submit").val("Update");
         $("#user_id").val(user_id);
         $("#frm_username").val(user_name);
         $("#frm_usrpassword").val(user_password);
        
    $("#frm_useractive").val(user_status);
   
    if (user_category == "Companyemployee") {
        $("#frm_emphidden").show();
        $("#frm_usertypehidden").show();
        $("#frm_assoctehidden").hide();

        $("#frm_slctemployee").val(employee_id);
        getMastervalues("UserType", "userType", userTypeId);
    }
    else {
        $("#frm_slctusertype").val(user_category);

        $("#frm_usertypehidden").show();
        $("#frm_assoctehidden").show();
        $("#frm_emphidden").hide();
        getselectcustomer(employee_id);
      

        if (user_category == "Associate") {
            getMastervalues("Associate Type", "userType", userTypeId);
        }
        else if (user_category == "Client") {
            getMastervalues("Client Type", "userType", userTypeId);
       }
        else if (user_category == "Seller") {
            getMastervalues("Seller Type", "userType", userTypeId);
       }
       

    }
   // $("#userType").val(userTypeId);
    $("#frm_username").attr("disabled", true);


}

function userdetailsinsert() {

    var btnval = $("#btn_submit").val();

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);

    if (validatorResult.valid) {

        var empid = "";
        if ($("#frm_slctusertype").val() == "Companyemployee") {
            empid = $("#frm_slctemployee").val();
        }
        else {
            empid = $("#frm_slctassociate").val();
        }


        if (btnval == "Submit") {

         

            _Val = {
                user_category: $("#frm_slctusertype").val(),
                employee_id: empid,
                user_type_id: $("#userType").val(),
                user_name: $("#frm_username").val(),
                user_password: $("#frm_usrpassword").val(),
                user_status: $("#frm_useractive").val(),
            };

            $.ajax({
                url: "/Userdetails/uservaluesInsert",
                data: { uservalues: _Val },
                cache: false,
                type: "POSt",
                datatype: "json",
                success: function (data) {

                    alert("Successfully Inserted!");

                    clearall();
                    getAlluserdetails();
                    //getAllmastervalues();
                }
            });
        }

        else {

            _Val = {

                user_id: $("#user_id").val(),
                user_category: $("#frm_slctusertype").val(),
                employee_id: empid,
                user_type_id: $("#userType").val(),
                user_password: $("#frm_usrpassword").val(),
                user_status: $("#frm_useractive").val(),
            };


            $.ajax({
                type: 'POST',
                data: { uservaluesup: _Val },
                url: "/Userdetails/uservaluesupdate",
                dataType: 'json',
                success: function (data) {
                    alert("Successfully Updated!");

                    clearall();
                    getAlluserdetails();
                    //getAllmastervalues();

                    $("#btn_submit").val("Submit");
                }
            });

        }
    }
}


function getAlluserdetails() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/Userdetails/SelectAlluserdetails",
        data: { userval: idvalue },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            $('#tbl1').DataTable().clear().destroy();

            if (data[0].user_id != -1) {

                var table = new $('#tbl1').DataTable(
                    {
                        autoWidth: false,
                        data: data,
                        columns: [
                            {
                                'data': 'user_name'
                            },
                            {
                                'data': 'user_password'
                            },
                            {
                                'data': 'user_password'
                            },
                            {
                                'data': 'user_type_id'
                            },
                            {
                                'data': 'user_category'
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updateuserdetails(' + row.user_id + ',\'' + row.user_name + '\',\'' + row.user_password + '\',\'' + row.employee_id + '\',\'' + row.user_status + '\',\'' + row.user_type_id + '\',\'' + row.user_category + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deleteuserdetails(' + row.user_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
                            }

                        ],

                        "columnDefs": [
                            {
                                "searchable": false,
                                "orderable": false,
                                "targets": 0
                            }],

                        dom: 'Bfrtip',

                        lengthMenu: [
                            [10, 25, 50, -1],
                            ['10 rows', '25 rows', '50 rows', 'Show all']
                        ],
                        buttons: [
                            'pageLength', {
                                extend: 'copyHtml5',
                                text: '<i class="far fa-copy"></i>',
                                titleAttr: 'Copy'
                            },
                            {
                                extend: 'excelHtml5',
                                text: '<i class="far fa-file-excel"></i>',
                                titleAttr: 'Excel'
                            },
                            {
                                extend: 'csvHtml5',
                                text: '<i class="fas fa-file-csv"></i>',
                                titleAttr: 'CSV'
                            },
                            {
                                extend: 'pdfHtml5',
                                text: '<i class="far fa-file-pdf"></i>',
                                titleAttr: 'PDF'
                            },

                            {
                                extend: 'print',
                                text: 'Print',
                                autoPrint: false

                            }
                        ],

                    });
            }

        },
        error: function () {

        }
    })
}

$(function () {
    $("#frm_slctusertype").change(function () {
        var usercategory = $("#frm_slctusertype").val();
        if (usercategory == "Companyemployee") {
            $("#frm_emphidden").show();
            $("#frm_usertypehidden").show();
            $("#frm_assoctehidden").hide();
            getMastervalues("UserType", "userType","NIL");
        }
        else {
            getselectcustomer("NIL");
            $("#frm_usertypehidden").show();
            $("#frm_assoctehidden").show();
            $("#frm_emphidden").hide();

            if (usercategory == "Associate") {
                getMastervalues("Associate Type", "userType", "NIL");
            }
            else if (usercategory == "Client") {
                getMastervalues("Client Type", "userType", "NIL");
            }
            else if (usercategory == "Seller") {
                getMastervalues("Seller Type", "userType", "NIL");
            }
            
        }
        });
    });


function getselectemployee() {
    var idvalue = 1;
    $.ajax({
        url: "/Emppersonal/getEmployee",
        data: { idval: idvalue },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));

            var optionval = "<option value='select'>--Choose an Option--</option>";
            for (var x = 0; x < data.length; x++) {
                optionval += "<option value=" + data[x].employee_id + ">" + data[x].emp_firstname + "</option>";
            }
            $("#frm_slctemployee").html(optionval).show();
            //select.reload();


        },
        error: function (reponse) {

            alert("Error");
        }
    });

}

function getselectcustomer(associateid) {
    var custtype = $("#frm_slctusertype").val();
  
    $.ajax({
        url: "/CreateCustomer/getassociate",
        data: { idval: custtype },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));

            var optionval = "<option value='select'>--Choose an Option--</option>";
            for (var x = 0; x < data.length; x++) {
                optionval += "<option value=" + data[x].customer_id + ">" + data[x].cust_name + "</option>";
            }
            $("#frm_slctassociate").html(optionval).show();
            //select.reload();
            if (associateid != "NIL") {
                $("#frm_slctassociate").val(associateid);
            }
   
        },
        error: function (reponse) {

            alert("Error");
        }
    });

}


function getMastervalues(checkingfeild, dropdownname,defaultval) {

    var url = "/Createmastervalues/Getspecificmastervalues";

    $.ajax({
        url: url,
        data: { checkfield: checkingfeild },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            // alert(JSON.stringify(data));
            if (data.length > 0) {

                if (data[0].master_id == "-1") {
                    var markup = "<option value=''>--Select--</option>";
                    // $("#frm_salesman").html(markup).show();
                    $('#' + dropdownname).html(markup).show();

                }
                else {
                    var markup = "<option value=''>--Choose an Option--</option>";
                    for (var x = 0; x < data.length; x++) {

                        markup += "<option value=" + data[x].master_id + ">" + data[x].master_valuename + "</option>";
                    }
                    //$("#frm_salesman").html(markup).show();
                    $('#' + dropdownname).html(markup).show();
                    if (defaultval != "NIL") {
                        $("#userType").val(defaultval);
                    }
                    //select.reload();
                }
            }
        },
        error: function (reponse) {
            new PNotify({
                title: 'Warning!',
                text: 'Database error happened while filling the drop down!!',
                type: 'error',
                hide: false,
                styling: 'bootstrap3'
            });
        }
    });

}
