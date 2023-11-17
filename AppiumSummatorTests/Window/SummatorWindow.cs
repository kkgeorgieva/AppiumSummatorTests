using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using NUnit.Framework;

namespace AppiumSummatorTests.Window
{
  public class SummatorWindow
    {
        private   WindowsDriver<WindowsElement> driver;
        public SummatorWindow(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
        }
        
        //Finding the elements of the window
        public WindowsElement num1 => (WindowsElement)driver.FindElementByAccessibilityId("textBoxFirstNum");
        public WindowsElement num2 => (WindowsElement)driver.FindElementByAccessibilityId("textBoxSecondNum");
        public WindowsElement calcBtn => (WindowsElement)driver.FindElementByAccessibilityId("buttonCalc");
        public WindowsElement result => (WindowsElement)driver.FindElementByAccessibilityId("textBoxSum");

        //Method that calculates the sum of input in the two fields
        public string Calculate(string field1, string field2) 
        { 
            num1.Click();
            num1.SendKeys(field1);
            num2.Click();
            num2.SendKeys(field2);
            calcBtn.Click();
            return result.Text;
        }
    }
}
