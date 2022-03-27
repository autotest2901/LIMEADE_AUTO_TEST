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
            
            //user1
            var firstName = "An";
            var lastName = "Nguyen";
            var userEmail = firstName + lastName + "@dummy.com";

            var errorPageXpath = ".//*[text()='Uh oh! Unable to add user because email already exists']";

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

            //Add an existing user into list and verify error displays
            Thread.Sleep(5000);
            Console.WriteLine("Add an existing user");
            driver.FindElement(By.XPath(firstNameFieldXpath)).SendKeys(firstName);
            driver.FindElement(By.XPath(lastNameFieldXpath)).SendKeys(lastName);
            driver.FindElement(By.XPath(userEmailFieldXpath)).SendKeys(userEmail);

            Console.WriteLine("Click Add People button");
            driver.FindElement(By.XPath(addPeopleButtonXpath)).Click();

            Console.WriteLine("Verify Error is displayed");
            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(By.XPath(errorPageXpath)).Displayed, "Error is displayed");

            driver.Close();
	    }
	}
}