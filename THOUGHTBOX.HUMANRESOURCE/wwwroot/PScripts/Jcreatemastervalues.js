$(document).ready(function () {
    getallmastertype();
    getAllmastervalues();

});

function Deletemastervalue(master_typevalue) {

    $.ajax({
        type: "POST",
        url: "/Createmastervalues/Deletingmastervalues",
        data: { Idmastervalues: master_typevalue },
        datatype: "json",
        success: function (data) {
            alert('Deleted successfully!!');


            getAllmastervalues();



        },
        error: function (reponse) {

            alert("Error");
        }
    });

}

function Updatemastervalue(master_id, master_typename, master_valuename, master_valueflag, master_valueremarks) {

    $("#btn_submit").val("Update");
    $("#master_id").val(master_id);
    
    $("#frm_selctmastertype").val(master_typename);
    $("#frm_mastervalue").val(master_valuename);
    $("#frm_permanent").val(master_valueflag);
    $("#frm_masterremarks").val(master_valueremarks);
    
}

function getAllmastervalues() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/Createmastervalues/SelectAllmastervalues",
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
                                'data': 'master_valuename'
                            },
                            {
                                'data': 'master_typename_string'
                            },

                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updatemastervalue(' + row.master_id + ',\'' + row.master_typename + '\',\'' + row.master_valuename + '\',\'' + row.master_valueflag + '\',\'' + row.master_valueremarks + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deletemastervalue(' + row.master_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
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
    $("#frm_mastervalue").val("");
    $("#frm_selctmastertype").val("");
    $("#frm_masterremarks").val("");
    $("#frm_permanent").val("");
                    
}

function addmastervalues() {

    var btnval = $("#btn_submit").val();

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);

    if (validatorResult.valid) {

        if (btnval == "Submit") {

            _Val = {
                master_valuename: $("#frm_mastervalue").val(),
                master_typename: $("#frm_selctmastertype").val(),
                master_valueremarks: $("#frm_masterremarks").val(),
                master_valueflag: $("#frm_permanent").val(),
                master_flag: "N",
            };

            $.ajax({
                url: "/Createmastervalues/mastervaluesInsert",
                data: { mastervalues: _Val },
                cache: false,
                type: "POSt",
                datatype: "json",
                success: function (data) {

                    if (data == 1) {
                        alert("Successfully Inserted!");
                    }
                    else {
                        alert("Entered Master Value already existing!");
                    }

                    clearall();
                    getallmastertype();
                    getAllmastervalues();
                }
            });
        }

        else {

            _Val = {
                master_id: $("#master_id").val(),
                master_valuename: $("#frm_mastervalue").val(),
                master_typename: $("#frm_selctmastertype").val(),
                master_valueremarks: $("#frm_masterremarks").val(),
                master_valueflag: $("#frm_permanent").val(),
                master_flag: "N",
            };


            $.ajax({
                type: 'POST',
                data: { Mastervalueup: _Val },
                url: "/Createmastervalues/Mastervaluesupdate",
                dataType: 'json',
                success: function (data) {
                    alert("Successfully Updated!");

                    clearall();
                    getAllmastervalues();
                    getallmastertype();
                    $("#btn_submit").val("Submit");
                }
            });

        }
    }
}

function getallmastertype() {
    var idvalue = 1;
    $.ajax({
        url: "/Createmastervalues/mastertypeget",
        data: { mastervalget: idvalue },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));

            var optionval = "<option value='select'>--Choose an Option--</option>";
            for (var x = 0; x < data.length; x++) {
                optionval += "<option value=" + data[x].master_id + ">" + data[x].master_typename + "</option>";
            }
            $("#frm_selctmastertype").html(optionval).show();
            //select.reload();


        },
        error: function (reponse) {

            alert("Error");
        }
    });

}