using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelButton : Button {
	
	public Text levelText;
	public int unlocked;
	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

    private AudioClip clickSound;
    private string _thisLevel;

    public override void OnPointerClick(PointerEventData eventData)
    {
        PlayClickSound();
        base.OnPointerClick(eventData);
        TKSceneManager.ChangeScene(thisLevel);
    }
    public void PlayClickSound()
    {
        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero, PlayerPrefs.GetFloat("soundEffectVolume"));
    }

    public AudioClip ClickSound
    {
        get { return clickSound; }
        set { clickSound = value; }
    }

    public string thisLevel{
		get {return _thisLevel;}
		set { _thisLevel = value; }
	}
}
