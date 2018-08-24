using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBossListener  {

    // this method is used to turn off wave and meteor spawns;
    void OnBossEnter(bool wavesTurned);
    void OnBossDeath();
}
