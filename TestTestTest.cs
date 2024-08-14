using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestFramework.Driver;

namespace TestFramework;

public class TestTestTest
{
    private IWebDriver? _driver;
    
    [SetUp]
    public void Setup()
    {
        _driver = DriverManager.Instance.GetDriver(BrowserType.Chrome);
    }

    [Test]
    public void TestTogoChtoYaYstal()
    {
        _driver.Navigate().GoToUrl("https://www.google.com");
        Thread.Sleep(15000);
    }
    
    [TearDown]
    public void TearDown()
    {
        DriverManager.Instance.CloseALlDrivers();
    }
}