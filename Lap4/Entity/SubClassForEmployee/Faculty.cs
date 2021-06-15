namespace Lap4.Entity.SubClassForEmployee
{
    public class Faculty : Employee
    {
        public string OfficeHours { get; set; }
        public int Rank { get; set; }// 1 chính thức // 2 không chính thức
        
        public override double CalculateBonus()
        {
            return 1000 + 0.05 * Salary;
        }
        public override int CalculateVacation()
        {
            if (DateHired > 3 && Rank == 1)
            {
                return 6;
            }
            else if(DateHired > 3 && Rank != 1)
            {
                return 5;
            }
            else
            {
                return 4;
            }
        }
    }}