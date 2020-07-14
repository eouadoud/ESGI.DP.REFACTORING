using System;
namespace ESGI.DesignPattern.Projet
{
    public abstract class CapitalStrategy
    {

        private const long MILLIS_PER_DAY = 86400000;
        private const long DAYS_PER_YEAR = 365;
        private const double riskRating = 0.03;
        private const double unusedRiskRating = 0.01;

        public abstract double Capital(Loan loan);

        protected double RiskFactorFor()
        {
            return riskRating;
        }

        protected double UnusedRiskFactorFor()
        {
            return unusedRiskRating;
        }

        public virtual double Duration(Loan loan)
        {
            return YearsTo(loan.GetExpiry(), loan);
        }

        protected double YearsTo(DateTime? endDate, Loan loan)
        {
            DateTime? beginDate = (loan.GetToday().HasValue ? loan.GetToday() : loan.GetStart());
            return (double)((endDate?.Ticks - beginDate?.Ticks) / MILLIS_PER_DAY / DAYS_PER_YEAR);
        }
    }
}