
using System.Collections.Generic;

namespace FirstAutomatedTestsProject.Tests.Tenants.YouTube.Pages
{
    public static class YouTubeMainPage
    {
        public static Dictionary<string, string> ElementLocators = new Dictionary<string, string>()
        {
            {"search_field" , "input#search" },
            {"search_button" , "button#search-icon-legacy > yt-icon"},
            {"sign_in_button" ,"div#buttons yt-formatted-string#text"},
            {"user_name_field" , "input#identifierId"},
            {"user_name_next_button" , "div#identifierNext span"},
            {"pass_word_field" , "input[name='password']"},
            {"pass_word_next_button" , "div#passwordNext span"},
            {"account_image" , "button#avatar-btn img#img"},
            {"account_settings_button" , "div#sections yt-multi-page-menu-section-renderer:nth-child(2) > div#items > ytd-compact-link-renderer:nth-child(2) > a#endpoint > paper-item > yt-formatted-string#label"},
            {"upload_button" , "div#buttons ytd-button-renderer > a > yt-icon-button#button > button#button > yt-icon"},
            {"upload_area" , "div#upload-prompt-box div:nth-child(2) > input[type='file']"},
            {"search_result_1st_image" , "#img" },
       

        };

        public static string MainURL = "https://www.youtube.com/";

        
    }
}
