namespace TheSummitCombat
{
    public interface ISpellAugment
    {
        void ApplyAugment(AttackStats spellStats);
        void ModifyStats(AttackStats spellStats);
        void OnHit(EnemyStats enemyStats);

        string GetName();
        string GetDescription();
        string GetFlavourText();
        string GetStats(AttackStats spellStats);
    }
}