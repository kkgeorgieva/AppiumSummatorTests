using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumSummatorTests
{
    public class NonPomTests
    {
        //Appium test project 

        private WindowsDriver <WindowsElement> driver;
        // Adding the url of the server we are going to use
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
      
        private AppiumOptions options;

        [SetUp]
        public void OpenApp()
        {

            this.options = new AppiumOptions();
            // The type of the platform that we will work on
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName,"Windows");
            // Location of the app that will be tested
            options.AddAdditionalCapability(MobileCapabilityType.App,
            @"C:\Users\georg\OneDrive\Desktop\Automation QA\SummatorDesktopApp.exe");
            // URI = Unified Recourse Identiificator
            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }

        [TearDown]
        public void CloseApp() 
        {
            this.driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNums()
        {
            //Arrange

            //First field
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            // var num1 =  driver.FindElement(By.Id("textBoxFirstNum")); => find element in web app 
            num1.Click();
            // First positive number
            num1.SendKeys("5");


            //Second field
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            //Second positive number    
            num2.SendKeys("15");

            //Calculate Button
            var calcBtn = driver.FindElementByAccessibilityId("buttonCalc");
            calcBtn.Click();

            //Assert the result
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;
            Assert.That(result, Is.EqualTo("20"));


        }
        [Test]
        public void Test_Sum_Invalid_Values()
        {
            //Arrange

            //First field
            var num1 = driver.FindElementByAccessibilityId("textBoxFirstNum");
            // var num1 =  driver.FindElement(By.Id("textBoxFirstNum")); => find element in web app 
            num1.Click();
            // First positive number
            num1.SendKeys("invalid1");


            //Second field
            var num2 = driver.FindElementByAccessibilityId("textBoxSecondNum");
            num2.Click();
            //Second positive number    
            num2.SendKeys("invalid2");

            //Calculate Button
            var calcBtn = driver.FindElementByAccessibilityId("buttonCalc");
            calcBtn.Click();

            //Assert the result
            var result = driver.FindElementByAccessibilityId("textBoxSum").Text;
            Assert.That(result, Is.EqualTo("error"));


        }
    }
}
    
