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
			
			//TODO ANTON finish this in MC-129
			var clientId = "";
			_mirageWebViewManager.ShowWebView(clientId);
		}
	}
}