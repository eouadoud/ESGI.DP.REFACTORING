namespace ESGI.DesignPattern.Projet
{
    public class CapitalStrategyRevolver : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            return (loan.GetOutStanding() * Duration(loan) * RiskFactorFor())
                        + (loan.UnusedRiskAmount() * Duration(loan) * UnusedRiskFactorFor());
        }

        private double UnusedRiskFactorFor(Loan loan)
        {
            return UnusedRiskFactors.unusedRiskRating;
        }
    }
}