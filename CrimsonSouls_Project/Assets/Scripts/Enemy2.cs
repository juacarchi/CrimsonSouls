using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public LayerMask whatIsEnemy;
    public LayerMask whatIsPlayerAttack;
    public LayerMask whatIsPlayer;
    public Transform originPoint;
    public Animator animEnemy2;
    public CapsuleCollider2D cc2D;

    public float speed;
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
    bool isInRange;
    private void Start()
    {
        timeToAttack = Random.Range(timeToAttackMin, timeToAttackMax);
        timerAttack = timeToAttack;
        cc2D = GetComponent<CapsuleCollider2D>();
        facingRight = true;
    }
    private void Update()
    {
        isInRange = Physics2D.OverlapCircle(originPoint.transform.position, originRadius, whatIsEnemy);
        isPersecution = Physics2D.OverlapCircle(transform.position, radiusPersecution, whatIsPlayer);
        isAttackRange = Physics2D.OverlapCircle(transform.position, radiusAttack, whatIsPlayer);

        isCollisionRight = Physics2D.OverlapCircle(new Vector2(transform.position.x + 1, transform.position.y), radiusDefend, whatIsPlayerAttack);
        isCollisionLeft = Physics2D.OverlapCircle(new Vector2(transform.position.x - 1, transform.position.y), radiusDefend, whatIsPlayerAttack);

        if (isInRange)
        {
            if (isPersecution && !isAttackRange)
            {
              
                    Persecution();
            }
            if(isPersecution && isAttackRange)
            {
                timerAttack -= Time.deltaTime;
                if (timerAttack <= 0)
                {
                    Attack();
                    timerAttack = Random.Range(timeToAttackMin, timeToAttackMax);
                }
            }
        }
        else
        {
            BackStart();
        }
        
       
        if (isCollisionRight && facingRight)
        {
            Debug.Log("Se defiende por la derecha");
            animEnemy2.SetTrigger("Defend");
            animEnemy2.SetBool("Walk", false);

        }
        if (isCollisionLeft && !facingRight)
        {
            Debug.Log("Se defiende por la izquierda");
            animEnemy2.SetTrigger("Defend");
            animEnemy2.SetBool("Walk", false);
        }
        //DefendAttack();
        
    }

    public void Persecution()
    {
        Debug.Log("Persecution");
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
        animEnemy2.SetBool("Walk", true);
    }
    public void BackStart()
    {
        Debug.Log("BackStart");
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(originPoint.transform.position.x, transform.position.y), step);
        if (originPoint.transform.position.x > transform.position.x)
        {
            if (transform.localScale.x < 0)
            {
                Flip();
                facingRight = true;
            }
        }
        if (originPoint.transform.position.x < transform.position.x)
        {
            if (transform.localScale.x > 0)
            {
                Flip();
                facingRight = false;
            }
        }
        animEnemy2.SetBool("Walk", true);
    }
    public void Attack()
    {
        Debug.Log("Attack");
        animEnemy2.SetTrigger("Attack");
        animEnemy2.SetBool("Walk", false);
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
