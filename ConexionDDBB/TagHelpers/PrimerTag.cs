using Microsoft.AspNetCore.Razor.TagHelpers;
namespace ConexionDDBB.TagHelpers
{
    [HtmlTargetElement("primer", TagStructure =TagStructure.NormalOrSelfClosing)] // <primer/>
    public class PrimerTag : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.Content.SetHtmlContent("<center><h3>Primer tag</h3></cener>");
        }
    }
}
