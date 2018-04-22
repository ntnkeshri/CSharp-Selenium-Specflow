using FirstAutomatedTestsProject.Test.Common;
using FirstAutomatedTestsProject.Tests.Tenants.YouTube.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstAutomatedTestsProject
{
    public static class YouTubeSpecSteps
    {

        public static void SignIn()
        {
            WebHelp.SelectWebElement("sign_in_button");

            WebHelp.EnterInToWebelement("user_name_field", "kiszols@gmail.com");

            WebHelp.SelectWebElement("user_name_next_button");

            WebHelp.EnterInToWebelement("pass_word_field", "HelpingTesters");

            WebHelp.SelectWebElement("pass_word_next_button");

        }


    }
}
