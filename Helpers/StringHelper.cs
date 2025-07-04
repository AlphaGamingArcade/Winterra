﻿using HtmlAgilityPack;

namespace Winterra.Helpers
{
	public class StringHelper
	{
		public static string TruncateString(string input, int length, string suffix = "...")
		{
			if (string.IsNullOrEmpty(input) || input.Length <= length)
				return input;

			// Ensure the truncated part + suffix does not exceed the length
			int adjustedLength = Math.Max(0, length - suffix.Length);
			return input.Substring(0, adjustedLength) + suffix;
		}

		public static string ExtractImageSrc(string input)
		{
			if (string.IsNullOrEmpty(input))
				return string.Empty;

			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(input);

			var imgNode = htmlDoc.DocumentNode.SelectSingleNode("//img");
			string imageSrc = imgNode?.GetAttributeValue("src", "") ?? "";
			return string.IsNullOrWhiteSpace(imageSrc) ? string.Empty : imageSrc;
		}

		public static List<string> ExtractImageSrcList(string input)
		{
			var imageSources = new List<string>();

			if (string.IsNullOrEmpty(input))
				return imageSources;

			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(input);

			var imgNodes = htmlDoc.DocumentNode.SelectNodes("//img");

			if (imgNodes != null)
			{
				foreach (var img in imgNodes)
				{
					var src = img.GetAttributeValue("src", "");
					if (!string.IsNullOrWhiteSpace(src))
						imageSources.Add(src);
				}
			}

			return imageSources;
		}

		public static string ExtractFirstParagraph(string input)
		{
			if (string.IsNullOrEmpty(input))
				return string.Empty;

			var htmlDoc = new HtmlAgilityPack.HtmlDocument();
			htmlDoc.LoadHtml(input);

			// Get the first <p> node
			var pNode = htmlDoc.DocumentNode.SelectSingleNode("//p");

			// Extract its text
			return pNode?.InnerText.Trim() ?? string.Empty;
		}
	}
}
