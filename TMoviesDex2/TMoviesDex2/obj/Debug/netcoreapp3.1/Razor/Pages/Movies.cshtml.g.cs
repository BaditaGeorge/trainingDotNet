#pragma checksum "C:\Users\Gogu\source\TMoviesDex2\TMoviesDex2\TMoviesDex2\Pages\Movies.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be70298287099e410c97655391e034fcddffb2a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TMoviesDex2.Pages.Pages_Movies), @"mvc.1.0.razor-page", @"/Pages/Movies.cshtml")]
namespace TMoviesDex2.Pages
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
#line 1 "C:\Users\Gogu\source\TMoviesDex2\TMoviesDex2\TMoviesDex2\Pages\_ViewImports.cshtml"
using TMoviesDex2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Gogu\source\TMoviesDex2\TMoviesDex2\TMoviesDex2\Pages\_ViewImports.cshtml"
using DevExtreme.AspNet.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be70298287099e410c97655391e034fcddffb2a2", @"/Pages/Movies.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e00a9d73fc52d70c58e86d0ab89c5eee34549ef", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Movies : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Gogu\source\TMoviesDex2\TMoviesDex2\TMoviesDex2\Pages\Movies.cshtml"
  
    ViewData["Title"] = "Movies";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    function show() {\r\n        alert(\"View Details!\");\r\n    }\r\n</script>\r\n\r\n<h2>Movies</h2>\r\n\r\n");
#nullable restore
#line 14 "C:\Users\Gogu\source\TMoviesDex2\TMoviesDex2\TMoviesDex2\Pages\Movies.cshtml"
Write(Html.DevExtreme().DataGrid<TMoviesDex2.Models.Movie>()
    .DataSource(ds => ds.Mvc()
        .Controller("Movie")
        .LoadAction("Get")
        .InsertAction("Post")
        .UpdateAction("Put")
        .DeleteAction("Delete")
        .Key("Id")
    )
    .RemoteOperations(true)
    .Columns(columns => {

    columns.AddFor(m => m.Title);

    columns.AddFor(m => m.Release);

    columns.AddFor(m => m.Budget);

    columns.Add().Type(GridCommandColumnType.Buttons).Buttons(b =>
    {
        b.Add().Name(GridColumnButtonName.Edit).Icon("edit");
        b.Add().Name(GridColumnButtonName.Delete).Icon("trash");
        b.Add().Text("View").Icon("link").OnClick(item => new global::Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_template_writer) => {
    PushWriter(__razor_template_writer);
    WriteLiteral("show");
    PopWriter();
}
));
    }).Width(200);

    

        
    })
    .Editing(e => e
        .AllowAdding(true)
        .AllowUpdating(true)
        .AllowDeleting(true)
    )
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_Movies> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Movies> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Movies>)PageContext?.ViewData;
        public Pages_Movies Model => ViewData.Model;
    }
}
#pragma warning restore 1591
