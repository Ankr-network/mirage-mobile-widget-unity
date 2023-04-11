using MirageWidget.MirageAPI.MirageID.Data.Wallet;
using Cysharp.Threading.Tasks;

namespace MirageWidget.MirageAPI.MirageID.Infrastructure
{
	public interface IMirageIdUserRequests
	{
		bool IsAuthorized();
		UniTask<string> SignIn(string clientId, string clientSecret, string username, string password);

		UniTask Logout();

		UniTask<WalletInfoResponseDTO> WalletInfo();
	}
}