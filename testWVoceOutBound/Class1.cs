using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace testWVoceOutBound
{

    public class testOutBound
    {
        private IWebDriver driver = new ChromeDriver();
        //public string homeURL = "http://wvoce-sviluppo.optimaitalia.com:8090/";
        private string _sHost = "http://wvoce-sviluppo.optimaitalia.com:8090/";
        private string _sLogin = "testoper";
        private string _sPassword = "test";
        private string _Chiamata = "ctl00_cphContents_optEsiti_1";
        private string _Esita_chaimata = "ctl00_cphContents_btnEsitaChiamata";
        public void LoadProperties(Dictionary<string, string> dictionary)
        {
            this._sHost = dictionary["host"];
            this._sLogin = dictionary["login"];
            this._sPassword = dictionary["password"];
            this._Chiamata = dictionary["_Chiamata"];
            this._Esita_chaimata = dictionary["Esita_chaimata"];
        }


        [Test]
        public void Execute()
        {
            driver.Navigate().GoToUrl(_sHost);

            Exist("ctl00_cphContents_LogIn1_txtUserName",10);


            //WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            //wait.Until(driver => driver.FindElement(By.Id("ctl00_cphContents_LogIn1_txtUserName")));

            //IList<IWebElement> inputs = driver.FindElements(By.XPath("//input"));
            driver.FindElement(By.Id("ctl00_cphContents_LogIn1_txtUserName")).SendKeys(_sLogin);
            driver.FindElement(By.Id("ctl00_cphContents_LogIn1_txtPassword")).SendKeys(_sPassword);
            driver.FindElement(By.Id("ctl00_cphContents_LogIn1_imgLogIn")).Click();

            OutboundClick();

            PlayButon();

            Chiama();

            LiberoCheck();

            LogOut();

        }
        public void OutboundClick()
        {

            driver.FindElement(By.CssSelector("div.wc_Menu"));
            driver.FindElement(By.LinkText("Operatività")).Click();
            driver.FindElement(By.LinkText("OutBound")).Click();

        }
        public void PlayButon()
        {
            //driver.FindElement(By.Id("timeBarOperatore"));

            driver.FindElement(By.Id("ctl00_cphContents_btnBarPlay")).Click();

        }
        public void Chiama()
        {

            driver.FindElement(By.Id("ctl00_cphContents_btnChiama")).Click();

        }



        public void LiberoCheck()
        {
            driver.FindElement(By.Id(_Chiamata)).Click();
            driver.FindElement(By.Id(_Esita_chaimata)).Click();
        }




        public void LogOut()
        {
            driver.FindElement(By.LinkText("Accesso")).Click();
            driver.FindElement(By.LinkText("LogOut")).Click();
        }
        public void TearDownTest()
        {
            driver.Close();
        }
        public void SetupTest()
        {
            driver = new ChromeDriver();
        }

       

        public void Exist(string _Id, int Wait_Time)
        {
            bool isElementDisplayed = driver.FindElement(By.Id(_Id)).Displayed;
            if (isElementDisplayed == false)
            {
                WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(Wait_Time));
                wait.Until(driver => driver.FindElement(By.Id(_Id)));
            }

            
        }



    }



}



