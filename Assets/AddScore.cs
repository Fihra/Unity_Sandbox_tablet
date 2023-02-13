using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AddScore : MonoBehaviour
{
    // [SerializeField]
    private GameObject scoreObject;
    
    private TMP_Text scoreText;

    void Start()
    {
        scoreObject = GameObject.Find("ScoreText");
        scoreText = scoreObject.GetComponent<TMP_Text>();
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.SetText("Score: " + ScoreManager.GetScore());
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0 && Input.GetKeyDown(KeyCode.S)){
            Debug.Log(ScoreManager.GetScore());
            ScoreManager.AddScore();
            scoreObject = GameObject.Find("ScoreText");
            scoreText = scoreObject.GetComponent<TMP_Text>();
            UpdateScoreText();
        }
    }
}
