using System.Collections.Concurrent;
using OpenQA.Selenium;
using TestFramework.Driver.CommonOptions;
using TestFramework.Driver.DriverFactory1;


namespace TestFramework.Driver;

public class CustomDriverManager
{
    private readonly DriverFactory _driverFactory;
    
    private CustomDriverManager()
    {
        _driverFactory = new DriverFactory(
            new ChromeDriverOptionsFactory(),
            new FirefoxDriverOptionsFactory()
            );
    }
    
    private static readonly Lazy<CustomDriverManager> Instance = new(() => new CustomDriverManager());

    public static CustomDriverManager CustomDriverManagerInstance => Instance.Value;

    private readonly ConcurrentDictionary<BrowserType, IWebDriver> _drivers = new();

    public IWebDriver GetDriver(BrowserType browserType)
    {
        return _drivers.GetOrAdd(browserType, type =>
        {
            var driver = _driverFactory.CreateDriver(type);
            SetUpImplWait(driver, TimeSpan.FromSeconds(5));
            return driver;
        });
    }

    public void CloseAllDrivers()
    {
        foreach (var driver in _drivers.Values)
        {
            try
            {
                driver.Close();
                driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine("eto prosto yzhas ya zaputalsa");
                throw;
            }
        }
        _drivers.Clear();
    }

    private static void SetUpImplWait(IWebDriver driver, TimeSpan duration)
    {
        driver.Manage().Timeouts().ImplicitWait = duration;
    }
}
