using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushPotion : Item
{
    public float Duration;
    public float SpeedIncrement;
    public override void effecacy()
    {
        player.GetFast(SpeedIncrement);
        Invoke("finish", Duration);
        base.effecacy();
    }

    void finish()
    {
        player.GetFast(this.Speed);
    }
}
