#pragma checksum "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "232d2978eb2e5a408206897d56b478aea6b75733"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Warehouse_Orders), @"mvc.1.0.view", @"/Views/Warehouse/Orders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"232d2978eb2e5a408206897d56b478aea6b75733", @"/Views/Warehouse/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc02168007f24d38038bd969e052ce5b5b2dcc80", @"/Views/_ViewImports.cshtml")]
    public class Views_Warehouse_Orders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Warehouse.ViewModels.OrdersViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
  
    ViewData["Title"] = "Orders";

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
    <h1 class=""col-md-12"">Заказы</h1>
</div>
<div class=""text-left"">
    <table style=""width:100%;"" class=""col-md-12"">
        <tr align=""center"">
            <td>Тип</td>
            <td>Плановое время</td>
            <td>Грузы</td>
        </tr>
");
#nullable restore
#line 26 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
         foreach (var order in Model.Orders)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr align=\"center\">\r\n        <td>");
#nullable restore
#line 29 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
       Write(order.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 30 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
       Write(order.ArrivalTime.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>\r\n");
#nullable restore
#line 32 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
             foreach (var cargo in order.Cargos)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>Номер заказа: ");
#nullable restore
#line 34 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
                            Write(cargo.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Количество паллет: ");
#nullable restore
#line 35 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
                                 Write(cargo.NumOfPalletes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Наименование продукции: ");
#nullable restore
#line 36 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
                                      Write(cargo.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 37 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\r\n    </tr>\r\n");
#nullable restore
#line 40 "C:\Users\lenovo\Desktop\Диплом\Алиев Александр\Программа\Warehouse\Warehouse\Views\Warehouse\Orders.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Warehouse.ViewModels.OrdersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591