using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyInfoDIsplay : MonoBehaviour
{

    public EnemyInfo enemyInfo;

    public TMP_Text nameText;
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        // enemyInfo.Print();
        nameText.text = "Name: " + enemyInfo.name;
        healthText.text = "Health: " + enemyInfo.health.ToString();
    }

}
