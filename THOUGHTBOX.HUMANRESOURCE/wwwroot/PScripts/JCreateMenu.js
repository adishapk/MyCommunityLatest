$(document).ready(function () {
    getAll();
    getMainMenu();
});

$(function () {
    $('input[name="r3"]:radio').change(function () {
        var pcheck = $("input[name='r3']:checked").val();
        if (pcheck == "sub") {
            $(".subList").show();
            $("#icon").hide();
        }
        else {
            $(".subList").hide();
        }
    });
});

function getMainMenu() {
    var condition = " where parent_id=0 order by menu_name";
    $.ajax({
        type: "POST",
        url: "/CreateMenu/selectAllMenu",
        data: { condition: condition },
        datatype: "json",
        success: function (data) {

            var markup = '';
            if (data != null) {

                markup = "<option value=0>--select--</option>";

                if (data != null) {
                    for (var x = 0; x < data.length; x++) {
                        markup += "<option value=" + data[x].master_id + ">" + data[x].master_valuename + "</option>";

                    }
                }
                $("#mainMenu").html(markup).show();
            }
            else {
                markup = "<option value=0>--select--</option>";
                $("#mainMenu").html(markup).show();
            }

        },
        error: function (reponse) {
            markup = "<option value=0>--select--</option>";
            $("#mainMenu").html(markup).show();
        }
    });
}

function getAll() {
    var condition = " order by menu_name";
    $.ajax({
        type: "POST",
        url: "/CreateMenu/selectAllMenu",
        data: { condition: condition },
        datatype: "json",
        success: function (data) {
            //alert(JSON.stringify(data));
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
                            'data': 'master_valuename'
                        },
                        {
                            'data': 'master_parent_text'
                        },
                        {
                            'data': 'master_valueremarks'
                        },

                        {
                            'sortable': false,
                            'render': function (data, type, row) { return '<i onclick="Update(' + row.master_id + ',\'' + row.master_typename + '\',\'' + row.master_valuename + '\',' + row.master_parentid + ',\'' + row.master_valueremarks + '\')"  class="fas fa-pencil-alt" style="color:orange;cursor: pointer;"></i>' }
                        },
                        {
                            'sortable': false,
                            'render': function (data, type, row) { return '<i onclick="Delete(' + row.master_id + ')" class="fas fa-trash" style="color:red;cursor: pointer;"></i>' }
                        }

                    ],

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

function addMenu() {

    var validator = new FormValidator({ "events": ['blur', 'input', 'change'] }, document.forms[0]);
    var y = document.getElementById("RegisterValidation");
    validatorResult = validator.checkAll(y);

    if (validatorResult.valid) {
        var statusmsg = ''
        var btn = $("#btn-submit").val();
        var pcheck = $("input[name='r3']:checked").val();
        if (pcheck == "main") {
            var icon = $("#iconName").val();
            $("#fileName").val(icon);
        }
        var url1 = "";
        if (btn == "Submit") {
            url1 = "/CreateMenu/insertMenu";
            statusmsg = 'Menu Successfully Added!!'
        }
        else {
            url1 = "/CreateMenu/updateMenu";
            statusmsg = 'Menu Successfully Updated!!'
        }
        _Val = {
            master_valuename: $("#menuName").val(),
            master_typename: $("#fileName").val(),
            master_valueremarks: $("#iconName").val(),
            master_id: $("#menu_id").val(),
            master_parentid: $("#mainMenu").val(),
        };

        $.ajax({
            type: 'POST',
            data: { Mastername: _Val },
            url: url1,
            dataType: 'json',
            success: function (data) {
                if (data == false) {
                    toastr.error('Unhandled error. Please try again!!');
                }
                else {
                    getAll();
                    getMainMenu();
                    resetForm();
                    toastr.success(statusmsg);
                    $("#btn-submit").val("Submit");
                }
            },
            error: function (reponse) {
                toastr.error('Unhandled error. Please try again!!');
            }
        });
    }

}

function Delete(id) {

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
                url: "/CreateMenu/deleteMenu",
                data: { Id: id },
                datatype: "json",
                success: function (data) {
                    getAll();
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

function Update(master_id, master_typename, master_valuename, master_parent, master_valueremarks) {
    $("#btn-submit").val("Update");
    $("#menu_id").val(master_id);
    $("#fileName").val(master_typename);
    $("#menuName").val(master_valuename);
    $("#mainMenu").val(master_parent);
    $("#iconName").val(master_valueremarks);
    if (master_parent != 0) {
        $(".subList").show();
        $("#icon").hide();
    }
    else {
        $(".subList").hide();
        $("#icon").show();
    }
}

function resetForm() {
    $(".subList").hide();
    $("#icon").hide();
    $("#btn-submit").val("Submit");
    document.getElementById("RegisterValidation").reset();
}