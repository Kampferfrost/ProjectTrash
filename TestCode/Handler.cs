namespace TestCode
{
    internal class Handler
    {
        public delegate int CalculateBonus(Position position);

        public CalculateBonus? CalculateBonusForEmployee { get; set; }

        private void CalculateBonuses(IEnumerable<Employee> employees)
        {
            foreach(Employee employee in employees)
            {
                employee.Bonus = CalculateBonusForEmployee(employee.Position);
            }
        }
    }
}
