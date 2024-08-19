using OpenQA.Selenium;

namespace TestFramework.Driver.DriverFactory1;

public interface IDriverFactory
{
    IWebDriver CreateDriver(BrowserType browserType);
}
