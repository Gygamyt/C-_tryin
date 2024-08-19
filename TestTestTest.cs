using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestFramework.Driver;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager.Models.Chrome;

namespace TestFramework;

public class TestTestTest
{
    private IWebDriver? _driver;
    
    [SetUp]
    public void Setup()
    {
        const string version = "88.0.4324.96";

        new DriverManager().SetUpDriver(new ChromeConfig());
        
        _driver = CustomDriverManager.CustomDriverManagerInstance.GetDriver(BrowserType.Chrome);
    }

    [Test]
    public void TestTogoChtoYaYstal()
    {
        _driver?.Navigate().GoToUrl("https://www.google.com");
        Thread.Sleep(15000);
    }
    
    [TearDown]
    public void TearDown()
    {
        CustomDriverManager.CustomDriverManagerInstance.CloseAllDrivers();
    }
}