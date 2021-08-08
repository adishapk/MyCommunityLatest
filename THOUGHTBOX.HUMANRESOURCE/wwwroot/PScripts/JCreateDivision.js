$(document).ready(function () {
    getAlldivision();
    getallcompany();
});

function Deletedivision(divi_delete) {
    $.ajax({
        type: "POST",
        url: "/CreateDivision/Deletingdivisn",
        data: { Iddivisn: divi_delete },
        datatype: "json",
        success: function (data) {
            alert('Deleted successfully!!');

            getAlldivision();
            clearall();
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });

}

function Updatedivision(division_id, division_name, division_code, division_details, company_id, department_id) {

    $("#btn_submit").val("Update");
    $("#division_id").val(division_id);
    $("#frm_diviname").val(division_name);
    $("#frm_divicode").val(division_code);
    $("#frm_dividetails").val(division_details);
    $("#frm_slctcompany").val(company_id);
    changedept(company_id, department_id) 
}

function getAlldivision() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/CreateDivision/SelectAlldivisn",
        data: { divival: idvalue },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            $('#tbl1').DataTable().clear().destroy();
            if (data[0].division_id != -1) {
                var table = new $('#tbl1').DataTable(
                    {
                        autoWidth: false,
                        data: data,
                        columns: [
                            {
                                'data': 'division_name'
                            },
                            {
                                'data': 'departmentname'
                            },

                            {
                                'data': 'companyname'
                            },

                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updatedivision(' + row.division_id + ',\'' + row.division_name + '\',\'' + row.division_code + '\',\'' + row.division_details + '\',\'' + row.company_id + '\',\'' + row.department_id + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deletedivision(' + row.department_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
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
    $("#frm_diviname").val("");
    $("#frm_divicode").val("");
    $("#frm_divicode").val("");
    $("#frm_dividetails").val("");
    $("#frm_slctcompany").val("select");
    $("#frm_slctdept").val("select");
}

function divisioninsert() {
    var btnval = $("#btn_submit").val();
    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);
    if (validatorResult.valid) {
        if (btnval == "Submit") {
            _Val = {
                division_name: $("#frm_diviname").val(),
                division_code: $("#frm_divicode").val(),
                division_details: $("#frm_dividetails").val(),
                company_id: $("#frm_slctcompany").val(),
                department_id: $("#frm_slctdept").val(),
            };

            $.ajax({
                url: "/CreateDivision/divisionInsert",
                data: { divisnvalues: _Val },
                cache: false,
                type: "POSt",
                datatype: "json",
                success: function (data) {
                    if (data == 1) {
                        alert("Successfully Inserted!");
                    }
                    else {
                        alert("Entered Department Name already existing!");
                    }
                    clearall();
                    getAlldivision();
                }
            });
        }
        else {
            _Val = {
                division_id: $("#division_id").val(),
                division_name: $("#frm_diviname").val(),
                division_code: $("#frm_divicode").val(),
                division_details: $("#frm_dividetails").val(),
                company_id: $("#frm_slctcompany").val(),
                department_id: $("#frm_slctdept").val(),
            };
            $.ajax({
                type: 'POST',
                data: { divisnupdate: _Val },
                url: "/CreateDivision/divisionupdate",
                dataType: 'json',
                success: function (data) {
                    alert("Successfully Updated!");
                    clearall();
                    getAlldivision();
                    $("#btn_submit").val("Submit");
                }
            });
        }
    }
}

function changedept(compid, department_id) {
  
    $.ajax({
        url: "/CreateDepartment/getalldepart",
        data: { departget: compid },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));

            var optionval = "<option value='select'>--Choose an Option--</option>";
            for (var x = 0; x < data.length; x++) {
                optionval += "<option value=" + data[x].department_id + ">" + data[x].department_name + "</option>";
            }
          
            $("#frm_slctdept").html(optionval).show();
            //select.reload();
            $("#frm_slctdept").val(department_id);

        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });
}

$(function () {
    $("#frm_slctcompany").change(function () {
        var selectcomp = $("#frm_slctcompany").val();

        $.ajax({
            url: "/CreateDepartment/getalldepart",
            data: { departget: selectcomp },
            cache: false,
            type: "POSt",
            datatype: "json",
            success: function (data) {
                //alert(JSON.stringify(data));

                var optionval = "<option value='select'>--Choose an Option--</option>";
                for (var x = 0; x < data.length; x++) {
                    optionval += "<option value=" + data[x].department_id + ">" + data[x].department_name + "</option>";
                }
                $("#frm_slctdept").html(optionval).show();
                //select.reload();


            },
            error: function (reponse) {
                toastr.success("Database error happened while filling the drop down!!");
            }
        });
    });
});

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


