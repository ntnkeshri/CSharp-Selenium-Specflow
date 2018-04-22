using System;
using System.Collections.Generic;
using System.Text;

namespace FirstAutomatedTestsProject.Tests.Tenants.YouTube.Pages
{
    public static class YouTubeAccountSettingsPage
    {

        public static Dictionary<string, string> ElementLocators = new Dictionary<string, string>()
        {
            {"notifications" , "li#creator-sidebar-section-id-account li:nth-child(4) > a" },
            {"subscription_via_dropdown" , "form#account-notifications-form div:nth-child(3) > span > select"},
            {"subscription_via_email_only_option" ,"#account-notifications-form > div:nth-child(6) > div:nth-child(3) > span > select > option:nth-child(3)"},
            {"subscription_via_dropdown_options" , "#account-notifications-form > div:nth-child(6) > div:nth-child(3) > span > select > option"},
            {"notification_only_send_radiobutton" , "form#account-notifications-form div:nth-child(2) > label > span > input[name='all-emails-radio-group']"},
            {"general_updates_checkbox" , "form#account-notifications-form div:nth-child(2) > div:nth-child(2) > div > label > span > input"},
           
        };

    }
}
