## Application test

### Overview
This holds the actual tests themselves that use the framewrok logic.

### Config
in the root of this directory (ApplicationTest) create appsettings.json and populate it with

```json
{
  "ApplicationUrl": "http://your-url/",
  "Headless": true,
  "SlowMo": 0,
  "DriverType": "edge/firefox/chrome/chromium"
}
```