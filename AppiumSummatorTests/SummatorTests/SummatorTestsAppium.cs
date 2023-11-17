using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppiumSummatorTests.Window;
using NUnit.Framework;

namespace AppiumSummatorTests.Tests
{
    public class SummatorTestsAppium
    {
        private WindowsDriver<WindowsElement> driver;
        // Adding the url of the server we are going to use
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";

        private AppiumOptions options;

        [SetUp]
        public void OpenApp()
        {

            this.options = new AppiumOptions();
            // The type of the platform that we will work on
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
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

        public WindowsDriver<WindowsElement> GetDriver()
        {
            return driver;
        }

        [TestCase("5","15","20")]
        [TestCase("10","20","30")]
        public void Test_Sum_PositiveNums_POM(string field1, string field2, string expected)
        {
            var window = new SummatorWindow(driver);
            string actual = window.Calculate(field1, field2);
            Assert.That(expected, Is.EqualTo(actual));
            Assert.That(expected, Is.EqualTo(actual));


        }
        [TestCase("-5","-5","-10")]
        [TestCase("-2","-3","-5")]
        public void Test_Sum_Negative_POM(string field1, string field2, string expected)
        {
            var window = new SummatorWindow(driver);
            string actual = window.Calculate(field1, field2);
            Assert.That(expected, Is.EqualTo(actual));
            Assert.That(expected, Is.EqualTo(actual));

        }
    }
}
