using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;



namespace ObjectStats
{
    public enum StatType
    {
        HealthPoints,
        MaxHealthPoints,
    }
    public enum ModifierType
    {
        Flat,
        Multiplicative,
        Additive
    }

    public class Stats
    {
        public readonly Dictionary<string, Stat> stats = new Dictionary<string, Stat>();
        public readonly Dictionary<string, ModifierStat> modifiers = new Dictionary<string, ModifierStat>();


        public Stats()
        {
            InitStats();
        }

        public void ChangeStatValueBy(string statName, float valueChange)
        {
            Stat newStat = stats[statName];
            newStat.value += valueChange;
            stats[statName] = newStat;
            newStat.isCalculated = false;
        }

        public void SetStatValueTo(string statName, float valueChange)
        {
            Stat newStat = stats[statName];
            newStat.value = valueChange;
            stats[statName] = newStat;
            newStat.isCalculated = false;
        }



        public void ConstructStat(string statName, StatType statType, float statValue)
        {
            AddNewStat(statName, new Stat(statType, statValue));
        }

        public void ConstructModifier(string statName, StatType statType, float statValue)
        {
            AddNewMod(statName, new ModifierStat(statType, statValue));
        }

        public Stat GetStat(string statName)
        {
            stats.TryGetValue(statName, out Stat stat);
            return stat;
        }

        public float GetStatValue(string statName)
        {
            return GetStat(statName).value;
        }

        private void AddNewStat(string statName, Stat stat)
        {
            stats.Add(statName, stat);
        }

        private void AddNewMod(string statName, ModifierStat modStat)
        {
            modifiers.Add(statName, modStat);
        }

        public void InitStats()
        {
            stats.Clear();
        }

        public float CalculateStat(string statName)
        {

            Stat targetStat = stats[statName];
            StatType targetStatType = targetStat.type;
            float targetStatValue = targetStat.value;
            float calculatedStatValue = targetStat.value;
            foreach (ModifierStat modifier in modifiers.Values)
            {
                if (modifier.type == targetStatType)
                {

                    switch (modifier.modType)
                    {
                        case ModifierType.Flat:
                            calculatedStatValue += modifier.value;
                            break;
                        case ModifierType.Multiplicative:
                            calculatedStatValue *= modifier.value;
                            break;
                        case ModifierType.Additive:
                            calculatedStatValue += calculatedStatValue * modifier.value;
                            break;
                        default:
                            Debug.LogError("Stat modifier " + modifier.modType + " is unknown. The modifier was not applied to the target stat.");
                            break;
                    }
                }
            }
            return calculatedStatValue;



        }

    }

    public struct Stat
    {

        public float value;
        public StatType type;
        public bool isCalculated;

        public Stat(StatType statType, float statValue, bool calculated = false)
        {
            type = statType;
            value = statValue;
            isCalculated = calculated;

        }
    }

    public struct ModifierStat
    {

        public float value;
        public bool isPercentage;
        public StatType type;
        public ModifierType modType;

        public ModifierStat(StatType statType, float statValue, bool statIsPercentage = false, ModifierType statModType = ModifierType.Flat)
        {
            type = statType;
            value = statValue;
            isPercentage = statIsPercentage;
            modType = statModType;


        }
    }

    public class Buff
    {
        Timer buffTimer;

        public Buff(float timerDuration)
        {
            buffTimer = new Timer(timerDuration);
        }

    }


}



