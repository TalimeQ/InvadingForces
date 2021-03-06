﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scores {

   public List<int> highScores = new List<int>();
    public void Init()
    {
        for(int i  = 0; i < 10;i++)
        {
            highScores.Add(0);
        }
    }
    public void AddScore(int scoreToAdd)
    {

        int index = 0;
        foreach (int i in highScores)
        {
            if(i < scoreToAdd )
            {
                index = highScores.IndexOf(i);
                break;
            }
        }
        for(int i = highScores.Count-1; i > index; i--)
        {
            highScores[i] = highScores[i - 1];
        }
        Debug.Log(index);
       highScores[index] = scoreToAdd;
    }

    public int ReturnScore(int index)
    {
        try
        { 
        return highScores[index];
        }
        catch(ArgumentOutOfRangeException)
        {
            return 0;
        }

        
    }
}
