$(document).ready(function () {
    $('#active').prop('checked', true);
    $("#active").val('Y');
    GetEmployees();
    GetUserType();
    GetAll();   
});

$(".reveal").on('click', function () {
    var $pwd = $(".pwd");
    if ($pwd.attr('type') === 'password') {
        $pwd.attr('type', 'text');
    } else {
        $pwd.attr('type', 'password');
    }
});

$(".creveal").on('click', function () {
    var $pwd = $(".cpwd");
    if ($pwd.attr('type') === 'password') {
        $pwd.attr('type', 'text');
    } else {
        $pwd.attr('type', 'password');
    }
});

function GetAll() {

    $.ajax({
        type: "POST",
        url: "/CreateUser/SelectAll",
        datatype: "json",
        success: function (data) {
         
            $('#tbl').DataTable().clear().destroy();
            var table = new $('#tbl').DataTable(
                {
                    autoWidth: false,
                    data: data,
                    columns: [
                        {
                            'data': 'id', defaultContent: ''
                        },

                        {
                            'data': 'reg_User_Name'

                        },
                        {
                            'data': 'user_Type_Name'

                        },
                        {
                            'data': 'user_Active'

                        },

                        {
                            'sortable': false,
                            'render': function (data, type, row) { return '<i onclick="Update(' + row.user_Id + ',' + row.user_Type_Id + ',' + row.employee_Id + ', \'' + row.reg_User_Name + '\' , \'' + row.user_Password + '\' , \'' + row.user_Active + '\', \'' + row.reg_Email_Id + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }

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
                            text: '<i class="fa fa-files-o"></i>',
                            titleAttr: 'Copy',
                            exportOptions: {
                                columns: [0, 1,2, 3]
                            }
                        },
                        {
                            extend: 'excelHtml5',
                            text: '<i class="fa fa-file-excel-o"></i>',
                            titleAttr: 'Excel',
                            exportOptions: {
                                columns: [0, 1,2, 3]
                            }
                        },
                        {
                            extend: 'csvHtml5',
                            text: '<i class="fa fa-file-text-o"></i>',
                            titleAttr: 'CSV' ,
                            exportOptions: {
                                columns: [0, 1,2, 3]
                            }
                        },
                        {
                            extend: 'pdfHtml5',
                            text: '<i class="fa fa-file-pdf-o"></i>',
                            titleAttr: 'PDF',
                            exportOptions: {
                                columns: [0, 1,2, 3]
                            }
                        },

                        {
                            extend: 'print',
                            text: 'Print',
                            autoPrint: false,
                            exportOptions: {
                                columns: [0, 1, 2,3]
                            }
                        }
                    ],

                });
            table.on('order.dt search.dt', function () {
                table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                    cell.innerHTML = i + 1;
                    table.cell(cell).invalidate('dom');
                });
            }).draw();   
           

        },
        error: function () {

        }
    })
}

function GetEmployees() {

    $.ajax({
        url: "CreateUser/GetEmployees",
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            var markup = '';         
            if (data != null) {
               
                markup = "<option value=''>--select--</option>";

                if (data !=null) {
                    for (var x = 0; x < data.length; x++) {
                        markup += "<option value=" + data[x].userTypeId + ">" + data[x].userName + "</option>";

                    }
                }
                $("#employee").html(markup).show();
            }
            else {
                markup = "<option value=''>--select--</option>";
                $("#employee").html(markup).show();
            }

        },
        error: function (reponse) {
            markup = "<option value=''>--select--</option>";
            $("#employee").html(markup).show();
        }
    });
}

