using UnityEngine;

namespace MirageWidget.MirageWebView
{
	public class MiragePlatformManagerStub : IMirageWebViewPlatformManager
	{
		void IMirageWebViewPlatformManager.ShowWebView(string clientId, string userToken)
		{
			Debug.Log($"ShowWebView is called for Stub with clientId={clientId} userToken={userToken}");
		}

		void IMirageWebViewPlatformManager.PushMessage(string message)
		{
			Debug.Log($"Message {message} pushed to Stub");
		}
	}
}