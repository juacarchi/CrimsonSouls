using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string namePlayer;
    public static GameManager instance;
    int damageMeleeAttack;
    int damageFarAttack;
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
        
    }
    public void SetDamageMeleeAttack(int damageMeleeAttack)
    {
        this.damageMeleeAttack = damageMeleeAttack;
    }
    public int GetDamageMeleeAttack()
    {
        return this.damageMeleeAttack;
    }
    public void SetDamageFarAttack(int damageFarAttack)
    {
        this.damageFarAttack = damageFarAttack;
    }
    public int GetDamageFarAttack()
    {
        return this.damageFarAttack;
    }
    public void SetNamePlayer(string namePlayer)
    {
        this.namePlayer = namePlayer;
        Debug.Log(namePlayer);
    }
}
