$(document).ready(function () {
    getAllcompany();
    
});

function Deletecompany(comp_delete) {
    $.ajax({
        type: "POST",
        url: "/CreateCompany/Deletingcompany",
        data: { Idcomp: comp_delete },
        datatype: "json",
        success: function (data) {
            toastr.success("Deleted successfully!!");
            getAllcompany();
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });

} 

function Updatecompany(company_id, company_name, company_code, company_details) {

    $("#btn_submit").val("Update");
    $("#company_id").val(company_id);

    $("#frm_compname").val(company_name);
    $("#frm_compcode").val(company_code);
    $("#frm_compdetails").val(company_details);
  
}


function getAllcompany() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/CreateCompany/SelectAllcompany",
        data: { checkval: idvalue },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            $('#tbl1').DataTable().clear().destroy();
            if (data[0].company_id != -1) {
                var table = new $('#tbl1').DataTable(
                    {
                        autoWidth: false,
                        data: data,
                        columns: [
                            {
                                'data': 'company_name'
                            },
                            {
                                'data': 'company_code'
                            },

                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updatecompany(' + row.company_id + ',\'' + row.company_name + '\',\'' + row.company_code + '\',\'' + row.company_details + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deletecompany(' + row.company_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
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

    $("#frm_compname").val("");
    $("#frm_compcode").val("");
    $("#frm_compdetails").val("");

}

function companyinsert() {

    var btnval = $("#btn_submit").val();

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);

    if (validatorResult.valid) {

        if (btnval == "Submit") {
            _Val = {
                company_name: $("#frm_compname").val(),
                company_code: $("#frm_compcode").val(),
                company_details: $("#frm_compdetails").val(),
            };
            $.ajax({
                url: "/CreateCompany/CompanyInsert",
                data: { companyvalues: _Val },
                cache: false,
                type: "POSt",
                datatype: "json",
                success: function (data) {
                    if (data == 1) {
                        toastr.success("New Company created Successfully!!");
                      }
                    else {
                        toastr.success("Entered Company Name already existing!!");
                    }
                   clearall();
                    getAllcompany();
                }
            });
        }
        else {
            _Val = {
                company_id: $("#company_id").val(),
                company_name: $("#frm_compname").val(),
                company_code: $("#frm_compcode").val(),
                company_details: $("#frm_compdetails").val(),
            };

            $.ajax({
                type: 'POST',
                data: { companyupdate: _Val },
                url: "/CreateCompany/companyupdate",
                dataType: 'json',
                success: function (data) {
                    toastr.success("Company details Successfully Updated!!");
                    clearall();
                    getAllcompany();
                    $("#btn_submit").val("Submit");
                }
            });

        }
    }
}