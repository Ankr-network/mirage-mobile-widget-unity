using System;
using Newtonsoft.Json;

namespace MirageWidget.MirageAPI.MirageID.Data.TransferNFT
{
	[Serializable]
	public class CreateNFTTransactionRequestDTO
	{
		[JsonProperty(PropertyName = "transactionHash")]
		public string TransactionHash;
	}
}