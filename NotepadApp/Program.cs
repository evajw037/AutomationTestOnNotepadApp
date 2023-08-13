using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WindowsDriver<WindowsElement> notPadSession;
            AppiumOptions appium = new AppiumOptions();
            appium.AddAdditionalCapability("app", @"C:\Windows\System32\Notepad.exe");
            notPadSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/"),appium);
            if (notPadSession == null)
            {
                Console.WriteLine("App not started");
                return;
            }
            Console.WriteLine($"Application title:{notPadSession.Title}");
            notPadSession.Manage().Window.Maximize();
            var screenshot = notPadSession.GetScreenshot();

            screenshot.SaveAsFile($".\\Screenshot{DateTime.Now.ToString("ddMMyyyyhhmmss")}", OpenQA.Selenium.ScreenshotImageFormat.Png);

            notPadSession.Quit();
           
        
        
        }
    }
}
