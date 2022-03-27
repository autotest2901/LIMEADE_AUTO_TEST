using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
  
namespace AutomationTestFramework {
  
	class TestSuite1 {
    	static void Main(string[] args)
   	 	{
            //Initiate data and elements
   	 		IWebDriver driver = new ChromeDriver();
            var loginURL = "https://staging.tinyserver.info/auth";

            var email = "vhtn291@gmail.com";
            var password = "P@ssword123";

            var emailFieldXpath = ".//input[@data-cucumber='input-login-email']";
            var passwordFieldXpath = ".//input[@data-cucumber='input-login-password']";

            var continueButonXpath = ".//div[@data-cucumber='button-continue']";
            var signinButonXpath = ".//div[@data-cucumber='button-login']";

            var settingMenuXpath = ".//li[@data-name='settings' and @data-cucumber='sitebar-item']";
            var addPeopleMenuXpath = ".//span[@data-cucumber='menu-item-label' and text()='Add People']";

            var firstNameFieldXpath = ".//input[@placeholder='First Name' and @field='firstName' and @value=''][1]";
            var lastNameFieldXpath = ".//input[@placeholder='Last Name' and @field='lastName' and @value=''][1]";
            var userEmailFieldXpath = ".//input[@field='email' and @value=''][1]";
            var addPeopleButtonXpath = ".//span[contains(@class, 'Button') and text()='Add People']";

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[9];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            
            //user1
            var firstName1 = new String(stringChars).ToString();
            var lastName1 = new String(stringChars).ToString();
            var userEmail1 = firstName1 + lastName1 + "@dummy.com";

            //user2
            var firstName2 = new String(stringChars).ToString();
            var lastName2 = new String(stringChars).ToString();
            var userEmail2 = firstName2 + lastName2 + "@dummy.com";

            var congratulationsPageXpath = ".//div[text()='Congratulations']";

            //Login and go to Add People page
        	Console.WriteLine("Open login url");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(loginURL);

            Console.WriteLine("Input Email field");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(emailFieldXpath)).SendKeys(email);

            Console.WriteLine("Click Continue button");
            driver.FindElement(By.XPath(continueButonXpath)).Click();

            Console.WriteLine("Input Password field");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(passwordFieldXpath)).SendKeys(password);

            Console.WriteLine("Click Sign in button");
            driver.FindElement(By.XPath(signinButonXpath)).Click();

            Console.WriteLine("Click Settings menu");
            Thread.Sleep(10000);
            driver.FindElement(By.XPath(settingMenuXpath)).Click();

            Console.WriteLine("Click Add People menu");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(addPeopleMenuXpath)).Click();

            //Add 2 users into list and verify Congratulations page displays
            Thread.Sleep(5000);
            Console.WriteLine("Add user1");
            driver.FindElement(By.XPath(firstNameFieldXpath)).SendKeys(firstName1);
            driver.FindElement(By.XPath(lastNameFieldXpath)).SendKeys(lastName1);
            driver.FindElement(By.XPath(userEmailFieldXpath)).SendKeys(userEmail1);

            Console.WriteLine("Add user1");
            driver.FindElement(By.XPath(firstNameFieldXpath)).SendKeys(firstName2);
            driver.FindElement(By.XPath(lastNameFieldXpath)).SendKeys(lastName2);
            driver.FindElement(By.XPath(userEmailFieldXpath)).SendKeys(userEmail2);

            Console.WriteLine("Click Add People button");
            driver.FindElement(By.XPath(addPeopleButtonXpath)).Click();

            Console.WriteLine("Verify Congratulations page is displayed");
            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(By.XPath(congratulationsPageXpath)).Displayed, "Congratulations page is displayed");

            driver.Close();
	    }
	}
}