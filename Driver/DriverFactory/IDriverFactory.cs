using OpenQA.Selenium;

namespace TestFramework.Driver.DriverFactory;

public interface IDriverFactory
{
    IWebDriver CreateDriver(BrowserType browserType);
}
