using System.Collections.Generic;
using MirageWidget.MirageWebView.Messaging.Infrastructure;
using UnityEngine;

namespace MirageWidget.MirageWebView.Messaging.Implementation
{
	public class MirageMessageBus : MonoBehaviour
	{
		private readonly List<IMessageListener> _listeners = new();
		
		public void AddListener(IMessageListener messageListener)
		{
			_listeners.Add(messageListener);
		}

		public void PushMessage(string message)
		{
			_listeners.ForEach(listener => listener.PushMessage(message));
		}

		public void Clear()
		{
			_listeners.Clear();
		}
	}
}