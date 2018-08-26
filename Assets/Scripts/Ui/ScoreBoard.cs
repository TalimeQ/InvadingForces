using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour, IBossListener {

    [SerializeField]
    TextMeshProUGUI scoreText;
    int currentScore = 0;
    [SerializeField]
    [Tooltip("Each time this score multiplier is reached, spawn a boss")]
    int bossSpawnLimit = 10;
    int nextBossSpawnsIn;
    int NextBossSpawnsIn { get { return nextBossSpawnsIn; } set { nextBossSpawnsIn = value; } }
    // Use this for initialization
    public IScoreBoardListener onScoreListener;
    void Start() {
        scoreText.SetText("Score: 0");
        BossHandler bossHandler = FindObjectOfType<BossHandler>();
        bossHandler.scoreBoardListener = this;
        nextBossSpawnsIn = bossSpawnLimit;
    }

    // Update is called once per frame

    public void addScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.SetText("Score: " + currentScore);
        CheckForBossSpawn();
    }

    private void CheckForBossSpawn()
    {
        if (currentScore > nextBossSpawnsIn)
        {
            onScoreListener.OnScoreReached();
            nextBossSpawnsIn += 100000000; // z gory nie osiagalny cap zeby wylaczyc bossa i zaoszczedzic na boolu :>
        }
    }

    public void OnBossEnter(bool wavesTurned)
    {

    }

    public void OnBossDeath()
    {
        // zdelayowany invoke w celu zabezpieczenia przed faktem pojawiania sei bossa za bossem za bossem,  w zwiazku z tym ze OnBossDeath() jest wywolywane szybciej niz Score
        Invoke("ChangeSpawnLimit",1);
       
    }
    private void ChangeSpawnLimit()
    {
         nextBossSpawnsIn = currentScore + bossSpawnLimit;
    }
}
