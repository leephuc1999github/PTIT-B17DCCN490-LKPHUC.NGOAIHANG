#pragma checksum "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d66a7cb70429dc05787b9c9b83681a0d53c4bf7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GiaiDau_Index), @"mvc.1.0.view", @"/Views/GiaiDau/Index.cshtml")]
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
#nullable restore
#line 4 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
using PTIT.B17DCCN490.PTTK_DBCLPM.Models.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d66a7cb70429dc05787b9c9b83681a0d53c4bf7", @"/Views/GiaiDau/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_GiaiDau_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<GiaiDau>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
  
    ViewData["Title"] = "Giải đấu | Thiết lập | Premier Language";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <style>
        .row {
            width: 100%;
            display: flex;
            flex-direction: column;
            color: #000;
            margin-bottom: 20px;
        }

            .row label {
                padding-bottom: 5px;
            }

            .row input {
                height: 32px;
                border: 1px solid #000;
                outline: none;
                padding-left: 15px;
                box-sizing: border-box;
                border-radius: 5px;
            }
    </style>
    <div class=""homePage"">
        <section class=""match mx-10"">
            <div class=""title-site d-flex align-items-center"">
                <div class=""footballIcon""></div>
                <h1 class=""title"">Danh sách giải đấu</h1>
                <div class=""ml-auto""></div>
                <button class=""btn"" onclick=""openForm()"">Thêm mới</button>
            </div>
        </section>
        <table class=""dataTable"" id=""ds-gd"">
            <thead>
        ");
            WriteLiteral(@"        <tr>
                    <th class=""txt-center"">STT</th>
                    <th class=""txt-left"">Giải đấu</th>
                    <th class=""txt-center"">Mùa giải</th>
                    <th class=""txt-center"">Thời gian bắt đầu</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 47 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
                  
                    for (int i = 0; i < Model.Count(); i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr title=\"Chọn để đăng ký đội bóng tham gia giải\"");
            BeginWriteAttribute("ondblclick", " ondblclick=\"", 1667, "\"", 1704, 3);
            WriteAttributeValue("", 1680, "loadPage(\'", 1680, 10, true);
#nullable restore
#line 50 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
WriteAttributeValue("", 1690, Model[i].Id, 1690, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1702, "\')", 1702, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td class=\"txt-center\">");
#nullable restore
#line 51 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
                                               Write(i + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"txt-left\">");
#nullable restore
#line 52 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
                                            Write(Model[i].Ten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"txt-center\">");
#nullable restore
#line 53 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
                                              Write(Model[i].MuaGiai);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"txt-center\">");
#nullable restore
#line 54 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
                                              Write(Model[i].ThoiGianBD.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 56 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
                    }
                    if (Model.Count() == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td colspan=\"4\">Dữ liệu không có sẵn</td>\r\n                        </tr>\r\n");
#nullable restore
#line 62 "E:\MYPROJECT\ASP.NETCoreApp\PTIT.B17DCCN490.PTTK_DBCLPM\PTIT.B17DCCN490.PTTK_DBCLPM\Views\GiaiDau\Index.cshtml"
                    }
                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>

        <div class=""bgForm"" id=""screen"" style=""display: none"">
            <div class=""form"">
                <div style=""position: relative; height: 100%; width: 100%"">
                    <div class=""title-form"">Thêm giải đấu <span class=""ml-auto"" style=""cursor: pointer"" onclick=""closeForm()"">x</span></div>
                    <div class=""body-form"">
                        <div class=""row"">
                            <label>Tên <span class=""c-red"">(*)</span></label>
                            <input id=""Ten"" required type=""text"" class=""input-form"" tabindex=""1"" />
                        </div>
                        <div class=""row"">
                            <label>Mùa giải <span class=""c-red"">(*)</span></label>
                            <input id=""MuaGiai"" required type=""text"" class=""input-form"" tabindex=""2"" />
                        </div>
                        <div class=""row"">
                            <label>Thời gian bắt đầu <span c");
            WriteLiteral(@"lass=""c-red"">(*)</span></label>
                            <input id=""ThoiGianBD"" required type=""date"" class=""input-form"" tabindex=""3"" />
                        </div>
                    </div>
                    <div class=""footer-form"">
                        <button class=""btn"" onclick=""save()"" tabindex=""4"">Cất</button>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script type=""text/javascript"">

        let screen = document.getElementById(""screen"");
        let name = document.getElementById(""Ten"");
        let season = document.getElementById(""MuaGiai"");
        let startDate = document.getElementById(""ThoiGianBD"");
        function openForm() {
            screen.style.display = ""block"";
            name.focus();
        }

        function closeForm() {
            screen.style.display = ""none"";
        }

        function save() {
            if (name.value != null && season.value != null && startDate.value != nul");
            WriteLiteral(@"l) {
                var data = {
                    Ten: name.value,
                    MuaGiai: season.value,
                    ThoiGianBD: startDate.value
                };
                fetch(""https://localhost:44352/GiaiDau"",
                    {
                        body: JSON.stringify(data),
                        method: ""POST"",
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        }
                    })
                    .then(response => {
                        window.location.href = ""/GiaiDau"";
                    })
                    .catch(error => { console.log(error); })
            }
        }

        function loadPage(giaiDauId) {
            window.location.href = `/DoiBongGiaiDau/${giaiDauId}`;
        }

    </script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<GiaiDau>> Html { get; private set; }
    }
}
#pragma warning restore 1591