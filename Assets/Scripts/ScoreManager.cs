using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    public Text textObject;
    public int currentScore = 0; 

    public void UpdateScore(int score)
    {
        currentScore += score;
    }

    void FixedUpdate()
    {
        if (textObject)
            textObject.text = currentScore.ToString();
    }
}
