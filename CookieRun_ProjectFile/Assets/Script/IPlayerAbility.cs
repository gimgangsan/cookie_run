using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAbility
{
    void RestoreHP(float amount);
    void Enlarge();
    void GetFast();
    void GetScore(int amount);
}
