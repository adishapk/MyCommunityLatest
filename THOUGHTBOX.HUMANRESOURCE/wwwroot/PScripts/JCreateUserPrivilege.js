$(document).ready(function () { 
    GetUsers();
    GetUserType(); 
    GetAll();
    GetRoles(0);
});

var chkArray = [];
function checkDuplication(val) {
    if (val != "") {
        var table = "public.tbl_mark_usertype_privi";
        var colm = "user_type_id";
        var condition = "user_type_id::varchar = :user_type_id and previlege_type='User'";
        var status = "#dupStatus";
        if (($("#btn-submit").val() == "Update") && ($("#dupUpdt").val() == val)) {
            $(status).val("Y");
            $("#dupUserNm").text("");
        }
        else {
            $.ajax({
                type: "POST",
                url: "/CreateUserTypePrivilege/checkDuplication/",
                data: { col: colm, tbl: table, cond: condition, para: val },
                datatype: "json",
                success: function (data) {
                    if (data == 0) {
                        $("#dupUserNm").text("Already assigned privileges for this user type.");
                        $(status).val("N");
                    }
                    else {
                        $("#dupUserNm").text("");
                        $(status).val("Y");
                    }

                },
                error: function () {

                }
            })
        }
    }
    else {
        $("#dupStatus").val("Y");
        $("#dupUserNm").text("");
    }
}

function hasDupes(arr) {
    /* temporary object */
    var uniqOb = {};
    /* create object attribute with name=value in array, this will not keep dupes*/
    for (var i in arr)
        uniqOb[arr[i]] = "";
    /* if object's attributes match array, then no dupes! */
    if (arr.length == Object.keys(uniqOb).length)
        //alert('NO dupes');
        return 0;
    else {
        //alert('HAS dupes');
        $("#prioStatus").val(1);
        return 1
    }

}

function GetAll() {

    $.ajax({
        type: "POST",
        url: "/CreateUserTypePrivilege/SelectPrvileges",
        data: { previlege_type: "User"},
        datatype: "json",
        success: function (data) {
           
            var collapsedGroups = {};
            $('#tbl').DataTable().clear().destroy();
            var table = new $('#tbl').DataTable(
                {
                    autoWidth: false,
                    data: data,
                    columns: [
                        {
                            'data': 'id', defaultContent: ''
                        },

                        {
                            "visible": false,
                            'data': 'userTypeName'

                        },
                        {
                            'data': 'masterName'

                        },
                        {
                            'data': 'priority'

                        },


                    ],
                    order: [[1, 'asc']],
                    rowGroup: {
                        dataSrc: 'userTypeName',
                        startRender: function (rows, group) {
                            var collapsed = !!collapsedGroups[group];
                            rows.nodes().each(function (r) {

                                r.style.display = collapsed ? 'none' : '';
                            });
                            var uData = rows
                                .data();
                            return $('<tr/>')
                                .append('<td colspan="' + rows.columns()[0].length + '">' + group + ' (' + rows.count() + ')<i onclick="Update(' + uData[0].userTypeId + ',' + uData[0].userId + ')"  class="fas fa-pencil-alt" style="padding-left:15px;float:right;color:orange;cursor: pointer;"></i><i onclick="Deletedata(' + uData[0].userTypeId + ' )" class="fas fa-trash" style="float:right;color:red;cursor: pointer;"></i></td>')
                                .attr('data-name', group)
                                .toggleClass('collapsed', collapsed);
                        },

                    },

                    "columnDefs": [
                        {
                            "searchable": false,
                            "orderable": false,
                            "targets": 0
                        }],

                    lengthMenu: [
                        [10, 25, 50, -1],
                        ['10 rows', '25 rows', '50 rows', 'Show all']
                    ],
                   

                });

            table.on('click', 'tr.group-start', function () {
                var name = $(this).data('name');
                collapsedGroups[name] = !collapsedGroups[name];
                table.draw(false);
            });

            table.on('order.dt search.dt', function () {
                table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
                    cell.innerHTML = i + 1;
                    table.cell(cell).invalidate('dom');
                });
            }).draw();


        },
        error: function () {

        }
    })
}

