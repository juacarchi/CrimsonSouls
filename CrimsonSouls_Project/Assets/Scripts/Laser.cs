using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 2.8f;
    public float aumentoScale = 2;
    float scaleX;
    bool contact;
    private void Start()
    {
        Destroy(this.gameObject, 2f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ha contactado con el láser");
            CollisionManager.instance.DamageToPlayer(3);
            contact = true;
        }

    }
    private void Update()
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        scaleX += aumentoScale * Time.deltaTime;
        transform.localScale = new Vector2(scaleX, transform.localScale.y);

    }
}
