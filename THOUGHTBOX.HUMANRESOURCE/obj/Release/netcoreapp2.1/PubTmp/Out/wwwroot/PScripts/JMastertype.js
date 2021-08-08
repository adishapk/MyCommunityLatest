
$(document).ready(function () {
    getAllmastertype();
});


function Deletemastertype(master_typevalue) {

    $.ajax({
        type: "POST",
        url: "/Mastertype/Deletingmastertype",
        data: { Idmastertype: master_typevalue },
        datatype: "json",
        success: function (data) {
            alert('Deleted successfully!!');
            getAllmastertype();


       
        },
        error: function (reponse) {

            alert("Error");
        }
    });

}




function getAllmastertype() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/Mastertype/SelectAllmastertype",
        data: { checkval: idvalue },
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
                                'data': 'master_typename'
                            },
                            {
                                'data': 'master_flag'
                            },

                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updatemastertype(' + row.master_id + ',\'' + row.master_typename + '\',\'' + row.master_flag + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deletemastertype(' + row.master_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
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

function Updatemastertype(master_id, mastername, masterflag) {

    $("#btn_submit").val("Update");
    $("#master_id").val(master_id);
    $("#frm_mastertype").val(mastername);
    $("#master_flag").val(masterflag);
}

function clearall (){
    $("#frm_mastertype").val("");
}

function addmastertype() {
   
    var btnval = $("#btn_submit").val();
  

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);   
    if (validatorResult.valid) {


        if (btnval == "Submit") {

            

            _Val = {
                master_typename: $("#frm_mastertype").val(),
                master_flag: "Y",
            };

            if (validatorResult.valid) {
                $.ajax({
                    url: "/Mastertype/mastertypeInsert",
                    data: { Mastername: _Val },
                    cache: false,
                    type: "POSt",
                    datatype: "json",
                    success: function (data) {
                        if (data == 1) {
                            alert("Successfully Inserted!");
                        }
                        else {
                            alert("Entered Master Type already existing!");
                        }
                        clearall();
                        getAllmastertype();
                    }
                });

            }
            else {

                _Val = {
                    master_id: $("#master_id").val(),
                    master_typename: $("#frm_mastertype").val(),
                    master_flag: "Y",
                };


                $.ajax({
                    type: 'POST',
                    data: { Masterupname: _Val },
                    url: "/Mastertype/Mastertypeupdate",
                    dataType: 'json',
                    success: function (data) {
                        alert("Successfully Updated!");

                        clearall();
                        getAllmastertype();
                        $("#btn_submit").val("Submit");

                    }
                });

            }
        }
    }
}