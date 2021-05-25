using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject canvasName;
  public void PlayGame()
    {
        canvasName.SetActive(true);
    }
}
