using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestFramework.Driver.CommonOptions;

public class ChromeDriverOptionsFactory : IDriverCommonOptionsFactory<ChromeOptions>
{
    public ChromeOptions CreateOptions()
    {
        var options = new ChromeOptions();
        options.AddArgument("enable-automation");
        options.AddArgument("--start-maximized");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-extensions");
        options.AddArgument("--remote-allow-origins=*");
        options.AddArgument("--disable-dev-shm-usage");
        options.AddArgument("--window-size=1920x1080");
        options.AddArgument("--disable-popup-blocking");
        options.AddArgument("--disable-infobars");
        options.AddArgument("--no-first-run");
        return options!;
    }
}
