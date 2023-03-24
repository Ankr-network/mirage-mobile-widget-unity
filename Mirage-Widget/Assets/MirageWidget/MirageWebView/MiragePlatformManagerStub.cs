using UnityEngine;

namespace MirageWidget.MirageWebView
{
	public class MiragePlatformManagerStub : IMirageWebViewPlatformManager
	{
		void IMirageWebViewPlatformManager.ShowWebView(string url)
		{
			Debug.Log($"ShowWebView is called for Stub with {url}");
		}

		void IMirageWebViewPlatformManager.PushMessage(string message)
		{
			Debug.Log($"Message {message} pushed to Stub");
		}
	}
}