using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string namePlayer;
    public static GameManager instance;
    int damageMeleeAttack;
    public float healthMax;
    [HideInInspector]
    public float health;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        damageMeleeAttack = 100;
    }
    public int GetDamageMeleeAttack()
    {
        return this.damageMeleeAttack;
    }
    public void SetNamePlayer(string namePlayer)
    {
        this.namePlayer = namePlayer;
        Debug.Log(namePlayer);
    }
}
