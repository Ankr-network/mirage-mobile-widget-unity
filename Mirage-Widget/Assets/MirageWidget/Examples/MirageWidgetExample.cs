using MirageWidget.MirageWebView;
using MirageWidget.MirageWebView.Messaging.Implementation;
using UnityEngine;

namespace MirageWidget.Examples
{
	public class MirageWidgetExample : MonoBehaviour
	{
		[SerializeField]
		private MirageMessageBus _messageBus;

		private MirageWebViewManager _mirageWebViewManager;
		
		private void Start()
		{
			Debug.Log("MirageWidgetExample:: start");
			_mirageWebViewManager = new MirageWebViewManager();
			_messageBus.AddListener(_mirageWebViewManager);
			_mirageWebViewManager.ShowWebView("https://google.com");
		}
		
		private void OnApplicationPause(bool pauseStatus)
		{
			if (pauseStatus)
			{
				Application.targetFrameRate = 30;
			}
		}
	}
}