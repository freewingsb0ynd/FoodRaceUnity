using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    
    public Text scoreHolder;

    private void Update()
    {
        scoreHolder.text = GameManager.score.ToString();
    }
    public static void Scoring()
    {
        GameManager.score += 20;
    }
}
