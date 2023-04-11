using System.Collections.Generic;
using MirageWidget.MirageAPI.SmartContractManager.Data.AllContracts;
using MirageWidget.MirageAPI.SmartContractManager.Data.GetContract;
using Cysharp.Threading.Tasks;

namespace MirageWidget.MirageAPI.SmartContractManager.Infrastructure
{
	public interface ISmartContractRequests
	{
		public bool IsInitialized();
		public void SetToken(string applicationToken);
		public UniTask<GetContractResponseDTO> GetContractInfo(string contractId);
		public UniTask<List<SCMContractIDPair>> GetAllContracts();
	}
}