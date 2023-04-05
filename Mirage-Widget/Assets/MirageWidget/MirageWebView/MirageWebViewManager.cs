using MirageWidget.MirageWebView.Android;
using MirageWidget.MirageWebView.Messaging.Infrastructure;

namespace MirageWidget.MirageWebView
{
	public class MirageWebViewManager : IMessageListener
	{
		#if UNITY_ANDROID
		private readonly IMirageWebViewPlatformManager _platformManager = new MirageAndroidWebViewManager();
		#elif UNITY_IOS
		private readonly IMirageWebViewPlatformManager _platformManager = new MiragePlatformManagerStub(); //IOS NOT IMPLEMENTED YET
		#else
		private readonly IMirageWebViewPlatformManager _platformManager = new MiragePlatformManagerStub();
		#endif
		
		public void ShowWebView(string clientId, string userToken)
		{
			_platformManager.ShowWebView(clientId, userToken);
		}

		void IMessageListener.PushMessage(string message)
		{
			_platformManager.PushMessage(message);
		}
	}
}