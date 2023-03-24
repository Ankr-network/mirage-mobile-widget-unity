package com.mirage.miragewebviewandroidplugin;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.webkit.WebView;
import android.widget.ImageButton;
import android.widget.ProgressBar;

import com.unity3d.player.UnityPlayer;

import org.json.JSONObject;

import java.util.HashMap;

public class MirageWebViewActivity extends Activity {
    private WebView _webView;
    private ImageButton _exitButton;
    private ProgressBar _progressBar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_web_view);

        _webView = findViewById(R.id.webview);
        _exitButton = findViewById(R.id.exit_button);
        _progressBar = findViewById(R.id.progress_bar);

        _webView.setWebViewClient(new CustomWebViewClient(_progressBar));
        _webView.getSettings().setJavaScriptEnabled(true);
        _webView.addJavascriptInterface(new CustomJavaScriptInterface(this), "AndroidInterface");

        Intent intent = getIntent();
        String url = intent.getStringExtra("url");
        _webView.loadUrl(url);

        _exitButton.setOnClickListener(v -> finish());
    }

    @Override
    public void onBackPressed() {
        if(_webView.canGoBack()) {
            _webView.goBack();
        } else {
            finish();
        }
    }

    public void sendLoginDataToUnity(String loginData) {

        HashMap<String, String> messageMap = new HashMap<>();
        messageMap.put("message_type", "login");
        messageMap.put("message_data", loginData);
        JSONObject messageMapJson = new JSONObject(messageMap);
        UnityPlayer.UnitySendMessage("MirageMessageBus", "PushMessage", messageMapJson.toString());
    }
}