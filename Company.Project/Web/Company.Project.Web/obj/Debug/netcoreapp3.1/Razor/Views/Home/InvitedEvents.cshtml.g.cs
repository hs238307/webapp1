#pragma checksum "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82727e1b26e61cc8918854ae6a735eee32b175a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_InvitedEvents), @"mvc.1.0.view", @"/Views/Home/InvitedEvents.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/InvitedEvents.cshtml", typeof(AspNetCore.Views_Home_InvitedEvents))]
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
#line 1 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\_ViewImports.cshtml"
using Company.Project.Web;

#line default
#line hidden
#line 2 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\_ViewImports.cshtml"
using Company.Project.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82727e1b26e61cc8918854ae6a735eee32b175a5", @"/Views/Home/InvitedEvents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c02771b3bf5c583f55fe47d163deb1c41c26a926", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_InvitedEvents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Company.Project.Web.Models.CombinedModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 11, true);
            WriteLiteral("\r\n\r\n<div>\r\n");
            EndContext();
#line 5 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
     foreach (var item in Model.eventWithComment)
    {
        string s = item.startTime;
        string s1 = s.Split(' ')[0].Replace(":", "");
        int itemTime = int.Parse(s1);

        string s2 = DateTime.Now.ToString("HH:mm").Replace(".", "");
        int realTime = int.Parse(s2);

        string year = item.date.ToString("Y");
        string date = item.date.ToString("dd");
        string dateYear = date + " " + year;


#line default
#line hidden
            BeginContext(506, 166, true);
            WriteLiteral("        <div class=\"card\" style=\"width: auto; border-radius:0px\">\r\n            <div class=\"card-body\" style=\"padding:10px\">\r\n                <h5><a class=\"card-title\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 672, "\"", 728, 1);
#line 20 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
WriteAttributeValue("", 679, Url.Action("Event", "Home", new { Id = item.Id}), 679, 49, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(729, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(731, 40, false);
#line 20 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                                                                                              Write(Html.DisplayFor(modelItem => item.title));

#line default
#line hidden
            EndContext();
            BeginContext(771, 78, true);
            WriteLiteral("</a></h5>\r\n                <h6 class=\"card-subtitle mb-2 text-body-secondary\">");
            EndContext();
            BeginContext(850, 38, false);
#line 21 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                                                              Write(Html.DisplayFor(modelItem => dateYear));

#line default
#line hidden
            EndContext();
            BeginContext(888, 77, true);
            WriteLiteral("</h6>\r\n                <p class=\"card-text\" style=\"margin:0px\"><b>Time:</b>  ");
            EndContext();
            BeginContext(966, 44, false);
#line 22 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                                                                 Write(Html.DisplayFor(modelItem => item.startTime));

#line default
#line hidden
            EndContext();
            BeginContext(1010, 60, true);
            WriteLiteral("</p>\r\n                <p class=\"card-text\"><b>Location:</b> ");
            EndContext();
            BeginContext(1071, 43, false);
#line 23 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                                                 Write(Html.DisplayFor(modelItem => item.location));

#line default
#line hidden
            EndContext();
            BeginContext(1114, 43, true);
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
            EndContext();
            BeginContext(1158, 46, false);
#line 24 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                                Write(Html.DisplayFor(modelItem => item.description));

#line default
#line hidden
            EndContext();
            BeginContext(1204, 61, true);
            WriteLiteral("</p>\r\n                <p class=\"card-text\"> <b>Duration:</b> ");
            EndContext();
            BeginContext(1266, 43, false);
#line 25 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.duration));

#line default
#line hidden
            EndContext();
            BeginContext(1309, 51, true);
            WriteLiteral(" hr</p>\r\n                <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1360, "\"", 1416, 1);
#line 26 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
WriteAttributeValue("", 1367, Url.Action("Event", "Home", new { Id = item.Id}), 1367, 49, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1417, 18, true);
            WriteLiteral(">See details</a>\r\n");
            EndContext();
#line 27 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                 using (Html.BeginForm("Index", "Home", FormMethod.Post, new { Mymodel = Model.comment }))
                {

#line default
#line hidden
            BeginContext(1562, 208, true);
            WriteLiteral("                    <div class=\"form-group form-group-lg\" style=\"padding:10px; padding-left:0px\">\r\n                        <p style=\"font-size:14px;margin:0px\"><b> Comments:-</b></p>\r\n                        ");
            EndContext();
            BeginContext(1771, 84, false);
#line 31 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                   Write(Html.TextBoxFor(Mymodel => Mymodel.comment.comment, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1855, 30, true);
            WriteLiteral("\r\n                    </div>\r\n");
            EndContext();
            BeginContext(1887, 133, true);
            WriteLiteral("                    <div class=\"form-group\" style=\"height:0px;width:0px\">\r\n                        <input type=\"hidden\" name=\"itemId\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2020, "\"", 2036, 1);
#line 35 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
WriteAttributeValue("", 2028, item.Id, 2028, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2037, 33, true);
            WriteLiteral(" />\r\n                    </div>\r\n");
            EndContext();
#line 37 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                    if (User.Identity.IsAuthenticated)
                    {

#line default
#line hidden
            BeginContext(2149, 113, true);
            WriteLiteral("                        <input type=\"submit\" value=\"Send\" style=\"margin-bottom:10px\" class=\"btn btn-primary\" />\r\n");
            EndContext();
#line 40 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(2334, 122, true);
            WriteLiteral("                        <input type=\"submit\" value=\"Send\" style=\"margin-bottom:10px\" class=\"btn btn-primary disabled\" />\r\n");
            EndContext();
#line 44 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(2498, 151, true);
            WriteLiteral("                <p class=\"card-text\" style=\"font-size:14px\"> <b>Past Comments:-</b></p>\r\n                <div style=\"max-height:200px;overflow:auto\">\r\n");
            EndContext();
#line 48 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                     for (int i = 0; i < item.comments.Count; i++)
                    {

#line default
#line hidden
            BeginContext(2740, 209, true);
            WriteLiteral("                        <div class=\"card mb-2\">\r\n                            <div class=\"card-body\" style=\"padding:5px\">\r\n                                <p class=\"small\" style=\"font-size:12px; margin:0px\"><b>");
            EndContext();
            BeginContext(2950, 51, false);
#line 52 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                                                                                  Write(Html.DisplayFor(modelItem => item.commenterName[i]));

#line default
#line hidden
            EndContext();
            BeginContext(3001, 80, true);
            WriteLiteral("</b> </p>\r\n                                <p style=\"font-size:16px;margin:0px\">");
            EndContext();
            BeginContext(3082, 46, false);
#line 53 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                                                                Write(Html.DisplayFor(modelItem => item.comments[i]));

#line default
#line hidden
            EndContext();
            BeginContext(3128, 74, true);
            WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 56 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
                    }

#line default
#line hidden
            BeginContext(3225, 64, true);
            WriteLiteral("                </div>\r\n\r\n\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 62 "C:\Users\hemantsingh02\hemant-singh\Company.Project\Company.Project\Web\Company.Project.Web\Views\Home\InvitedEvents.cshtml"
    }

#line default
#line hidden
            BeginContext(3296, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Company.Project.Web.Models.CombinedModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
