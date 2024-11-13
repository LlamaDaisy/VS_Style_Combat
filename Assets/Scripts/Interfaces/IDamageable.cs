using UnityEngine;
namespace TheSummitCombat
{
    public interface IDamageable
    {
        Vector3 Position { get; }
        void Damage(float damage);
    }
}