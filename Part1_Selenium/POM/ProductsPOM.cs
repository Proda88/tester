using System;
using OpenQA.Selenium;
namespace Part1_Selenium.POM
{
    public class ProductsPOM
    {
        public IWebDriver driver { get; }
        private IWebElement backpack => driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        private IWebElement bikelight => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        private IWebElement tshirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        private IWebElement basket => driver.FindElement(By.Id("shopping_cart_container"));



        public ProductsPOM(IWebDriver _driver)
        {
            driver = _driver;
        }

        public bool BackpackDisplayed() => backpack.Displayed;

        public bool BikelightDisplayed() => bikelight.Displayed;

        public bool TshirtDisplayed() => tshirt.Displayed;

        public bool BasketDisplayed() => basket.Displayed;

        public void AddProductsToCart()
        {
            bikelight.Click();
            tshirt.Click();
            backpack.Click();
        }

        public void BasketClick() => basket.Click();

        public int GetCartItemCount()
        {
            string itemCountText = basket.Text;
            int itemCount = int.Parse(itemCountText);
            return itemCount;
        }
    }
}

