using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBehaviourScript : MonoBehaviour {
    public AudioClip clickSound;

    private float scaleResize = .2f;
    private Vector3 scaleResizer;
    private void Start()
    {
        scaleResizer = new Vector3(scaleResize, scaleResize, 0f);
    }

    public void PlayClickSound()
    {
        AudioSource.PlayClipAtPoint(clickSound, Vector3.zero, PlayerPrefs.GetFloat("soundEffectVolume"));
    }

    public void ZoomInButton()
    {
        if (transform.localScale.Equals(Vector3.one))
            transform.localScale += (scaleResizer);

    }
    public void ZoomOutButton()
    {
        Vector3 scaleResized = Vector3.one + scaleResizer;
        if (transform.localScale.Equals(scaleResized))
            transform.localScale -= (scaleResizer);

    }
    
}
