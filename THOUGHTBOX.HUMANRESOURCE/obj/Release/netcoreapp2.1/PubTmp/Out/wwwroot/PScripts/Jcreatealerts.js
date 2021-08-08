$(document).ready(function () {
    getselectemployee();
    getAllalerts();

});

function clearall(){
    $("#frm_slctemployee").val("");
    $("#frm_alertmsge").val("");
    $("#frm_Videolink").val("");
    $("#hiddenphoto").val("");

    var alertimage = "<img width='100px' height='100px' src='" + " " + "'/>";
    $("#alert_image").html(alertimage).show();

}

function Deletealertvalue(alert_notify) {

    $.ajax({
        type: "POST",
        url: "/Createalerts/Deletingalerts",
        data: { Idalert: alert_notify },
        datatype: "json",
        success: function (data) {
            toastr.success("Deleted successfully!!");
            getAllalerts();
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });

}


function Updatealertvalue(alert_id, employee_id, alert_message, imagealert, alert_videolink) {

        $("#btn_submit").val("Update");
        $("#alert_id").val(alert_id);

         $("#frm_slctemployee").val(employee_id);
         $("#frm_alertmsge").val(alert_message);
    $("#hiddenphoto").val(imagealert);

    $("#frm_Videolink").val(alert_videolink);

    var alertimage = "<img width='100px' height='100px' src='" + imagealert + "'/>";
  
    $("#alert_image").html(alertimage).show();

    }

function getAllalerts() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/Createalerts/SelectAllalerts",
        data: { checkval: idvalue },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            $('#tbl1').DataTable().clear().destroy();

            if (data[0].alert_id != -1) {

                var table = new $('#tbl1').DataTable(
                    {
                        autoWidth: false,
                        data: data,
                        columns: [
                            {
                                'data': 'alert_date'
                            },
                            {
                                'data': 'alert_message'
                            },

                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updatealertvalue(' + row.alert_id + ',\'' + row.employee_id + '\',\'' + row.alert_message + '\',\'' + row.alert_image + '\',\'' + row.alert_videolink + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deletealertvalue(' + row.alert_id + ')" class="fa fa-book" style="color:red;cursor: pointer;"></i>' }
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
                                titleAttr: 'Copy'
                            },
                            {
                                extend: 'excelHtml5',
                                text: '<i class="fa fa-file-excel-o"></i>',
                                titleAttr: 'Excel'
                            },
                            {
                                extend: 'csvHtml5',
                                text: '<i class="fa fa-file-text-o"></i>',
                                titleAttr: 'CSV'
                            },
                            {
                                extend: 'pdfHtml5',
                                text: '<i class="fa fa-file-pdf-o"></i>',
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
            toastr.success("Database error happened while filling the drop down!!");
        }
    });

}

function alertsinsert() {

  
    var btnval = $("#btn_submit").val();

    var alertdata = new FormData();

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);
    if (validatorResult.valid) {

        if (btnval == "Submit") {

            alertdata.append("employee", $("#frm_slctemployee").val());
            alertdata.append("alertmsge", $("#frm_alertmsge").val());
            alertdata.append("video", $("#frm_Videolink").val());
            alertdata.append("alertphoto", frm_photograph.files[0]);


            $.ajax({
                type: 'POST',
                url: "/Createalerts/alertsInsert",
                cache: false,
                contentType: false,
                processData: false,
                data: alertdata,
                async: false,
                success: function (data) {
                    toastr.success("Alerts created successfully!!");
                    getAllalerts();
                    clearall();

                }
            });
        }
        else {

            alertdata.append("alertid", $("#alert_id").val());
            alertdata.append("employee", $("#frm_slctemployee").val());
            alertdata.append("alertmsge", $("#frm_alertmsge").val());
            alertdata.append("video", $("#frm_Videolink").val());
            alertdata.append("alertphoto", $("#hiddenphoto").val());
            //empdata.append("existingphoto", $("#hiddenphoto").val());

            $.ajax({
                type: 'POST',
                url: "/Createalerts/alertsUpdate",
                cache: false,
                contentType: false,
                processData: false,
                data: alertdata,
                async: false,
                success: function (data) {
                    toastr.success("Alerts Updated successfully!!");
                    $("#btn_submit").val("Submit");
                    getAllalerts();
                    clearall();
                }
            });

        }
    }
}

