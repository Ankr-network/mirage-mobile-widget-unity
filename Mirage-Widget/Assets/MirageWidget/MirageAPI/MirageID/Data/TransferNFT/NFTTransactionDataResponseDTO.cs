using System;
using Newtonsoft.Json;

namespace MirageWidget.MirageAPI.MirageID.Data.TransferNFT
{
	[Serializable]
	public class NFTTransactionDataResponseDTO : JsonResponseBase
	{
		[JsonProperty(PropertyName = "data")]
		public string Data;
	}
}