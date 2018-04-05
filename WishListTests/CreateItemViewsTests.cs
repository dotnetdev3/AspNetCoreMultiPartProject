﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace WishListTests
{
    public class CreateItemViewsTests
    {
        [Fact(DisplayName = "Add Tag Helper Support @add-tag-helper-support")]
        public void AddTagHelperSupportTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Views" + Path.DirectorySeparatorChar + "_ViewImports.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`_ViewImports.cshtml` was not found in the `Views` folder.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }
            Assert.True(file.Contains(@"@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers"), "`_ViewImports.cshtml` was found, but does not appear to contain `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers`.");
        }

        [Fact(DisplayName = "Add Base Layout @add-base-layout")]
        public void AddBaseLayoutTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Views" + Path.DirectorySeparatorChar + "_ViewStart.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`_ViewStart.cshtml` was not found in the `Views` folder.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }
            var pattern = @"@{\s?Layout\s?=\s?""_Layout""\s?;\s?}";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), @"`_ViewStart.cshtml` was found, but does not appear to contain `@{ Layout = ""_Layout""; }`.");
        }

        [Fact(DisplayName = "Create Item's Index View @create-items-index-view")]
        public void CreateItemsIndexView()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Views" + Path.DirectorySeparatorChar + "Item" + Path.DirectorySeparatorChar + "Index.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`Index.cshtml` was not found in the `Views" + Path.DirectorySeparatorChar + "Item` folder.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }
            var pattern = @"@model\s*?List\s*?<\s*?Item\s*?>";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`Index.cshtml` was found, but does not appear to have a model of `List<Item>`.");
            pattern = @"<\s*?h1\s*?>\s*?Wishlist\s*?</\s*?h1\s*?>";
            rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`Index.cshtml` was found, but does not appear to have a include an opening and closing `h1` tag with a contents of 'Wishlist'");
            pattern = @"<\s*?[uU][lL]\s*?>\s*?@foreach[(]\s*?(var|Item)\s*item\s*in\s*Model\s*?[)]\s*?{\s*?<\s*?[lL][iI]\s*?>\s*?@item.Description\s*?<\s*?[aA](.*)\s*?>\s*?delete\s*?</\s*?[aA]\s*?>\s*?</\s*?[lL][iI]\s*?>\s*?}\s*?</\s*?[uU][lL]\s*?>";
            rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`Index.cshtml` was found, but does not appear to contain a `ul` with a `foreach` loop that provides the `item.Description` and a link to the `delete` action foreach item.");
            pattern = @"<\s*?[aA](\s*?.*)\s*?>\s*?delete";
            rgx = new Regex(pattern);
            var aTag = rgx.Match(file).Value;
            Assert.True(aTag.Contains(@"asp-action=""delete""") && aTag.Contains(@"asp-route-id=""@item.Id"""),"`Index.cshtml` contains an `a` tag, but that `a` tag does not appear to have both tag helpers `asp-action` set to 'delete' and `asp-route-id` set to `@item.Id`");
        }

        [Fact(DisplayName = "Create Create Partial View @create-create-partial-view")]
        public void CreateCreatePartialView()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Views" + Path.DirectorySeparatorChar + "Item" + Path.DirectorySeparatorChar + "_Create.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`_Create.cshtml` was not found in the `Views" + Path.DirectorySeparatorChar + "Item` folder.");

            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }
            var pattern = @"@model\s*Item";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`_Create.cshtml` was found, but does not appear to have a model of `Item`.");
            pattern = @"<\s*?[hH]3\s*?>\s*?Add item to wishlist\s*?</\s*?[hH]3\s*?>";
            rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`_Create.cshtml` was found, but does not appear to have a include an opening and closing `h3` tag with a contents of 'Add item to wishlist'");
            pattern = @"<\s*?form\s*asp-action\s*?=\s*?""create""\s*?>(\s*?.*)*?</\s*?form\s*?>";
            rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`_Create.cshtml` was found, but does not appear to contain a `form` with the attribute `asp-for` set to 'create'.");
            pattern = @"<\s*?form(\s*?.*)>(\s*?.*)<\s*?input\s*asp-for\s*?=\s*?""description""\s*?([/]>|>[/]s*?<[/]\s*?input\s*?>)(\s*?.*)*?<[/]\s*?form\s*?>";
            rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`_Create.cshtml` was found, but does not appear to contain a `form` containing an `input` tag with an attribute `asp-for` set to 'description'.");
            pattern = @"<\s*?form(\s*?.*)>(\s*?.*)<\s*?span\s*asp-validation-for\s*?=\s*?""description""\s*?([/]>|>[/]s*?<[/]\s*?span\s*?>)(\s*?.*)*?<[/]\s*?form\s*?>";
            rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`_Create.cshtml` was found, but does not appear to contain a `form` containing an `span` tag with an attribute `asp-validation-for` set to 'description'.");
            pattern = @"<\s*?form(\s*?.*)>(\s*?.*)<\s*?button\s*type\s*?=\s*?""submit""\s*?([/]>|>[/]s*?<[/]\s*?button\s*?>)(\s*?.*)*?<[/]\s*?form\s*?>";
            rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`_Create.cshtml` was found, but does not appear to contain a `form` containing an `button` tag with an attribute `type` set to 'submit'.");
        }
}
