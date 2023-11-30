using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AlarmClock
{
    public class AlarmClockTests
    {

        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appIdentificator = "AntaraSoftware.AlarmClockHD_7jhd16s0b93qm!App";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability("app", appIdentificator);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), options);
            
        }

        [TearDown]

        public void CloseApp() 
        
        { 
            driver.Quit(); 
        
        } 

        [Test]
        public void Test_SetAlarm()
        {

            var setAlarm = driver.FindElementByAccessibilityId("BtnFullViewAlarms");
            setAlarm.Click();   

            var newAlarm = driver.FindElementByAccessibilityId("ButtonLabelText"); 
            newAlarm.Click();

         
        }
    }
}