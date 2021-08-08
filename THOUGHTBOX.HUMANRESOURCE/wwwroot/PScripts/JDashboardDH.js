$(document).ready(function () {
    //Top box count for jobcard
    accordcount("tbl_mark_approval_trans", "NIL2", "NIL", "NIL", "NIL", "requ_appby", "requ_type_id", "NIL", "NIL", "2", "Department Request", "NIL", "NIL", "requestapproval1", "Yes");
    //Accordion bucket table filling for jobcard pending
    accordbucketfillinnerjoin("Request No", "Request Date", "Title", "requesttable1", "/AllocateEmployees/AllocateEmployees?requestid=", "NIL1", "request_id", "request_code", "request_date", "request_title", "requ_appby", "requ_type_id", "jobc_jobstat", "2", "Department Request", "Pending", "tbl_mark_requests", "tbl_mark_approval_trans", "request_id", "request_id");

});

function accordbucketfillinnerjoin(colhead1, colhead2, colhead3, acctabledivid, editurl, decisionvalue, fieldname1, fieldname2, fieldname3, fieldname4, conditionfield1, conditionfield2, conditionfield3, conditionval1, conditionval2, conditionval3, tablename1, tablename2, Connectfield1, Connectfield2) {

    var url = "/DashboardMD/fillallbucketinnerjoin";

    $.ajax({
        url: url,
        data: { Decivalue: decisionvalue, Fiename1: fieldname1, Fiename2: fieldname2, Fiename3: fieldname3, Fiename4: fieldname4, condfield1: conditionfield1, condfield2: conditionfield2, condfield3: conditionfield3, condval1: conditionval1, condval2: conditionval2, condval3: conditionval3, Tblname1: tablename1, Tblname2: tablename2, Confield1: Connectfield1, Confield2: Connectfield2 },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));

            var tablestruc = "";
            tablestruc += "<table class='table table-bordered'>";
            tablestruc += "<thead>";
            tablestruc += "<tr>";
            tablestruc += "<th>#</th>";

            if (colhead1 != "NIL") {
                tablestruc += "<th>" + colhead1 + "</th>";
            }

            if (colhead2 != "NIL") {
                tablestruc += "<th>" + colhead2 + "</th>";
            }

            if (colhead3 != "NIL") {
                tablestruc += "<th>" + colhead3 + "</th>";
            }
            tablestruc += "<th><i class='fas fa-binoculars' style='color:orange;'></i></th>";
            tablestruc += "</tr >";
            tablestruc += "</thead >";
            tablestruc += "<tbody id='" + tablename1 + "'></tbody>";
            tablestruc += " </table >";

            $('#' + acctabledivid).html(tablestruc).show();



            tablestruc = "";
            if (data[0].generalval1 != -1) {
                var inc = 0;
                for (var x = 0; x < data.length; x++) {
                    inc += 1;
                    tablestruc += "<tr>";
                    tablestruc += "<th scope='row'>" + inc;
                    if (colhead1 != "NIL") {
                        tablestruc += "<td>" + data[x].generalval2 + "</td>";
                    }
                    if (colhead2 != "NIL") {
                        tablestruc += "<td>" + data[x].gneralaval3 + "</td>";
                    }
                    if (colhead3 != "NIL") {
                        tablestruc += "<td>" + data[x].gneralaval4 + "</td>";
                    }

                    tablestruc += "<td><a href='" + editurl + data[x].generalval1 + "'><i class='fas fa-binoculars' style='color:orange;cursor:pointer;'></i></a></td>";
                    tablestruc += "</tr>";
                }

                $('#' + tablename1).html(tablestruc).show();
            }
        },
        error: function (reponse) {
            new PNotify({
                title: 'Warning!',
                text: 'Database error happened while filling the drop down!!',
                type: 'error',
                hide: false,
                styling: 'bootstrap3'
            });
        }
    });

}

function accordcount(tablename, decisionvalue, Fieldtoretrieve1, Fieldtoretrieve2, Fieldtoretrieve3, Fieldname1, Fieldname2, Fieldname3, Fieldname4, conditionfield1, conditionfield2, conditionfield3, conditionfield4, formval, linkneeded) {


    var url = "/DashboardMD/selectAllAccordioncount";

    $.ajax({
        url: url,
        data: { tablenam: tablename, decisionvalu: decisionvalue, Fieldtoretriev1: Fieldtoretrieve1, Fieldtoretriev2: Fieldtoretrieve2, Fieldtoretriev3: Fieldtoretrieve3, Fieldnam1: Fieldname1, Fieldnam2: Fieldname2, Fieldnam3: Fieldname3, Fieldnam4: Fieldname4, conditionfied1: conditionfield1, conditionfied2: conditionfield2, conditionfied3: conditionfield3, conditionfied4: conditionfield4 },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {

            if (data.length > 0) {

                var markup = "0";
                if (data[0].master_id == "-1") {

                    $('#' + formval).html(markup).show();

                }
                else {

                    if (linkneeded == "Yes") {
                        markup = "<a href='/GeneralListingRequests/GeneralListingRequests?Reqappby=" + conditionfield1 + "&Reqtype=" + conditionfield2 + "' >" + data[0].master_typename + "</a>";
                    }
                    else {
                        markup = data[0].master_typename;
                    }

                    $('#' + formval).html(markup).show();
                }
            }
        },
        error: function (reponse) {
            new PNotify({
                title: 'Warning!',
                text: 'Database error happened while filling the drop down!!',
                type: 'error',
                hide: false,
                styling: 'bootstrap3'
            });
        }
    });

}
