﻿using CoreBusiness;

namespace UseCases
{
    public interface IGetTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate);
    }
}