using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Loan
    {
        double _commitment = 1.0;
        private DateTime? _expiry;
        private DateTime? _maturity;
        private double _outstanding;
        IList<Payment> _payments = new List<Payment>();
        private DateTime? _today = DateTime.Now;
        private DateTime _start;
        private double _riskRating;
        private double _unusedPercentage;
        private CapitalStrategy _capitalStrategy;

        internal Loan(double commitment,
                    DateTime start,
                    DateTime? expiry,
                    DateTime? maturity,
                    int riskRating,
                    CapitalStrategy capitalStrategy,
                    double unusedPercentage,
                    double _outstanding)
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
            this._outstanding = _outstanding;
        }

        public static Loan NewTermLoan(double commitment, DateTime start, DateTime maturity, int riskRating)
        {
            return new LoanBuilder()
                .WithCommitment(commitment)
                .WithStartDate(start)
                .WithExpiryDate(null)
                .WithMaturityDate(maturity)
                .WithRiskRating(riskRating)
                .WithStrategy(new CapitalStrategyTermLoan())
                .Build();
        }

        public static Loan NewRevolver(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            return new LoanBuilder()
                .WithCommitment(commitment)
                .WithStartDate(start)
                .WithExpiryDate(expiry)
                .WithMaturityDate(null)
                .WithRiskRating(riskRating)
                .WithStrategy(new CapitalStrategyRevolver())
                .Build();
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            return new LoanBuilder()
                .WithCommitment(commitment)
                .WithStartDate(start)
                .WithExpiryDate(expiry)
                .WithMaturityDate(null)
                .WithRiskRating(riskRating)
                .WithStrategy(new CapitalStrategyAdvisedLine())
                .WithUnusedPercentage(0.1)
                .Build();
        }

        public DateTime? GetExpiry()
        {
            return _expiry;
        }

        public double GetCommitment()
        {
            return _commitment;
        }

        public double GetOutStanding()
        {
            return _outstanding;
        }

        public void Payment(double amount, DateTime paymentDate)
        {
            _payments.Add(new Payment(amount, paymentDate));
        }


        public DateTime? GetToday()
        {
            return _today;
        }

        public DateTime? GetStart()
        {
            return _start;
        }

        public IList<Payment> Payments()
        {
            return _payments;
        }

        public double GetUnusedPercentage()
        {
            return _unusedPercentage;
        }

        public double UnusedRiskAmount()
        {
            return (_commitment - _outstanding);
        }

        public double OutstandingRiskAmount()
        {
            return _outstanding;
        }
    }
}