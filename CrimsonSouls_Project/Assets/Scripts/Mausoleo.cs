using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mausoleo : MonoBehaviour
{
    public void Start()
    {
        SoundManager.instance.PlaySFX(SoundManager.instance.audioMausoleo);
    }
}
