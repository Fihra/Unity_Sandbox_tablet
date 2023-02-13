using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplyLatestScore : MonoBehaviour
{
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
        text.SetText("Score: " + ScoreManager.GetScore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
