#pragma checksum "C:\Development\Projects\TestProjects\DynamicFormBuilder\InputSelectionDemo\Views\Patient\PatientList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f2a75f5f0709b88e21aa67d787c4059dc79ff50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient_PatientList), @"mvc.1.0.view", @"/Views/Patient/PatientList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Patient/PatientList.cshtml", typeof(AspNetCore.Views_Patient_PatientList))]
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
#line 1 "C:\Development\Projects\TestProjects\DynamicFormBuilder\InputSelectionDemo\Views\_ViewImports.cshtml"
using InputSelectionDemo;

#line default
#line hidden
#line 2 "C:\Development\Projects\TestProjects\DynamicFormBuilder\InputSelectionDemo\Views\_ViewImports.cshtml"
using InputSelectionDemo.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f2a75f5f0709b88e21aa67d787c4059dc79ff50", @"/Views/Patient/PatientList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac69967c5d4b63822c25ba06c15fad8b49bed4c6", @"/Views/_ViewImports.cshtml")]
    public class Views_Patient_PatientList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(494, 54, true);
            WriteLiteral("<div id=\"info\"></div>\r\n\r\n<div id=\"showData\">\r\n</div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(566, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(632, 4391, true);
                WriteLiteral(@"    <script>
        $(document).ready(function () {
            $.ajax({
                url: '/patient/patientapi',
                data: {
                    format: 'json'
                },
                error: function () {
                    $('#info').html('<p>An error has occurred</p>');
                },
                dataType: 'json',
                success: function (data) {
                    // EXTRACT VALUE FOR HTML HEADER.
                    var col = [];
                    for (var i = 0; i < data.length; i++) {
                        for (var key in data[i]) {
                            if (col.indexOf(key) === -1) {
                                col.push(key);
                            }
                        }
                    }

                    // CREATE DYNAMIC TABLE.
                    var table = document.createElement(""table"");


                    // CREATE HTML TABLE HEADER ROW USING THE EXTRACTED HEADERS ABOVE.

              ");
                WriteLiteral(@"      var header = table.createTHead();

                    // Create an empty <tr> element and add it to the first position of <thead>:
                    var row = header.insertRow(0);

                    for (var i = 0; i < col.length; i++) {
                        var th = document.createElement(""th"");      // TABLE HEADER.
                        th.innerHTML = col[i];
                        row.appendChild(th);
                    }

                    var bbody = table.appendChild(document.createElement('tbody'))

                    // ADD JSON DATA TO THE TABLE AS ROWS.
                    for (var i = 0; i < data.length; i++) {

                        tr = bbody.insertRow(-1);

                        for (var j = 0; j < col.length; j++) {
                            var tabCell = tr.insertCell(-1);
                            tabCell.innerHTML = data[i][col[j]];
                        }
                    }

                    // FINALLY ADD THE NEWLY CREATED TABLE");
                WriteLiteral(@" WITH JSON DATA TO A CONTAINER.
                    var divContainer = document.getElementById(""showData"");
                    divContainer.innerHTML = """";
                    divContainer.appendChild(table);

                    // convert it to a data table
                    table.setAttribute(""id"", ""example"");
                    $('#example').DataTable();

                },
                type: 'POST'
            });
            //$.ajax({
            //    url: '/patient/patientapi',
            //    type: 'POST',
            //    // data: Payload,
            //    success: function (response) {
            //        if (response.status != true) {
            //            // toastr.options.timeOut = 1500; // 1.5s
            //            //toastr.error(""Internal Server Error!"", 'Error Notification');
            //        }
            //        else {
            //            if ($.fn.DataTable.isDataTable('#sample_rv')) {
            //                $('#sample_rv').D");
                WriteLiteral(@"ataTable().destroy();
            //                $('#sample_rv').empty();
            //            }
            //            var Columns = [];
            //            var TableHeader = ""<thead><tr>"";
            //            $.each(response.result[0], function (key, value) {
            //                Columns.push({ ""data"": key })
            //                TableHeader += ""<th>"" + key + ""</th>""
            //            });
            //            TableHeader += ""</thead></tr>"";
            //            $(""#sample_rv"").append(TableHeader);
            //            $('#sample_rv').dataTable({
            //                language: {
            //                    aria: { sortAscending: "": activate to sort column ascending"", sortDescending: "": activate to sort column descending"" },
            //                    //""sLengthMenu"": ""_MENU_ &nbsp;"",
            //                    emptyTable: ""No data available to display"",
            //                }, order: [], leng");
                WriteLiteral(@"thMenu: [[5, 10, 15, 20, 40, -1], [5, 10, 15, 20, 40, ""All""]],
            //                ""data"": response.result,
            //                ""columns"": Columns,
            //            });
            //        }
            //    }
            //});
        });
    </script>
");
                EndContext();
            }
            );
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