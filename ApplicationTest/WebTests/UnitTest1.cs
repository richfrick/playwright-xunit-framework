using Framework.Config;
using Framework.Driver;
using Framework.Driver.Config;

namespace PlaywrightXunitFramework.WebTests;

public class Tests: IClassFixture<PlaywrightDriverInitializer>
{
    private PlaywrightDriver _playwrightDriverdriver;
    private PlaywrightDriverInitializer _playwrightDriverInitializer;
    private TestSettings _testSettings;
    
    public Tests(PlaywrightDriverInitializer playwrightDriverInitializer)
    {
        _testSettings = ConfigReader.readerConfig();
        _playwrightDriverInitializer = playwrightDriverInitializer;
        _playwrightDriverdriver = new PlaywrightDriver(_testSettings, _playwrightDriverInitializer);
       
    }

    [Fact]
    public async Task Test1()
    {
        var page = await _playwrightDriverdriver.Page;
        await page.GotoAsync(_testSettings.ApplicationUrl);
        await page.Locator("[href=\"/articles?topic=football\"]").ClickAsync();
    }
    
    [Fact]
    public async Task Test2()
    {
        var page = await _playwrightDriverdriver.Page;
        await page.GotoAsync(_testSettings.ApplicationUrl);
        await page.Locator("[href=\"/articles?topic=cooking\"]").ClickAsync();
    }
    
}