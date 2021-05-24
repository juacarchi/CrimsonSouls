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

    public int health = 560;
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
        isCollisionRight = Physics2D.OverlapCircle(new Vector2(transform.position.x + 1.5f, transform.position.y), radiusDefend, whatIsPlayerAttack);
        isCollisionLeft = Physics2D.OverlapCircle(new Vector2(transform.position.x - 1.5f, transform.position.y), radiusDefend, whatIsPlayerAttack);

        if (isCollisionRight && facingRight)
        {
            cc2D.enabled = false;
            animEnemy2.SetTrigger("Defend");
            animEnemy2.SetBool("Walk", false);
        }
        if (isCollisionLeft && !facingRight)
        {
            cc2D.enabled = false;
            animEnemy2.SetTrigger("Defend");
            animEnemy2.SetBool("Walk", false);
        }
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
            Debug.Log("Quita vida");
            animEnemy2.SetTrigger("Hit");
            timerAttack = Random.Range(timeToAttackMin, timeToAttackMax);
            health -= GameManager.instance.GetDamageMeleeAttack();
        }
    }
}
