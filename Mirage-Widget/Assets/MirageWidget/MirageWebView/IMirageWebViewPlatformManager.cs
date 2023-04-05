namespace MirageWidget.MirageWebView
{
	public interface IMirageWebViewPlatformManager
	{
		void ShowWebView(string clientId, string userToken);
		void PushMessage(string message);
	}
}