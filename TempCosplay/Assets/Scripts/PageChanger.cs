using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PageChanger : MonoBehaviour {
	Sprite[] pages;
	int place;

	public Image curPage;
	// Use this for initialization
	void Start(){
		place = 0;
		object[] pageHolder = (Resources.LoadAll ("SizingPages"));
		pages = new Sprite[pageHolder.Length];
		for(int i = 0; i<pageHolder.Length; i++) {
			pages[i] = (Sprite)(pageHolder[i]);
		}
	}

	void FixedUpdate () {
		if (Input.GetMouseButtonDown (0)) 
			NextPage ();
	}

	public void NextPage(){
		if (place == pages.Length - 1)
			place = 0;
		curPage.sprite = pages [place];

	}
}
