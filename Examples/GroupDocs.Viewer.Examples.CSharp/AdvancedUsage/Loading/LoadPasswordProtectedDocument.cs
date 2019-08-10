﻿using System;
using System.IO;
using GroupDocs.Viewer.Options;

namespace GroupDocs.Viewer.Examples.CSharp.AdvancedUsage.Loading
{
    /// <summary>
    /// This example demonstrates how to render password-protected document.
    /// </summary>
    class LoadPasswordProtectedDocument
    {
        public static void Run()
        {                       
            string outputDirectory = Constants.GetOutputDirectoryPath();
            string pageFilePathFormat = Path.Combine(outputDirectory, "page_{0}.html");
            string password = "12345";

            // Specify document password in load options
            GroupDocs.Viewer.Common.Func<LoadOptions> getLoadOptions = 
                () => new LoadOptions(FileType.DOCX, password);

            using (Viewer viewer = new Viewer(Constants.SAMPLE_DOCX_WITH_PASSWORD, getLoadOptions))
            {
                HtmlViewOptions options = HtmlViewOptions.ForEmbeddedResources(pageFilePathFormat);
                viewer.View(options);
            }

            Console.WriteLine($"\nSource document rendered successfully.\nCheck output in {outputDirectory}.");
        }
    }
}
