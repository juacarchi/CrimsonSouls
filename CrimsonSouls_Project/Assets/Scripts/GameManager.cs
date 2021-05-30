using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public string namePlayer;
    public static GameManager instance;
    bool hasBaston;
    int damageMeleeAttack=25;
    int damageFarAttack;
    public float healthMax;
    [HideInInspector]
    int health;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        health = 3;

    }
    private void Update()
    {
        if (health == 0)
        {
            Character2DController.instance.rb2D.simulated = false;
        }
       
    }
    public void SetDamageMeleeAttack(int damageMeleeAttack)
    {
        this.damageMeleeAttack = damageMeleeAttack;
    }
    public int GetDamageMeleeAttack()
    {
        return this.damageMeleeAttack;
    }
    public void SetDamageFarAttack(int damageFarAttack)
    {
        this.damageFarAttack = damageFarAttack;
    }
    public int GetDamageFarAttack()
    {
        return this.damageFarAttack;
    }
    public void SetNamePlayer(string namePlayer)
    {
        this.namePlayer = namePlayer;
        Debug.Log(namePlayer);
    }
    public int GetHealth()
    {
        return this.health;
    }
    public void SetHealth(int health)
    {
        this.health = health;
    }
    public void LoseHealth(int health)
    {
        this.health -= health;
        HUDManager.instance.ChangeLifeUI();
        if (this.health <= 0)
        {
            StartCoroutine(UIManager.instance.FadeImageToBlack(SceneManager.GetActiveScene().buildIndex));

        }
    }
    public void SetHasBaston(bool hasBaston)
    {
        this.hasBaston = hasBaston;
    }
    public bool GetHasBaston()
    {
        return hasBaston;
    }
}
