#pragma checksum "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Storages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45ac55b33fad755afa6f40419cc224a0bb1bf265"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Warehouse_Storages), @"mvc.1.0.view", @"/Views/Warehouse/Storages.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45ac55b33fad755afa6f40419cc224a0bb1bf265", @"/Views/Warehouse/Storages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc02168007f24d38038bd969e052ce5b5b2dcc80", @"/Views/_ViewImports.cshtml")]
    public class Views_Warehouse_Storages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Warehouse.Models.Storage>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Storages.cshtml"
  
    ViewData["Title"] = "Storages";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style type=""text/css"">
    TABLE {
        border: 1px solid black; /* Рамка вокруг таблицы */
    }

    TR {
        padding: 3px; /* Поля вокруг содержимого ячеек */
        border: 1px solid black; /* Рамка вокруг таблицы */
    }
</style>
<div class=""text-center"">
    <h1 class=""col-md-12"">Продукция</h1>
</div>
<div class=""text-left"">
    <table style=""width:100%;"" class=""col-md-12"">
        <tr align=""center"">
            <td>Наименование</td>
            <td>Территория</td>
            <td>Город</td>
        </tr>
");
#nullable restore
#line 26 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Storages.cshtml"
         foreach (var storage in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr align=\"center\">\r\n                <td>");
#nullable restore
#line 29 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Storages.cshtml"
               Write(storage.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Storages.cshtml"
               Write(storage.Territory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Storages.cshtml"
               Write(storage.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Storages.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Warehouse.Models.Storage>> Html { get; private set; }
    }
}
#pragma warning restore 1591