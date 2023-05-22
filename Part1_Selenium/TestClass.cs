
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Part1_Selenium.POM;
using Xunit;

namespace Part1_Selenium
{
    public class TestClass : BaseTest
    {
        private readonly LogInPOM loginpom;
        private readonly ProductsPOM productspom;
        private readonly BasketPOM basketpom;

        public TestClass()
        {
            loginpom = new LogInPOM(driver);
            productspom = new ProductsPOM(driver);
            basketpom = new BasketPOM(driver);
        }

        [Fact(DisplayName = "Successful user login")]
        public void WhenIEnterValidCredentials()
        {
            Navigate();
            Assert.True(loginpom.UsernameDisplayed() && loginpom.PasswordDisplayed() && loginpom.LoginbuttonDisplayed());
            loginpom.LogInClick("standard_user", "secret_sauce");
            Assert.True(productspom.BasketDisplayed());
        }

        [Theory(DisplayName = "Failed user login")]
        [InlineData("standard_user", "pass1")]
        [InlineData("standarduser", "secret_sauce")]
        [InlineData("", "")]
        public void WhenIEnterWrongCredentials(string username, string pass)
        {
            Navigate();
            loginpom.LogInClick(username, pass);
            Thread.Sleep(3000);
            Assert.True(loginpom.IsErrorMessageDisplayed());
        }

        [Fact(DisplayName = "Successful adding 3 products")]
        public void WhenClickOnAddtoCartForThreeProductsItShowsThreeProductsAreInTheBasket()
        {
            WhenIEnterValidCredentials();
            Assert.True(productspom.BackpackDisplayed() &&
                        productspom.BikelightDisplayed() &&
                        productspom.TshirtDisplayed() &&
                        productspom.BasketDisplayed());
            productspom.AddProductsToCart();
            Assert.Equal(3, productspom.GetCartItemCount());
        }

        [Fact(DisplayName = "Successful removing 3 products")]
        public void WhenThreeProductsAreRemovedTheBasketIsEmpty()
        {
            WhenClickOnAddtoCartForThreeProductsItShowsThreeProductsAreInTheBasket();
            productspom.BasketClick();
            Assert.True(basketpom.ContinueshoppingDisplayed() &&
                        basketpom.RemovebackpackDisplayed() &&
                        basketpom.RemovebikelightDisplayed() &&
                        basketpom.RemovetshirtDisplayed());
            basketpom.RemoveAllProducts();
            Assert.True(basketpom.IsCartEmpty());
            basketpom.ContinueshoppingClic();
            Assert.True(productspom.BackpackDisplayed() &&
                        productspom.BikelightDisplayed() &&
                        productspom.TshirtDisplayed() &&
                        productspom.BasketDisplayed());
        }
    }
}
