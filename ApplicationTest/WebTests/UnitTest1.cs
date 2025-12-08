using Framework.Driver;
using Framework.Driver.Config;

namespace PlaywrightXunitFramework.WebTests;

public class Tests: IClassFixture<PlaywrightDriverInitializer>
{
    private PlaywrightDriver _playwrightDriverdriver;
    private PlaywrightDriverInitializer _playwrightDriverInitializer;
    
    public Tests(PlaywrightDriverInitializer playwrightDriverInitializer)
    {
        TestSettings testSettings = new TestSettings
        {
            Headless = false,
            SlowMo = 0f,
            DriverType = DriverType.Chrome,
        };

        _playwrightDriverInitializer = playwrightDriverInitializer;
        _playwrightDriverdriver = new PlaywrightDriver(testSettings, _playwrightDriverInitializer);
       
    }

    [Fact]
    public async Task Test1()
    {
        var page = await _playwrightDriverdriver.Page;
        await page.GotoAsync("http://localhost:5173/");
        await page.Locator("[href=\"/articles?topic=football\"]").ClickAsync();
    }
    
    [Fact]
    public async Task Test2()
    {
        var page = await _playwrightDriverdriver.Page;
        await page.GotoAsync("http://localhost:5173/");
        await page.Locator("[href=\"/articles?topic=cooking\"]").ClickAsync();
    }
    
}