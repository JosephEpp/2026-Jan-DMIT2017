using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Scriptable Objects/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    string characterName;
    public CharaceterStats stats;
}

[Serializable]
public class CharaceterStats
{
    public int maxHP;
    public int currentHP;
    public int maxSP;
    public int currentSP;
    public int ATK;
    public int DEF;
    public int MATK;
    public int MDEF;
    public int AGI;
}
