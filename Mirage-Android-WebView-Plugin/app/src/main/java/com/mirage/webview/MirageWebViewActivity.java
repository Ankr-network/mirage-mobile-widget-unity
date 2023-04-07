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

    public void sendAuthDataToUnity(String authData) {
        HashMap<String, String> messageMap = new HashMap<>();
        messageMap.put("message_type", "auth");
        messageMap.put("message_data", authData);
        JSONObject messageMapJson = new JSONObject(messageMap);
        UnityPlayer.UnitySendMessage("MirageMessageBus", "PushMessage", messageMapJson.toString());
    }
    
    public void sendMessage(String message) {
        UnityPlayer.UnitySendMessage("MirageMessageBus", "PushMessage", message);
    }

    public void exitActivity() {
        finish();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        requestWindowFeature(Window.FEATURE_NO_TITLE);
        Window window = getWindow();
        window.setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
        window.setDimAmount(0); //Making the window dim transparent
        window.addFlags(WindowManager.LayoutParams.FLAG_DIM_BEHIND);

        setContentView(R.layout.activity_main);

        _webView = findViewById(R.id.webview);
        _exitButton = findViewById(R.id.exit_button);
        _progressBar = findViewById(R.id.progress_bar);
        _relativeLayout = findViewById(R.id.webViewLayout);
        
        _relativeLayout.setBackgroundColor(Color.TRANSPARENT);
        
        customizeWebView();
        openWebView();

        _exitButton.setOnClickListener(v -> exitActivity());
    }
    
    private void customizeWebView()
    {
        _webView.setWebViewClient(new CustomWebViewClient(_progressBar));
        _webView.getSettings().setJavaScriptEnabled(true);
        _webView.addJavascriptInterface(new CustomJavaScriptInterface(this), "WebViewInterface");
    }
    
    private void openWebView()
    {
        Intent intent = getIntent();
        String clientId = intent.getStringExtra("clientId"); //to be used in the URL later
        String authUrl = getString(R.string.mirage_auth_url);
        _webView.loadUrl(authUrl);
    }
}