using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Image imageRun;
    public GameObject imageFadeGO;
    public Image imageFade;
    public static UIManager instance;
    bool isFinish;
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
    }

    public IEnumerator FadeImageToBlack(int sceneToLoad)
    {

        imageFade.enabled = true;
        
        for (float i = 0; i < 1; i += Time.deltaTime * 0.5f)
        {
            imageFade.color = new Color(0, 0, 0, i);
            if (i > 0.5f)
            {
                imageRun.enabled = true;
                imageRun.color = new Color(1, 1, 1, i);
            }
            yield return null;
        }
        imageFade.color = new Color(0, 0, 0, 1);
        imageRun.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(3);
        StartCoroutine("FadeImageToTransparent");
        SceneManager.LoadScene(sceneToLoad);

    }
    public IEnumerator FadeImageToTransparent()
    {

        for (float i = 1; i > 0; i -= Time.deltaTime * 0.5f)
        {
            imageFade.color = new Color(0, 0, 0, i);
            if (i < 0.5f)
            {
                imageRun.color = new Color(1, 1, 1, i);
            }
            yield return null;
        }
        imageFade.color = new Color(0, 0, 0, 0);
        imageRun.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(2);
        Debug.Log("SegundaCorroutine");
    }

}
