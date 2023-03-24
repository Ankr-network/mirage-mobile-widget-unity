namespace MirageWidget.MirageWebView
{
	public interface IMirageWebViewPlatformManager
	{
		void ShowWebView(string url);
		void PushMessage(string message);
	}
}