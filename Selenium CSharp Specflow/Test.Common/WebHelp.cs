using FirstAutomatedTestsProject.Test.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace FirstAutomatedTestsProject.Test.Common
{
    public static class WebHelp
    {

        public static IWebDriver WebDriver = null;

        public static void StartWebDriver(string browserName)
        {
            Console.WriteLine("Starting webdriver" + browserName + " from "+   SetUp.driverPath);

            switch (browserName)
            {
                case "Chrome":
                    {
                        ChromeOptions chromeoptions = new ChromeOptions();
                        chromeoptions.AddArgument("--ignore-certificate-errors");
                        WebDriver = new ChromeDriver(SetUp.driverPath);
                        break;
                    }
                case "IE":
                    {
                        DesiredCapabilities capabilities = new DesiredCapabilities();
                        capabilities.SetCapability(CapabilityType.AcceptSslCertificates,true);
                        WebDriver = new InternetExplorerDriver(SetUp.driverPath);
                        break;
                    }
                case "FireFox":
                    {
                        WebDriver = new FirefoxDriver(SetUp.driverPath);
                        break;
                    }
                default: Console.WriteLine(browserName + "driver does not implemented in the startbrowser");
                    break;
            }

            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            WebDriver.Manage().Window.Maximize();

        }

        public static void StopWebDriver()
        {
            Console.WriteLine("Stopping webdriver");

            WebDriver.Close();
            WebDriver.Quit();
        }


        public static void NavigateTo(string URL)
        {
            try
            {
                WebDriver.Navigate().GoToUrl(URL);
                Console.WriteLine("Navigated to " + URL + "page");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }          
        }

        public static void WaitSomeSec(int wait)
        {
            try
            {
                Thread.Sleep(wait * 1000);
                Console.WriteLine("Waited for " + wait + "sec");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void WaitSomeSecUntil(int wait,string element)
        {
            try
            {
                var webdriverwait = new WebDriverWait(WebDriver,TimeSpan.FromSeconds(wait));
                webdriverwait.Until(ExpectedConditions.ElementExists(By.CssSelector(element)));
                webdriverwait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(element)));
                webdriverwait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(element)));
                Console.WriteLine("Waited for " + wait + "sec until");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void WaitSomeSecImplicitly(int wait)
        {
            try
            {
                WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
                Console.WriteLine("Waited for " + wait + "sec implititly");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static bool isDisplayed(string elementLocator)
        {
            try
            {
                IWebElement WebElement = WebDriver.FindElement(By.CssSelector(elementLocator));
                return (WebElement.Displayed  || WebElement.Enabled);
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
            catch (InvalidElementStateException ex)
            {
                return false;
            }
            catch (StaleElementReferenceException ex)
            {
                return false;
            }
            catch (TargetInvocationException ex)
            {
                return false;
            }
        }

        public static bool WaitToAppear(string elementLocator)
        {
            int startTime = 0;
            int waitTime = 200;
            int maxTime = 20000;
            while (startTime < maxTime)
            {
                if (isDisplayed(elementLocator))             
                    return true;
                Thread.Sleep(waitTime);
                startTime = startTime + waitTime;
            }
            Console.WriteLine("Element with locator " + elementLocator + "did not Appear in " + maxTime/1000 + "secs");
            return false;
        }

        public static bool WaitToDisppear(string elementLocator)
        {
            int startTime = 0;
            int waitTime = 250;
            int maxTime = 10000;
            while (startTime < maxTime)
            {
                if (!(isDisplayed(elementLocator)))             
                    return true;              
                Thread.Sleep(waitTime);
                startTime = startTime + waitTime;
            }
            Console.WriteLine("Element with locator " + elementLocator + "did not Disappear in " + maxTime/1000 + "secs");
            return false;
        }

        public static void SelectWebElement(string ElementName)
        {
            try
            {
                SafeSelectWebelement(ElementName, "click");
                Console.WriteLine("Selected the element with name " + ElementName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SelectFromDropDownByClick(string DropDownName, string OptionName)
        {
            try
            {
                string DropDownLocator = AllPages.getElementLocator(DropDownName);
                string OptionLocator = AllPages.getElementLocator(OptionName);
                SelectWebElement(DropDownLocator);
                SelectWebElement(OptionLocator);
                Console.WriteLine("Selected the element with locator " + OptionLocator + " from dropdown with locator " + DropDownLocator  );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SelectFromDropDownByText(string DropDownName, string OptionsLocator, string OptionText)
        {
            try
            {
                string DropDownLocator = AllPages.getElementLocator(DropDownName);
                SelectWebElement(DropDownLocator);

                IList<IWebElement> Options = WebDriver.FindElements(By.CssSelector(OptionsLocator));

                foreach (var Option in Options)
                {
                    if (Option.Text == OptionText)
                        Option.Click();
                }
                
                Console.WriteLine("Selected the element with text " + OptionText + " from dropdown with locator " + DropDownLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SelectFromDropDownBySelect(string OptionText, string DropDownName)
        {
            try
            {
                string DropDownLocator = AllPages.getElementLocator(DropDownName);
                IWebElement DropDown = WebDriver.FindElement(By.CssSelector(DropDownLocator));
                SelectElement Select = new SelectElement(DropDown);

                Select.SelectByText(OptionText);

                Console.WriteLine("Selected the element with text " + OptionText + " from dropdown with locator " + DropDownLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SelectRadioButton(string RadioButtonName)
        {
            try
            {
                string RadioButtonLocator = AllPages.getElementLocator(RadioButtonName);
                SelectWebElement(RadioButtonLocator);
                IWebElement RadioButton = WebDriver.FindElement(By.CssSelector(RadioButtonLocator));
                if (RadioButton.GetAttribute("checked") == "checked")
                    Console.WriteLine("Checked");
                else Console.WriteLine("UnChecked");
                Console.WriteLine("Selected the RadioButton with locator " + RadioButtonLocator );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SelectCheckBox(string CheckBoxName)
        {
            try
            {
                string CheckBoxLocator = AllPages.getElementLocator(CheckBoxName);
                SelectWebElement(CheckBoxLocator);
                IWebElement RadioButton = WebDriver.FindElement(By.CssSelector(CheckBoxLocator));
                if (RadioButton.Selected)
                    Console.WriteLine("Selected");
                else Console.WriteLine("UnSelected");
                Console.WriteLine("Selected the CheckBox with locator " + CheckBoxLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SafeSelectWebelement(string ElementName, string Action)
        {
            try
            {
                string ElementLocator = AllPages.getElementLocator(ElementName);
                WaitToAppear(ElementLocator);
                IWebElement WebElement = WebDriver.FindElement(By.CssSelector(ElementLocator));

                if (Action == "click")
                    WebElement.Click();
                else
                {                
                    if (Action == "safeclick")
                        WebElement.Click();
                    if (Action == "enter")
                        WebElement.SendKeys(Keys.Enter);
                    if (Action == "return")
                        WebElement.SendKeys(Keys.Return);
                }
                Console.WriteLine("Selected the element with locator" + ElementLocator + " with " + Action);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void EnterInToWebelement( string Entry, string ElementName)
        {
            try
            {
                string ElementLocator = AllPages.getElementLocator(ElementName);
                WaitToAppear(ElementLocator);
                IWebElement WebElement = WebDriver.FindElement(By.CssSelector(ElementLocator));

                WebElement.SendKeys(Entry);
                Console.WriteLine(Entry + " entered into the element with locator " + ElementLocator );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static string ReadFromWebelement(string ElementName, string Attribute)
        {
            string Text = "";
            try
            {
                string ElementLocator = AllPages.getElementLocator(ElementName);
                WaitToAppear(ElementLocator);
                IWebElement WebElement = WebDriver.FindElement(By.CssSelector(ElementLocator));
               
                if (Attribute == "text")
                    Text = WebElement.Text;
                if (Attribute == "attributetext")
                    Text = WebElement.GetAttribute("text");
                if (Attribute == "attributevalue")
                    Text = WebElement.GetAttribute("value");
                Console.WriteLine(Text + " read from element with locator " + ElementLocator);

                return Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Text;
            }
        }

        public static void Navigate(string Navigate)
        {
            try
            {
                if (Navigate == "back")
                WebDriver.Navigate().Back();
                if (Navigate == "forward")
                    WebDriver.Navigate().Forward();
                Console.WriteLine("Navigated " + Navigate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void UploadFile(string FilePath, string ElementName)
        {
            try
            {
                string ElementLocator = AllPages.getElementLocator(ElementName);
                WebDriver.FindElement(By.CssSelector(ElementLocator)).SendKeys(FilePath);
                Console.WriteLine("Uploaded the file with path " + FilePath + " to element with locator " + ElementLocator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void HandleAlert(string Action)
        {
            try
            {
                if (Action == "Accept")
                    WebDriver.SwitchTo().Alert().Accept();
                if (Action == "Dismiss")
                    WebDriver.SwitchTo().Alert().Dismiss();
                Console.WriteLine("Alert has been  " + Action + "ed ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void HandleWindow(string WindowPosition)
        {
            try
            {
                if (WindowPosition == "NewWindow")
                {
                    string NewWindow = WebDriver.WindowHandles.Last();
                    WebDriver.SwitchTo().Window(NewWindow);
                }
                if (WindowPosition == "PreviousWindow")
                {
                    string PreviousWindow = WebDriver.WindowHandles.First();
                    WebDriver.SwitchTo().Window(PreviousWindow);
                }

                Console.WriteLine("Swiched to  " + WindowPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public static string GetDynamicDate(double Days, string Pattern)
        {
            string GeneratedDate = "";
            try
            {
                DateTime CurrentDate = DateTime.Now;
                GeneratedDate = CurrentDate.AddDays(Days).ToString(Pattern);
                Console.WriteLine("Generated date " + GeneratedDate);
                return GeneratedDate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return GeneratedDate;           
            }
        }

        public static void OnThePageOf(string PageName)
        {
            AllPages.CurrentPageName = PageName;
        }

        public static void ITakeSceenShot()
        {      
            var ScreenShotDriver = WebDriver as ITakesScreenshot;
            var ScreenShot = ScreenShotDriver.GetScreenshot();
            string fullPath = SetUp.resultsPath + SetUp.resultName + DateTime.Now.ToString("yyyy-MM-ddHHmmss") + ".jpeg";
            Console.WriteLine(fullPath);
            ScreenShot.SaveAsFile(fullPath, ScreenshotImageFormat.Jpeg);
            WaitSomeSec(2);
        }
    }
}
