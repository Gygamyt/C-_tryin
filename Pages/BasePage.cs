using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.Driver;

namespace TestFramework.Pages;

public class BasePage
{
    private IWebDriver? Driver { get; set; }

    private static string BrowserType => Environment.GetEnvironmentVariable("BROWSER_TYPE") ?? "Chrome";

    [SetUp]
    public void SetUp()
    {
        if (!Enum.TryParse(BrowserType, true, out BrowserType browserType))
        {
            throw new ArgumentException($"Unknown browser type: {BrowserType}");
        }

        Driver = CustomDriverManager.CustomDriverManagerInstance.GetDriver(browserType);
    }

    [TearDown]
    public void TearDown()
    {
        Driver?.Close();
        Driver?.Quit();
    }
}
