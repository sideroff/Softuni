namespace TheSlum.Items
{
    public class Injection : Bonus
    {
        private const int HealthEffect = 200;
        private const int DefenseEffect = 0;
        private const int AttackEffect = 0;
        public Injection(string id) 
            : base(id, HealthEffect, DefenseEffect, AttackEffect)
        {
            this.Timeout = 3;
        }
    }
}