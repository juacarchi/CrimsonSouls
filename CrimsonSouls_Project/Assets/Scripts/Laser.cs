using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 2.8f;
    public float aumentoScale = 2;
    float scaleX;
    float scaleY;
    bool contact;
    LineRenderer lineRenderer;
    Vector2 direction;
    public GameObject enemyGO;
    public Enemy1 enemy1;
    public bool isRight;
    private void Awake()
    {
        enemyGO = GameObject.FindGameObjectWithTag("Enemy1");
        enemy1 = enemyGO.GetComponent<Enemy1>();
    }
    private void Start()
    {
        Destroy(this.gameObject, 2f);
        lineRenderer = GetComponent<LineRenderer>();
        scaleY = lineRenderer.startWidth;
        Vector2 posPlayer = Character2DController.instance.transform.position;
        if (isRight)
        {
            direction = Vector2.right;
        }
        else
        {
            direction = Vector2.left;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            Debug.Log("Ha contactado con el láser");
            CollisionManager.instance.DamageToPlayer(3);
            if (!Character2DController.instance.isDashing)
            {
                contact = true;
                
            }

        }

    }
    private void Update()
    {
        if (!contact)
        {
            transform.Translate(direction * speed * Time.deltaTime);
            scaleX += aumentoScale * Time.deltaTime;
            transform.localScale = new Vector2(scaleX, transform.localScale.y);
        }
        else
        {

            transform.Translate(direction * speed * Time.deltaTime);
            scaleY -= aumentoScale * Time.deltaTime;
            transform.localScale = new Vector2(transform.localScale.x, scaleY);
            Debug.Log("Empequeñece escala");
            lineRenderer.startWidth = scaleY;
            lineRenderer.endWidth = scaleY;

            if (scaleY <= 0)
            {
                Destroy(this.gameObject);

            }



        }



    }
}
