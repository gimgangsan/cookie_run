using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantifyPotion : Item
{
    public override void effecacy()
    {
        base.player.Enlarge();
    }
}