function GetUsers() {

    $.ajax({
        url: "/CreateUserPrivilege/GetUsers",
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
          
            var markup = '';
            if (data != null) {

                markup = "<option value=''>--select--</option>";

                if (data != null) {
                    for (var x = 0; x < data.length; x++) {
                        markup += "<option value=" + data[x].userId + ">" + data[x].userName + "</option>";

                    }
                }
                $("#user").html(markup).show();
            }
            else {
                markup = "<option value=''>--select--</option>";
                $("#user").html(markup).show();
            }

        },
        error: function (reponse) {
            markup = "<option value=''>--select--</option>";
            $("#user").html(markup).show();
        }
    });
}

function GetUserType() {

    $.ajax({
        url: "/CreateUserTypePrivilege/GetUserType",
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {
            var markup = '';
            if (data != null) {

                markup = "<option value=''>--select--</option>";

                if (data != null) {
                    for (var x = 0; x < data.length; x++) {
                        markup += "<option value=" + data[x].userTypeId + ">" + data[x].userTypeName + "</option>";

                    }
                }
                $("#userType").html(markup).show();
            }
            else {
                markup = "<option value=''>--select--</option>";
                $("#userType").html(markup).show();
            }

        },
        error: function (reponse) {
            markup = "<option value=''>--select--</option>";
            $("#userType").html(markup).show();
        }
    });
}


function FillPriority() {
    var markup = "<option value=''>-select-</option>";
    for (var x = 1; x < 50; x++) {
        markup += "<option value=" + x + ">" + x + "</option>";
    }
    $(".priority").html(markup).show();
}

function changechk(obj, ulId, x) {
  //  chkArray = [];
    SelectedService();
    //$(".icheckbox_flat-green:checked").each(function () {
    //    var selected = $(this).val();
    //    selected = selected.split(',');
    //    chkArray.push({ "regId": selected[0], "masterId": selected[1], "masterParentId": selected[2], "masterSubParentId": selected[3], "masterPriority": selected[4], "masterSubPriority": selected[5], "masterSubSubPriority": selected[6], "fileName": selected[7] })

    //});
    var substring = "mainchk";
    if (document.getElementById(obj.id).checked) {      
        $('#pr' + x + '').attr('required', true);
    }
    else {  
        $('#pr' + x + '').attr('required', false);
    }
    if ((obj.id).indexOf(substring) !== -1) {
        var lis = document.getElementById('role' + ulId + '').getElementsByClassName('icheckbox_flat-green');
        var sel = document.getElementById('role' + ulId + '').getElementsByClassName('priority');
        for (var chk = 0; chk < lis.length; chk++) {
            if (document.getElementById(obj.id).checked) {
                var selected = $(this).val();
                selected = selected.split(',');
                chkArray.push({ "regId": selected[0], "masterId": selected[1], "masterParentId": selected[2], "masterSubParentId": selected[3], "masterPriority": selected[4], "masterSubPriority": selected[5], "masterSubSubPriority": selected[6], "fileName": selected[7] })
                document.getElementById(lis[chk].id).checked = true;
                document.getElementById(lis[chk].id).disabled = false;
                document.getElementById(sel[chk].id).required = true;
            }
            else {
                document.getElementById(lis[chk].id).checked = false;
                document.getElementById(lis[chk].id).disabled = true;
                document.getElementById(sel[chk].id).required = false;
            }
        }
    }

}

