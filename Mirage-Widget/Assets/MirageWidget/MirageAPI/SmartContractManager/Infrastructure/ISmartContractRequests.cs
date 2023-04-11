using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MirageWidget.MirageAPI.SmartContractManager.Data.AllContracts;
using MirageWidget.MirageAPI.SmartContractManager.Data.GetContract;

namespace MirageWidget.MirageAPI.SmartContractManager.Infrastructure
{
	public interface ISmartContractRequests
	{
		bool IsInitialized();
		void SetToken(string applicationToken);
		UniTask<GetContractResponseDTO> GetContractInfo(string contractId);
		UniTask<List<SCMContractIDPair>> GetAllContracts();
	}
}