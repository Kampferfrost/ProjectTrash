namespace TestCode
{
    internal class Handler
    {
        public delegate void Congratulate(int employeeId);

        public event Congratulate Congatulated;

        public void CongratulateEmployees(Employee employee)
        {


                Congatulated(employee.Id);

        }

        
    }
}
