#pragma checksum "C:\Users\asharma2\Documents\ASPCore.BlazorDemo\BlazorDemo\BlazorDemo\Pages\Calculator.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f172d1af2621dfb23c5c2d465422d2ebba9989a"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorDemo.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Blazor;
    using Microsoft.AspNetCore.Blazor.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Blazor.Layouts;
    using Microsoft.AspNetCore.Blazor.Routing;
    using Microsoft.JSInterop;
    using BlazorDemo;
    using BlazorDemo.Shared;
    [Microsoft.AspNetCore.Blazor.Layouts.LayoutAttribute(typeof(MainLayout))]

    [Microsoft.AspNetCore.Blazor.Components.RouteAttribute("/calculator")]
    public class Calculator : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 52 "C:\Users\asharma2\Documents\ASPCore.BlazorDemo\BlazorDemo\BlazorDemo\Pages\Calculator.cshtml"
            
double operand1 { get; set; }
double operand2 { get; set; }
string finalResult { get; set; }
void AddNumbers()
{
    finalResult = (operand1 + operand2).ToString();
}
void SubtractNumbers()
{
    finalResult = (operand1 - operand2).ToString();
}
void MultiplyNumbers()
{
    finalResult = (operand1 * operand2).ToString();
}
void DivideNumbers()
{
    if (operand2 != 0)
    {
        finalResult = (operand1 / operand2).ToString();
    }
    else
    {
        finalResult = "Cannot Divide by Zero";
    }
}

#line default
#line hidden
    }
}
#pragma warning restore 1591