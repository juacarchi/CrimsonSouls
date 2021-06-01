using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostMausoleo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.audioPostMausoleo);
    }
}
