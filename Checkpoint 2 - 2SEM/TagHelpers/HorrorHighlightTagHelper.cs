using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Checkpoint_2___2SEM.TagHelpers
{
    [HtmlTargetElement("horror-highlight")]
    public class HorrorHighlightTagHelper : TagHelper
    {
        public string Genre { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";

            if (Genre?.Equals("Horror", StringComparison.OrdinalIgnoreCase) == true)
            {
                output.Attributes.SetAttribute("style", "color: red;");
            }

            output.Content.SetContent(output.Content.GetContent());
        }

    }
}
