using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILifeListener  {


    void OnLifeGained();
    void OnLifeLost(int hpLost);
}
