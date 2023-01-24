using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectStats;

public class StatsScript : MonoBehaviour
{
    [SerializeField] private Stats stats = new Stats();
    private readonly Dictionary<string, Stat> statValues = new Dictionary<string, Stat>();




    public void AddBuff()
    {

    }

    public void RemoveBuff()
    {

    }

    public bool ContainsStat(string statName)
    {
        return statValues.ContainsKey(statName);   
    }

    public void ChangeStat(string statName, float value)
    {
        stats.ChangeStatValueBy(statName, value);
    }
    public void CreateStat(string statName, StatType statType, float statValue)
    {
        statValues.Add(statName, new Stat(statType, statValue));
        stats.ConstructStat(statName, statType, statValue);
    }

    public void CreateModifier(string statName, StatType statType, float statValue)
    {

        stats.ConstructModifier(statName, statType, statValue);
    }
    public float GetStatValue(string statName)
    {
        Stat stat = statValues[statName];
        if (stat.isCalculated) return stat.value;

        CalculateStat(statName);
        return statValues[statName].value;
    }

    public float GetModifierValue(string modifierName)
    {
        return stats.modifiers[modifierName].value;
    }

    private void CalculateStat(string statName)
    {
        if (!statValues.ContainsKey(statName)) return;
        Stat targetStat = stats.GetStat(statName);
        statValues[statName] = new Stat(targetStat.type, stats.CalculateStat(statName), targetStat.isCalculated);


    }

    public class StatContainer
    {
        public Stat stat;


    }
}
