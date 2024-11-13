//Handles augment lookup and hold augment dictionary where you can set damage and duration of augments.
using System.Collections.Generic;
using UnityEngine;

namespace TheSummitCombat
{
    public class AugmentLookup : MonoBehaviour
    {
        List<string> avaliableAugments = new List<string>();
        private Dictionary<string, ISpellAugment> spellAugments;

        private void Start()
        {
            spellAugments = new Dictionary<string, ISpellAugment>();

            spellAugments.Add("Ignition", new FireIgnition(5f, 5f));
            spellAugments.Add("Chill", new IceChill(1f, 3f));
            spellAugments.Add("Freeze", new IceFreeze(3f));
        }

        public void AddAvailableAugment(string augmentName)
        {
            if (!avaliableAugments.Contains(augmentName))
            {
                avaliableAugments.Add(augmentName);
            }
        }

        public string GetRandomAugmentName()
        {
            if (avaliableAugments.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, avaliableAugments.Count);
            return avaliableAugments[randomIndex];
        }

        public ISpellAugment GetRandomAugment()
        {
            if (avaliableAugments.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, avaliableAugments.Count);
            string selectedAugmentName = avaliableAugments[randomIndex];
            ISpellAugment selectedAugment = GetAugment(selectedAugmentName);

            RemoveAugment(selectedAugmentName);
            return selectedAugment;
        }

        public ISpellAugment GetAugment(string augName)
        {
            if (spellAugments.ContainsKey(augName))
            {
                return spellAugments[augName];
            }

            else
            {
                return null;
            }
        }

        /// <summary>
        /// Removes the selected augment from the list of avaliable augments so it can't be selected again.
        /// </summary>
        /// <param name="augmentName"></param>
        public void RemoveAugment(string augmentName)
        {
            if (avaliableAugments.Contains(augmentName))
            {
                avaliableAugments.Remove(augmentName);
            }
        }
    }
}
