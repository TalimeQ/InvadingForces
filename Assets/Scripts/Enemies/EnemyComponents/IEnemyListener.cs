using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyListener  {


    void OnEnemyDeath(Transform deathPos,int chanceBonus);
}
