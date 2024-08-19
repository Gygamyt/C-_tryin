using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestFramework.Driver.CommonOptions;

namespace TestFramework.Driver.DriverFactory1;

public class DriverFactory : IDriverFactory
{
    private readonly IDriverCommonOptionsFactory<ChromeOptions> _chromeOptionsFactory;
    private readonly IDriverCommonOptionsFactory<FirefoxOptions> _firefoxOptionsFactory;

    public DriverFactory(
        IDriverCommonOptionsFactory<ChromeOptions> chromeOptionsFactory,
        IDriverCommonOptionsFactory<FirefoxOptions> firefoxOptionsFactory)
    {
        _chromeOptionsFactory = chromeOptionsFactory;
        _firefoxOptionsFactory = firefoxOptionsFactory;
    }

    public IWebDriver CreateDriver(BrowserType browserType)
    {
        return browserType switch
        {
            BrowserType.Chrome => new ChromeDriver(_chromeOptionsFactory.CreateOptions()),
            BrowserType.Firefox => new FirefoxDriver(_firefoxOptionsFactory.CreateOptions()),
            _ => throw new ArgumentException($"Unsupported browser type: {browserType}")
        };
    }
}
