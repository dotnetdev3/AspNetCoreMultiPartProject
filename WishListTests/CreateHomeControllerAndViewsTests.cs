﻿using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace WishListTests
{
    public class CreateHomeControllerAndViewsTests
    {
        [Fact(DisplayName = "Create the Home/Index View @create-index-view")]
        public void CreateIndexViewTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Views" + Path.DirectorySeparatorChar + "Home" + Path.DirectorySeparatorChar + "Index.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`Index.cshtml` was not found in the `Views" + Path.DirectorySeparatorChar + "Home` folder.");

            string file;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }
            string pattern = @"<\s?[hH]1\s?>\s?.*<\/\s?[hH]1\s?>";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`Index.cshtml` was found, but does not appear to contain both an openning and closing `h1` tag.");
        }

        [Fact(DisplayName = "Create the Shared/Error View @create-error-view")]
        public void CreateErrorViewTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Views" + Path.DirectorySeparatorChar + "Shared" + Path.DirectorySeparatorChar + "Error.cshtml";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`Error.cshtml` was not found in the `Views" + Path.DirectorySeparatorChar + "Shared` folder.");

            string file;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }
            string pattern = @"<\s?[pP]\s?>\s?(?i:An Error has occurred. Please Try again.)\s?<\/\s?[pP]\s?>";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`Error.cshtml` was found, but does not appear to contain both an openning and closing `p` tag containing the message 'An error has occurred. Please try again.'.");
        }

        [Fact]
        public void CreateHomeControllerTest()
        {
            // Get appropriate path to file for the current operating system
            var filePath = ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar + "WishList" + Path.DirectorySeparatorChar + "Controllers" + Path.DirectorySeparatorChar + "HomeController.cs";
            // Assert Index.cshtml is in the Views/Home folder
            Assert.True(File.Exists(filePath), "`HomeController.cs` was not found in the `Controllers` folder.");

            var controllerType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                              from type in assembly.GetTypes()
                              where type.Name == "HomeController"
                              select type).FirstOrDefault();

            var controller = Activator.CreateInstance(controllerType);
            var method = controllerType.GetMethod("Index");
            var result = (ViewResult)method.Invoke(controller,null);
            Assert.True(result.GetType() == typeof(ViewResult), "`HomeController.Index` did not return the correct type of `ActionResult`.");
            Assert.True(result.ViewName == "Index", "`HomeController.Index` returned a `ViewResult` but it was not the `Index` view.");

            method = controllerType.GetMethod("Error");
            result = (ViewResult)method.Invoke(controller, null);
            Assert.True(result.GetType() == typeof(ViewResult), "`HomeController.Error` did not return the correct type of `ActionResult`.");
            Assert.True(result.ViewName == "Index", "`HomeController.Error` returned a `ViewResult` but it was not the `Error` view.");
        }
    }
}
