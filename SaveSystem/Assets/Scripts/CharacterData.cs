using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[Serializable]
public class CharacterData
{
    public CharaceterStats stats;

    public void InitializeCharacterData(CharacterSO config_)
    {
        stats = new CharaceterStats();
        stats = config_.stats;
        stats.currentHP = config_.stats.currentHP;
        stats.maxHP = config_.stats.maxHP;
    }
}
