package com.mirage.webview;

import android.webkit.JavascriptInterface;

public class CustomJavaScriptInterface {
    private MirageWebViewActivity _webViewActivity;

    public CustomJavaScriptInterface(MirageWebViewActivity webViewActivity) {
        _webViewActivity = webViewActivity;
    }

    @JavascriptInterface
    public void sendAuthData(String authData) {
        _webViewActivity.sendAuthDataToUnity(authData);
    }
    
    @JavascriptInterface
    public void sendMessage(String message) {
        _webViewActivity.sendMessage(message);
    }
    
    @JavascriptInterface
    public void closeWebView() {
        _webViewActivity.exitActivity();
    }
}
