using OpenQA.Selenium;

namespace TestFramework.Driver.CommonOptions;

public interface IDriverCommonOptionsFactory<out T> where T : DriverOptions
{
    T CreateOptions();
}
