#pragma checksum "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52c4d6777f4235d26792e3fa38604f6f00bfef19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Expiration), @"mvc.1.0.view", @"/Views/Report/Expiration.cshtml")]
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
#line 1 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\_ViewImports.cshtml"
using Warehouse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\_ViewImports.cshtml"
using Warehouse.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52c4d6777f4235d26792e3fa38604f6f00bfef19", @"/Views/Report/Expiration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc02168007f24d38038bd969e052ce5b5b2dcc80", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_Expiration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
  
    ViewData["Title"] = "Отчет по срокам годности товаров";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style type=""text/css"">
    TABLE {
        border: 1px solid black;
    }

    TR {
        padding: 3px;
        border: 1px solid black;
    }
</style>
<div class=""text-center"">
    <h1 class=""col-md-12"">Продукция</h1>
</div>
<div class=""text-left"">
    <table style=""width:100%;"" class=""col-md-12"">
        <tr align=""center"">
            <td>Наименование</td>
            <td></td>
            <td></td>
        </tr>
");
#nullable restore
#line 25 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
         foreach (var storage in ViewBag.Storages)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr align=\"center\">\r\n                <td>");
#nullable restore
#line 28 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
               Write(storage.Territory);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 28 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                                   Write(storage.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
             foreach (var place in storage.Places)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr align=\"center\">\r\n                    <td></td>\r\n                    <td></td>\r\n                    <td></td>\r\n                </tr>\r\n");
#nullable restore
#line 38 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                 foreach (var product in place.Products)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr align=\"center\">\r\n                        <td>");
#nullable restore
#line 41 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                       Write(product.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 41 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                                     Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 41 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                                                   Write(product.Party);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 41 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                                                                  Write(product.Term);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 41 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                                                                                Write(product.NumOfPalletes);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 41 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                                                                                                       Write(product.BoxesInPallete);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </td>\r\n                        <td></td>\r\n                        <td></td>\r\n                    </tr>\r\n");
#nullable restore
#line 45 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Report\Expiration.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>");
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
