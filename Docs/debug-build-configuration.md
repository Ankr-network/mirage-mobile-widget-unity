# Debug Build Configuration

To make a debug build for Mirage-Android-WebView-Plugin go to folder `Mirage-Android-WebView-Plugin/app/src/` and create `debug/res/values/urls.xml`. Fill the content of this xml file with this:

```
<?xml version="1.0" encoding="utf-8"?>
<resources>
    <string name="mirage_login_url">URL_TO_DEBUG_WEBVIEW_PAGE</string>
</resources>
```

Where `URL_TO_DEBUG_WEBVIEW_PAGE` is a URL to a development or staging authentication page.