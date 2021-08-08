$(document).ready(function () {
    getEmployeecode();
    getselectemployee();
    getAllemppersonal();
     getMastervalues("Nationality", "frm_nationality");
    getMastervalues("Designation", "frm_designation");
    Createtablesalary();
    

});


function Deletepersonalvalue(emp_person) {

    $.ajax({
        type: "POST",
        url: "/Emppersonal/Deletingempperson",
        data: { Idempperson: emp_person },
        datatype: "json",
        success: function (data) {
            alert('Deleted successfully!!');
            getAllemppersonal();
        },
        error: function (reponse) {

            alert("Error");
        }
    });

}

function getEmployeecode() {

    var customertype = "Employee Code";
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

                $("#frm_empcode").val(data)
            }
        },
        error: function (reponse) {
            toastr.success("Database error happened while filling the drop down!!");
        }
    });

}

function clearall() {
    $("#frm_reportedto").val('select');
    $("#frm_firstname").val('');
    $("#frm_lastname").val('');
    $("#frm_empcode").val('');
    $("#frm_cardno").val('');
    $("#frm_mobileno").val('');
    $("#frm_empstatus").val('');
    $("#frm_dteofbirth").val('');
    $("#frm_nationality").val('');
    $("#frm_designation").val('');
    $("#frm_dtejoin").val('');
    $("#frm_qid").val('');
    $("#frm_qidexpdte").val('');
    $("#frm_hlthcardid").val('');
    $("#frm_hlthcrdexpdte").val('');
    $("#frm_psprtno").val('');
    $("#frm_pasprtexpdte").val('');
    $("#hiddenphoto").val('');

    var imgname = "/Webimages/Employee/blankimage.jpg";

    var empimage = "<img width='50px' height='50px' src='" + imgname + "'/>";
    $("#emp_image").html(empimage).show();
}

   
function Updatepersonalvalue(emp_id, firstname, lastname, code, cardno, mobno, status, birthdate, nation, design, join, qid, qidxp, hlthid, hlthidxp, ppno, ppxp, emp_photo, emp_reportedto, totalsalary, emp_grosssalary, emp_totaldeductions) {
    $("#btn_submit").val("Update");
    $("#employee_id").val(emp_id);
    $("#frm_firstname").val(firstname);
    $("#frm_lastname").val(lastname);
    $("#frm_empcode").val(code);
    $("#frm_cardno").val(cardno);
    $("#frm_mobileno").val(mobno);
    $("#frm_empstatus").val(status);
    $("#frm_dteofbirth").val(birthdate);
    $("#frm_nationality").val(nation);
    $("#frm_designation").val(design);
    $("#frm_dtejoin").val(join);
    $("#frm_qid").val(qid);
    $("#frm_qidexpdte").val(qidxp);
    $("#frm_hlthcardid").val(hlthid);
    $("#frm_hlthcrdexpdte").val(hlthidxp);
    $("#frm_psprtno").val(ppno);
    $("#frm_pasprtexpdte").val(ppxp);
    $("#hiddenphoto").val(emp_photo);

    $("#frm_reportedto").val(emp_reportedto);
    $("#Netsalary").val(totalsalary);
    $("#Grosssalary").val(emp_grosssalary);
    $("#Totaldeductions").val(emp_totaldeductions);
    
    var empimage = "<img width='100px' height='100px' src='" + emp_photo + "'/>";
    $("#emp_image").html(empimage).show();

    var totadd = $("#Tabcounter1").val();
    var totded = $("#Tabcounter2").val();

    var trid = "Addition";
    var url = "/Emppersonal/Getallsalarydetails";

    $.ajax({
        url: url,
        data: { empid: emp_id, Transtype: trid },
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            var fimages = "";
            if (data.length > 0) {

                for (var x = 1; x <= totadd; x++) {
                    //   alert($('#hiddenidvalad' + x).val());

                    for (var w = 0; w < data.length; w++) {
                        // alert(data[w].sal_type_id);
                        //alert(data[w].sal_amount);
                        if ($('#hiddenidvalad' + x).val() == data[w].emp_salaryheadid) {

                            $('#salaryaddamt' + x).val(data[w].emp_salaryamount);

                        }
                    }

                }

            }

            var trid = "Deletion";

            var url = "/Emppersonal/Getallsalarydetails";

            $.ajax({
                url: url,
                data: { empid: emp_id, Transtype: trid },
                cache: false,
                type: "POSt",
                datatype: "json",
                success: function (data) {
                    // alert(JSON.stringify(data));


                    var fimages = "";
                    if (data.length > 0) {

                        for (var x = 1; x <= totded; x++) {
                            //   alert($('#hiddenidvalad' + x).val());

                            for (var w = 0; w < data.length; w++) {
                                // alert(data[w].sal_type_id);
                                //alert(data[w].sal_amount);
                                if ($('#hiddenidvalded' + x).val() == data[w].emp_salaryheadid) {

                                    $('#salarydedamt' + x).val(data[w].emp_salaryamount);

                                }
                            }

                        }

                    }

                },
                error: function (reponse) {
                    return "NIL;NIL,";
                }
            });


        },
        error: function (reponse) {
            return "NIL;NIL,";
        }
    });
}

