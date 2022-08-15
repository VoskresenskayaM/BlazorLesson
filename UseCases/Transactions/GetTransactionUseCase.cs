using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfasces;

namespace UseCases
{
    public class GetTransactionUseCase : IGetTransactionUseCase
    {
        private readonly ITransactionRepository trancactionRepository;

        public GetTransactionUseCase(ITransactionRepository trancactionRepository)
        {
            this.trancactionRepository = trancactionRepository;
        }

        public IEnumerable<Transaction> Execute(string cashierName,
            DateTime startDate,
            DateTime endDate)
        {
            return trancactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
