using UnityEngine;

namespace MirageWidget.MirageWebView
{
	public class MiragePlatformManagerStub : IMirageWebViewPlatformManager
	{
		void IMirageWebViewPlatformManager.ShowWebView(string clientId)
		{
			Debug.Log($"ShowWebView is called for Stub with clientId={clientId}");
		}

		void IMirageWebViewPlatformManager.PushMessage(string message)
		{
			Debug.Log($"Message {message} pushed to Stub");
		}
	}
}