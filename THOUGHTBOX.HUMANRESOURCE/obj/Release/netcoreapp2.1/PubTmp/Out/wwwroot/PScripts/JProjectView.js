$(document).ready(function () {
    GetRequestView();
});


function GetRequestView() {


    var regid = 1;

    $.ajax({
        type: "POST",
        url: "/CreateRequest/GetRequestforempview",
        data: { Reg_id: regid },
        datatype: "json",
        success: function (data) {
            // alert(JSON.stringify(data));

            if (data[0].employ_id != -1) {

                var tablestruc = "";
                tablestruc += "<table class='table table-striped projects'>";
                tablestruc += "<thead>";
                tablestruc += "<tr>";
                tablestruc += "<th style='width: 1%'>";
                tablestruc += "#";
                tablestruc += "</th>";
                tablestruc += "<th style='width: 20%'>";
                tablestruc += "Request Name";
                tablestruc += "</th>";
                tablestruc += "<th style='width: 30%'>";
                tablestruc += "Team Members";
                tablestruc += "</th>";
                tablestruc += "<th>";
                tablestruc += "Request Progress";
                tablestruc += "</th>";
                tablestruc += "<th style='width: 8%' class='text-center'>";
                tablestruc += "Status";
                tablestruc += "</th>";
                tablestruc += "<th style='width: 20%'>";
                tablestruc += "</th>";
                tablestruc += "</tr>";
                tablestruc += "</thead>";
                tablestruc += "<tbody id='Tbody_garageservice'></tbody>";
                tablestruc += " </table >";
                $("#reqviewstruct").html(tablestruc).show(); 
                tablestruc = "";
                int counter = 0;

                for (var x = 0; x < data.length; x++) {
                    counter += 1;
                    tablestruc += "<tr>";
                    tablestruc += "<td>" + counter;
                    tablestruc += "</td>";
                    tablestruc += "<td>" + data[x].emp_qid ;
                    tablestruc += "<br /> <small>" + data[x].datecreated;
                    tablestruc += "</small>";
                    tablestruc += "</td>";
                    
                    tablestruc += "<td>";
                    tablestruc += "<ul class='list-inline'>";
                    tablestruc += "<li class='list-inline-item'>";
                    tablestruc += "<img alt='Avatar' class='table-avatar' src='../../dist/img/avatar.png'>";
                    tablestruc += "</li>";
                    tablestruc += "<li class='list-inline-item'>";
                    tablestruc += "<img alt='Avatar' class='table-avatar' src='../../dist/img/avatar2.png'>";
                    tablestruc += "</li>";
                    tablestruc += "<li class='list-inline-item'>";
                    tablestruc += "<img alt='Avatar' class='table-avatar' src='../../dist/img/avatar3.png'>";
                    tablestruc += "</li>";
                    tablestruc += "<li class='list-inline-item'>";
                    tablestruc += "<img alt='Avatar' class='table-avatar' src='../../dist/img/avatar04.png'>";
                    tablestruc += "</li>";
                    tablestruc += "</ul>";
                    tablestruc += "</td>";
                    tablestruc += "<td class='project_progress'>";
                    tablestruc += "<div class='progress progress-sm'>";
                    tablestruc += "<div class='progress-bar bg-green' role='progressbar' aria-volumenow='57' aria-volumemin='0' aria-volumemax='100' style='width: 57%'>";
                    tablestruc += "</div>";
                    tablestruc += "</div>";
                    tablestruc += "<small>";
                    tablestruc += "57% Complete";
                    tablestruc += "</small>";
                    tablestruc += "</td>";
                    tablestruc += " <td class='project-state'>";
                    tablestruc += "<span class='badge badge-success'>Success</span>";
                    tablestruc += "</td>";
                    tablestruc += "<td class='project-actions text-right'>";
                    tablestruc += "<a class='btn btn-primary btn-sm' href='#'>";
                    tablestruc += "<i class='fas fa-folder'>";
                    tablestruc += "</i>";
                    tablestruc += "View";
                    tablestruc += "</a>";
                    tablestruc += "<a class='btn btn-danger btn-sm' href='#'>";
                    tablestruc += "<i class='fas fa-trash'>";
                    tablestruc += "</i>";
                    tablestruc += "Delete";
                    tablestruc += "</a>";
                    tablestruc += "</td>";
                    tablestruc += "</tr>";
                    //alert(tablestruc);

                }

                tablestruc += "</div>";
                tablestruc += "</div>";

                $("#reqviewstruct").html(tablestruc).show();
            }

        },
        error: function () {

        }
    })
}
