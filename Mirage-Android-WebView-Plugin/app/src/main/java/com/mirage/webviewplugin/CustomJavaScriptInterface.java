package com.mirage.webviewplugin;

import android.webkit.JavascriptInterface;

public class CustomJavaScriptInterface {
    private MirageWebViewActivity _webViewActivity;

    public CustomJavaScriptInterface(MirageWebViewActivity webViewActivity) {
        _webViewActivity = webViewActivity;
    }

    @JavascriptInterface
    public void onLoginDataReceived(String loginData) {
        _webViewActivity.sendLoginDataToUnity(loginData);
    }
}
