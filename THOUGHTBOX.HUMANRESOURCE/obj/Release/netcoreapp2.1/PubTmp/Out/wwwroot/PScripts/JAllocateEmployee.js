$(document).ready(function () {
    getselectemployee();
    getAllrequestdetails($("#RequestID").val());
});


function allocaterequestupdate() {

    var btnval = $("#btn_submit").val();
    var empdata = new FormData();
    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);

    if (validatorResult.valid) {

        if (btnval == "Submit") {
           
            empdata.append("request_id", $("#RequestID").val());
            empdata.append("allemployeeids", $("#frm_slctemployee").val());
            empdata.append("allocated_comments", $("#frm_allocatcomnts").val());
            empdata.append("reqttitle", $("#request_title").val());
            empdata.append("request_code", $("#request_code").val());
            empdata.append("allocated_image", frm_imageallocate.files[0]);
          
            $.ajax({
                type: 'POST',
                url: "/AllocateEmployees/allocateempInsert",
                cache: false,
                contentType: false,
                processData: false,
                data: empdata,
                async: false,
                success: function (data) {
                    //window.location.href = '/DashboardDH/';
                    window.location.replace("/DashboardDH/");
                    toastr.success("Successfully submitted for allocation!!");
                }
            });
        }

    }
}


function getAllrequestdetails(requestid) {

    var idvalue = requestid;
    $.ajax({
        type: "POST",
        url: "/CreateRequest/SelectAllrequest",
        data: { requestval: idvalue },
        datatype: "json",
        success: function (data) {
           //alert(JSON.stringify(data));

            if (data[0].request_id != -1) {

                // $("#request_id").val(requestid);
                $("#FrmDisplay1").html(data[0].request_title).show();
                $("#FrmDisplay2").html(data[0].request_date).show();
                $("#FrmDisplay3").html(data[0].request_details).show();
                $("#FrmDisplay4").html(data[0].request_priority).show();
                $("#request_title").val(data[0].request_title);
                $("#request_code").val(data[0].request_code);

                $("#FrmDisplayA1").html(data[0].request_stdate).show();
                $("#FrmDisplayA2").html(data[0].request_eddate).show();
                $("#FrmDisplayA3").html(data[0].request_apcomments).show();

                $("#FrmDisplayV1").html(data[0].request_vericomments).show();

                var filetype1 = "";
                var empimage1 = "";
                if (data[0].request_image != "") {
                    filetype1 = data[0].request_image.trim().split(".");
                    if (filetype1[1] == "PDF" || filetype1[1] == "pdf") {
                        empimage1 = "<a href='" + data[0].request_image.trim() + "' target='_blank' class='thickbox'> <img  src='/WebImages/SystemImages/pdffile.png' class='img-circle img-fluid'></a>";
                    }
                    else if (filetype1[1] == "docx" || filetype1[1] == "DOCX") {
                        empimage1 = "<a href='" + data[0].request_image.trim() + "' target='_blank' class='thickbox'> <img  src='/WebImages/SystemImages/wordfile.jpg' class='img-circle img-fluid'></a>";
                    }
                    else if (filetype1[1] == "xls" || filetype1[1] == "XLS") {
                        empimage1 = "<a href='" + data[0].request_image.trim() + "' target='_blank' class='thickbox'> <img  src='/WebImages/SystemImages/excelimage.jpg' class='img-circle img-fluid'></a>";
                    }
                    else {
                        empimage1 = "<a href='" + data[0].request_image.trim() + "' target ='_blank' class='thickbox'> <img width='100px' height='100px' src='" + data[0].request_image.trim() + "' alt='' class='img-circle img-fluid'></a>";
                    }
                }
                else {

                    empimage1 = "<img width='100px' height='100px' src='/WebImages/SystemImages/noimage.png' alt='' class='img-circle img-fluid'>";
                }

                $("#FrmDisplay5").html(empimage1).show();


                var filetype2 = "";
                var empimage2 = "";
                if (data[0].request_appimage != "") {
                    filetype2 = data[0].request_appimage.trim().split(".");
                    if (filetype2[1] == "PDF" || filetype2[1] == "pdf") {
                        empimage2 = "<a href='" + data[0].request_appimage.trim() + "' target='_blank' class='thickbox'> <img  src='/WebImages/SystemImages/pdffile.png' class='img-circle img-fluid'></a>";
                    }
                    else if (filetype2[1] == "docx" || filetype2[1] == "DOCX") {
                        empimage2 = "<a href='" + data[0].request_appimage.trim() + "' target='_blank' class='thickbox'> <img  src='/WebImages/SystemImages/wordfile.jpg' class='img-circle img-fluid'></a>";
                    }
                    else if (filetype2[1] == "xls" || filetype2[1] == "XLS") {
                        empimage2 = "<a href='" + data[0].request_appimage.trim() + "' target='_blank' class='thickbox'> <img  src='/WebImages/SystemImages/excelimage.jpg' class='img-circle img-fluid'></a>";
                    }
                    else {
                        empimage2 = "<a href='" + data[0].request_appimage.trim() + "' target ='_blank' class='thickbox'> <img width='100px' height='100px' src='" + data[0].request_appimage.trim() + "' alt='' class='img-circle img-fluid'></a>";
                    }
                }
                else {

                    empimage2 = "<img width='100px' height='100px' src='/WebImages/SystemImages/noimage.png' alt='' class='img-circle img-fluid'>";
                }
                $("#FrmDisplayA4").html(empimage2).show();



                var filetype3 = "";
                var empimage3 = "";
                if (data[0].request_veriimage != "") {
                    filetype3 = data[0].request_veriimage.trim().split(".");
                    if (filetype3[1] == "PDF" || filetype3[1] == "pdf") {
                        empimage3 = "<a href='" + data[0].request_veriimage.trim() + "' target='_blank' class='thickbox'> <img  src='/WebImages/SystemImages/pdffile.png' class='img-circle img-fluid'></a>";
                    }
                    else if (filetype3[1] == "docx" || filetype3[1] == "DOCX") {
                        empimage3 = "<a href='" + data[0].request_veriimage.trim() + "' target='_blank' class='thickbox'> <img  src='/WebImages/SystemImages/wordfile.jpg' class='img-circle img-fluid'></a>";
                    }
                    else if (filetype3[1] == "xls" || filetype3[1] == "XLS") {
                        empimage3 = "<a href='" + data[0].request_veriimage.trim() + "' target='_blank' class='thickbox'> <img  src='/WebImages/SystemImages/excelimage.jpg' class='img-circle img-fluid'></a>";
                    }
                    else {
                        empimage3 = "<a href='" + data[0].request_veriimage.trim() + "' target ='_blank' class='thickbox'> <img width='100px' height='100px' src='" + data[0].request_veriimage.trim() + "' alt='' class='img-circle img-fluid'></a>";
                    }
                }
                else {

                    empimage3 = "<img width='100px' height='100px' src='/WebImages/SystemImages/noimage.png' alt='' class='img-circle img-fluid'>";
                }
                $("#FrmDisplayV2").html(empimage3).show();
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
        url: "/Emppersonal/getEmployeereportedto",
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