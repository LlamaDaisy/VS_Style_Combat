using System;
using UnityEngine;
namespace TheSummitCombat
{

    [CreateAssetMenu(menuName = "Health Stats")]
    [Serializable]
    public class HealthStats : ScriptableObject
    {
        [SerializeField] GameObject gameObject;

        [Header("General Stats")]
        [SerializeField] public float currentHealth;
        [SerializeField] public float maxHealth;
        [SerializeField] public float movementSpeed;

        [Header("XP: Player Only")]
        [SerializeField] public float currentXP;
        [SerializeField] public float maxXP;
    }
}
