using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public LayerMask whatIsEnemy;
    public LayerMask whatIsPlayerAttack;
    public LayerMask whatIsPlayer;
    public Transform originPoint;
    public Animator animEnemy2;
    public CapsuleCollider2D cc2D;

    public float originRadius;
    public float radiusPersecution;
    public float radiusAttack;
    public float radiusDefend;
    float timeToAttack;
    float timerAttack;
    public float timeToAttackMin, timeToAttackMax;

    bool checkPosition;
    bool isPersecution;
    bool isCollisionRight;
    bool isCollisionLeft;
    bool isAttackRange;
    bool facingRight;
    bool isOutOfRange;
    private void Start()
    {
        timeToAttack = Random.Range(timeToAttackMin, timeToAttackMax);
        timerAttack = timeToAttack;
        cc2D = GetComponent<CapsuleCollider2D>();
        facingRight = true;
    }
    private void Update()
    {
        isOutOfRange = Physics2D.OverlapCircle(originPoint.transform.position, originRadius, whatIsEnemy);
        isPersecution = Physics2D.OverlapCircle(transform.position, radiusPersecution, whatIsPlayer);
        isAttackRange = Physics2D.OverlapCircle(transform.position, radiusAttack, whatIsPlayer);

        isCollisionRight = Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), radiusDefend, whatIsPlayerAttack);
        isCollisionLeft = Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), radiusDefend, whatIsPlayerAttack);
        Collider2D colliderLeft = Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), radiusDefend, whatIsPlayerAttack);


        if (isPersecution && !isAttackRange)
        {
            if (isOutOfRange)
            {
                BackStart();
            }
            else
            {
                Persecution();
            }
            
        }
        if(isPersecution && isAttackRange)
        {
            if (isOutOfRange)
            {
                BackStart();
            }
            else
            {
                timerAttack -= Time.deltaTime;
                if (timerAttack <= 0)
                {
                    Attack();
                    timerAttack = Random.Range(timeToAttackMin, timeToAttackMax);
                }
            }
        }
        if(isCollisionRight && facingRight)
        {
            Debug.Log("Se defiende por la derecha");
            //colliderRight.enabled = false;
        }
        if(isCollisionLeft && !facingRight)
        {
            Debug.Log("Se defiende por la izquierda");
            //colliderLeft.enabled = false;
            Debug.Log(colliderLeft.name);
        }



    }
    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(new Vector2(transform.position.x - 1, transform.position.y), new Vector2(1, cc2D.size.y));
    //}
    public void Persecution()
    {
        Debug.Log("Persecution");
    }
    public void BackStart()
    {
        Debug.Log("BackStart");
    }
    public void Attack()
    {
        Debug.Log("Attack");
    }
    public void DefendAttack()
    {
        Debug.Log("DefendAttack");
    }

    public void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

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
}
