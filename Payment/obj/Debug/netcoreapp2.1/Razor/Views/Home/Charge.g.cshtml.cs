#pragma checksum "C:\Users\Islam-Al Azhary\Source\Repos\Payment\Payment\Views\Home\Charge.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a38669b1ac86f61269595bb6aefc178773bdb9dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Charge), @"mvc.1.0.view", @"/Views/Home/Charge.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Charge.cshtml", typeof(AspNetCore.Views_Home_Charge))]
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
#line 1 "C:\Users\Islam-Al Azhary\Source\Repos\Payment\Payment\Views\_ViewImports.cshtml"
using Payment;

#line default
#line hidden
#line 2 "C:\Users\Islam-Al Azhary\Source\Repos\Payment\Payment\Views\_ViewImports.cshtml"
using Payment.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a38669b1ac86f61269595bb6aefc178773bdb9dc", @"/Views/Home/Charge.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ffbbdc5a55e63972bdf36c2eef71d4817708355", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Charge : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Islam-Al Azhary\Source\Repos\Payment\Payment\Views\Home\Charge.cshtml"
  
    ViewData["Title"] = "Charge";

#line default
#line hidden
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(46, 109, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae92798a9ea444a783fac72ad45a793b", async() => {
                BeginContext(52, 96, true);
                WriteLiteral("\r\n    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js\"></script>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(155, 959, true);
            WriteLiteral(@"
<h2>Charge</h2>

<div id=""FormContainer"" style=""margin-left: 25%; width: 50%;background-color: aqua;height: 400px;padding-top: 10px"">
   
   
        <div style=""margin-top: 100px;display: inline"">المبلغ المدفوع:</div>
        <div style=""margin-top: 100px;display: inline"">
            <input type=""text"" id=""amount"" value="""" class=""form-control"" style=""margin-top: 100px;width: 50%; margin-left:25%;display: inline"" />
        </div>
      
    
    <p>عدد النقاط المضافة لرصيدك</p>
    <div id=""Points"" style=""display: inline""></div>
    <input type=""button"" id=""btnAmount"" value=""دفع"" style=""margin-top: 120px;margin-left: 25%"" />
     نتيجه الطلب:<input type=""text"" id=""Result"" style=""margin-top: 150px;margin-left: 25%"" />
</div>
<script type=""text/javascript"">
    $(document).ready(function () {
        $(""#btnAmount"").click(function () {
       
           var amount= $(""#amount"").val();
             $.ajax({
        url: '");
            EndContext();
            BeginContext(1115, 35, false);
#line 31 "C:\Users\Islam-Al Azhary\Source\Repos\Payment\Payment\Views\Home\Charge.cshtml"
         Write(Url.Action("ChargeProcess", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(1150, 651, true);
            WriteLiteral(@"',
        dataType: ""json"",
        type: ""POST"",            
        cache: false,
        data: { amount: amount} ,
                 success: function (data) {
                     window.alert(data.Mobile);
                   //  $(""#Points"").val(data.Points);
                   //  $(""#Result"").val(data.StatusResponseObject.paymentStatus);
                    // window.alert(data.StatusDescription);
                   
          // var x= data.IsChargeCompletedSuccessfuly
           
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
});


        });
    });

</script>



");
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
