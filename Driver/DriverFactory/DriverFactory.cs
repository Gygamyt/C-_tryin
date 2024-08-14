using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestFramework.Driver.CommonOptions;

namespace TestFramework.Driver.DriverFactory;

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
        switch (browserType)
        {
            case BrowserType.Chrome:
                return new ChromeDriver(_chromeOptionsFactory.CreateOptions());
            case BrowserType.Firefox:
                return new FirefoxDriver(_firefoxOptionsFactory.CreateOptions());
            default:
                throw new ArgumentException($"Unsupported browser type: {browserType}");
        }
    }
}
