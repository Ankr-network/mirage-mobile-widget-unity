using UnityEngine;

namespace MirageWidget.MirageWebView
{
	public class AndroidWebViewManager 
	{
		public void ShowWebView(string url)
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				using (AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
				{
					using (AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity"))
					{
						using (AndroidJavaClass pluginClass = new AndroidJavaClass("com.example.plugin.UnityBridge"))
						{
							pluginClass.CallStatic("getInstance", currentActivity).Call("showWebView", url);
						}
					}
				}
			}
		}

		public void OnLoginDataReceived(string loginData)
		{
			Debug.Log("Login data received: " + loginData);
			// Process login data as needed.
		}
	}
}