﻿using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public Transform[] destinos;
    public Animator animEnemy1;
    public CapsuleCollider2D ccEnemy;

    public float speed;
    public float radiusPersecution;
    public float radiusAttack;
    public float timeToAttack;

    float timerAttack;

    int cur;
    
    bool isPersecution;
    bool isAttacking;
    bool canAttack;

    private void Start()
    {
        timerAttack = timeToAttack;
        ccEnemy = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        isPersecution = Physics2D.OverlapCircle(transform.position, radiusPersecution, whatIsPlayer);
        isAttacking = Physics2D.OverlapCircle(transform.position, radiusAttack, whatIsPlayer);

        if(isPersecution && !isAttacking)
        {
            Persecution();
        }
        if (!isPersecution && !isAttacking)
        {
            Patrolling();
        }
        if (isAttacking)
        {
            canAttack = true;
        }
        if (!isAttacking)
        {
            timerAttack = Random.Range(0.3f, 1.2f);
        }
        if (canAttack)
        {
            Attacking();
        }


        if (Character2DController.instance.isDashing)
        {
            ccEnemy.enabled = false;
        }
        else
        {
            ccEnemy.enabled = true;
        }
        
    }
    public void Persecution()
    {
        Vector2 posPlayer = Character2DController.instance.transform.position;
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(posPlayer.x, transform.position.y), step);

        if (posPlayer.x > transform.position.x)
        {
            if (transform.localScale.x < 0)
            {
                Flip();
            }
        }
        if (posPlayer.x < transform.position.x)
        {
            if (transform.localScale.x > 0)
            {
                Flip();
            }
        }
        animEnemy1.SetBool("PosAtaque", true);

    }
    public void Patrolling()
    {
        if (transform.position.x > destinos[cur].position.x)
        {
            if (transform.localScale.x > 0)
            {
                Flip();
            }
        }
        if (transform.position.x < destinos[cur].position.x)
        {
            if (transform.localScale.x < 0)
            {
                Flip();
            }
        }


        if (transform.position != destinos[cur].position)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, destinos[cur].position, step);
        }
        else
        {
            cur++;
        }
        if (cur == destinos.Length)
        {
            cur = 0;
        }


        animEnemy1.SetBool("PosAtaque", false);
    }
    public void Attacking()
    {
        timerAttack -= Time.deltaTime;
        if (timerAttack <= 0)
        {
            Debug.Log("Ataca");
            animEnemy1.SetTrigger("Attack_01");
            timerAttack = timeToAttack;
            canAttack = false;
        }
    }
    public void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusPersecution);
    }

}