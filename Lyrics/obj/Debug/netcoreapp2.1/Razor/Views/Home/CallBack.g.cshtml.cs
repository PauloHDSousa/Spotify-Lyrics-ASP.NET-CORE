#pragma checksum "C:\Users\psousa\Documents\GitHub\Lyrics\Spotify-Lyrics-ASP.NET-CORE\Lyrics\Views\Home\CallBack.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63a2be68987a6ae4fdb3926c22af1eacd74ac09e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CallBack), @"mvc.1.0.view", @"/Views/Home/CallBack.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/CallBack.cshtml", typeof(AspNetCore.Views_Home_CallBack))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63a2be68987a6ae4fdb3926c22af1eacd74ac09e", @"/Views/Home/CallBack.cshtml")]
    public class Views_Home_CallBack : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Spotify.Model.Lyrics>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(36, 12, false);
#line 3 "C:\Users\psousa\Documents\GitHub\Lyrics\Spotify-Lyrics-ASP.NET-CORE\Lyrics\Views\Home\CallBack.cshtml"
Write(Model.Artist);

#line default
#line hidden
            EndContext();
            BeginContext(48, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(52, 11, false);
#line 3 "C:\Users\psousa\Documents\GitHub\Lyrics\Spotify-Lyrics-ASP.NET-CORE\Lyrics\Views\Home\CallBack.cshtml"
               Write(Model.Music);

#line default
#line hidden
            EndContext();
            BeginContext(63, 7, true);
            WriteLiteral("</h1>\r\n");
            EndContext();
            BeginContext(71, 26, false);
#line 4 "C:\Users\psousa\Documents\GitHub\Lyrics\Spotify-Lyrics-ASP.NET-CORE\Lyrics\Views\Home\CallBack.cshtml"
Write(Html.Raw(Model.LyricsHTML));

#line default
#line hidden
            EndContext();
            BeginContext(97, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Spotify.Model.Lyrics> Html { get; private set; }
    }
}
#pragma warning restore 1591
