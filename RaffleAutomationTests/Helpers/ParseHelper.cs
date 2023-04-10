using HtmlAgilityPack;
using RaffleAutomationTests.PageObjects.WebSitePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace RaffleAutomationTests.Helpers
{
    public class ParseHelper
    {
        private static string IgnoreLinkInHtml(string html)
        {
            // Find the link in the HTML code
            string pattern = $"<a.href=\"" + "(.+?)\"";
            string result = Regex.Replace(html, pattern, "<a href=" + "\"" + "link with token" + "\"", RegexOptions.IgnoreCase);
            pattern = "src=\"(.+?)\"";
            result = Regex.Replace(result, pattern, "src=" + "\"" + "link with token" + "\"", RegexOptions.IgnoreCase);
            pattern = "<td>(.+?)</td>";
            result = Regex.Replace(result, pattern, "<td>" + "</td>", RegexOptions.IgnoreCase);
            pattern = "<strong>Hi(.+?),";
            result = Regex.Replace(result, pattern, "<strong>Hi \"Name\",", RegexOptions.IgnoreCase);

            return result;
        }

        private static void CompareEmailWithTemplate(string html, string template)
        {
            
            string expectedText = template;
            string actualText = html;

            Assert.Multiple(() =>
            {
                Assert.That(actualText, Is.EqualTo(expectedText), "Texts don't match");
                Assert.That(expectedText.Length, Is.EqualTo(actualText.Length), "Number of elements doesn't match");

                var mismatchedIndices = expectedText.Select((text, index) => new { text, index })
                    .Where(item => !actualText[item.index].Equals(item.text))
                    .Select(item => item.index)
                    .ToList();

                if (mismatchedIndices.Count > 0)
                {
                    string errorMessage = $"Expected text does not match the actual text at index(es): {string.Join(", ", mismatchedIndices)}";
                    Assert.Fail(errorMessage);
                }
            });
        }

        public static void ParseHtmlAndCompare(string html, string template)
        {
            // Load HTML code into an HtmlDocument object
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            // Convert the modified HTML back to a string
            string parsedHtml = htmlDoc.DocumentNode.OuterHtml;

            //replase links
            parsedHtml = IgnoreLinkInHtml(parsedHtml);

            // Compare the parsed HTML with the template
            CompareEmailWithTemplate(parsedHtml, template);
            
        }



    }
}
