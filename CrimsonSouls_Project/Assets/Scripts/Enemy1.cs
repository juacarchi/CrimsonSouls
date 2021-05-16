﻿using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    public Transform[] destinos;
    public Animator animEnemy1;
    public CapsuleCollider2D ccEnemy;
    public GameObject laser;
    public Transform posBoca;

    public float speed;
    public float radiusPersecution;
    public float radiusAttack;
    float timeToAttack;
    public float timeToAttackMin, timeToAttackMax;
    float timerAttack;

    int cur;

    bool isPersecution;
    bool isAttacking;
    bool canAttack;
    public bool facingRight = true;//True Right, false left.
    bool checkPosition;

    private void Start()
    {
        timeToAttack = Random.Range(timeToAttackMin, timeToAttackMax);
        timerAttack = timeToAttack;
        ccEnemy = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        isPersecution = Physics2D.OverlapCircle(transform.position, radiusPersecution, whatIsPlayer);
        isAttacking = Physics2D.OverlapCircle(transform.position, radiusAttack, whatIsPlayer);

        if (isPersecution && !isAttacking)
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
            animEnemy1.SetTrigger("NotWalk");
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
        posBoca.transform.position = new Vector2(transform.position.x, posBoca.position.y);
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
                facingRight = true;
            }
        }
        if (posPlayer.x < transform.position.x)
        {
            if (transform.localScale.x > 0)
            {
                Flip();
                facingRight = false;
            }
        }
        animEnemy1.SetTrigger("Walk");
    }
    public void Patrolling()
    {
        if (transform.position.x > destinos[cur].position.x)
        {
            if (transform.localScale.x > 0)
            {
                Flip();
                facingRight = false;
            }
        }
        if (transform.position.x < destinos[cur].position.x)
        {
            if (transform.localScale.x < 0)
            {
                Flip();
                facingRight = true;
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
        animEnemy1.SetTrigger("Walk");
    }
    public void Attacking()
    {
        timerAttack -= Time.deltaTime;
        if (timerAttack <= 0)
        {
            Debug.Log("Ataca");
            timeToAttack = Random.Range(timeToAttackMin, timeToAttackMax);
            animEnemy1.SetTrigger("Attack_01");
            timerAttack = timeToAttack;
            canAttack = false;
        }
    }
    public void CheckFlip()
    {
        Vector2 posPlayer = Character2DController.instance.transform.position;
        if (posPlayer.x > transform.position.x)
        {
            if (transform.localScale.x < 0)
            {
                Flip();
                facingRight = true;
            }
        }
        if (posPlayer.x < transform.position.x)
        {
            if (transform.localScale.x > 0)
            {
                Flip();
                facingRight = false;
            }
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
        Gizmos.DrawWireSphere(transform.position, radiusAttack);
    }

    public void InstantiateLaser()
    {
        Instantiate(laser, posBoca.transform.position, Quaternion.identity);

    }
}
