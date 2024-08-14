using OpenQA.Selenium.Firefox;

namespace TestFramework.Driver.CommonOptions;

public class FirefoxDriverOptionsFactory : IDriverCommonOptionsFactory<FirefoxOptions>
{
    public FirefoxOptions CreateOptions()
    {
        var options = new FirefoxOptions();
        options.AddArgument("--disable-notifications");
        options.AddArgument("--start-maximized");
        return options!;
    }
}