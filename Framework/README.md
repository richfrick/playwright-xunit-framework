## Framework Project

### Overview
This is where the framework we use to conduct the testing lives.

### Config
Under ApplicationTest create appsettings.json for the TestSettings you wish to use. At the moment these are 

```json
{
  "ApplicationUrl": "http://localhost:9090/",
  "Headless": true,
  "SlowMo": 0,
  "DriverType": "edge/firefox/chrome/chromium"
}
```

This framework will handle:

E2E tests
1. The creation of Browser, BrowserContext and Page Context per test via lazy loading
2. Disposal of the Browser, BrowserContext and Page Context per test 
3. The browsers that the framework supports

