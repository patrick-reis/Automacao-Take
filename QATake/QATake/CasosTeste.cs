using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;
using System.Linq;

namespace QATake
{
    public class CasosTeste
    {
        private IWebDriver driver;
        private static int cont = 0;

        [Fact]
        public void Test1()
        {
            AbreNagevador();



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
            string screenshotsPasta = @"C:\Users\Patrick Reis\Documents\Git\Base2\Mantis\Mantis\Mantis\Screenshot\" + nome + "_" + cont++ + ".png";
            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);


        }
    }
}
