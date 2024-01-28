using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SFXController : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> AudioClipsList;
    [SerializeField]
    private List<AudioClip> VoicesList;

    public static SFXController specialEffects { get; private set; }

    private void Awake()
    {
        SetupSFXController();
    }

    public void CreateSFX(string _sfxName, Transform _transform, bool isLoop)
    {
        AudioClip audioClip = AudioClipsList.Single(go => go.name == _sfxName);
        GameObject speaker = new GameObject();
        speaker.transform.position=_transform.position;
        speaker.gameObject.AddComponent<AudioSource>();
        speaker.gameObject.GetComponent<AudioSource>().clip = audioClip;
        speaker.gameObject.GetComponent<AudioSource>().loop=isLoop;
        //speaker.gameObject.GetComponent<AudioSource>().pitch= Random.Range(0.85f,0.95f);
        speaker.gameObject.GetComponent<AudioSource>().Play();
        if(!isLoop)
            Destroy(speaker.gameObject, audioClip.length);    
    }

    
    public void PlayRandomVoiceSFX(Transform _transform)
    {
        System.Random random = new  System.Random();
        int index = random.Next(VoicesList.Count);
        
        AudioClip audioClip = VoicesList[index];
        GameObject speaker = new GameObject();
        speaker.transform.position=_transform.position;
        speaker.gameObject.AddComponent<AudioSource>();
        speaker.gameObject.GetComponent<AudioSource>().clip = audioClip;
        speaker.gameObject.GetComponent<AudioSource>().pitch= Random.Range(0.85f,0.95f);
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