function getAllemppersonal() {
    var idvalue = 1;
    $.ajax({
        type: "POST",
        url: "/Emppersonal/SelectAllpersonalvalues",
        data: { personalval: idvalue },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
            $('#tbl1').DataTable().clear().destroy();

            if (data[0].employee_id != -1) {

                var table = new $('#tbl1').DataTable(
                    {
                        autoWidth: false,
                        data: data,
                        columns: [
                            {
                                'data': 'emp_code'
                            },
                            {
                                'data': 'emp_firstname'
                            },
                            {
                                'data': 'emp_lastname'
                            },
                            {
                                'data': 'emp_mobileno'
                            },
                            {
                                'data': 'emp_qid'
                            },
                            {
                                'data': 'emp_ppno'
                            },
                            {
                                'data': 'emp_status'
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Updatepersonalvalue(' + row.employee_id + ',\'' + row.emp_firstname + '\',\'' + row.emp_lastname + '\',\'' + row.emp_code + '\',\'' + row.emp_cardno + '\',\'' + row.emp_mobileno + '\',\'' + row.emp_status + '\',\'' + row.emp_dob + '\',\'' + row.emp_nationality + '\',\'' + row.emp_designation + '\',\'' + row.emp_dojoin + '\',\'' + row.emp_qid + '\',\'' + row.emp_qidexpiry + '\',\'' + row.emp_healthcardid + '\',\'' + row.emp_hcardexpiry + '\',\'' + row.emp_ppno + '\',\'' + row.emp_ppexpiry + '\',\'' + row.emp_photo + '\',\'' + row.emp_reportedto + '\',\'' + row.totalsalary + '\',\'' + row.emp_grosssalary + '\',\'' + row.emp_totaldeductions + '\')"  class="fa fa-edit" style="color:orange;cursor: pointer;"></i>' }
                            },
                            {
                                'sortable': false,
                                'render': function (data, type, row) { return '<i onclick="Deletepersonalvalue(' + row.employee_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
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

function Dateret() {

    var d = new Date();
    var year = d.getFullYear();
    var month = d.getMonth() + 1;
    if (month < 10) {
        month = "0" + month;
    };
    var day = d.getDate() - 2;

    if (day < 10) {
        day = "0" + day;
    };

    var dday = d.getDate();

    if (dday < 10) {
        dday = "0" + dday;
    };


    var dateinformat = day.toString() + "/" + month.toString() + "/" + year.toString();
    return dateinformat;
}

function addemployeedetails() {


    var btnval = $("#btn_submit").val();

    var formData = new FormData();

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);
    if (validatorResult.valid) {
      
        if (btnval == "Submit") {

            formData.append("emp_reportedto", $("#frm_reportedto").val());
            formData.append("firstname", $("#frm_firstname").val());
            formData.append("lastname", $("#frm_lastname").val());
            formData.append("empcode", $("#frm_empcode").val());
            formData.append("cardno", $("#frm_cardno").val());
            formData.append("mobno", $("#frm_mobileno").val());

            formData.append("birthdate", $("#frm_dteofbirth").val());
            formData.append("nation", $("#frm_nationality").val());
            formData.append("design", $("#frm_designation").val());
            formData.append("joindte", $("#frm_dtejoin").val());
            formData.append("qidno", $("#frm_qid").val());
            formData.append("qidxp", $("#frm_qidexpdte").val());
            formData.append("hlthid", $("#frm_hlthcardid").val());
            formData.append("hthidxp", $("#frm_hlthcrdexpdte").val());
            formData.append("psprtno", $("#frm_psprtno").val());
            formData.append("psprtxp", $("#frm_pasprtexpdte").val());
            formData.append("status", $("#frm_empstatus").val());
           
            formData.append("emp_totalsalary", $("#Netsalary").val());
            formData.append("emp_grosssalary", $("#Grosssalary").val());
            formData.append("emp_totaldeductions", $("#Totaldeductions").val());
           
            var addcnt = $("#Tabcounter1").val();
            var additionval = "";
            var addhead = "";
            var addcnt1 = 0;
            for (var i = 1; i <= addcnt; i++) {
                if ($('#salaryaddamt' + i).val() != "0") {
                    additionval += $('#salaryaddamt' + i).val() + ",";
                    addhead += $('#hiddenidvalad' + i).val() + ",";
                    addcnt1 += 1;
                }
            }
            formData.append("salaryheadsad", addhead);
            formData.append("salaryamountad", additionval);
            formData.append("addcount", addcnt1);
           
            var dedcnt = $("#Tabcounter2").val();
            var deductionval = "";
            var dedhead = "";
            var dedcnt1 = 0;
            for (var c = 1; c <= dedcnt; c++) {
                if ($('#salarydedamt' + c).val() != "0") {
                    deductionval += $('#salarydedamt' + c).val() + ",";
                    dedhead += $('#hiddenidvalded' + c).val() + ",";
                    dedcnt1 += 1;
                }
            }
         
            formData.append("salaryheadsded", dedhead);
            formData.append("salaryamountded", deductionval);
            formData.append("dedcount", dedcnt1);
           
            var dd = Dateret();
            formData.append("sal_from_date", dd);
            formData.append("sal_to_date", "");
            formData.append("entry_date", dd);
           
            formData.append("empphoto", frm_photograph.files[0]);


            $.ajax({
                type: "POST",
                url: "/Emppersonal/PersonaldetailsInsert",
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                async: false,
                success: function (data) {
                    toastr.success("Added new Employee Successfully!!");
                    getAllemppersonal();
                   clearall();

                }
            });
        }
        else {

            formData.append("employee_id", $("#employee_id").val());
            formData.append("emp_reportedto", $("#frm_reportedto").val());
            formData.append("firstname", $("#frm_firstname").val());
            formData.append("lastname", $("#frm_lastname").val());
            formData.append("empcode", $("#frm_empcode").val());
            formData.append("cardno", $("#frm_cardno").val());
            formData.append("mobno", $("#frm_mobileno").val());

            formData.append("birthdate", $("#frm_dteofbirth").val());
            formData.append("nation", $("#frm_nationality").val());
            formData.append("design", $("#frm_designation").val());
            formData.append("joindte", $("#frm_dtejoin").val());
            formData.append("qidno", $("#frm_qid").val());
            formData.append("qidxp", $("#frm_qidexpdte").val());
            formData.append("hlthid", $("#frm_hlthcardid").val());
            formData.append("hthidxp", $("#frm_hlthcrdexpdte").val());
            formData.append("psprtno", $("#frm_psprtno").val());
            formData.append("psprtxp", $("#frm_pasprtexpdte").val());
            formData.append("status", $("#frm_empstatus").val());

            formData.append("emp_totalsalary", $("#Netsalary").val());
            formData.append("emp_grosssalary", $("#Grosssalary").val());
            formData.append("emp_totaldeductions", $("#Totaldeductions").val());

            var addcnt = $("#Tabcounter1").val();
            var additionval = "";
            var addhead = "";
            var addcnt1 = 0;
            for (var i = 1; i <= addcnt; i++) {
                if ($('#salaryaddamt' + i).val() != "0") {
                    additionval += $('#salaryaddamt' + i).val() + ",";
                    addhead += $('#hiddenidvalad' + i).val() + ",";
                    addcnt1 += 1;
                }
            }
            formData.append("salaryheadsad", addhead);
            formData.append("salaryamountad", additionval);
            formData.append("addcount", addcnt1);

            var dedcnt = $("#Tabcounter2").val();
            var deductionval = "";
            var dedhead = "";
            var dedcnt1 = 0;
            for (var c = 1; c <= dedcnt; c++) {
                if ($('#salarydedamt' + c).val() != "0") {
                    deductionval += $('#salarydedamt' + c).val() + ",";
                    dedhead += $('#hiddenidvalded' + c).val() + ",";
                    dedcnt1 += 1;
                }
            }

            formData.append("salaryheadsded", dedhead);
            formData.append("salaryamountded", deductionval);
            formData.append("dedcount", dedcnt1);

            var dd = Dateret();
            formData.append("sal_from_date", dd);
            formData.append("sal_to_date", "");
            formData.append("entry_date", dd);

            formData.append("empphoto", frm_photograph.files[0]);
            formData.append("emp_photohide", $("#hiddenphoto").val());

            $.ajax({
                type: 'POST',
                url: "/Emppersonal/personaldetailsUpdate",
                cache: false,
                contentType: false,
                processData: false,
                data: formData,
                async: false,
                success: function (data) {
                    toastr.success("Updated Employee details Successfully!!");
                    getAllemppersonal();
                    $("#btn_submit").val("Submit");
                    clearall();
                }
            });

        }
    }
}

function amountchange(addval) {
    var cnt1 = $("#Tabcounter1").val();
    var gross = 0;
    for (var x = 1; x <= cnt1; x++) {

        gross += parseInt($('#salaryaddamt' + x).val());
    }

    $("#Grosssalary").val(gross);
    var totded = $("#Totaldeductions").val();
    var netsal = gross - parseInt(totded);
    $("#Netsalary").val(netsal);

}

function amountchange1(addval) {
    var cnt2 = $("#Tabcounter2").val();
    var totded = 0;
    for (var x = 1; x <= cnt2; x++) {

        totded += parseInt($('#salarydedamt' + x).val());
    }

    $("#Totaldeductions").val(totded);
    var gross = $("#Grosssalary").val();
    var netsal = gross - parseInt(totded);
    $("#Netsalary").val(netsal);

}

function Createtablesalary() {

     var subnode = "Addition";
   
    $.ajax({
        type: "POST",
        url: "/Emppersonal/Getsalarystructure",
        data: { Sub_node: subnode },
        datatype: "json",
        success: function (data) {
            // alert(JSON.stringify(data));
            if (data[0].Master_Id != -1) {

                var tablestruc = "";
                tablestruc += "<div class='table-responsive'>";
                tablestruc += "<table style='width:50%;text-align:center;float:left;' class='table table-striped jambo_table bulk_action'>";
                tablestruc += "<thead>";
                tablestruc += "<tr class='headings'>";
                tablestruc += "<th class='column-title' colspan='3' style='color:darkgreen;font-weight:bold;'>Salary Additions</th>";
                tablestruc += "</tr >";
                tablestruc += "<tr class='headings'>";
                tablestruc += "<th class='column-title'>Sr No.</th>";
                tablestruc += "<th class='column-title'>Salary Head</th>";
                tablestruc += "<th class='column-title'>Amount</th>";
                tablestruc += "</tr >";
                tablestruc += "</thead >";
                tablestruc += "<tbody id='Tbody_salaryaddition'></tbody>";
                tablestruc += " </table >";

                // var tablestruc1 = "";
                //tablestruc += "<div class='table-responsive'>";
                tablestruc += "<table style='width:40%;text-align:center;float:right;' class='table table-striped jambo_table bulk_action'>";
                tablestruc += "<thead>";
                tablestruc += "<tr class='headings'>";
                tablestruc += "<th class='column-title' colspan='3' style='color:red;font-weight:bold;'>Salary Deductions</th>";
                tablestruc += "</tr >";
                tablestruc += "<tr class='headings'>";
                tablestruc += "<th class='column-title'>Sr No.</th>";
                tablestruc += "<th class='column-title'>Salary Head</th>";
                tablestruc += "<th class='column-title'>Amount</th>";
                tablestruc += "</tr >";
                tablestruc += "</thead >";
                tablestruc += "<tbody id='Tbody_salarydeduction'></tbody>";
                tablestruc += " </table >";
                tablestruc += "  </div >";
                $("#empl_saldetails").html(tablestruc).show();


                tablestruc = "";
                var cnt1 = 0;

                for (var x = 0; x < data.length; x++) {
                    cnt1 += 1;
                    tablestruc += "<tr class='even pointer'>";
                    tablestruc += " <td class=' ' style='text-align:center;'> " + cnt1 + "</td >";
                    tablestruc += " <td class=' ' style='text-align:left;'> " + data[x].salstruct_head + "</td >";
                    tablestruc += " <td class=' ' style='text-align:right;'>";
                    tablestruc += "<input style='width:80px;text-align:right;' type='number' onchange='amountchange(this);'  id= 'salaryaddamt" + cnt1 + "' value='0' >";
                    tablestruc += "<input type='hidden' id= 'hiddenidvalad" + cnt1 + "' value='" + data[x].salstruct_id + "' >";
                    tablestruc += "</td>";
                    tablestruc += " </tr>";
                }

                $("#Tabcounter1").val(cnt1);

                tablestruc += "<tr class='even pointer'>";
                tablestruc += " <td class=' ' style='text-align:right;' colspan='2'>Gross Salary </td >";
                tablestruc += " <td class=' ' style='text-align:right;'>";
                tablestruc += "<input type='number' style='width:80px;text-align:right;' id= 'Grosssalary' value='0' >";
                tablestruc += "</td>";
                tablestruc += " </tr>";


                $("#Tbody_salaryaddition").html(tablestruc).show();
                var url = "/Emppersonal/Getsalarystructure";
                var subnode = "Deletion";
             

                $.ajax({
                    url: url,
                    data: { Sub_node: subnode },
                    cache: false,
                    type: "POSt",
                    datatype: "json",
                    success: function (data) {
                        //alert(JSON.stringify(data));
                        tablestruc = "";
                        var cnt2 = 0;

                        for (var x = 0; x < data.length; x++) {
                            cnt2 += 1;
                            tablestruc += "<tr class='even pointer'>";
                            tablestruc += " <td class=' ' style='text-align:center;'> " + cnt2 + "</td >";
                            tablestruc += " <td class=' ' style='text-align:left;'> " + data[x].salstruct_head + "</td >";
                            tablestruc += " <td class=' ' style='text-align:right;'>";
                            tablestruc += "<input type='number' style='width:80px;text-align:right;' onchange='amountchange1(this);'  id= 'salarydedamt" + cnt2 + "' value='0' >";
                            tablestruc += "<input type='hidden' id= 'hiddenidvalded" + cnt2 + "' value='" + data[x].salstruct_id + "' >";
                            tablestruc += "</td>";
                            tablestruc += " </tr>";
                        }
                        $("#Tabcounter2").val(cnt2);
                        tablestruc += "<tr class='even pointer'>";
                        tablestruc += " <td class=' ' style='text-align:right;' colspan='2'>Total Deductions </td >";
                        tablestruc += " <td class=' ' style='text-align:right;'>";
                        tablestruc += "<input type='number' style='width:80px;text-align:right;' id= 'Totaldeductions' value='0' >";
                        tablestruc += "</td>";
                        tablestruc += " </tr>";

                        tablestruc += "<tr class='even pointer'>";
                        tablestruc += " <td class=' ' style='text-align:right;' colspan='2'>Net Salary </td >";
                        tablestruc += " <td class=' ' style='text-align:right;'>";
                        tablestruc += "<input type='number' style='width:80px;text-align:right;' id= 'Netsalary' value='0' >";
                        tablestruc += "</td>";
                        tablestruc += " </tr>";



                        $("#Tbody_salarydeduction").html(tablestruc).show();
                    },
                    error: function (reponse) {
                        return "NIL;NIL,";
                    }
                });

            }
        },
        error: function () {

        }
    })

    tablestruc += "</table >";
    tablestruc += "</div >";
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
            if (data[0].employee_id != "-1") {
                var optionval = "<option value='select'>--Choose an Option--</option>";
                //optionval += "<option value='1'>Shaiju</option>";
                for (var x = 0; x < data.length; x++) {
                    optionval += "<option value=" + data[x].employee_id + ">" + data[x].emp_firstname + "</option>";
                }
                $("#frm_reportedto").html(optionval).show();
                //select.reload();
            }
            else {
                var optionval = "<option value='select'>--Choose an Option--</option>";
                optionval += "<option value='-1'>Shaiju</option>";
                $("#frm_reportedto").html(optionval).show();
            }
        },
        error: function (reponse) {

            alert("Error");
        }
    });

}

function getMastervalues(checkingfeild, dropdownname) {

    var url = "/Createmastervalues/Getspecificmastervalues";
  
    $.ajax({
        url: url,
        data: { checkfield: checkingfeild},
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
           // alert(JSON.stringify(data));
            if (data.length > 0) {

                if (data[0].master_id == "-1" ) {
                    var markup = "<option value=''>--Select--</option>";
                    // $("#frm_salesman").html(markup).show();
                    $('#' + dropdownname).html(markup).show();

                }
                else {
                    var markup = "<option value=''>--Choose an Option--</option>";
                    for (var x = 0; x < data.length; x++) {
                        
                        markup += "<option value=" + data[x].master_id + ">" + data[x].master_valuename + "</option>";
                    }
                    //$("#frm_salesman").html(markup).show();
                    $('#' + dropdownname).html(markup).show();
                    //select.reload();
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