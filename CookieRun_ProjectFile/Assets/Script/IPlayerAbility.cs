using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAbility
{
    void RestoreHP(float amount);
    void Enlarge();
    void GetFast(float speed);
    void GetScore(int amount);
}
