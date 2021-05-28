using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int damageAttackMelee;
    public int damageAttackFar;

    public int healthPlayer;

    private void Start()
    {
        GameManager.instance.SetDamageMeleeAttack(damageAttackMelee);
        GameManager.instance.SetDamageMeleeAttack(damageAttackFar);
    }
}
