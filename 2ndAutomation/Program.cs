using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2ndAutomation
{
    internal class Program
    {
        IWebDriver driver = new ChromeDriver();
        string ExpectedResult = "User successfully registered.";
        
        static void Main(string[] args)
        {

        }
        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://demo.wpeverest.com/user-registration/guest-registration-form/");
            driver.Manage().Window.Maximize();

        }
        [Test]
        public void Test()
        {

            IWebElement inputFname = driver.FindElement(By.CssSelector("#first_name"));
            //Below Code Is For Stimulating Each Key
            //stimulateEachKey(inputFname, "Owen Patrick");
            inputFname.SendKeys("Owen Patrick");//Input First Name

            IWebElement inputLname = driver.FindElement(By.CssSelector("#last_name"));
            inputLname.SendKeys("Espadilla");//Input Last Name

            IWebElement email = driver.FindElement(By.XPath("//input[@id='user_email']"));
            email.SendKeys("akhdfkqahdkjahk@gmail.com");//Input Email

            IWebElement gender = driver.FindElement(By.CssSelector("#radio_1665627729_Male"));
            gender.Click();//Clicking Gender

            IWebElement passw = driver.FindElement(By.XPath("//input[@id='user_pass']"));
            passw.SendKeys("@L03124gs");//Input Password

            IWebElement clickDate = driver.FindElement(By.XPath("//input[@data-id='date_box_1665628538']"));
            clickDate.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//body/div[5]")));
            IWebElement month = driver.FindElement(By.XPath("//body/div[5]/div[1]/div[1]/div[1]/select[1]"));
            var selectmonth = new SelectElement(month);
            selectmonth.SelectByValue("8");
            IWebElement year = driver.FindElement(By.XPath("//body/div[5]/div[1]/div[1]/div[1]/div[1]/input[1]"));
            year.Clear();
            year.SendKeys("2001");
            IWebElement day = driver.FindElement(By.XPath("//body/div[5]/div[2]/div[1]/div[2]/div[1]/span[23]"));
            day.Click();//Selecting Specific Date

            IWebElement dropdown = driver.FindElement(By.Id("country_1665629257"));
            SelectElement select = new SelectElement(dropdown);
            select.SelectByValue("PH"); // Selects from Dropdown Country

            IWebElement phoneInput = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/div[1]/div[1]/div[1]/article[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[2]/p[1]/input[1]"));
            phoneInput.SendKeys("9662632718");// Input Phone

            //Simulate typing according to the input
            //stimulateEachKey(phoneInput, "9662632718");

            IWebElement emergencyphone = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/div[1]/div[1]/div[1]/article[1]/div[1]/div[1]/form[1]/div[2]/div[1]/div[3]/p[1]/input[1]"));
            emergencyphone.SendKeys("9662632718");//Input Emergency Number

            IWebElement inputElement = driver.FindElement(By.Id("input_box_1665629217"));
            inputElement.Clear();
            inputElement.SendKeys("Filipino");//Input Nationality

            IWebElement ArrivalDate = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/main[1]/div[1]/div[1]/div[1]/article[1]/div[1]/div[1]/form[1]/div[3]/div[1]/div[1]/div[1]/span[1]/input[1]"));
            ArrivalDate.Click();
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait1.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//body[1]/div[6]")));
            IWebElement datetoday = driver.FindElement(By.XPath("//body[1]/div[6]/div[2]/div[1]/div[2]/div[1]/span[19]"));
            datetoday.Click();// Click Specific Date in Arrival Date

            IWebElement numofDays = driver.FindElement(By.Id("number_box_1665629930"));
            numofDays.SendKeys("12");//Input No of Days

            IWebElement RoomBedNum = driver.FindElement(By.XPath("//input[@data-id='input_box_1665630010']"));
            RoomBedNum.SendKeys("4");//Input No of Room

            IWebElement textarea = driver.FindElement(By.XPath("//textarea[@data-id='textarea_1665630078']"));
            textarea.SendKeys("Im inlove with your body");//Input in text area

            IWebElement ParkingBut = driver.FindElement(By.XPath("//input[@id='radio_1665627931_Yes']"));
            ParkingBut.Click();//Click Parking

            IWebElement TypeOFRoom = driver.FindElement(By.XPath("//input[@id='radio_1665627997_Shared Room']"));
            TypeOFRoom.Click();// Click Type Of Room

            IWebElement DIetary = driver.FindElement(By.Id("radio_1665628131_None"));
            DIetary.Click();// click Type Of food

            IWebElement AttendType = driver.FindElement(By.Id("select_1665628361"));
            SelectElement selectattend = new SelectElement(AttendType);
            selectattend.SelectByValue("Town Hall");// Select Type of attend
            IWebElement checkbox = driver.FindElement(By.Id("privacy_policy_1665633140"));

            // Click the checkbox if it's not already selected
            if (!checkbox.Selected)
            {
                checkbox.Click();}//click Privacy policy

            IWebElement Submit = driver.FindElement(By.XPath("//body[1]/div[1]/main[1]/div[1]/div[1]/div[1]/article[1]/div[1]/div[1]/form[1]/div[4]/button[1]"));
            Submit.Click();//Click Submit Button

            WebDriverWait WaitSubmit = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            WaitSubmit.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//*[@id=\"ur-submit-message-node\"]")));
            IWebElement element = driver.FindElement(By.Id("ur-submit-message-node"));

            // Get the text of the element
            string ActualResult = element.Text;
            //Note If You Already Register the Inputted details the test will failed because of the assert code
            ClassicAssert.AreEqual(ExpectedResult, ActualResult);//Assert If success Register
            


        }
        //method Simulate typing according to the input
        static void stimulateEachKey(IWebElement element, string keys)
        {
            foreach (char c in keys)
            {
                // Simulate typing each character
                element.SendKeys(c.ToString());
                // Wait for a short time (adjust as needed)
                Thread.Sleep(100);
            }
        }
        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }
    }
}
