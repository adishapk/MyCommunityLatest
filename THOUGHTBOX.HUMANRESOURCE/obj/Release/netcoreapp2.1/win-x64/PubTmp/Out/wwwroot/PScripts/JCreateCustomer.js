$(document).ready(function () {
    getAllcustomerdetails();
    getselectemployee();
});

function Deletecustomerdetails(customer_value) {
    $.ajax({
        type: "POST",
        url: "/CreateCustomer/Deletingcustmrvalues",
        data: { Idcustomervalues: customer_value },
        datatype: "json",
        success: function (data) {
            toastr.success("Deleted successfully!!");
            getAllcustomerdetails();
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });
}

function Updatecustomerdetails(customer_id, cust_name, cust_address, cust_city, cust_state, cust_phoneno, cust_emailaddress, cust_contactperson, cust_cpdesignation, cust_status, cust_paidstatus, cust_type, cust_paidamount, cust_employeeid) {

    $("#btn_submit").val("Update");
    $("#customer_id").val(customer_id);
    $("#frm_customername").val(cust_name);
    $("#frm_strtaddress").val(cust_address);
    $("#frm_city").val(cust_city);
    $("#frm_state").val(cust_state);
    $("#frm_phnumber").val(cust_phoneno);
    $("#frm_email").val(cust_emailaddress); 
    $("#frm_contactpersn").val(cust_contactperson);
    $("#frm_cpdesigntn").val(cust_cpdesignation);
    $("#frm_cpstatus").val(cust_status);
    $("#frm_paidstatus").val(cust_paidstatus);
    $("#frm_custtype").val(cust_type);
    $("#frm_paidamnt").val(cust_paidamount);
    $("#frm_empployeeid").val(cust_employeeid);
}

function getAllcustomerdetails() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/CreateCustomer/SelectAllcustomer",
        data: { custval: idvalue },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            $('#tbl1').DataTable().clear().destroy();

            if (data[0].customer_id != -1) {

                var table = new $('#tbl1').DataTable(
                    {
                        autoWidth: false,
                        data: data,
                        columns: [
                            {
                                'data': 'cust_name'
                            },
                            {
                                'data': 'cust_type'
                            },
                            {
                                'data': 'cust_contactperson'
                            },
                            {
                                'data': 'cust_paidstatus'
                            },
                            {
                                'data': 'cust_phoneno'
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updatecustomerdetails(' + row.customer_id + ',\'' + row.cust_name + '\',\'' + row.cust_address + '\',\'' + row.cust_city + '\',\'' + row.cust_state + '\',\'' + row.cust_phoneno + '\',\'' + row.cust_emailaddress + '\',\'' + row.cust_contactperson + '\',\'' + row.cust_cpdesignation + '\',\'' + row.cust_status + '\',\'' + row.cust_paidstatus + '\',\'' + row.cust_type + '\',\'' + row.cust_paidamount + '\',\'' + row.cust_employeeid + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deletecustomerdetails(' + row.customer_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
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
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    })
}


function clearall() {
    $("#frm_customername").val("");
    $("#frm_strtaddress").val("");
    $("#frm_city").val("");
    $("#frm_state").val("");
    $("#frm_phnumber").val("");
    $("#frm_email").val("");
    $("#frm_contactpersn").val("");
    $("#frm_cpdesigntn").val("");
    $("#frm_cpstatus").val("");
    $("#frm_paidstatus").val("");
    $("#frm_custtype").val("");
    $("#frm_paidamnt").val("");
    $("#frm_empployeeid").val("select");
}


function createcustomerinsert() {

    var btnval = $("#btn_submit").val();

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);

    if (validatorResult.valid) {

        if (btnval == "Submit") {

            _Val = {
                cust_name: $("#frm_customername").val(),
                cust_address: $("#frm_strtaddress").val(),
                cust_city: $("#frm_city").val(),
                cust_state: $("#frm_state").val(),
                cust_phoneno: $("#frm_phnumber").val(),
                cust_emailaddress: $("#frm_email").val(),
                cust_contactperson: $("#frm_contactpersn").val(),
                cust_cpdesignation: $("#frm_cpdesigntn").val(),
                cust_status: $("#frm_cpstatus").val(),
                cust_paidstatus: $("#frm_paidstatus").val(),
                cust_type: $("#frm_custtype").val(),
                cust_paidamount: $("#frm_paidamnt").val(),
                cust_employeeid: $("#frm_empployeeid").val(),
            };

            $.ajax({
                url: "/CreateCustomer/CustomerInsert",
                data: { customervalues: _Val },
                cache: false,
                type: "POSt",
                datatype: "json",
                success: function (data) {
                    toastr.success("New Customer created successfully!!");
                    clearall();
                    getAllcustomerdetails();
                    
                }
            });
        }

        else {
          //  alert($("#frm_empployeeid").val());
            _Val = {
                customer_id: $("#customer_id").val(),
                cust_name: $("#frm_customername").val(),
                cust_address: $("#frm_strtaddress").val(),
                cust_city: $("#frm_city").val(),
                cust_state: $("#frm_state").val(),
                cust_phoneno: $("#frm_phnumber").val(),
                cust_emailaddress: $("#frm_email").val(),
                cust_contactperson: $("#frm_contactpersn").val(),
                cust_cpdesignation: $("#frm_cpdesigntn").val(),
                cust_status: $("#frm_cpstatus").val(),
                cust_paidstatus: $("#frm_paidstatus").val(),
                cust_type: $("#frm_custtype").val(),
                cust_paidamount: $("#frm_paidamnt").val(),
                cust_employeeid: $("#frm_empployeeid").val(),
            };


            $.ajax({
                type: 'POST',
                data: { Customervalupdate: _Val },
                url: "/CreateCustomer/customerupdate",
                dataType: 'json',
                success: function (data) {
                    toastr.success("Customer Details Successfully Updated!!");
                    clearall();
                    getAllcustomerdetails();
                    $("#btn_submit").val("Submit");
                }
            });
        }
    }
}


function getMastervalues(checkingfeild, dropdownname) {
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
                    //select.reload();
                }
            }
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });
}

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
            $("#frm_empployeeid").html(optionval).show();
            //select.reload();
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });
}