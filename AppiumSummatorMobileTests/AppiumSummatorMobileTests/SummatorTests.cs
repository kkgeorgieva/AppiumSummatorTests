using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumSummatorMobileTests
{
    public class SummatorTests
    {
        //Defining the driver

        private AndroidDriver<AndroidElement> driver;
        private AppiumOptions options ;
        private const string appiumUri = "http://127.0.0.1:4723/wd/hub";
        private const string appPath = @"C:\Users\georg\AppData\Local\Android\Sdk\platform-tools\com.example.androidappsummator.apk";

        [SetUp]
        public void StartApp()
        {
            this.options = new AppiumOptions() { PlatformName = "Android" };
            this.options.AddAdditionalCapability("app", appPath);
            // Adding device name in case of multiple available devices
            // options.AddAdditionalCapability("deviceName","5554");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            this.driver = new AndroidDriver<AndroidElement> (new Uri(appiumUri), options);
           
        }
        public void CloseApp()
        { 
        this.driver.Quit();
        }


        [Test]
        public void TestTwoPositiveNums()
        {
           //Arrange
           var field1 = driver.FindElementById("com.example.androidappsummator:id/editText1");
           var field2 = driver.FindElementById("com.example.androidappsummator:id/editText2");
           var sum = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
           var calcBtn = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
            //Act
            field1.SendKeys("5");
            field2.SendKeys("6");
            calcBtn.Click();

            //Assert
           var resutl = sum.Text;
           Assert.That(resutl, Is.EqualTo("11"));
        }
    }
}