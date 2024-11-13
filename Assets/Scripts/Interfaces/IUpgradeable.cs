using UnityEngine;
namespace TheSummitCombat
{
    public interface IUpgradeable
    {
        void ApplyUpgrade(HealthStats healthStats);
    }
}