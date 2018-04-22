using FirstAutomatedTestsProject.Tests.Tenants.YouTube.Pages;
using System;

namespace FirstAutomatedTestsProject.Test.Steps
{
    public static class AllPages
    {

        public static string CurrentPageName = null;
        public static string CurrentAppName = null;

        public static string getElementLocator(string ElementName)
        {
            string elementLocator = null;

            CurrentAppName = "YouTube";

            switch (CurrentAppName)
            {
                case "YouTube":
                    {
                        elementLocator = getYouTubeElementLocator(ElementName);
                        return elementLocator;
                    }
                case "Google":
                    {
                        elementLocator = getGoogleElementLocator(ElementName);
                        return elementLocator;
                    }
                default:
                    {
                        Console.WriteLine("No such a tenant");
                        return elementLocator;
                    }
            }
        }

        public static string getYouTubeElementLocator(string ElementName)
        {

            switch (CurrentPageName)
            {
                case "YouTubeMainPage":
                    {
                        return YouTubeMainPage.ElementLocators[ElementName];
                    }
                case "YouTubeAccountSettingsPage":
                    {
                        return YouTubeAccountSettingsPage.ElementLocators[ElementName];
                    }
                default:
                    {
                        Console.WriteLine("No such a tenant");
                        return null ;
                    }
            }
        }

        public static string getGoogleElementLocator(string ElementName)
        {
            return null;
        }




    }
}