function GetRoles(_val) {
 
    $("#accordion").empty();
    $.ajax({
        url: "/CreateUserTypePrivilege/GetPrivilegeRoles",
        cache: false,
        type: "POSt",
        datatype: "json",
        success: function (data) {           
          //  alert(JSON.stringify(data));
            var markup = '';          
            var markup1 = '';
            var markup2 = '';
            
            if (data[0].masterId != -1) {
                $("#regId").val(data[0].regId);
                for (var x = 0; x < data.length; x++) {
                    
                    if (data[x].masterParentId == 0 && data[x].masterSubParentId == 0) {
                        markup = '<div class="panel">'
                            + '<span class="field item form-group row panel-heading" role="tab" id="heading' + data[x].masterId + '" data-toggle="collapse" data-parent="#accordion" href="#collapse' + data[x].masterId + '" aria-expanded="true" aria-controls="collapse' + data[x].masterId + '">'
                            + '<h5 class="panel-title">'
                            + '<i class="fa fa-plus-circle" style="color:green;padding-right:10px;font-size:22px;"></i><input type="checkbox" id="mainchk' + x + '" class="icheckbox_flat-green" value="' + data[0].regId + ',' + data[x].masterId + ',0,0,' + 'pr' + x + '' + ',0,0,' + data[x].fileName + ',' + data[x].masterName +'";  onclick=changechk(this,' + data[x].masterId + ',' + x + ')>&nbsp;&nbsp;'
                            + data[x].masterName + '<select class="form-group priority mainPrio" id="pr' + x + '" style="float:right"> </select></h5></span>'
                            + '<div id="collapse' + data[x].masterId + '" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="heading' + data[x].masterId + '"> '
                            + '<div class="panel-body">'
                            + '<ul class="to_do" id="role' + data[x].masterId + '"></ul></div></div></div>'
                        $("#accordion").append(markup);                      
                        
                    }
                    else if (data[x].masterParentId != 0 && data[x].masterSubParentId == 0) {
                        markup1 = '<li id="li' + data[x].masterId + '"><p><div class="row">'
                            + '<div class="field item form-group row col-md-12 col-sm-12">'
                            + '<div class="col-md-10 col-sm-10">'
                            + '<input type="checkbox" id="subchk' + x + '" class="icheckbox_flat-green" value="' + data[0].regId + ',' + data[x].masterId + ',' + data[x].masterParentId + ',0,0,' + 'pr' + x + '' + ',0,' + data[x].fileName + ',' + data[x].masterName +'";  onclick=changechk(this,' + data[x].masterId + ',' + x + ')>&nbsp;&nbsp;' + data[x].masterName + '</div>'
                            + ' <div class="col-md-2 col-sm-2">'
                            + ' <h5><select class="priority subPrio" id="pr' + x + '" style="float:right"> </select></h5>'
                            + ' </div></div></div></p></li><ul id="uli' + data[x].masterId +'"></ul>'
                        $("#role" + data[x].masterParentId + "").append(markup1);                       
                    }
                    else if (data[x].masterParentId != 0 && data[x].masterSubParentId != 0) {
                        markup2 = '<li id="subli' + data[x].masterId + '"><p><div class="row">'
                            + '<div class="col-md-12 col-sm-12">'
                            + '<div class="col-md-10 col-sm-10">'
                            + '<input type="checkbox" id="subsubchk' + x + '" class="icheckbox_flat-green"  value="' + data[0].regId + ',' + data[x].masterId + ',' + data[x].masterParentId + ',' + data[x].masterSubParentId + ',0,0,' + 'pr' + x + '' + ',' + data[x].fileName + ',' + data[x].masterName +'";  onclick=changechk(this,' + data[x].masterId + ',' + x + ')>&nbsp;&nbsp;' + data[x].masterName + '</div>'
                            + ' <div class="col-md-2 col-sm-2">'
                            + ' <h5><span class="field item form-group"><select class="priority subSubPrio" id="pr' + x + '" style="float:right"> </select></span></h5>'
                            + ' </div></div></div></p></li>'
                        $("#uli" + data[x].masterSubParentId + "").append(markup2);                       
                    }

                }
               
                FillPriority();
            }
            else {
               
            }

        },
        error: function (reponse) {
           
        }
    });

    if (_val != 0) {
        SetRoles(_val, 1);
    }
   
}

