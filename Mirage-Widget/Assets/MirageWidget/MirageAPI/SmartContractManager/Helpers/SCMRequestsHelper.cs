using System.Collections.Generic;

namespace MirageWidget.MirageAPI.SmartContractManager.Helpers
{
	public static class SCMRequestsHelper
	{
		public static Dictionary<string, string> GetAuthorizationHeader(string token)
		{
			return new Dictionary<string, string>
			{
				{ "Authorization", $"Bearer {token}" }
			};
		}
	}
}