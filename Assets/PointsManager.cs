using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsManager : MonoBehaviour
{
    private static int currentPoints = 0;
    public TMP_Text pointsText;

    public void AddPoints()
    {
        currentPoints++;
        if(currentPoints == 10)
        {
            Slash slashDamage = GameObject.Find("Slash").GetComponent<Slash>();
            slashDamage.UpdateDamage();
        }
        UpdatePointsText();
    }

    public void ResetPoints()
    {
        currentPoints = 0;
    }

    public void UpdatePointsText()
    {
        pointsText.SetText("Points: " + currentPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
