using System;
using System.Collections.Generic;
using System.Text;

namespace ESGI.DesignPattern.Projet
{
    public class LoanBuilder
    {
        private double commitment = 1.0;
        private DateTime start = DateTime.Now;
        private DateTime? expiry;
        private DateTime? maturity;
        private CapitalStrategy capitalStrategy;
        private int riskRating;
        private double unusedPercentage = 1.0;
        private double outstanding = 0;

        public Loan Build()
        {
            return new Loan(
                commitment,
                start,
                expiry,
                maturity,
                riskRating,
                capitalStrategy,
                unusedPercentage
            );
        }

        public LoanBuilder WithCommitment(double commitment)
        {
            this.commitment = commitment;
            return this;
        }

        public LoanBuilder WithUnusedPercentage(double unusedPercentage)
        {
            this.unusedPercentage = unusedPercentage;
            return this;
        }

        public LoanBuilder WithStartDate(DateTime start)
        {
            this.start = start;
            return this;
        }

        public LoanBuilder WithExpiryDate(DateTime? expiry)
        {
            this.expiry = expiry;
            return this;
        }

        public LoanBuilder WithMaturityDate(DateTime? maturity)
        {
            this.maturity = maturity;
            return this;
        }

        public LoanBuilder WithRiskRating(int riskRating)
        {
            this.riskRating = riskRating;
            return this;
        }

        public LoanBuilder WithStrategy(CapitalStrategy capitalStrategy)
        {
            this.capitalStrategy = capitalStrategy;
            return this;
        }

    }
}
