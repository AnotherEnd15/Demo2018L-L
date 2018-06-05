using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BuffType
{
    //物理封印
    PhysicalSealAhs,
    MagicSealAhs,
    MagicDrop,
    StrengthDrop,
    DefenseDrop,
    MagicDefenseDrop,
    HpMaxDrop,
    HpLoss,
    MpMaxDrop,
    MpLoss
}
public class Buff : SpellBase {

    public float Time { get; set; }
    public BuffType Type { get; set; }
    //强度如果在0~1之间，就代表着百分比，如果在1~n之间，那就代表着具体的数值
    public float BuffIntensity { get; set; }
    public void Attach(Transform trans)
    {

    }
    public void Detach(Transform trans)
    {

    }
}
