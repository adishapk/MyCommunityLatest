$(document).ready(function () {

    getAllrequestdetails($("#RequestID").val());

});

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
            }

        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    })
}

function verifyrequestupdate() {

    var btnval = $("#btn_submit").val();

    var empdata = new FormData();

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);
    if (validatorResult.valid) {

        if (btnval == "Submit") {

            empdata.append("rqstid", $("#RequestID").val());
            empdata.append("request_vericomments", $("#frm_verifycomnts").val());
            empdata.append("request_veriimage", frm_imageverify.files[0]);
            empdata.append("reqttitle", $("#request_title").val());
            empdata.append("request_code", $("#request_code").val());

            $.ajax({
                type: 'POST',
                url: "/CreateRequest/verifyupdate",
                cache: false,
                contentType: false,
                processData: false,
                data: empdata,
                async: false,
                success: function (data) {
                    
                    //alert("Request Approved Successfully!");
                   // window.location.href = '/DashboardBDM/';
                    window.location.replace("/DashboardBDM/");
                 
                }
            });
        }

    }
}