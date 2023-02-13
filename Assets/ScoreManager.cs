using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score = 0;
    // Start is called before the first frame update

    public static void AddScore()
    {
        score++;
    }

    public static void ResetScore()
    {
        score = 0;
    }

    public static int GetScore()
    {   
        return score;
    }
}
