using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;
using System.Linq;
using QATake.PageObjects;

namespace QATake
{
    public class CasosTeste
    {
        private IWebDriver driver;
        private ContactPage contato;
        private static int cont = 0;

        [Theory]
        [InlineData("Patrick Reis","reis@gmail.com","QATake", "h3", "A mensagem foi enviada")]
        public void TestesContato(string nome, string mail, string coment, string element, string mensage)
        {
            AbreNagevador();
            contato = new ContactPage(driver);
            contato.RealizaContato(nome, mail, coment);
            Screenshot(driver, "RealizaContato");
            contato.ValidaMsg(element, mensage);
            Fechar();
        }

        public void AbreNagevador()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            driver.Navigate().GoToUrl("https://qadatake.wordpress.com/");
            driver.Manage().Window.Maximize();
        }
        public void Fechar()
        {
            driver.Close();
            driver.Quit();
        }

        public void Screenshot(IWebDriver driver, string nome)
        {
            string screenshotsPasta = @"C:\Users\Patrick Reis\Documents\Git\Take\Automacao-Take\QATake\QATake\Screenshot\" + nome + "_" + cont++ + ".png";
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);


        }
    }
}
