//Manages avaliable augments and lvl up UI & player selection.
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheSummitCombat
{
    [System.Serializable]
    public class AugmentUI
    {
        [Header("Augment UI elements")]
        [SerializeField] public TMP_Text augmentNameText;
        [SerializeField] public TMP_Text augmentDescText;
        [SerializeField] public TMP_Text augmentFlavourText;
        [SerializeField] public TMP_Text augmentStatsText;
    }

    public class PlayerLvlSystem : MonoBehaviour
    {
        public float lvlUpThreshold = 100f;
        public GameObject augmentUI;
        public AttackStats spellStats;
        public HealthStats healthStats;
        public AugmentLookup augmentLookup;

        private List<string> avaliableAugments;
        private List<ISpellAugment> activeAugments = new List<ISpellAugment>();
        [SerializeField] AugmentUI[] augmentUIs;

        private void Start()
        {
            avaliableAugments = new List<string>
        {
            "Ignition",
            "Chill",
            "Freeze"
        };

            foreach (var augment in avaliableAugments)
            {
                augmentLookup.AddAvailableAugment(augment);
            }
        }

        private void Update()
        {
            if (healthStats.currentXP >= lvlUpThreshold)
            {
                healthStats.currentXP = 0;
                ShowUpgradeOptions();
            }
        }

        void ShowUpgradeOptions()
        {
            Time.timeScale = 0;
            augmentUI.SetActive(true);

            if (avaliableAugments.Count < augmentUIs.Length)
            {
                Debug.Log("Not Enough augements avaliable");
                return;
            }

            for (int i = 0; i < augmentUIs.Length; i++)
            {
                string chosenAugment = SelectRandomAugment();
                PopulateAugmentUI(chosenAugment, augmentUIs[i]);
            }
    ;
        }

        string SelectRandomAugment()
        {
            return augmentLookup.GetRandomAugmentName();
        }

        void PopulateAugmentUI(string augmentName, AugmentUI augmentUI)
        {
            ISpellAugment augment = augmentLookup.GetAugment(augmentName);

            augmentUI.augmentNameText.text = augmentName;
            augmentUI.augmentDescText.text = augment.GetDescription();
            augmentUI.augmentFlavourText.text = augment.GetFlavourText();
            augmentUI.augmentStatsText.text = augment.GetStats(spellStats);

            Button augmentButton = augmentUI.augmentNameText.transform.parent.GetComponentInChildren<Button>();
            augmentButton.onClick.RemoveAllListeners();

            augmentButton.onClick.AddListener(() => SelectAugment(augmentName));
        }

        public void SelectAugment(string augmentName)
        {
            ISpellAugment augment = augmentLookup.GetAugment(augmentName);
            if (augment != null)
            {
                activeAugments.Add(augment);
                ReapplyAllAugments();
                augmentLookup.RemoveAugment(augmentName);
            }
            HideUpgradeOptions();
        }

        void ReapplyAllAugments()
        {
            spellStats.ResetStatsToBase();

            foreach (var augment in activeAugments)
            {
                augment.ApplyAugment(spellStats);
            }
        }

        public List<ISpellAugment> GetActiveAugments()
        {
            return activeAugments;
        }

        void HideUpgradeOptions()
        {
            augmentUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
