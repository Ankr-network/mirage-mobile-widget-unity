using MirageWidget.MirageWebView.Utils;
using UnityEngine;

namespace MirageWidget.MirageWebView.Android
{
	public class MirageAndroidWebViewManager : IMirageWebViewPlatformManager
	{
		private const string UnityPlayerClass = "com.unity3d.player.UnityPlayer";
		private const string UnityBridgeClass = "com.mirage.webview.UnityBridge";
		private const string CurrentActivityField = "currentActivity";
		
		void IMirageWebViewPlatformManager.ShowWebView(string url)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				Debug.Log("MirageWidgetExample:: MirageAndroidWebViewManager:: creating unity player class object");
				using (AndroidJavaClass unityPlayerClass = new AndroidJavaClass(UnityPlayerClass))
				{
					Debug.Log("MirageWidgetExample:: MirageAndroidWebViewManager:: getting current activity");
					using (AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>(CurrentActivityField))
					{
						Debug.Log("MirageWidgetExample:: MirageAndroidWebViewManager:: creating unity bridge class object");
						using (AndroidJavaClass pluginClass = new AndroidJavaClass(UnityBridgeClass))
						{
							const string getInstanceMethod = "getInstance";
							const string showWebViewMethod = "showWebView";
							
							Debug.Log("MirageWidgetExample:: MirageAndroidWebViewManager:: getting UnityBridge object");

							var unityBridgeInstance = pluginClass.CallStatic<AndroidJavaObject>(getInstanceMethod, currentActivity);
							
							Debug.Log("MirageWidgetExample:: MirageAndroidWebViewManager:: calling showWebView() with url=" + url);
							unityBridgeInstance.Call(showWebViewMethod, url);
						}
					}
				}
			}
		}

		void IMirageWebViewPlatformManager.PushMessage(string message)
		{
			if (MessageUtils.DeserializeMessage(message, out var messageDto))
			{
				switch (messageDto.MessageType)
				{
					case "login":
						OnLoginDataReceived(messageDto.MessageData);
						break;
				}
			}
		}

		private void OnLoginDataReceived(string loginData)
		{
			Debug.Log("Login data received: " + loginData);
			// Process login data as needed.
		}
	}
}