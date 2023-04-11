using System;
using Newtonsoft.Json;

namespace MirageWidget.MirageAPI.MirageID.Data.CreateUser
{
	[Serializable]
	public class CreateUserResponseDTO
	{
		[JsonProperty(PropertyName = "id")]
		public string Id;
		[JsonProperty(PropertyName = "walletId")]
		public string WalletId;
	}
}