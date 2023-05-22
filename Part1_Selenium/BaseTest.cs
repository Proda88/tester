using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Part1_Selenium
{
    public class BaseTest : IDisposable
    {
        public IWebDriver driver;
        private bool disposedValue = false;

        public BaseTest()
        {
            driver = new ChromeDriver();
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    driver.Quit();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

