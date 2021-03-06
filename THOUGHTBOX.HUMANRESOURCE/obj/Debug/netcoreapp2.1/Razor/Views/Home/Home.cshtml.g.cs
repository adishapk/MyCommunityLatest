#pragma checksum "D:\ASSETS\MyCommunity\THOUGHTBOX.HUMANRESOURCE\Views\Home\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c97c28592719f37bc6933d2e52dbbf3a859e7ad6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Home), @"mvc.1.0.view", @"/Views/Home/Home.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Home.cshtml", typeof(AspNetCore.Views_Home_Home))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\ASSETS\MyCommunity\THOUGHTBOX.HUMANRESOURCE\Views\_ViewImports.cshtml"
using THOUGHTBOX.HUMANRESOURCE;

#line default
#line hidden
#line 2 "D:\ASSETS\MyCommunity\THOUGHTBOX.HUMANRESOURCE\Views\_ViewImports.cshtml"
using THOUGHTBOX.HUMANRESOURCE.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c97c28592719f37bc6933d2e52dbbf3a859e7ad6", @"/Views/Home/Home.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fae38dcf9c13c6ccfe13f1878d328b91260908ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 16394, true);
            WriteLiteral(@" <!-- Content Header (Page header) -->
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Request Graph</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                    <li class=""breadcrumb-item active"">ChartJS</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<!-- Main content -->
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-md-6"">
                <input type=""hidden"" id=""status"" />
                <!-- PIE CHART -->
                <div class=""card card-danger"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">Complete Status Chart</h3>

                        <div cl");
            WriteLiteral(@"ass=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <canvas id=""pieChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>
                        <div class=""row"" id=""subchart"" style=""font-weight:600;font-size:18px"" ;></div>
                    </div>


                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
                <!-- BAR CHART -->
                <div class=""card card-success"">
                    <div class=""card-header"">
                        <h3 class=""card-title"" id=""emphead"">");
            WriteLiteral(@"</h3>

                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""chart"" id=""empdiv"">
                            <canvas id=""empChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>
                        </div>
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col (LEFT) -->
            <div class=""col-md-6"">
                <!-- LINE CHART -->
                <div class=""card card-i");
            WriteLiteral(@"nfo"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">DepartmentWise Status Chart</h3>

                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""chart"" id=""pdeptChart"">
                            <canvas id=""pieChartDept"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>

                        </div>
                        <div class=""row"" id=""subemp"" style=""font-weight:600""></div>
                    </div>
                    <!-- /.card-body -->
 ");
            WriteLiteral(@"               </div>
                <!-- /.card -->
                
                <!-- STACKED BAR CHART -->
                <div class=""card card-success"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">chart</h3>

                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""chart"">
                            <canvas id=""stackedBarChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>
                        </div>
                    </div>
     ");
            WriteLiteral(@"               <!-- /.card-body -->
                </div>
                <!-- /.card -->

            </div>
            <!-- /.col (RIGHT) -->
        </div>
        <!-- /.row -->
    </div><!-- /.container-fluid -->
</section>
<!-- /.content -->
<!-- jQuery -->
<script src=""../../plugins/jquery/jquery.min.js""></script>
<!-- Bootstrap 4 -->
<script src=""../../plugins/bootstrap/js/bootstrap.bundle.min.js""></script>
<!-- ChartJS -->
<script src=""../../plugins/chart.js/Chart.min.js""></script>
<!-- AdminLTE App -->
<script src=""../../dist/js/adminlte.min.js""></script>
<!-- AdminLTE for demo purposes -->
<script src=""../../dist/js/demo.js""></script>
<!-- page script -->
<script>

    $(document).ready(function () {
        GetDepartmentGraphs();
        
    });

    function GetDepartmentGraphs() {
        
        $.ajax({
            url: ""/DepartmentGraph/GetDepartmentGraphs"",
            cache: false,
            type: ""POSt"",
            datatype: ""json"",
            s");
            WriteLiteral(@"uccess: function (data) {
                //alert(JSON.stringify(data));
                if (data != null) {
                    var deptLabel = [];
                    var deptCount = [];
                    var deptColor = [];
                    var cocode = 1;
                    var htmlString = """";                    
                    
                    for (var x = 0; x < data.length; x++) {  
                        var req = data[x].reqId.toString();
                        var color = '#' + Math.floor(Math.random() * 16777215).toString(16);
                        if (data[x].status == ""Completed"") {
                            htmlString += ""&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='#' onclick='subPieChart(\"""" + req + ""\"",\"""" + data[x].status + ""\"")'>Completed</a>"";
                        }
                       
                        if (data[x].status == ""Not Completed"") {
                            //htmlString += '&nbsp;&nbsp;&nbsp;<a href=""#"" onclick=""subPieChart(' + re");
            WriteLiteral(@"q + ')"">Not Completed</a>';
                            htmlString += ""&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='#' onclick='subPieChart(\"""" + req + ""\"",\"""" + data[x].status + ""\"")'>Not Completed</a>"";
                        }
                        if (data[x].status == ""Pending"") {
                            htmlString += ""&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='#' onclick='subPieChart(\"""" + req + ""\"",\"""" + data[x].status + ""\"")'>Pending</a>"";
                        }
                        deptLabel.push(data[x].status);
                        deptCount.push(data[x].no_task);
                        deptColor.push(color);
                        cocode += 10;

                    }
                    $(""#subchart"").append(htmlString);
                    var deptData = {
                        labels: deptLabel,
                        datasets: [
                            {
                                data: deptCount,
                                backgroundColor: deptColor,");
            WriteLiteral(@"
                            }
                        ]
                    }

                    var pieChartCanvas = $('#pieChart').get(0).getContext('2d')
                    var pieData = deptData;
                    var pieOptions = {
                        maintainAspectRatio: false,
                        responsive: true,
                    }
                    //Create pie or douhnut chart
                    // You can switch between pie and douhnut using the method below.
                    var pieChart = new Chart(pieChartCanvas, {
                        type: 'pie',
                        data: pieData,
                        options: pieOptions
                    })

                }
                else {
                  
                }

            },
            error: function (reponse) {
              
            }
        });
    }

    function subPieChart(reqId, status) {
       
        $(""#status"").val(status);        
        documen");
            WriteLiteral(@"t.querySelector(""#pdeptChart"").innerHTML = '<canvas id=""pieChartDept"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>';
        $.ajax({
            url: ""/DepartmentGraph/GetDepartmentSubGraphStatus"",
            data: { reqId: reqId },
            cache: false,
            type: ""POSt"",
            datatype: ""json"",
            success: function (data) {
                var htmlString = """";
                $(""#subemp"").empty();
               // alert(JSON.stringify(data));
                if (data != null)
                {
                    var emp1 = data[0].emp_name;                   
                    if (emp1.indexOf("","") > -1)
                    {                      
                        var emp = emp1.split("","");
                        for (var i = 0; i < emp.length; i++) {
                            var empname = emp[i].split('^');
                            htmlString += ""&nbsp;&nbsp;&nbsp;&nbsp<a href='#' onclick='empPieChar");
            WriteLiteral(@"t(\"""" + empname[1] + ""\"",\"""" + empname[0] + ""\"")'>"" + empname[0] + ""</a>"";

                        }

                    }
                    else {                        
                        var empname = emp1.split('^');                       
                        htmlString += ""&nbsp;&nbsp;&nbsp;&nbsp<a href='#' onclick='empPieChart(\"""" + empname[1] + ""\"",\"""" + empname[0] + ""\"")'>"" + empname[0] + ""</a>"";

                    }
                   
                    $(""#subemp"").append(htmlString);
                    var deptLabel = [];
                    var deptCount = [];
                    var deptColor = [];
                    var cocode = 1;
                    for (var x = 0; x < data.length; x++) {
                       
                        var color = '#' + Math.floor(Math.random() * 16777215).toString(16);
                        deptLabel.push(data[x].dept);
                        deptCount.push(data[x].no_task);
                        deptColor.push(co");
            WriteLiteral(@"lor);
                        cocode += 10;

                    }
                    var deptData = {
                        labels: deptLabel,
                        datasets: [
                            {
                                data: deptCount,
                                backgroundColor: deptColor,
                            }
                        ]
                    }

                    var pieChartCanvas = $('#pieChartDept').get(0).getContext('2d')
                    var pieData = deptData;
                    var pieOptions = {
                        maintainAspectRatio: false,
                        responsive: true,
                    }
                    //Create pie or douhnut chart
                    // You can switch between pie and douhnut using the method below.
                    var pieChart = new Chart(pieChartCanvas, {
                        type: 'pie',
                        data: pieData,
                        options: pieOpti");
            WriteLiteral(@"ons
                    })

                }
                else {
                    var deptLabel = [];
                    var deptCount = [];
                    var deptColor = [];
                    var pieChartCanvas = $('#pieChartDept').get(0).getContext('2d')
                    var pieData = deptData;
                    var pieOptions = {
                        maintainAspectRatio: false,
                        responsive: true,
                    }
                    //Create pie or douhnut chart
                    // You can switch between pie and douhnut using the method below.
                    var pieChart = new Chart(pieChartCanvas, {
                        type: 'pie',
                        data: pieData,
                        options: pieOptions
                    })

                }

            },
            error: function (reponse) {

            }
        });
    }

    function empPieChart(empId,empname) {
        var status = $(""#st");
            WriteLiteral(@"atus"").val();
        document.getElementById(""emphead"").innerText = empname;
        document.querySelector(""#empdiv"").innerHTML = '<canvas id=""empChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>';
        $.ajax({
            url: ""/DepartmentGraph/GetDepartmentSubGraphByEmp"",
            data: { empId: empId, status: status },
            cache: false,
            type: ""POSt"",
            datatype: ""json"",
            success: function (data) {
               
                //alert(JSON.stringify(data));
                if (data != null) {
                   
                    var deptLabel = [];
                    var deptCount = [];
                    var deptColor = [];
                    var cocode = 1;
                    for (var x = 0; x < data.length; x++) {

                        var color = '#' + Math.floor(Math.random() * 16777215).toString(16);
                        deptLabel.push(data[x].dept);
                    ");
            WriteLiteral(@"    deptCount.push(data[x].no_task);
                        deptColor.push(color);
                        cocode += 10;

                    }
                    var deptData = {
                        labels: deptLabel,
                        datasets: [
                            {
                                data: deptCount,
                                backgroundColor: deptColor,
                            }
                        ]
                    }

                    var pieChartCanvas = $('#empChart').get(0).getContext('2d')
                    var pieData = deptData;
                    var pieOptions = {
                        maintainAspectRatio: false,
                        responsive: true,
                    }
                    //Create pie or douhnut chart
                    // You can switch between pie and douhnut using the method below.
                    var pieChart = new Chart(pieChartCanvas, {
                        type: 'pie',
     ");
            WriteLiteral(@"                   data: pieData,
                        options: pieOptions
                    })

                }
                else {
                    var deptLabel = [];
                    var deptCount = [];
                    var deptColor = [];
                    var pieChartCanvas = $('#empChart').get(0).getContext('2d')
                    var pieData = deptData;
                    var pieOptions = {
                        maintainAspectRatio: false,
                        responsive: true,
                    }
                    //Create pie or douhnut chart
                    // You can switch between pie and douhnut using the method below.
                    var pieChart = new Chart(pieChartCanvas, {
                        type: 'pie',
                        data: pieData,
                        options: pieOptions
                    })

                }

            },
            error: function (reponse) {

            }
        });
    }
<");
            WriteLiteral("/script>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
