using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudioScript : MonoBehaviour {

    public bool reset = false;
    public float backgroundAudioVolume = 1f;
    public float soundEffectVolume = 1f;

    private static BackGroundAudioScript _instance;

    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
        {
            if (reset) PlayerPrefs.DeleteAll();
            _instance = this;
            PlayerPrefs.SetFloat("backgroundAudioVolume", backgroundAudioVolume);
            PlayerPrefs.SetFloat("soundEffectVolume", soundEffectVolume);

        }
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);
        

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
    }
    private void Update()
    {
        this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("backgroundAudioVolume");
    }
}
