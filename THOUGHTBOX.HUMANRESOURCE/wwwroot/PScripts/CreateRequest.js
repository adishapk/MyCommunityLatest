$(document).ready(function () {
  
    //getAllrequest();
    getJobCardno();
    $("#frm_reqstdate").val(Dateret());
    
});


function clearall() {
    $("#frm_reqsttiltle").val("");
    $("#frm_reqstdate").val("");
    $("#frm_rqstdetails").val("");
    $("#frm_priortytype").val("");
    $("#frm_imagephotograph").val("");
    $("#frm_reqstcomments").val("");

    var imgname = "/Webimages/Employee/blankimage.jpg";
    var empimage = "<img width='50px' height='50px' src='" + imgname + "'/>";
    $("#spanimage").html(empimage).show();

}

function createrequestinsert() {

    var btnval = $("#btn_submit").val();
    var empdata = new FormData();

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);
    if (validatorResult.valid) {

        if (btnval == "Submit") {
            empdata.append("reqttitle", $("#frm_reqsttiltle").val());
            empdata.append("rqstdate", $("#frm_reqstdate").val());
            empdata.append("rqstdetails", $("#frm_rqstdetails").val());
            empdata.append("priortytype", $("#frm_priortytype").val());
            empdata.append("image", frm_imagephotograph.files[0]);
            empdata.append("request_code", $("#frm_reqstcode").val());
            empdata.append("user_comments", $("#frm_reqstcomments").val());

            // empdata.append("empphoto", frm_photograph.files[0]);


            $.ajax({
                type: 'POST',
                url: "/CreateRequest/requestInsert",
                cache: false,
                contentType: false,
                processData: false,
                data: empdata,
                async: false,
                success: function (data) {
                    toastr.success("Successfully submitted for approval!!");
                   clearall();

                }
            });
        }
       
    }
}

function Dateret() {
  
    var d = new Date();
    var year = d.getFullYear();
    var month = d.getMonth() + 1;
    if (month < 10) {
        month = "0" + month;
    };
    var day = d.getDate();

    if (day < 10) {
        day = "0" + day;
    };

    var dday = d.getDate();

    if (dday < 10) {
        dday = "0" + dday;
    };


    var dateinformat = year.toString() + "-" + month.toString() + "-" + day.toString();
    return dateinformat;
}

function getJobCardno() {

    var customertype = "Department Request";
    var url = "/CreateRequest/GetJobCard";

    $.ajax({
        url: url,
        data: { Cust_Type: customertype },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            if (data.length > 0) {

                $("#frm_reqstcode").val(data)
            }
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });

}