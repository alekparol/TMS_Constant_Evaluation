using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/* TODO: Create a class modeling home page for a project with at least two elements - title and "Status" section's element. 
 * TODO: Add an implication when Database Error occurs on the Status page.
 * TODO: All paths to the elements should be validated. 
 * TODO: All Thread.Sleep() occurances should be replaced with Explicit or Implicit waits.*/

namespace TMS_Constant_Evaluation
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://tms.lionbridge.com/");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            
            string projectTitle = "Porsche BAL 2.0";
            
            string projectXPath = "//div[contains(text(),'" + projectTitle + "')]";

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Porsche BAL 2.0')]")));
            IWebElement projectTMS =  driver.FindElement(By.XPath("//div[contains(text(),'Porsche BAL 2.0')]"));


            projectTMS.Click();

            Thread.Sleep(5000);
            IWebElement planningPage = driver.FindElement(By.XPath("//li[@id='status']"));

            planningPage.Click();
            Thread.Sleep(35000);

            StatusPage st = new StatusPage(driver);
            Console.WriteLine(st.pageTitle.Text);
            Console.WriteLine(st.filtersButton.Text);
            Console.WriteLine(st.jobsFilter.Text);
            Console.WriteLine(st.activityFilter.Text);

            Console.WriteLine(st.activityListGeneratedProperly);
            Console.WriteLine(st.jobsListGeneratedProperly);


            st.ChoseActivity("Translation", driver);
            Thread.Sleep(7000);
            // This should be the returning bool value for the function which will check whether the job under the name is within the PMExcel.
            // If yes, the program wont work for it. 
            bool ifTheJobIsOnPMExcel;

            driver.Quit();
            Thread.Sleep(2000);

        }
    }
}
