using System;
using MirageWidget.MirageWebView.Messaging.Data;
using Newtonsoft.Json;
using UnityEngine;

namespace MirageWidget.MirageWebView.Utils
{
	public static class MessageUtils
	{
		public static bool DeserializeMessage(string message, out MessageDTO messageDto)
		{
			messageDto = null;
			try
			{
				messageDto = JsonConvert.DeserializeObject<MessageDTO>(message);
			}
			catch (Exception e)
			{
				Debug.LogError($"Failied to deserialize message: {message} ; with exception: {e.Message}");
				return false;
			}

			if (messageDto == null 
			    || string.IsNullOrWhiteSpace(messageDto.MessageType)
			    || string.IsNullOrWhiteSpace(messageDto.MessageData))
			{
				Debug.LogError($"Wrong message format: {message}");
				return false;
			}

			return true;
		}
	}
}