function GetUserType() {

    $.ajax({
        url: "CreateUser/GetUserType",
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            var markup = '';         
            if (data != null) {
               
                markup = "<option value=''>--select--</option>";

                if (data!= null) {
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

function checkDuplication(val) {
    if (val != "") {
        var table = "public.tbl_re_user_details";
        var colm = "user_name";
        var condition = "upper(user_name) = upper(:user_name)";
        var status = "#dupStatus";

        $.ajax({
            type: "POST",
            url: "/CreateUser/checkDuplication/",
            data: { col: colm, tbl: table, cond: condition, para: val },
            datatype: "json",
            success: function (data) {
                if (data == 0) {
                    $("#dupUserNm").text("Already existing data.");
                    $(status).val("N");
                }
                else {
                    $("#dupUserNm").text("");
                    $(status).val("Y");
                }

            },
            error: function () {

            }
        })
    }
    else {
        $("#dupStatus").val("Y");
        $("#dupUserNm").text("");
    }
}

function Insert() {

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);
    var empid = $("#employee option:selected").val();
    var usertypeid = $("#userType option:selected").val();
    var userId = $("#userId").val();
    if ($("#hidden_empId").val() == 0) {
        userId = 0;
    }
    if (document.getElementById("active").checked) {
        $("#active").val('Y');
    }
    else {
        $("#active").val('N');
    }
    if (validatorResult.valid) {
        var _Val = {
            User_Type_Id: usertypeid,
            Reg_User_Name: $("#userName").val(),
            Employee_Id: empid,
            User_Password: $("#pswd").val(),
            User_Active: $("#active").val(),
            Reg_Email_Id: $("#emailId").val(),
            User_Id: userId,
        };
        var btn = $("#btn-submit").val();
        if (btn == "Submit") {
            if ($("#dupStatus").val() != "N") {
                document.getElementById("btn-submit").disabled = true;
                $.ajax({
                    type: 'POST',
                    data: { registrationForm: _Val },
                    url: "/CreateUser/Insert",
                    dataType: 'json',
                    success: function (data) {
                        if (data == false) {
                       //     resetForm();   
                            new PNotify({
                                title: 'Warning!',
                                text: 'Unhandled error. Please try again!!',
                                type: 'error',
                                delay: 1800,
                                styling: 'bootstrap3'
                            });
                        }
                        else {
                           
                            GetAll();
                            resetForm();                           
                            new PNotify({
                                title: 'Success!',
                                text: 'New User Successfully Added!!',
                                type: 'success',
                                delay: 1800,
                                styling: 'bootstrap3'
                            });
                        }
                    },
                    error: function (reponse) {
                        new PNotify({
                            title: 'Warning!',
                            text: 'Unhandled error. Please try again!!',
                            type: 'error',
                            delay: 1800,                         
                            styling: 'bootstrap3'
                        });
                    }
                });
            }
        }
        else {
            document.getElementById("btn-submit").disabled = true;
            $.ajax({
                type: "post",
                url: "/CreateUser/Update",
                data: { registrationForm: _Val },
                datatype: "json",
                success: function (data) {                   
                    if (data == false) {
                      //  resetForm();  
                        new PNotify({
                            title: 'Warning!',
                            text: 'Unhandled error. Please try again!!',
                            type: 'error',
                            delay: 1800,
                            styling: 'bootstrap3'
                        });
                    }
                    else {                        
                        $("#btn-submit").val("Submit");                        
                        GetAll();    
                        resetForm();
                        new PNotify({
                            title: 'Success!',
                            text: 'User Successfully Updated!!',
                            type: 'success',
                            delay: 1800,
                            styling: 'bootstrap3'
                        });                         
                    }
                },
                error: function () {
                   // resetForm();  
                    new PNotify({
                        title: 'Warning!',
                        text: 'Unhandled error. Please try again!!',
                        type: 'error',
                        delay: 1800,
                        styling: 'bootstrap3'
                    });
                }
            })
        }
    }
}

function Update(userid, usertypeid, employeeid, username, pswd, active, emailid) {

    if (active == "Y") {       
        var changeCheckbox = document.querySelector('.js-switch');
        changeCheckbox.checked = false;
        if (changeCheckbox.checked == false) {
            $(".switchery").prop('checked', true).trigger("click");
        }   
    }
    else {
        var changeCheckbox = document.querySelector('.js-switch');
        changeCheckbox.checked = true;
        if (changeCheckbox.checked == true) {
            $(".switchery").prop('checked', false).trigger("click");
        }   
    }
    $("#btn-submit").val("Update");  
    $("#userName").val("");
    $("#pswd").val("");
    $("#cPswd").val("");
    $("#userType").val("");   
    $("#emailId").val("");
    $("#active").val("");  
    $("#employee").val("");
    document.getElementById("userName").disabled = true;   
    $("#userName").val(username);
    $("#pswd").val(pswd);
    $("#cPswd").val(pswd);
    
    if (employeeid == 0) {
        $("#employee").val(''); 
        $("#hidden_empId").val(0); 
    }
    else {
        document.getElementById("employee").disabled = true;
        $("#employee").val(employeeid); 
        $("#hidden_empId").val(-1); 
    }
    $("#userType").val(usertypeid);
    $("#emailId").val(emailid);
    $("#active").val(active);   
    $("#userId").val(userid);    

}

function resetForm() {
    document.getElementById("btn-submit").disabled = false;
    document.getElementById("RegisterValidation").reset();
    var changeCheckbox = document.querySelector('.js-switch');
    changeCheckbox.checked = false;
    if (changeCheckbox.checked == false) {
        $(".switchery").prop('checked', true).trigger("click");
    }   
    $("#active").val('Y');
    document.getElementById("userName").disabled = false;
    document.getElementById("employee").disabled = false;
    $("#dupUserNm").text("");   
    $("#btn-submit").val("Submit");  
}

function showLoadingImage() {
    $('#yourParentElement').append('<div id="loading-image"><img src="path/to/loading.gif" alt="Loading..." /></div>');
}

function hideLoadingImage() {
    $('#loading-image').remove();
}