function SetRoles(_val, flag) {
    
    var previlege_type = "UserType";
    if (flag == 0) {
        previlege_type = "User";
    }
    else {
        previlege_type = "UserType";
    }
    $.ajax({
        type: "POST",
        url: "CreateUserPrivilege/GetSelectedUserTypePrvileges",
        data: { userTypeId: _val, previlege_type: previlege_type },
        datatype: "json",
        success: function (data) {
            if (data != "") {
              
                for (var x = 0; x < data.length; x++) {

                    if (data[x].masterParentId == 0 && data[x].masterSubParentId == 0) {
                        var lis = document.getElementById('heading' + data[x].masterId + '').getElementsByClassName('icheckbox_flat-green');
                        var sel = document.getElementById('heading' + data[x].masterId + '').getElementsByClassName('mainPrio');
                        //document.getElementById(lis[0].id).value = "Y";
                        document.getElementById(lis[0].id).checked = true;
                        document.getElementById(lis[0].id).disabled = false;
                        document.getElementById(sel[0].id).required = true;
                        document.getElementById(sel[0].id).value = data[x].masterPriority;
                    }
                    else if (data[x].masterParentId != 0 && data[x].masterSubParentId == 0) {
                        var lis = document.getElementById('li' + data[x].masterId + '').getElementsByClassName('icheckbox_flat-green');
                        var sel = document.getElementById('li' + data[x].masterId + '').getElementsByClassName('subPrio');
                      //  document.getElementById(lis[0].id).value = "Y";
                        document.getElementById(lis[0].id).checked = true;
                        document.getElementById(lis[0].id).disabled = false;
                        document.getElementById(sel[0].id).required = true;
                        document.getElementById(sel[0].id).value = data[x].masterPriority;
                    }
                    else if (data[x].masterParentId != 0 && data[x].masterSubParentId != 0) {
                        var lis = document.getElementById('subli' + data[x].masterId + '').getElementsByClassName('icheckbox_flat-green');
                        var sel = document.getElementById('subli' + data[x].masterId + '').getElementsByClassName('subPrio');
                       // document.getElementById(lis[0].id).value = "Y";
                        document.getElementById(lis[0].id).checked = true;
                        document.getElementById(lis[0].id).disabled = false;
                        document.getElementById(sel[0].id).required = true;
                        document.getElementById(sel[0].id).value = data[x].masterPriority;
                    }

                }
                SelectedService();
            }
            else {

            }

        },
        error: function () {

        }
    })
}

function InsertRole() {

    var Array = [];
    var cnt = 0;
    $("#prioStatus").val(0);
    var regId = $("#regId").val();  
    var userTypeId = $("#userType").val();
    var userId = $("#user").val();
    var msg = "";
    var lis = document.getElementsByClassName('mainPrio');
    var valArray1 = [];
    // var valArray2 = [];
    var valArray3 = [];
    for (var sel = 0; sel < lis.length; sel++) {
        if (lis[sel].value != "") {
            valArray1.push(lis[sel].value);
        }
    }
    var dup1 = hasDupes(valArray1);
    if (dup1 == 1) {
        msg = "More than one Main roles have same priority!!"
    }

    var lis1 = '';
    lis = document.getElementsByClassName('to_do');
    for (var sel = 0; sel < lis.length; sel++) {
        var valArray2 = [];
        lis1 = document.getElementById(lis[sel].id).getElementsByClassName('subPrio');

        for (var sel1 = 0; sel1 < lis1.length; sel1++) {
            if (lis1[sel1].value != "") {
                valArray2.push(lis1[sel1].value);
            }
        }
        var dup2 = hasDupes(valArray2);
        if (dup2 == 1) {
            msg = "More than one Sub roles have same priority!!"
        }
    }

    lis = document.getElementsByClassName('subSubPrio');
    for (var sel = 0; sel < lis.length; sel++) {
        if (lis[sel].value != "") {
            valArray3.push(lis[sel].value);
        }
    }
    var dup3 = hasDupes(valArray3);
    if (dup3 == 1) {
        msg = "More than one SubSub roles have same priority!!"
    }


    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);

    if (validatorResult.valid) {
        if ($("#dupStatus").val() == "Y") {
            $("#dupUserNm").text("");
            if ($("#prioStatus").val() == 0) {
                {

                    if (chkArray.length > 0) {
                        var masterpr, subpr, subsubpr;
                        for (var d in chkArray) {
                            if (chkArray[d].masterPriority == 0) {
                                masterpr = 0;
                            }
                            else {
                                masterpr = chkArray[d].masterPriority;
                            }
                            if (chkArray[d].masterSubPriority == 0) {
                                subpr = 0;
                            }
                            else {
                                subpr = chkArray[d].masterSubPriority;
                            }
                            if (chkArray[d].masterSubSubPriority == 0) {
                                subsubpr = 0;
                            }
                            else {
                                subsubpr = chkArray[d].masterSubSubPriority;
                            }
                            Array.push({ "regId": regId, "userTypeId": userId, "masterId": chkArray[d].masterId, "masterParentId": chkArray[d].masterParentId, "masterSubParentId": chkArray[d].masterSubParentId, "masterPriority": $("#" + masterpr + " option:selected").val(), "masterSubPriority": $("#" + subpr + " option:selected").val(), "masterSubSubPriority": $("#" + subsubpr + " option:selected").val(), "fileName": chkArray[d].fileName, "userId": userTypeId, "masterName": chkArray[d].masterName })

                        }
                    }

                    cnt = Array.length;
                    var statusmsg = ''
                    var btn = $("#btn-submit").val();
                    var url1 = "";
                    if (btn == "Submit") {
                        url1 = "/CreateUserTypePrivilege/InsertPrivilege";
                        statusmsg = 'User Privilege Successfully Added!!'
                    }
                    else {
                        url1 = "/CreateUserTypePrivilege/UpdateUserTypePrivilege";
                        statusmsg = 'User Privilege Successfully Updated!!'
                    }
                    if (Array.length > 0) {
                        $.ajax({
                            type: 'POST',
                            data: { userTypes: Array, count: cnt, previlege_type: "User" },
                            url: url1,
                            dataType: 'json',
                            success: function (data) {
                                if (data == false) {
                                    toastr.error('Unhandled error. Please try again!!');                               
                                }
                                else {
                                    GetAll();
                                    resetForm();
                                    toastr.success(statusmsg);
                                    getAdminType();
                                  
                                    $("#btn-submit").val("Submit");
                                }
                            },
                            error: function (reponse) {
                                toastr.error('Unhandled error. Please try again!!');         
                            }
                        });
                    }
                    else {
                        toastr.error('Please select atleast one role!!');        
                       
                    }

                }
            }
            else {
                toastr.error(msg); 
            }
        }
        else {
            $("#dupUserNm").text("Already assigned privileges for this user.");
        }
    }

}

