using VendingMachineBackend.Repositories;

namespace VendingMachineBackend.Services
{
    public class DepositService: IDepositService
    {
        private readonly IDepositRepository _depositRepository;
        private readonly HashSet<decimal> _validDeposits = new HashSet<decimal> { 5, 10, 20, 50, 100 };
        public DepositService(IDepositRepository depositRepository)
        {
            _depositRepository = depositRepository;
        }

        //public Results<decimal> PostDeposit(User au, decimal deposit)
        //{


        //    //return 0M;
        //}

        private bool IsValidDeposit(decimal deposit)
        {
            return _validDeposits.Contains(deposit);
        }
    }
}
