using System.Collections.Concurrent;
using OpenQA.Selenium;
using TestFramework.Driver.CommonOptions;
using TestFramework.Driver.DriverFactory;

namespace TestFramework.Driver;

public class DriverManager
{
    private readonly IDriverFactory _driverFactory;
    
    private DriverManager()
    {
        _driverFactory = new DriverFactory.DriverFactory(
            new ChromeDriverOptionsFactory(),
            new FirefoxDriverOptionsFactory());
    }
    
    private static readonly Lazy<DriverManager> _instance = new Lazy<DriverManager>(() => new DriverManager());

    public static DriverManager Instance => _instance.Value;

    private readonly ConcurrentDictionary<BrowserType, IWebDriver> _drivers = new ConcurrentDictionary<BrowserType, IWebDriver>();

    public IWebDriver GetDriver(BrowserType browserType)
    {
        return _drivers.GetOrAdd(browserType, type =>
        {
            var driver = _driverFactory.CreateDriver(type);
            SetUpImplWait(driver, TimeSpan.FromSeconds(5));
            return driver;
        });
    }

    public void CloseALlDrivers()
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
