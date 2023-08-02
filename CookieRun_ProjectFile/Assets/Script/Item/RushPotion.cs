using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushPotion : Item
{
    public float Duration;
    public float SpeedIncrement;
    public override void effecacy()
    {
        General.Instance.player.GetFast(SpeedIncrement);
        Invoke("finish", Duration);
        base.effecacy();
    }

    void finish()
    {
        General.Instance.player.GetFast(this.Speed);
    }
}
