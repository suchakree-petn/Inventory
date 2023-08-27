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
    public float _bonusAttack;
    public virtual void Equip(GameObject player) { }
}
