using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Loan
    {

        public readonly DateTime? _expiry;
        public readonly DateTime? _maturity;
        public double _commitment { get; }
        public double _outstanding { get; }
        public IList<Payment> _payments { get; } = new List<Payment>();
        public readonly DateTime? _today = DateTime.Now;
        public readonly DateTime _start;
        public readonly double _riskRating;
        public readonly double _unusedPercentage;
        private readonly CapitalStrategy _capitalStrategy;

        internal Loan(double commitment,
                    double notSureWhatThisIs,
                    DateTime start,
                    DateTime? expiry,
                    DateTime? maturity,
                    int riskRating,
                    CapitalStrategy capitalStrategy,
                    double unusedPercentage,
                    double outstanding)
        {
            this._expiry = expiry;
            this._commitment = commitment;
            this._today = null;
            this._start = start;
            this._maturity = maturity;
            this._riskRating = riskRating;
            this._unusedPercentage = 1.0;
            this._capitalStrategy = capitalStrategy;
            this._unusedPercentage = unusedPercentage;
            this._outstanding = outstanding;
        }

        public void Payment(double amount, DateTime paymentDate)
        {
            _payments.Add(new Payment(amount, paymentDate));
        }

        public double UnusedRiskAmount()
        {
            return (_commitment - _outstanding);
        }

    }
}