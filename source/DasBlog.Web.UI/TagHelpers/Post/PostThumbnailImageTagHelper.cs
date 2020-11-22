using DasBlog.Web.Models.BlogViewModels;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;


namespace DasBlog.Web.TagHelpers.Post
{
	public class PostThumbnailImageTagHelper : TagHelper
	{
		public PostViewModel Post { get; set; }

		public string Css { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";
			output.TagMode = TagMode.StartTagAndEndTag;
			if (!string.IsNullOrEmpty(Css))
			{
				output.Attributes.SetAttribute("class", Css);
			}
			output.Attributes.SetAttribute("style", $"background-image: url('{Post.ImageUrl}');");
		}

		public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			return Task.Run(() => Process(context, output));
		}
	}
}
