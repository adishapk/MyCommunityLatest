
$(document).ready(function () {
    getAllslrystruct();
    

});




function Updateslrystructure(salstruct_id, salstruct_type, salstruct_head) {

    $("#btn_submit").val("Update");
    $("#salstruct_id").val(salstruct_id);

    $("#frm_salrytype").val(salstruct_type);
    $("#frm_salaryhead").val(salstruct_head);
    
}


function Deleteslrystructure(salary_structure) {

    $.ajax({
        type: "POST",
        url: "/Salarystructure/Deletingsalarystruct",
        data: { Idsalrystruct: salary_structure },
        datatype: "json",
        success: function (data) {
            alert('Deleted successfully!!');
            getAllslrystruct();



        },
        error: function (reponse) {

            alert("Error");
        }
    });

}

function getAllslrystruct() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/Salarystructure/SelectAllsalstruct",
        data: { salrystructval: idvalue },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            $('#tbl1').DataTable().clear().destroy();

            if (data[0].master_Id != -1) {

                var table = new $('#tbl1').DataTable(
                    {
                        autoWidth: false, 
                        
                        data: data,
                        columns: [
                            {
                                'data': 'salstruct_head'
                            },
                            {
                                'data': 'salstruct_type'
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updateslrystructure(' + row.salstruct_id + ',\'' + row.salstruct_type + '\',\'' + row.salstruct_head + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deleteslrystructure(' + row.salstruct_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
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


function clearall() {
    $("#frm_salrytype").val("");
    $("#frm_salaryhead").val("");
}

function addsalarystructure() {
    
    var btnval = $("#btn_submit").val();
    
    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);

    if (validatorResult.valid) {
       
        if (btnval == "Submit") {
       
            _Val = {
                salstruct_type: $("#frm_salrytype").val(),
                salstruct_head: $("#frm_salaryhead").val(),
                
            };

            $.ajax({
                url: "/Salarystructure/salrystructureInsert",
                data: { salaryvalues: _Val },
                cache: false,
                type: "POSt",
                datatype: "json",
                success: function (data) {

                    if (data == 1) {
                        alert("Successfully Inserted!");
                    }
                    else {
                        alert("Entered Salary Head is already existing under selected Salary Type!");
                    }
                    getAllslrystruct();
                    clearall();
                    
                }
            });
        }

        else {
            
            _Val = {
                salstruct_id: $("#salstruct_id").val(),
                salstruct_type: $("#frm_salrytype").val(),
                salstruct_head: $("#frm_salaryhead").val(),
            };


            $.ajax({
                type: 'POST',
                data: { salaryvalueup: _Val },
                url: "/Salarystructure/salrystructureupdate",
                dataType: 'json',
                success: function (data) {
                    alert("Successfully Updated!");
                    getAllslrystruct();
                    clearall();
                    $("#btn_submit").val("Submit");
                    

                }
            });

        }
    }
}


