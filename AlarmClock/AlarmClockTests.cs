using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

namespace AlarmClock
{
    public class AlarmClockTests
    {

        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appIdentificator = "AntaraSoftware.AlarmClockHD_7jhd16s0b93qm!App";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions options;
        private string createdAlarm = "Early alarm";


        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability("app", appIdentificator);
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), options);

            

        }

        private void DeleteAlarm(string createdAlarm)
        {

            var deleteAlarm = driver.FindElementByAccessibilityId("BtnDeleteAlarm");
            deleteAlarm.Click();    
            
        }

        private bool IsAlarmPresent(string createdAlarm)
        {
            try
            {
                var presentAlarm = driver.FindElementByName("Early alarm");

                return presentAlarm != null;

            }

            catch (NoSuchElementException)
            {
                return false;

            }
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

            Thread.Sleep(3000);

            if (IsAlarmPresent(createdAlarm))
            {
                DeleteAlarm(createdAlarm);
            }
            Thread.Sleep(3000);

            var newAlarm = driver.FindElementByAccessibilityId("BtnAction"); 
            newAlarm.Click();

            Thread.Sleep(5000);

            var alarmTitle = driver.FindElementByName("Alarm Title");
            alarmTitle.Clear();
            alarmTitle.SendKeys("Early alarm");

            var alarmTime = driver.FindElementByAccessibilityId("FlyoutButton");
            alarmTime.Click();

            var sevenDigit = driver.FindElementByName("7");
            sevenDigit.Click();

            var arrowMinutesButton = driver.FindElementByAccessibilityId("MinuteLoopingSelector");
            var desiredMinutes = driver.FindElementByName("00");
            desiredMinutes.Click();

            Thread.Sleep(3000);

            var pmButton = driver.FindElementByName("AM");
            pmButton.Click();

            var acceptButton = driver.FindElementByAccessibilityId("AcceptButton");
            acceptButton.Click();

            Thread.Sleep(6000);

            

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementToBeClickable(arrowMinutesButton));

            //for (int i = 0; i <= 2; i++)
            //{
            //arrowMinutesButton.SendKeys(Keys.ArrowDown);
            //Thread.Sleep(500);
            //}

            //int targetMinutes = 00;
            //int currentMinutes;

            // Wait for the arrow button to be clickable
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementToBeClickable(arrowMinutesButton));

            // Continue looping until the current minutes match the target minutes
            //do
            //{
            //arrowMinutesButton.SendKeys(Keys.ArrowUp);
            //Thread.Sleep(500); // Add a small pause if needed
            //currentMinutes = GetCurrentMinutesValue();
            //} while (currentMinutes != targetMinutes);

            //private int GetCurrentMinutesValue()
            //{
            //var desiredMinutes = driver.FindElementByName("00");

            // Get the text content of the minutes text box and parse it as an integer
            //if (int.TryParse(desiredMinutes.Text, out int currentMinutes))
            //{
            //return currentMinutes;
            //}

            // Return a default value or throw an exception if parsing fails
            //return -1;

            //}

            var saveButton = driver.FindElementByAccessibilityId("BtnSave");
            saveButton.Click();

            Thread.Sleep(3000);

            var listAlarms = driver.FindElementByName("Early alarm");
            
            Assert.That(listAlarms.Text, Is.EqualTo("Early alarm"));  


        }





    }
}