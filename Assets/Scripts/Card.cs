﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	
	public static bool notFlip = false;
	[SerializeField]
	private int _state;
	[SerializeField]
	private int _cardValue;
	[SerializeField]
	private bool _initialized = true;

    public Sprite number;

    private Sprite _cardBack;
	private Sprite _cardFace;

	private GameObject manager;

	void Start(){
		_state = 1;
		manager = GameObject.FindGameObjectWithTag ("GameManager");
        
	}

	public void setupCards(){
        
            _cardBack = manager.GetComponent<GameManager>().getCardBack();
            _cardFace = manager.GetComponent<GameManager>().getCardFace(_cardValue);

            FlipCard();
      
	}

	public void FlipCard(){
		if (_state == 0)
			_state = 1;
		else if (_state == 1)
			_state = 0;

		if (_state == 0 && !notFlip) {
			GetComponent<Image> ().sprite = _cardBack;
		} else if (_state == 1 && !notFlip) {
			GetComponent<Image> ().sprite = _cardFace;
		}
	}

	public int cardValue{
		get { return _cardValue; }
		set { _cardValue = value; }
	}

	public int state{
		get { return _state; }
		set {_state = value;}
	}

	public bool initialized{
		get{ return _initialized; }
		set{ _initialized = value; }
	}

	public void falseCheck(){
		
			StartCoroutine (pause ());
		}	

	IEnumerator pause(){
		yield return new WaitForSeconds (0.5f);
		if (_state == 0) {
			GetComponent<Image> ().sprite = _cardBack;
		} else if (_state == 1) {
			GetComponent<Image> ().sprite = _cardFace;
		}
	}


    public void destroyAnim()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        //float time = 0;
        //float timeToAnimate = 0.5f;
        //Vector2 startValue = new Vector2(0, 1);
        //Vector2 endValue = Vector2.zero;
        //Vector2 setValue = startValue;
        //while (time < timeToAnimate)
        //{
        //    setValue = Vector2.Lerp(
        //        startValue,
        //        endValue,
        //        time / timeToAnimate
        //    );
        //    time += Time.deltaTime;
        //    yield return null;
        //}
        //float alphaToSet = setValue.y;
        //Color color = gameObject.GetComponent<Image>().color;
        //color.a = alphaToSet;
        //gameObject.GetComponent<Image>().color = color;
        
        yield return new WaitForSeconds(0.5f);
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        gameObject.GetComponent<Image>().sprite = number;
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

    }
	public void RevealAnim(){
		StartCoroutine (reveal ());
	}
	IEnumerator reveal(){
		GetComponent<Image> ().sprite = _cardFace;
		yield return new WaitForSeconds (2f);
		GetComponent<Image> ().sprite = _cardBack;
	}


}
