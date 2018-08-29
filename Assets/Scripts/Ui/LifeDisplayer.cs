using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplayer : MonoBehaviour, ILifeListener {

    [SerializeField] Sprite lifeSprite;
    [SerializeField] Sprite lifeLostSprite;

    [Tooltip("Po lewo, pierwsze po prawo ostatnie")]
    [SerializeField] List<Image> hpBars;
    // Tez mi sie ten sztywniak nie podoba.
    private int hp = 5;

    void ILifeListener.OnLifeGained()
    {
        if (hp >= 5) return;
        AddHpOnBar();
        
    }

    void ILifeListener.OnLifeLost(int hpLost)
    {

        DeductHpOnBar(hpLost);
    }

    void AddHpOnBar()
    {
        hp++;
        for(int i = 0; i < hp; i++)
        {
            hpBars[i].sprite = lifeSprite;
        }
    }
    void DeductHpOnBar(int hpLost)
    {
        hp = hp - hpLost;
        if (hp <= 0) hp = 0;
        for (int i = hp; i < 5; i++)
        {
            hpBars[i].sprite = lifeLostSprite;
        }
    }
}
