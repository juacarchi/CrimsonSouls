using UnityEngine;

public class TakeBaston : MonoBehaviour
{
    public GameObject baston;
    bool canTake;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.ShowBaston(true);
            canTake = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.ShowBaston(false);
            canTake = false;
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Take") && canTake)
        {
            GameManager.instance.SetHasBaston(true);
            Character2DController.instance.SetHasBaston(true);
            Destroy(baston);
            BoxCollider2D bxCetro = GetComponent<BoxCollider2D>();
            Destroy(bxCetro);
            Dialogue1.instance.StartDialogue(Dialogue1.instance.dialogue4);
        }
    }
}
