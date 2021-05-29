using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    public Image life1;
    public Image life2;
    public Image life3;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public void ChangeLifeUI()
    {
        if (GameManager.instance.GetHealth() == 3)
        {
            life1.enabled = true;
            life2.enabled = true;
            life3.enabled = true;
        }
        else if (GameManager.instance.GetHealth() == 2)
        {
            life1.enabled = true;
            life2.enabled = true;
            life3.enabled = false;
        }
        else if (GameManager.instance.GetHealth() == 1)
        {
            life1.enabled = true;
            life2.enabled = false;
            life3.enabled = false;
        }
        else if (GameManager.instance.GetHealth() == 0)
        {
            life1.enabled = false;
            life2.enabled = false;
            life3.enabled = false;
        }
    }
}
