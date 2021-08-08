$(document).ready(function () {
    GetEmployeeView();
});


function GetEmployeeView() {

   
    var regid = 1;

    $.ajax({
        type: "POST",
        url: "/Emppersonal/GetEmployeeforempview",
        data: { Reg_id: regid },
        datatype: "json",
        success: function (data) {
           // alert(JSON.stringify(data));

            if (data[0].employ_id != -1) {

                var tablestruc = "";
                tablestruc += "<div class='card-body pb-0'>";
                tablestruc += "<div class='row d-flex align-items-stretch'>";

                for (var x = 0; x < data.length; x++) {

                    tablestruc += "<div class='col-12 col-sm-6 col-md-4 d-flex align-items-stretch'>";
                    tablestruc += "<div class='card bg-light'>";
                    tablestruc += "<div class='card-header text-muted border-bottom-0'>" + data[x].emp_designationstring + "&nbsp;&nbsp;<b>(" + data[x].emp_code + ")</b>";
                    tablestruc += "</div>";
                    tablestruc += "<div class='card-body pt-0'>";
                    tablestruc += "<div class='row'>";
                    tablestruc += "<div class='col-7'>";
                    tablestruc += "<h2 class='lead'><b>" + data[x].emp_firstname + " " + data[x].emp_lastname;
                    tablestruc += "</b></h2>";
                    tablestruc += "<p class='text-muted text-sm'><b>Reporting To: </b>" + data[x].emp_reportedtostring + " </p>";
                    tablestruc += " <ul class='ml-4 mb-0 fa-ul text-muted'>";
                    tablestruc += "<li class='small'><span class='fa-li'><i class='fas fa-id-card'></i></span> Qatar ID: " + data[x].emp_qid + "</li>";
                    tablestruc += "<li class='small'><span class='fa-li'><i class='fas fa-lg fa-phone'></i></span> Phone #: " + data[x].emp_mobileno + "</li>";
                    tablestruc += "<li class='small'><span class='fa-li'><i class='far fa-money-bill-alt'></i></span> Net Salary #: " + data[x].totalsalary + "</li>";
                    tablestruc += "<li class='small'><span class='fa-li'><i class='fas fa-table'></i></span> Date of Birth #: " + data[x].emp_dob + "</li>";
                    tablestruc += "</ul>";
                    tablestruc += "</div>";
                    tablestruc += "<div class='col-5 text-center'>";
                    tablestruc += "<img src='" + data[x].emp_photo + "' alt='' class='img-circle img-fluid'>";
                    tablestruc += "</div>";
                    tablestruc += "</div>";
                    tablestruc += "</div>";
                    tablestruc += "<div class='card-footer'>";
                    tablestruc += "<div class='text-right'>";
                    tablestruc += "<a href='#' class='btn btn-sm bg-teal'>";
                    tablestruc += "<i class='fas fa-comments'></i>";
                    tablestruc += "</a>";
                    tablestruc += "<a href='#' class='btn btn-sm btn-primary'>";
                    tablestruc += "<i class='fas fa-user'></i> View Profile";
                    tablestruc += "</a>";
                    tablestruc += "</div>";
                    tablestruc += "</div>";
                    tablestruc += "</div>";
                    tablestruc += "</div>";
                  

                    //alert(tablestruc);

                }

                tablestruc += "</div>";
                tablestruc += "</div>";

                $("#empviewstruct").html(tablestruc).show();
            }

        },
        error: function () {

        }
    })
}
