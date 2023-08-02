using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    public int Score;
    public override void effecacy()
    {
        General.Instance.player.GetScore(Score);
        base.effecacy();
    }
}
