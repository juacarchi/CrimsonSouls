using UnityEngine;

public class PlayerAnimationsEvents : MonoBehaviour
{
    public void AttackAway()
    {
        Character2DController.instance.ProyectileAttack();
    }
}
