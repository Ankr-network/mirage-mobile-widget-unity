package com.mirage.miragewebviewandroidplugin;

import android.content.Context;
import android.content.Intent;

public class UnityBridge {
    private static UnityBridge instance;
    private Context _context;

    public UnityBridge(Context context) {
        _context = context;
    }

    public static UnityBridge getInstance(Context context) {
        if (instance == null) {
            instance = new UnityBridge(context);
        }
        return instance;
    }

    public void showWebView(String url) {
        Intent intent = new Intent(_context, MirageWebViewActivity.class);
        intent.putExtra("url", url);
        _context.startActivity(intent);
    }

    // Implement other methods to pass data between WebView and Unity as needed.
}