using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPotion : Item
{
    public float restore;
    public override void effecacy()
    {
        General.Instance.player.RestoreHP(restore);
        base.effecacy();
    }
}
