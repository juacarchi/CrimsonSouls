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
    public int damage;
    float timeToAttack;
    float timerAttack;
    public float timeToAttackMin, timeToAttackMax;

    public int health = 25;
    bool checkPosition;
    bool isPersecution;
    bool isPlayerOnRight;
    bool isPlayerOnLeft;
    bool isCollision;
    bool isAttackRange;
    public bool facingRight;
    bool isInRange;
    bool isEnemyInFront;
    private void Start()
    {
        timeToAttack = Random.Range(timeToAttackMin, timeToAttackMax);
        timerAttack = timeToAttack;
        cc2D = GetComponent<CapsuleCollider2D>();
        facingRight = true;
        health = 125;
    }
    private void Update()
    {
        isInRange = Physics2D.OverlapCircle(originPoint.transform.position, originRadius, whatIsPlayer);
        isPersecution = Physics2D.OverlapCircle(transform.position, radiusPersecution, whatIsPlayer);
        isAttackRange = Physics2D.OverlapCircle(transform.position, radiusAttack, whatIsPlayer);



        if (isInRange)
        {
            if (isPersecution && !isAttackRange)
            {

                Persecution();
            }
            if (isPersecution && isAttackRange)
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

        if (health <= 0)
        {
            Debug.Log("Muerto");
            Destroy(this.gameObject, 1f);
        }
    }
    private void FixedUpdate()
    {
        isCollision = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), radiusDefend, whatIsPlayerAttack);
        isPlayerOnRight = Physics2D.Raycast(new Vector2(this.transform.position.x + 1f, transform.position.y), transform.TransformDirection(Vector2.right), 10f, whatIsPlayer);
        isPlayerOnLeft = Physics2D.Raycast(new Vector2(this.transform.position.x + -1f, transform.position.y), transform.TransformDirection(Vector2.left), 10f, whatIsPlayer);

        


    }
    public void Persecution()
    {
        Debug.Log("Persecution");
        Vector2 posPlayer = Character2DController.instance.transform.position;
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(posPlayer.x, transform.position.y), step);
        CheckFlip();
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            if (facingRight && isPlayerOnRight)
            {
                animEnemy2.SetTrigger("Defend");
                animEnemy2.SetBool("Walk", false);
                Debug.Log("Defend");
            }
            else if (!facingRight && isPlayerOnLeft)
            {
                cc2D.enabled = false;
                animEnemy2.SetTrigger("Defend");
                animEnemy2.SetBool("Walk", false);
                Debug.Log("Defend");
            }
            else
            {
                Debug.Log("Quita vida");
                animEnemy2.SetTrigger("Hit");
                timerAttack = Random.Range(timeToAttackMin, timeToAttackMax);
                health -= GameManager.instance.GetDamageMeleeAttack();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("PlayerAttack"))
        {
            if (health <= 0)
            {
                Death();
            }
        }
    }
    public void Death()
    {
        //animEnemy2.SetTrigger("Death");
        //Destroy(this.gameObject, 2f);
        Destroy(this.gameObject);
    }
}
