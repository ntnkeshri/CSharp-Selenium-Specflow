
using System;
using System.IO;

namespace FirstAutomatedTestsProject.Test.Steps
{
    public static class SetUp
    {
        public static string projectPath = (Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\").Replace("\\bin\\Debug\\","");
        public static string driverPath = projectPath + "Selenium CSharp SpecFlow\\Test.Common\\Webdrivers\\";
        public static string resultsPath = projectPath + "TestResults\\";
        public static string resultName = "Selenium CSharp SpecFlow_Default" + DateTime.Now.ToString("yyyy-MM-ddHHmmss") + "_";
    }

}
