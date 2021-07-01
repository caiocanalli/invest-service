using System;
using Invest.Domain.Common;

namespace Invest.Domain.Investments
{
    public class Investment
    {
        public string Name { get; }
        public decimal InvestedValue { get; }
        public decimal TotalValue { get; }
        public DateTime DueDate { get; }
        public decimal IncomeTaxes { get; }
        public decimal RescueValue { get; }

        public Investment(
            string name,
            decimal investedValue,
            decimal totalValue,
            DateTime dueDate,
            IncomeTaxesPolicy policy)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Invalid name");
            if (investedValue <= 0)
                throw new DomainException("Invalid invested value");
            if (totalValue < 0)
                throw new DomainException("Invalid total value");
            if (dueDate == default)
                throw new DomainException("Invalid due date");

            Name = name;
            InvestedValue = investedValue;
            TotalValue = totalValue;
            DueDate = dueDate;
            IncomeTaxes = policy.CalcIncomeTaxes(this);
            RescueValue = CalcRescueValue();
        }

        decimal CalcRescueValue()
        {
            if (DateTime.Now > DueDate)
                return InvestedValue;
            if (DueDate.AddMonths(-6) <= DateTime.Now)
                return InvestedValue - InvestedValue * (decimal) 0.06;
            if (DueDate.AddMonths(-3) <= DateTime.Now)
                return InvestedValue - InvestedValue * (decimal) 0.15;
            return InvestedValue - InvestedValue * (decimal) 0.3;
        }
    }
}