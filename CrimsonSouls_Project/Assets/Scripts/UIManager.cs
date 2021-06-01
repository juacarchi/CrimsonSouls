using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public GameObject canvasPause;
    public GameObject panelMuerte;
    public GameObject panelBaston;
    public Image imageRun;
    public GameObject imageFadeGO;
    public Image imageFade;
    public static UIManager instance;
    bool isFinish;
    bool checkEnter;
    bool isPause;
    float speedFade = 0.5f;
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
        imageRun.enabled = false;
        panelBaston.SetActive(false);
        panelMuerte.SetActive(false);
        canvasPause.SetActive(false);
        isPause = false;
    }

    public IEnumerator FadeImageToBlack(int sceneToLoad)
    {

        imageFade.enabled = true;

        for (float i = 0; i < 1; i += Time.deltaTime * 0.5f)
        {
            SoundManager.instance.audioSource.volume = 1- i;
            imageFade.color = new Color(0, 0, 0, i);
            if (i > 0.5f)
            {
                imageRun.enabled = true;
                imageRun.color = new Color(1, 1, 1, i);
            }
            yield return null;
        }
        if (GameManager.instance.GetHealth() <= 0)
        {
            SetCanvasMuerte(true);
            checkEnter = true;
            Debug.Log("CanvasMuerte activado");
            

        }
        imageFade.color = new Color(0, 0, 0, 1);
        imageRun.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(1.5f);
        if (GameManager.instance.GetHealth() > 0)
        {
            StartCoroutine("FadeImageToTransparent");
            SceneManager.LoadScene(sceneToLoad);
        }
        speedFade = 0.5f;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K) && checkEnter)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.instance.SetHealth(3);
            speedFade = 0.5f;
            checkEnter = false;
            StartCoroutine("FadeImageToTransparent");
            
        }
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPause)
                {
                    isPause = true;
                    SetCanvasPause(isPause);
                    Character2DController.instance.SetCanMove(false);
                    Character2DController.instance.anim.SetFloat("Speed", 0);
                    Time.timeScale=0;
                }
                else
                {
                    isPause = false;
                    SetCanvasPause(isPause);
                    Character2DController.instance.SetCanMove(true);
                }
            }
        }
    }

    public IEnumerator FadeImageToTransparent()
    {
        UIManager.instance.SetCanvasMuerte(false);
        for (float i = 1; i > 0; i -= Time.deltaTime * speedFade)
        {
            SoundManager.instance.audioSource.volume = 1 - i;
            imageFade.color = new Color(0, 0, 0, i);
            if (i < 0.5f)
            {
                imageRun.color = new Color(1, 1, 1, i);
            }
            yield return null;
        }
        imageFade.color = new Color(0, 0, 0, 0);
        imageRun.color = new Color(1, 1, 1, 0);
        HUDManager.instance.ChangeLifeUI();
        yield return new WaitForSeconds(2);
        Debug.Log("SegundaCorroutine");
        speedFade = 0.5f;
        
    }
    public void ShowBaston(bool showBaston)
    {
        panelBaston.SetActive(showBaston);
    }
    public void SetCanvasMuerte(bool isActive)
    {
        panelMuerte.SetActive(isActive);
    }
    public void SetCanvasPause(bool isPause)
    {
        canvasPause.SetActive(isPause);
    }

}
