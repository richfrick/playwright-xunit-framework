using Framework.Config;
using Framework.Driver.Config;
using Microsoft.Playwright;

namespace Framework.Driver;

// This handles the Browsers the framework supports and provides a readable way of using in the PlaywrightDriver
public class PlaywrightDriverInitializer : IPlaywrightDriverInitializer
{
    public const float DefaultTimeout = 3000f;
    
    public async Task<IBrowser> GetChromeDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = "chrome";
        return await GetBrowserAsync(DriverType.Chromium, options);
    }
    
    public async Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = "firefox";
        return await GetBrowserAsync(DriverType.Firefox, options);
    }
    
    public async Task<IBrowser> GetWebkitDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = "";
        return await GetBrowserAsync(DriverType.WebKit, options);
    }
    
    public async Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = "chromium";
        return await GetBrowserAsync(DriverType.Chromium, options);
    }
    
    public async Task<IBrowser> GetEdgeDriverAsync(TestSettings testSettings)
    {
        var options = GetParameters(testSettings.Args, testSettings.Timeout, testSettings.Headless,
            testSettings.SlowMo);
        options.Channel = "msedge";
        return await GetBrowserAsync(DriverType.Chromium, options);
    }
    

    private async Task<IBrowser> GetBrowserAsync(DriverType driverType, BrowserTypeLaunchOptions options)
    {
        var playwright = await Playwright.CreateAsync();
        return await playwright[driverType.ToString().ToLower()].LaunchAsync(options);
    }

    private BrowserTypeLaunchOptions GetParameters(string[]? args, float? timeout = DefaultTimeout, bool? headless = true, float? slomo = null)
    {
        return new BrowserTypeLaunchOptions
        {
            Args = args,
            Timeout = timeout,
            Headless = headless,
            SlowMo = slomo
        };
    }
}