namespace Empires.Contracts
{
    /// <summary>
    /// Inheritants of this interface have attack damage
    /// </summary>
    public interface IAttacker
    {
        int AttackDamage { get; }
    }
}
