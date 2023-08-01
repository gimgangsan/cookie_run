using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushPotion : Item
{
    public float Duration;
    public float SpeedIncrement;
    public override void effecacy()
    {
        base.back.speed += SpeedIncrement;
        Invoke("finish", Duration);
    }

    void finish()
    {
        base.back.speed -= SpeedIncrement;
    }
}
