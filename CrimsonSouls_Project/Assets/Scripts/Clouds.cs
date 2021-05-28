using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float speed = 0.1f;
    public SpriteRenderer spriteInfo;
    public float changePosition = -30;
    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= changePosition)
        {
            transform.position = new Vector2(70, 0);
        }
    }
}
