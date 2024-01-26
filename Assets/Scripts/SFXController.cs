using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SFXController : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> AudioClipsList;

    public static SFXController specialEffects { get; private set; }

    private void Awake()
    {
        SetupSFXController();
    }

    public void CreateSFX(string _sfxName, Transform _transform)
    {
        AudioClip audioClip = AudioClipsList.Single(go => go.name == _sfxName);
        GameObject speaker = new GameObject();
        speaker.gameObject.AddComponent<AudioSource>();
        speaker.gameObject.GetComponent<AudioSource>().clip = audioClip;
        speaker.gameObject.GetComponent<AudioSource>().Play();
        Destroy(speaker.gameObject, audioClip.length);
    }

    private void SetupSFXController()
    {
        if (specialEffects != null && specialEffects != this)
        {
            Destroy(this);
        }
        else
        {
            specialEffects = this;
        }
    }
}
