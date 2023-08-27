using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RelicPart
{
    Necklace,
    Ring,
    Cloak,
}
public class Relic : Item
{
    public RelicPart _relicPart;
    public ElementalType _elementalBonusType;
    public float _elementalBonusDamage;
    public float _bonusAttack;
    public float _BonusHp;
    public float _BonusDefense;
    public float _BonusMana;

    public virtual void Equip(GameObject player) { }
}
