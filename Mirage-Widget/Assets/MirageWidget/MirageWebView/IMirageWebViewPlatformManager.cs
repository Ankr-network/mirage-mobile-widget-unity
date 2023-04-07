namespace MirageWidget.MirageWebView
{
	public interface IMirageWebViewPlatformManager
	{
		void ShowWebView(string clientId);
		void PushMessage(string message);
	}
}