$(document).ready(function () {
    getAlldepartment();
    getallcompany();
});

function Deletedepartment(depart_delete) {
    $.ajax({
        type: "POST",
        url: "/CreateDepartment/Deletingdepart",
        data: { Iddepart: depart_delete },
        datatype: "json",
        success: function (data) {
            toastr.success("Deleted successfully!!");
            getAlldepartment();
            clearall();
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });

}

function Updatedepartment(department_id, company_id, department_name, department_code, department_details) {

    $("#btn_submit").val("Update");

    $("#frm_slctcompany").val(company_id);
    $("#department_id").val(department_id);
    $("#frm_deptname").val(department_name);
    $("#frm_deptcode").val(department_code);
    $("#frm_deptdetails").val(department_details);
    }

function getAlldepartment() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/CreateDepartment/SelectAlldepart",
        data: { deptval: idvalue },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            $('#tbl1').DataTable().clear().destroy();

            if (data[0].department_id != -1) {

                var table = new $('#tbl1').DataTable(
                    {
                        autoWidth: false,
                        data: data,
                        columns: [
                            {
                                'data': 'department_name'
                            },
                            {
                                'data': 'companyname'
                            },

                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updatedepartment(' + row.department_id + ',\'' + row.company_id + '\',\'' + row.department_name + '\',\'' + row.department_code + '\',\'' + row.department_details + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deletedepartment(' + row.department_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
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
    $("#frm_slctcompany").val("select");
    $("#frm_deptname").val("");
    $("#frm_deptcode").val("");
    $("#frm_deptdetails").val("");
}

function departmentinsert() {
    var btnval = $("#btn_submit").val();
    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);

    if (validatorResult.valid) {
        if (btnval == "Submit") {
            _Val = {
                Company_id: $("#frm_slctcompany").val(),
                department_name: $("#frm_deptname").val(),
                department_code: $("#frm_deptcode").val(),
                department_details: $("#frm_deptdetails").val(),
            };

            $.ajax({
                url: "/CreateDepartment/departmentInsert",
                data: { deptvalues: _Val },
                cache: false,
                type: "POSt",
                datatype: "json",
                success: function (data) {
                    if (data == 1) {
                        toastr.success("New Department Successfully Created!!");
                    }
                    else {
                        toastr.success("Entered Department Name already existing!!");
                    }
                    clearall();
                    getAlldepartment();
                }
            });
        }
        else {
            _Val = {
                department_id: $("#department_id").val(),
                Company_id: $("#frm_slctcompany").val(),
                department_name: $("#frm_deptname").val(),
                department_code: $("#frm_deptcode").val(),
                department_details: $("#frm_deptdetails").val(),
            };
            $.ajax({
                type: 'POST',
                data: { departmentupdate: _Val },
                url: "/CreateDepartment/departmntupdate",
                dataType: 'json',
                success: function (data) {
                    toastr.success("Department detail successfully Updated!!");
                    clearall();
                    getAlldepartment();
                    $("#btn_submit").val("Submit");
                }
            });
        }
    }
}

function getallcompany() {
    var idvalue = 1;
    $.ajax({
        url: "/CreateCompany/getallcomp",
        data: { companyget: idvalue },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));

            var optionval = "<option value='select'>--Choose an Option--</option>";
            for (var x = 0; x < data.length; x++) {
                optionval += "<option value=" + data[x].company_id + ">" + data[x].company_name + "</option>";
            }
            $("#frm_slctcompany").html(optionval).show();
            //select.reload();
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });
}