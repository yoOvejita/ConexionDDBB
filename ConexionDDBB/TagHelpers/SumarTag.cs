using Microsoft.AspNetCore.Razor.TagHelpers;
namespace ConexionDDBB.TagHelpers
{
    [HtmlTargetElement("sumar", TagStructure = TagStructure.NormalOrSelfClosing)]
    // <sumar numero1="" numero2=""/>
    public class SumarTag : TagHelper
    {
        [HtmlAttributeName("numero1")]
        public double a { get; set; }
        [HtmlAttributeName("numero2")]
        public double b { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.Content.SetHtmlContent(string.Format("<h3>{0} + {1} = {2}</h3>", a, b, a+b));
        }
    }
}
