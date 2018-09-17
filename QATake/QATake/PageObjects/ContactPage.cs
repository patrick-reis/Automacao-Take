using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;
using Xunit;

namespace QATake.PageObjects
{
    class ContactPage
    {
        private IWebDriver driver;
        public ContactPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//button['Menu']")]
        private IWebElement menu;

        [FindsBy(How = How.CssSelector, Using = "[href='https://qadatake.wordpress.com/contact/']")]
        private IWebElement contato;

        [FindsBy(How = How.Id, Using = "g2-name")]
        private IWebElement name;

        [FindsBy(How = How.Id, Using = "g2-email")]
        private IWebElement email;

        [FindsBy(How = How.Id, Using = "contact-form-comment-g2-comment")]
        private IWebElement comentario;

        [FindsBy(How = How.CssSelector, Using = "input[value='Enviar »']")]
        private IWebElement enviar;


        public void RealizaContato(string nome, string mail, string coment)
        {
            menu.Click();
            contato.Click();
            name.SendKeys(nome);
            email.SendKeys(mail);
            comentario.SendKeys(coment);
            Thread.Sleep(4000);
            enviar.Click();
            Thread.Sleep(2000);

        }

        public void ValidaMsg(string elemento, string msg)
        {

            IWebElement msgTela = driver.FindElement(By.CssSelector(elemento));
            string valor = msgTela.Text;
            try
            {
                bool mnsg = (valor + "").Contains(msg);
                Assert.True(mnsg);
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
        }
    }
}
