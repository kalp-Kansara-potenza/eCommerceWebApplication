#pragma checksum "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d35923a523fa435fa51bb8bd0f57bebfbecdafa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_category_Category), @"mvc.1.0.view", @"/Views/category/Category.cshtml")]
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
#line 1 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\_ViewImports.cshtml"
using ASPNET_Core_3;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d35923a523fa435fa51bb8bd0f57bebfbecdafa", @"/Views/category/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60f8273389c73ee67b936bf8b94df025c2d5af05", @"/Views/_ViewImports.cshtml")]
    public class Views_category_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<eCommerceWebApplication.Models.Category>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap-icons-1.3.0/plus.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString(" border-radius:50px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("min-height: 50px;max-width: 50px; border-radius: 30px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("parent_category_id"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n");
            WriteLiteral("    <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 480, "\"", 530, 1);
#nullable restore
#line 11 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
WriteAttributeValue("", 487, Url.Action("addupdatecategory","category"), 487, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "6d35923a523fa435fa51bb8bd0f57bebfbecdafa6908", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" Category</a>\r\n</div>\r\n\r\n");
            WriteLiteral(@"

            
                
                    <div class=""table-responsive"">
                        <table id=""tree-table-3"" class=""table table-hover table-bordered mm-bg-primary  tree"">
                            <thead class=""bg-primary"">
                                <tr>
                                    <th>Ctegory</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 30 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr data-id=\"");
#nullable restore
#line 32 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                                            Write(item.category_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-parent=\"");
#nullable restore
#line 32 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                                                                            Write(item.parent_category_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-level=\"1\">\r\n                                        <td data-column=\"name\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1503, "\"", 1542, 3);
            WriteAttributeValue("", 1513, "getchild(", 1513, 9, true);
#nullable restore
#line 33 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
WriteAttributeValue("", 1522, item.category_id, 1522, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1541, ")", 1541, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
                                            <span class=""ml-2""></span>
                                            <svg class=""svg-icon mm-arrow-right arrow-active"" id=""mm-dash-1"" width=""20"" xmlns=""http://www.w3.org/2000/svg""
                                                 fill=""none"" viewBox=""0 0 50 50"" stroke=""currentColor"" style=""width: 20px;"">
                                                <path stroke-width=""3""
                                                      d=""M21 22a2.99 2.99 0 0 1 2.121.879l8.89 8.636 8.868-8.636a3 3 0 0 1 4.242 4.242L32.011 40 18.879 27.121A3 3 0 0 1 21 22z"" />
                                            </svg>
");
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6d35923a523fa435fa51bb8bd0f57bebfbecdafa10891", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2853, "~/image/category/", 2853, 17, true);
#nullable restore
#line 45 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
AddHtmlAttributeValue("", 2870, item.thumbnail_image, 2870, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 46 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                                       Write(item.category_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 49 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                \r\n\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d35923a523fa435fa51bb8bd0f57bebfbecdafa13251", async() => {
                WriteLiteral(@"
    <div id=""insertupdatemodel"" class=""modal"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Category</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" airal-label=""Close"" onclick=""cleardata()"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <span id=""error"" class=""text-danger""></span>
                <div class=""modal-body"">
                    <div class=""form-group"">

                        <input type=""hidden"" name=""category_id"" id=""category_id"" class=""form-control"" />

                        <input type=""hidden"" name=""thumbnail_image"" id=""thumb_image"" class=""form-control"" />



                        <label>Catgeory Name :</label>
                        <input type=""text"" id=""category_name"" name=""category_name"" class=""f");
                WriteLiteral(@"orm-control"" />



                        <label>Thumbnail Image:</label>
                        <input type=""file"" id=""thumbnail_image"" name=""file"" class=""form-control"" onchange=""readurl(this);"" />

                        <img id=""cahngethumbimage"" src=""#"" /> <br />



                        <label id=""parent_category_id_lable"">Parent Category</label>
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6d35923a523fa435fa51bb8bd0f57bebfbecdafa15038", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 91 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(ViewBag.categoryname,"category_id","category_name"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </div>
                </div>

                <div class=""modal-footer"">
                    <button type=""button"" onclick=""insertupdateclick()"" class=""btn btn-primary"">Submit</button>
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" onclick=""cleardata()"">Close</button>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral(@"<div id=""delmodal"" class=""modal"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4>Are you sure you want to delete this record?</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" airal-label=""Close"" onclick=""cleardata()"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
                <input type=""hidden"" id=""cat_id"" class=""form-control"" />

            </div>
            <div class=""modal-footer"">
                <button type=""button"" onclick=""deletecategory()"" class=""btn btn-primary"">Delete</button>
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" onclick=""cleardata"">Cancel</button>
            </div>
        </div>
    </div>
</div>

");
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {

        $('#tblcategory').DataTable({
            //""ordering"": true,
            ""columns"": [{ ""sortable"": true }, { ""sortable"": false }],
            ""bLengthChange"": false,
            ""bInfo"": false
        });
    })
");
            WriteLiteral("\r\n    function getchild(parent_category_id) {\r\n        $.ajax({\r\n            type: \'GET\',\r\n            url: \"");
#nullable restore
#line 155 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
             Write(Url.Action("getchildCategory","category"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?parent_category_id="" + parent_category_id,
            success: function (response) {
                $(""#partialview"" + parent_category_id).html(response);
            }
        })
    }

    function insertupdateclick() {
        if ($('#category_id').val() == 0) {


            var file = $('#thumbnail_image').val().replace(/C:\\fakepath\\/i, '');
            var files = $('#thumbnail_image')[0].files[0];

            console.log(files);
            var formData = new FormData();
            formData.append(""category_name"", $('#category_name').val());
            formData.append(""file"", files);
            formData.append(""thumbnail_image"", file);
            formData.append(""parent_category_id"", $('#parent_category_id').val());
            $.ajax({
                data: formData,
                type: ""POST"",
                processData: false,
                contentType: false,
                url: """);
#nullable restore
#line 180 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                 Write(Url.Action("addupdatecategory", "category"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                success: function (response) {
                    console.log(response.error);
                    if (response.errors.length != 0) {
                        for (err = 0; err < response.errors.length; err++) {
                            document.getElementById('error').innerHTML += ""<li>"" + response.errors[err] + ""</li>""
                        }
                    }
                    else {
                        window.location.reload(""");
#nullable restore
#line 189 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                                           Write(Url.Action("Category","category"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""");
                    }
                }
            });
            document.getElementById('error').innerHTML = """";
        }
        else {
            var file = $('#thumbnail_image').val().replace(/C:\\fakepath\\/i, '');
            var files = $('#thumbnail_image')[0].files[0];

            console.log(files);
            var formData = new FormData();
            formData.append(""category_id"", $('#category_id').val())
            formData.append(""category_name"", $('#category_name').val());
            if (file == """") {
                formData.append(""thumbnail_image"", $('#thumb_image').val())
            }
            formData.append(""file"", files);
            formData.append(""thumbnail_image"", file);
            formData.append(""parent_category_id"", $('#parent_category_id').val());
                $.ajax({
                    data: formData,
                    type: ""POST"",
                    processData: false,
                    contentType: false,
                  ");
            WriteLiteral("  url: \"");
#nullable restore
#line 214 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                     Write(Url.Action("addupdatecategory", "category"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    success: function (response) {
                         if (response.errors.length != 0) {
                             for (err = 0; err < response.errors.length; err++) {
                                document.getElementById('error').innerHTML += ""<li>"" + response.errors[err] + ""</li>""
                             }
                         }
                         else {
                            window.location.reload(""");
#nullable restore
#line 222 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                                               Write(Url.Action("Category","category"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n                         }\r\n                    }\r\n                })\r\n                document.getElementById(\'error\').innerHTML = \"\";\r\n        }\r\n    }\r\n\r\n    function dataonclick(category_id) {\r\n            $.ajax({\r\n                url: \"");
#nullable restore
#line 232 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                 Write(Url.Action("editCategory", "category"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"?category_id="" + category_id,
                type: ""GET"",
                contentType: ""application/json"",
                success: function (response) {
                    console.log(response);
                    $(""#cahngethumbimage"").attr('src', ""/image/category/"" + response.thumbnail_image).width(100).height(100);
                    $('#cat_id').val(response.category_id);
                    $('#category_id').val(response.category_id);
                    $('#category_name').val(response.category_name);
                    if (response.parent_category_id == 0) {
                        $('#parent_category_id_lable').hide();
                        $('#parent_category_id').hide();
                    }
                    else {
                        $('#parent_category_id_lable').show();
                        $('#parent_category_id').show();
                    }
                    $('#parent_category_id').val(response.parent_category_id);
                    $('#thumb_image').");
            WriteLiteral("val(response.thumbnail_image)\r\n                }\r\n            })\r\n\r\n\r\n    }\r\n\r\n    function deletecategory() {\r\n\r\n        $.ajax({\r\n            url: \"");
#nullable restore
#line 260 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
             Write(Url.Action("deleteCategory", "category"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?category_id=\" + document.getElementById(\"category_id\").value,\r\n            type: \"GET\",\r\n            success: function () {\r\n                window.location.href = \"");
#nullable restore
#line 263 "G:\KALP\KALP-KANSARA-POTENZA\eCommerceWebApplication\Views\category\Category.cshtml"
                                   Write(Url.Action("Category","category"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
            }
        });

    }


    function cleardata() {
        document.getElementById(""cat_id"").value = 0;
        document.getElementById(""category_id"").value = 0;
        document.getElementById(""thumb_image"").value = """";
        document.getElementById(""category_name"").value = """";
        document.getElementById(""thumbnail_image"").value = """";
        document.getElementById(""parent_category_id"").value = 0;
        $(""#cahngethumbimage"").attr('src', """").width(100).height(100);
        $('#parent_category_id_lable').show();
        $('#parent_category_id').show();

    }

    function readurl(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $(""#cahngethumbimage"").attr('src', e.target.result).width(100).height(100);
            };
            reader.readAsDataURL(input.files[0]);
        }
    }


</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<eCommerceWebApplication.Models.Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
