#pragma checksum "D:\ASSETS\MyCommunity\THOUGHTBOX.HUMANRESOURCE\Views\DashboardBDM\DashboardBDM.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e4de822e651018339d568508c6dacbb112f5334"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DashboardBDM_DashboardBDM), @"mvc.1.0.view", @"/Views/DashboardBDM/DashboardBDM.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/DashboardBDM/DashboardBDM.cshtml", typeof(AspNetCore.Views_DashboardBDM_DashboardBDM))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e4de822e651018339d568508c6dacbb112f5334", @"/Views/DashboardBDM/DashboardBDM.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fae38dcf9c13c6ccfe13f1878d328b91260908ea", @"/Views/_ViewImports.cshtml")]
    public class Views_DashboardBDM_DashboardBDM : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/validator/multifield.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/validator/validator.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/iCheck/icheck.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/PScripts/JDashboardBDM.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2155, true);
            WriteLiteral(@"<!-- Content Header (Page header) -->
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Dashboard - BDM</h1>
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
                <div class=""card card-danger"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">Pending for Approval</h3>
                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool""");
            WriteLiteral(@" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
                    </div>
                    <!-- /.card-header -->
                    <div class=""card-body"">
                        <div id=""accordion"">
                            <!-- we are adding the .class so bootstrap.js collapse plugin detects it -->
                            <div class=""card"">
                                <div class=""card-header"">
                                    <h4 class=""card-title"">

                                        <a data-toggle=""collapse"" href=""#collapseOne"" data-card-widget=""collapse"">
                                            Requests for Approval &nbsp;<span id=""requestapproval1"" style=""color:black;font-weight:bold;""></span>
                      ");
            WriteLiteral("                  </a>\r\n                                    </h4>\r\n                                </div>\r\n");
            EndContext();
            BeginContext(2233, 118, true);
            WriteLiteral("                                <div class=\"card-body\" id=\"requesttable1\">\r\n\r\n                                </div>\r\n");
            EndContext();
            BeginContext(2395, 622, true);
            WriteLiteral(@"                            </div>
                            <div class=""card"">
                                <div class=""card-header"">
                                    <h4 class=""card-title"">
                                        <a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseTwo"" data-card-widget=""collapse"">
                                            Requests for Approval &nbsp;<span id=""requestapproval2"" style=""color:black;font-weight:bold;"">0</span>
                                        </a>
                                    </h4>
                                </div>
");
            EndContext();
            BeginContext(3109, 78, true);
            WriteLiteral("                                <div class=\"card-body\" id=\"requesttable2\">\r\n\r\n");
            EndContext();
            BeginContext(3235, 1689, true);
            WriteLiteral(@"                                </div>
                            </div>

                        </div>
                    </div>


                    <!-- /.card-body -->
                </div>
            </div>

            <div class=""col-md-6"">
                <div class=""card card-info"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">Status View</h3>
                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
                    </div>
                    <!-- /.card-header -->
                    <div class=""card-body"">
                        <div id=""accordion"">
                 ");
            WriteLiteral(@"           <!-- we are adding the .class so bootstrap.js collapse plugin detects it -->
                            <div class=""card"">
                                <div class=""card-header"">
                                    <h4 class=""card-title"">
                                        <a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseThree"" data-card-widget=""collapse"">
                                            Target Status <span id=""requestapproval3"" style=""color:black;font-weight:bold;"">0</span>

                                        </a>
                                    </h4>
                                </div>
");
            EndContext();
            BeginContext(5021, 118, true);
            WriteLiteral("                                <div class=\"card-body\" id=\"requesttable3\">\r\n\r\n                                </div>\r\n");
            EndContext();
            BeginContext(5183, 612, true);
            WriteLiteral(@"                            </div>
                            <div class=""card"">
                                <div class=""card-header"">
                                    <h4 class=""card-title"">
                                        <a data-toggle=""collapse"" data-parent=""#accordion"" href=""#collapseFour"" data-card-widget=""collapse"">
                                            Meeting Status <span id=""requestapproval4"" style=""color:black;font-weight:bold;"">0</span>

                                        </a>
                                    </h4>
                                </div>
");
            EndContext();
            BeginContext(5888, 118, true);
            WriteLiteral("                                <div class=\"card-body\" id=\"requesttable4\">\r\n\r\n                                </div>\r\n");
            EndContext();
            BeginContext(6050, 6330, true);
            WriteLiteral(@"                            </div>

                        </div>
                    </div>


                    <!-- /.card-body -->
                </div>
            </div>

        </div>

        <div class=""row"">
            <div class=""col-md-6"">
                <input type=""hidden"" id=""status"" />
                <!-- PIE CHART -->
                <div class=""card card-danger"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">Complete Status Chart</h3>

                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
                    </div>
                    <div class=""card-body"">");
            WriteLiteral(@"
                        <div class=""input-group"">
                            <div class=""form-group clearfix"">
                                <div class=""icheck-danger d-inline"">
                                    <input type=""radio"" name=""r3"" checked="""" value=""Internal"" id=""radioSuccess1"">
                                    <label for=""radioSuccess1"">
                                        Internal
                                    </label>
                                </div>
                                <div class=""icheck-primary d-inline"">
                                    <input type=""radio"" name=""r3"" value=""LeadGeneration"" id=""radioSuccess2"">
                                    <label for=""radioSuccess2"">
                                        Lead Generation
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class=""chart"" id=""compdiv"">
        ");
            WriteLiteral(@"                    <canvas id=""pieChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>
                            <div class=""row"" id=""subchart"" style=""font-weight:600;font-size:18px"" ;></div>
                        </div>
                    </div>


                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
                <!-- BAR CHART -->
                <div class=""card card-success"">
                    <div class=""card-header"">
                        <h3 class=""card-title""></h3>

                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
              ");
            WriteLiteral(@"      </div>
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
                <div class=""card card-info"">
                    <div class=""card-header"">
                        <h3 class=""card-title"" id=""emphead""></h3>

                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn btn-too");
            WriteLiteral(@"l"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""chart"" id=""pdeptChart"">
                            <canvas id=""pieChartDept"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>

                        </div>
                        <div class=""row"" id=""subemp"" style=""font-weight:600""></div>
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
                <!-- STACKED BAR CHART -->
                <div class=""card card-success"">
                    <div class=""card-header"">
                        <h3 class=""card-title""></h3>

                        <div class=""card-tools"">
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""collapse"">
                                <i class=""fas fa-minus");
            WriteLiteral(@"""></i>
                            </button>
                            <button type=""button"" class=""btn btn-tool"" data-card-widget=""remove""><i class=""fas fa-times""></i></button>
                        </div>
                    </div>
                    <div class=""card-body"">
                        <div class=""chart"">
                            <canvas id=""stackedBarChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>
                        </div>
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->

            </div>
            <!-- /.col (RIGHT) -->
        </div>


    </div><!-- /.container-fluid -->



</section>
<!-- /.content -->
<!-- jQuery -->
<script src=""../../plugins/jquery/jquery.min.js""></script>
<!-- Bootstrap 4 -->
<script src=""../../plugins/bootstrap/js/bootstrap.bundle.min.js""></script>
<!-- ChartJS -->
<script src=""../../plugins/chart.js/Cha");
            WriteLiteral("rt.min.js\"></script>\r\n<!-- AdminLTE App -->\r\n<script src=\"../../dist/js/adminlte.min.js\"></script>\r\n<!-- AdminLTE for demo purposes -->\r\n<script src=\"../../dist/js/demo.js\"></script>\r\n\r\n");
            EndContext();
            BeginContext(12380, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0be51dfb4796455487c6b6ae599fd4e7", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(12429, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(12431, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0c00edf17d94d649040106a1f34a6df", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(12479, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(12481, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6bc2e4c327e49469c5e89a810f7b3d9", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(12535, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(12537, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9262434523f540fd93549d11c26906ec", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(12611, 14583, true);
            WriteLiteral(@"
<!-- page script -->


<script>

    $(document).ready(function () {
        GetDepartmentGraphs(""Internal"");
    });

    $(function () {
        $('input[name=""r3""]:radio').change(function () {
            var pcheck = $(""input[name='r3']:checked"").val();
            GetDepartmentGraphs(pcheck);
        });
    });

    function GetDepartmentGraphs(reqType) {
        document.querySelector(""#compdiv"").innerHTML = '<canvas id=""pieChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas><div class=""row"" id=""subchart"" style=""font-weight:600;font-size:18px"" ;></div>';

        $.ajax({
            url: ""/DepartmentGraph/GetDHDepartmentGraphs"",
            cache: false,
            data: { Dtype: ""BDM"", reqType: reqType },
            type: ""POSt"",
            datatype: ""json"",
            success: function (data) {
               // alert(JSON.stringify(data));
                if (data != null) {
                    var deptLabel = [];
        ");
            WriteLiteral(@"            var deptCount = [];
                    var deptColor = [];
                    var cocode = 1;
                    var htmlString = """";

                    for (var x = 0; x < data.length; x++) {
                        var req = data[x].reqId.toString();
                        var color = '#' + Math.floor(Math.random() * 16777215).toString(16);
                        if (data[x].status == ""Completed"") {
                            htmlString += ""&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='#emphead' onclick='subPieChart(\"""" + req + ""\"",\"""" + data[x].status + ""\"")'>Completed</a>"";
                        }

                        if (data[x].status == ""Not Completed"") {
                            htmlString += ""&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='#emphead' onclick='subPieChart(\"""" + req + ""\"",\"""" + data[x].status + ""\"")'>Not Completed</a>"";
                        }
                        if (data[x].status == ""Pending"") {
                            htmlString += ""&nbsp;&nbsp;");
            WriteLiteral(@"&nbsp;&nbsp;&nbsp;<a href='#emphead' onclick='subPieChart(\"""" + req + ""\"",\"""" + data[x].status + ""\"")'>Pending</a>"";
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
                                backgroundColor: deptColor,
                            }
                        ]
                    }

                    var pieChartCanvas = $('#pieChart').get(0).getContext('2d')
                    var pieData = deptData;
                    var pieOptions = {
                        maintainAspectRatio: false,
                        responsive:");
            WriteLiteral(@" true,
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
        document.getElementById(""emphead"").innerText = status;
        document.querySelector(""#pdeptChart"").innerHTML = '<canvas id=""pieChartDept"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>';
        $.ajax({
            url: ""/DepartmentGraph/GetDepartmentSubGraphStatus"",
            data: { reqId: reqId },
            cache: false,
            ");
            WriteLiteral(@"type: ""POSt"",
            datatype: ""json"",
            success: function (data) {
                var htmlString = """";
                $(""#subemp"").empty();
                // alert(JSON.stringify(data));
                if (data != null) {
                   
                    var empid = 0;
                    var deptLabel = [];
                    var deptCount = [];
                    var deptColor = [];
                    var cocode = 1;
                    for (var x = 0; x < data.length; x++) {
                        if (empid != data[x].emp_id) {
                            empid = data[x].emp_id;
                            htmlString += ""&nbsp;&nbsp;&nbsp;&nbsp<a href='#emphead' onclick='GetDeptHead(\"""" + reqId + ""\"",\"""" + status + ""\"",\"""" + data[x].dept + ""\"")'>"" + data[x].dept + ""</a>"";
                        }
                      
                        var color = '#' + Math.floor(Math.random() * 16777215).toString(16);
                        deptLabel.push(data[x");
            WriteLiteral(@"].dept);
                        deptCount.push(data[x].no_task);
                        deptColor.push(color);
                        cocode += 10;

                    }
                    $(""#subemp"").append(htmlString);
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
                   ");
            WriteLiteral(@" var pieChart = new Chart(pieChartCanvas, {
                        type: 'pie',
                        data: pieData,
                        options: pieOptions
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

    function GetDeptHea");
            WriteLiteral(@"d(reqId, status,empname) {
        // $(""#status"").val(status);
        document.getElementById(""emphead"").innerText = empname;
        document.querySelector(""#pdeptChart"").innerHTML = '<canvas id=""pieChartDept"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>';
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
                if (data != null) {
                    var emp1 = data[0].emp_name;
                    if (emp1.indexOf("","") > -1) {
                        var emp = emp1.split("","");
                        for (var i = 0; i < emp.length; i++) {
                            var empname = emp[i].split('^');
                            h");
            WriteLiteral(@"tmlString += ""&nbsp;&nbsp;&nbsp;&nbsp<a href='#emphead' onclick='empPieChart(\"""" + empname[1] + ""\"",\"""" + empname[0] + ""\"")'>"" + empname[0] + ""</a>"";

                        }

                    }
                    else {
                        var empname = emp1.split('^');
                        htmlString += ""&nbsp;&nbsp;&nbsp;&nbsp<a href='#emphead' onclick='empPieChart(\"""" + empname[1] + ""\"",\"""" + empname[0] + ""\"")'>"" + empname[0] + ""</a>"";

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
                        deptColor.push(color);
");
            WriteLiteral(@"                        cocode += 10;

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
                        options: pieOptions
  ");
            WriteLiteral(@"                  })

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

    function empPieChart(empId, empname) {
        var status = $(""#status"")");
            WriteLiteral(@".val();
        var reqType = $(""input[name='r3']:checked"").val();
        document.getElementById(""emphead"").innerText = empname;
        document.querySelector(""#pdeptChart"").innerHTML = '<canvas id=""pieChartDept"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>';

        //   document.querySelector(""#empdiv"").innerHTML = '<canvas id=""empChart"" style=""min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;""></canvas>';
        $.ajax({
            url: ""/DepartmentGraph/GetDepartmentSubGraphByEmp"",
            data: { empId: empId, status: status, reqType: reqType },
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
           ");
            WriteLiteral(@"         for (var x = 0; x < data.length; x++) {

                        var color = '#' + Math.floor(Math.random() * 16777215).toString(16);
                        deptLabel.push(data[x].dept);
                        deptCount.push(data[x].no_task);
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

                    var pieChartCanvas = $('#pieChartDept').get(0).getContext('2d')
                    var pieData = deptData;
                    var pieOptions = {
                        maintainAspectRatio: false,
                        responsive: true,
                    }
                    ");
            WriteLiteral(@"//Create pie or douhnut chart
                    // You can switch between pie and douhnut using the method below.
                    var pieChart = new Chart(pieChartCanvas, {
                        type: 'pie',
                        data: pieData,
                        options: pieOptions
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
                        type: 'pie',");
            WriteLiteral("\r\n                        data: pieData,\r\n                        options: pieOptions\r\n                    })\r\n\r\n                }\r\n\r\n            },\r\n            error: function (reponse) {\r\n\r\n            }\r\n        });\r\n    }\r\n\r\n</script>\r\n\r\n\r\n\r\n");
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
