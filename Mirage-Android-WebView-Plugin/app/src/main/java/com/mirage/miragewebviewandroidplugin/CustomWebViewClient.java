package com.mirage.miragewebviewandroidplugin;

import android.graphics.Bitmap;
import android.graphics.Color;
import android.view.View;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.ProgressBar;

public class CustomWebViewClient extends WebViewClient {
    private ProgressBar _progressBar;

    public CustomWebViewClient(ProgressBar progressBar)
    {
        _progressBar = progressBar;
    }

    @Override
    public void onPageStarted(WebView view, String url, Bitmap favicon) {
        _progressBar.setVisibility(View.VISIBLE);
    }

    @Override
    public void onPageFinished(WebView view, String url) {
        _progressBar.setVisibility(View.GONE);


//Example of executing page javascript if needed:
//        view.evaluateJavascript("getLoginData();", value -> {
//            if (value != null && !value.equals("null")) {
//                UnityPlayer.UnitySendMessage("AndroidWebViewManager", "OnLoginDataReceived", value);
//            }
//        });
    }

}
