using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public LayerMask whatIsPlayerAttack;
    public LayerMask whatIsPlayer;
    public Transform originPoint;
    public Animator animEnemy2;
    public CapsuleCollider2D cc2D;

    public float radiusPersecution;
    public float radiusAttack;
    float timeToAttack;
    float timerAttack;
    public float timeToAttackMin, timeToAttackMax;

    bool checkPosition;
    bool isPersecution;
    bool isCollisionRight;
    bool isCollisionLeft;
    bool isAttackRange;
    bool facingRight;

    private void Start()
    {
        timeToAttack = Random.Range(timeToAttackMin, timeToAttackMax);
        timerAttack = timeToAttack;
        cc2D = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
        isPersecution = Physics2D.OverlapCircle(transform.position, radiusPersecution, whatIsPlayer);
        isAttackRange = Physics2D.OverlapCircle(transform.position, radiusAttack, whatIsPlayer);

        isCollisionRight = Physics2D.OverlapBox(new Vector2(transform.position.x + 1, transform.position.y), new Vector2(1,cc2D.size.y), whatIsPlayerAttack);
        isCollisionLeft = Physics2D.OverlapBox(new Vector2(transform.position.x - 1, transform.position.y), new Vector2(1, cc2D.size.y), whatIsPlayerAttack);

        if (isPersecution)
        {

        }


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x - 1, transform.position.y), new Vector2(1, cc2D.size.y));
    }
}
