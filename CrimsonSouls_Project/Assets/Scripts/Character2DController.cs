using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public static Character2DController instance;
    public BoxCollider2D animCollider;
    public BoxCollider2D realCollider2D;
    public Rigidbody2D rb2D;
    public Animator anim;
    public Transform groundCheck;
    public Transform posProyectile;
    public GameObject proyectile;
    public PhysicsMaterial2D physic2D;

    public LayerMask whatIsGround;
    public LayerMask whatIsClimbWall;

    public float forceImpact1 = -25;
    public float movementSpeed;
    public float jumpForce;
    public float dashSpeed;
    public float timeBetweenShoot;
    public float timeToDash;
    public float timeToCombo = 2.5f;
    public float startDashTime;
    public float gravity = -10;
    public float checkRadius;
    public float checkClimb;
    public float timeBetweenAttack;
    public float timeHurt;
    float timerBettweenShoot;
    float timerBetweenAttack;
    float dashTime;
    float timerJumping = 0.2f;
    float timerToDash;
    float timerToCombo;
    float timerHurt;

    public int climbJumpsLimit = 7;
    public int jumpsLimit;

    int jumps;
    int attacks;

    public bool isGrounded;
    public bool isSecondJump;

    bool isHurt;
    bool isCombo;
    bool canShoot;
    public bool facingRight = true;
    public bool isDashing;
    bool isClimbing;
    bool isJumping;
    bool isCrouch;
    bool canAttack;
    bool hasBaston;
    bool canMove=true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        canAttack = true;
        timerBetweenAttack = timeBetweenAttack;
       
    }
    void Start()
    {
        
        jumps = jumpsLimit;
        dashTime = startDashTime;
        timerToDash = timeToDash;
        timerToCombo = timeToCombo;
        timerBettweenShoot = timeBetweenShoot;
        timerHurt = timeHurt;
        canShoot = true;
        hasBaston = GameManager.instance.GetHasBaston();
    }


    void Update()
    {

        timerToDash -= Time.deltaTime;
        if (timerToDash <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isDashing = true;
                anim.SetTrigger("Dash");
            }
        }
        if (isJumping)
        {
            timerJumping -= Time.deltaTime;
            if (timerJumping < 0)
            {
                isJumping = false;
                timerJumping = 0.2f;
            }
        }
        if (isCombo)
        {
            timerToCombo -= Time.deltaTime;
            if (timerToCombo < 0)
            {
                attacks = 0;
                isCombo = false;
                timerToCombo = timeToCombo;
            }
        }
        if (isDashing)
        {
            Dash();
        }

        if (isClimbing)
        {
            jumps = climbJumpsLimit;
        }

        if (isGrounded)
        {
            jumps = jumpsLimit;
            Physics2D.gravity = new Vector2(0, gravity);
        }
        if (!canShoot)
        {
            timerBettweenShoot -= Time.deltaTime;
            if (timerBettweenShoot <= 0)
            {
                canShoot = true;
                timerBettweenShoot = timeBetweenShoot;
            }
        }

        if (isHurt)
        {
            canMove = false;
            timerHurt -= Time.deltaTime;
            if (timerHurt <= 0)
            {
                canMove = true;
                isHurt = false;
                timerHurt = timeHurt;
            }
        }

        if (canMove)
        {
            if (hasBaston)
            {
                #region Salto
                if (Input.GetButtonDown("Jump") && jumps > 0)
                {
                    isGrounded = false;
                    isJumping = true;
                    Jump();

                }
                jumpsLimit = 2;
                #endregion
                #region Ataque cercano y CoolDown
                if (Input.GetButtonDown("Fire1") && canAttack)
                {
                    if (jumps == 0)//DOBLE SALTO
                    {
                        FlyAttack();
                    }
                    else
                    {
                        if (isGrounded)
                        {
                            attacks++;
                            if (attacks == 1)
                            {
                                isCombo = true;
                                canAttack = false;
                                anim.SetTrigger("Attack_01");
                                Debug.Log("Ataque1");
                            }
                            else if (attacks == 2)
                            {
                                canAttack = false;
                                anim.SetTrigger("Attack_02");
                                Debug.Log("Ataque2");
                            }
                            else if (attacks > 2)
                            {
                                canAttack = false;
                                anim.SetTrigger("Attack_03");
                                Debug.Log("Ataque3");
                                attacks = 0;
                                isCombo = false;
                                timerToCombo = timeToCombo;
                            }
                        }

                    }
                }
                if (!canAttack)
                {
                    timerBetweenAttack -= Time.deltaTime;
                    if (timerBetweenAttack <= 0)
                    {
                        canAttack = true;
                        timerBetweenAttack = timeBetweenAttack;
                    }
                }
                #endregion
                #region Ataque Lejano
                if (Input.GetButtonDown("Fire2") && canShoot)
                {
                    AttackAway();
                }
                #endregion
                #region Agachar
                //if (Input.GetKeyDown(KeyCode.LeftControl))
                //{
                //    if (isCrouch)
                //    {
                //        anim.SetBool("Crouch", false);
                //        isCrouch = false;
                //    }
                //    else
                //    {
                //        anim.SetBool("Crouch", true);
                //        isCrouch = true;
                //    }

                //}
                //if (isCrouch)
                //{
                //    realCollider2D = animCollider;
                //}
                #endregion

            }
            else
            {
                jumpsLimit = 1;
                #region Salto
                if (Input.GetButtonDown("Jump") && jumps > 0)
                {
                    isGrounded = false;
                    isJumping = true;
                    Jump();

                }
                #endregion
            }
            //Llamar a la animación de final de salto en caso de que esté saltando.
            if (isGrounded)
            {
                anim.SetBool("isGrounded", true);
            }
            else { anim.SetBool("isGrounded", false); }
        }
        if (GameManager.instance.GetHealth() <= 0)
        {
            canMove = false;
            rb2D.simulated = false;
            SpriteRenderer spritePlayer = GetComponentInChildren<SpriteRenderer>();
            spritePlayer.color = new Color(1, 1, 1, 0);
        }
    }



    private void FixedUpdate()
    {
        if (!isJumping)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            isClimbing = Physics2D.OverlapCircle(groundCheck.position, checkClimb, whatIsClimbWall);
        }
        if (canMove)
        {
            float moveInput = Input.GetAxis("Horizontal");
            anim.SetFloat("Speed", moveInput);
            if (!isDashing)
            {
                rb2D.velocity = new Vector2(moveInput * movementSpeed, rb2D.velocity.y);
            }

            if (!facingRight && moveInput > 0)
            {
                Flip();
            }
            else if (facingRight && moveInput < 0)
            {
                Flip();
            }
        }
       
    }
    void Jump()
    {
        anim.SetTrigger("Jump");
        rb2D.velocity = Vector2.up * jumpForce;
        jumps--;

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    void FlyAttack()
    {
        Physics2D.gravity = new Vector2(0, forceImpact1);
        Debug.Log("Ataque aereo");
    }
    void Dash()
    {
        dashTime -= Time.deltaTime;
        if (facingRight)
        {
            rb2D.velocity = Vector2.right * dashSpeed;
            //anim.SetTrigger("Dash");
        }
        else
        {
            rb2D.velocity = Vector2.left * dashSpeed;
            //anim.SetTrigger("Dash");
        }

        if (dashTime <= 0)
        {
            isDashing = false;
            dashTime = startDashTime;
            timerToDash = timeToDash;
        }
    }
    void AttackAway()
    {
        Debug.Log("DisparoLejano");
        anim.SetTrigger("AttackAway");
        canShoot = false;
    }
    public void ProyectileAttack()
    {
        Instantiate(proyectile, posProyectile.transform.position, Quaternion.identity);
    }
    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
        if (canMove)
        {
            physic2D.friction = 1;
        }
        else
        {
            physic2D.friction = 0;
        }
    }
    public void Hurt(int damage)
    {
        if (!isDashing)
        {
            GameManager.instance.LoseHealth(1);
            anim.SetTrigger("Hurt");
            Debug.Log("Recibe daño");
            isHurt = true;
            
        }
        else
        {
            Debug.Log("No recibe daño");
        }
    }
    public void SetHasBaston(bool hasBaston)
    {
        this.hasBaston = hasBaston;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pinchos"))
        {
            CollisionManager.instance.DamageToPlayer(GameManager.instance.GetHealth());
        }
    }
}
