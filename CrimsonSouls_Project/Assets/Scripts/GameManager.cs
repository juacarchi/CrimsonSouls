using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string namePlayer;
    public static GameManager instance;
    bool hasBaston;
    int damageMeleeAttack;
    int damageFarAttack;
    public float healthMax;
    [HideInInspector]
    int health;
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
        health = 3;
        
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
    public int GetHealth()
    {
        return this.health;
    }
    public void SetHealth(int health)
    {
        this.health = health;
    }
    public void LoseHealth(int health)
    {
        this.health -= health;
        HUDManager.instance.ChangeLifeUI();
    }
    public void SetHasBaston(bool hasBaston)
    {
        this.hasBaston = hasBaston;
    }
    public bool GetHasBaston()
    {
        return hasBaston;
    }
}
