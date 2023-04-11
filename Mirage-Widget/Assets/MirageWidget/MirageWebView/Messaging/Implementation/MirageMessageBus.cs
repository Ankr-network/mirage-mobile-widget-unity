using System.Collections.Generic;
using MirageWidget.MirageWebView.Messaging.Infrastructure;
using UnityEngine;

namespace MirageWidget.MirageWebView.Messaging.Implementation
{
	public class MirageMessageBus : MonoBehaviour
	{
		private readonly List<IMessageListener> _listeners = new List<IMessageListener>();

		public void AddListener(IMessageListener messageListener)
		{
			_listeners.Add(item: messageListener);
		}

		public void PushMessage(string message)
		{
			_listeners.ForEach(action: listener => listener.PushMessage(message: message));
		}

		public void Clear()
		{
			_listeners.Clear();
		}
	}
}