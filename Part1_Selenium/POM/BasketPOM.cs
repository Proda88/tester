using System;
using OpenQA.Selenium;

namespace Part1_Selenium.POM
{
    public class BasketPOM
    {
        public IWebDriver driver { get; }
        private IWebElement removebackpack => driver.FindElement(By.Id("remove-sauce-labs-backpack"));
        private IWebElement removebikelight => driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        private IWebElement removetshirt => driver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt"));
        private IWebElement continueshopping => driver.FindElement(By.Id("continue-shopping"));
        private IWebElement basket => driver.FindElement(By.Id("shopping_cart_container"));

        public BasketPOM(IWebDriver _driver)
        {
            driver = _driver;
        }

        public bool RemovebackpackDisplayed() => removebackpack.Displayed;

        public bool RemovebikelightDisplayed() => removebikelight.Displayed;

        public bool RemovetshirtDisplayed() => removetshirt.Displayed;

        public bool ContinueshoppingDisplayed() => continueshopping.Displayed;

        public void RemoveAllProducts()
        {
            removebackpack.Click();
            removebikelight.Click();
            removetshirt.Click();
        }

        public bool IsCartEmpty()
        {
            var basketItems = basket.FindElements(By.CssSelector(".cart_item"));
            return basketItems.Count == 0;
        }

        public void ContinueshoppingClic() => continueshopping.Click();

    }
}

