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
        private long MILLIS_PER_DAY = 86400000;
        private long DAYS_PER_YEAR = 365;
        private double _riskRating;
        private double _unusedPercentage;
        private CapitalStrategy _capitalStrategy;

        internal Loan(double commitment,
                    DateTime start,
                    DateTime? expiry,
                    DateTime? maturity,
                    int riskRating,
                    CapitalStrategy capitalStrategy,
                    double unusedPercentage)
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

        public DateTime? GetMaturity()
        {
            return _maturity;
        }

        public double GetRiskRating()
        {
            return _riskRating;
        }

        public void Payment(double amount, DateTime paymentDate)
        {
            _payments.Add(new Payment(amount, paymentDate));
        }

        public double Capital()
        {
            return _capitalStrategy.Capital(this);
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

        public void SetUnusedPercentage(double unusedPercentage)
        {
            _unusedPercentage = unusedPercentage;
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