function Deletedata(id) {

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: false
    })
    swalWithBootstrapButtons.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes, delete it!',
        cancelButtonText: 'No, cancel!',
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                url: "/CreateUserTypePrivilege/Delete",
                data: { Id: id, previlege_type: "User" },
                datatype: "json",
                success: function (data) {
                    GetAll();
                },
                error: function () {
                    new PNotify({
                        title: 'Oh No!',
                        text: 'Something terrible happened.',
                        type: 'error',
                        delay: 1800,
                        styling: 'bootstrap3'
                    });
                }
            })
            swalWithBootstrapButtons.fire(

                'Deleted!',
                'Your file has been deleted.',
                'success'
            )

        } else if (
            /* Read more about handling dismissals below */
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'Cancelled',
                'Your imaginary file is safe :)',
                'error'
            )
        }
    })

}

function Update(_val, userTypeId) {
   // alert(_val);
    resetForm();
    $("#dupStatus").val("Y");
    $("#dupUserNm").text("");
    $("#prioStatus").val(0);
    $("#userType").val(userTypeId);
    $("#btn-submit").val("Update");
    $("#dupUpdt").val(_val);
    $("#user").val(_val);   
    GetRoles(_val);  
    SetRoles(_val,0);
}

function resetForm() {
    $("#dupUserNm").text("");
    $("#btn-submit").val("Submit");  
    $("input:checkbox").prop("checked", "false"); 
    $('.priority').prop("required", false);
    document.getElementById("RegisterValidation").reset();
}

function SelectedService() {
    chkArray = [];
    $(".icheckbox_flat-green:checked").each(function () {
        var selected = $(this).val();
        selected = selected.split(',');   
        chkArray.push({ "regId": selected[0], "masterId": selected[1], "masterParentId": selected[2], "masterSubParentId": selected[3], "masterPriority": selected[4], "masterSubPriority": selected[5], "masterSubSubPriority": selected[6], "fileName": selected[7], "masterName": selected[8] })

    });
}
