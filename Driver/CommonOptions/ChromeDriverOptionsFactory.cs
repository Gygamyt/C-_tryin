using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestFramework.Driver.CommonOptions;

public class ChromeDriverOptionsFactory : IDriverCommonOptionsFactory<ChromeOptions>
{
    public ChromeOptions CreateOptions()
    {
        var options = new ChromeOptions();
        options.AddArgument("--disable-notifications");
        options.AddArgument("--start-maximized");
        return options!;
    }
}
