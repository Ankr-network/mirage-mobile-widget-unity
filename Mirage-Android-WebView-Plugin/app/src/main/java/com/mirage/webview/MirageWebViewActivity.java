package com.mirage.webview;

import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.view.Window;
import android.view.WindowManager;
import android.webkit.WebView;
import android.widget.ImageButton;
import android.widget.ProgressBar;
import android.widget.RelativeLayout;

import com.unity3d.player.UnityPlayer;

import org.json.JSONObject;

import java.util.HashMap;

public class MirageWebViewActivity extends Activity {

    private RelativeLayout _relativeLayout;
    private WebView _webView;
    private ImageButton _exitButton;
    private ProgressBar _progressBar;

    @Override
    public void onBackPressed() {
        if(_webView.canGoBack()) {
            _webView.goBack();
        } else {
            exitActivity();
        }
    }

    public void sendLoginDataToUnity(String loginData) {
        HashMap<String, String> messageMap = new HashMap<>();
        messageMap.put("message_type", "login");
        messageMap.put("message_data", loginData);
        JSONObject messageMapJson = new JSONObject(messageMap);
        UnityPlayer.UnitySendMessage("MirageMessageBus", "PushMessage", messageMapJson.toString());
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        requestWindowFeature(Window.FEATURE_NO_TITLE);
        Window window = getWindow();
        window.addFlags(WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS);
        window.setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
        window.setDimAmount(0); //Making the window dim transparent
        window.addFlags(WindowManager.LayoutParams.FLAG_DIM_BEHIND);

        setContentView(R.layout.activity_main);

        _webView = findViewById(R.id.webview);
        _exitButton = findViewById(R.id.exit_button);
        _progressBar = findViewById(R.id.progress_bar);
        _relativeLayout = findViewById(R.id.webViewLayout);

        _webView.setWebViewClient(new CustomWebViewClient(_progressBar));
        _webView.getSettings().setJavaScriptEnabled(true);
        _webView.addJavascriptInterface(new CustomJavaScriptInterface(this), "WebViewInterface");

        Intent intent = getIntent();
        String url = intent.getStringExtra("url");
        _webView.loadUrl(url);
        _relativeLayout.setBackgroundColor(Color.TRANSPARENT);

        _exitButton.setOnClickListener(v -> exitActivity());
    }

    private void exitActivity() {
        finish();
    }
}