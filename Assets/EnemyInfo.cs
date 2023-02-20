using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Info", menuName = "Enemy")]
public class EnemyInfo : ScriptableObject
{
    public new string name;
    public int health;

    public void Print()
    {
        Debug.Log("Name: " + name);
        Debug.Log("Health: " + health);
    }
}
