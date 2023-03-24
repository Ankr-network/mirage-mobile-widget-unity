using Newtonsoft.Json;

namespace MirageWidget.MirageWebView.Messaging.Data
{
	public class MessageDTO
	{
		[JsonProperty("message_type")]
		public string MessageType { get; set; }
		
		[JsonProperty("message_data")]
		public string MessageData { get; set; }
	}
}