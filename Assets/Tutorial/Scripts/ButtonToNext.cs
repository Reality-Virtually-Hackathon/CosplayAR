using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ButtonToNext : MonoBehaviour {
	Texture2D[] pages;
	int place;

	//Rect size= new Rect(0,0,Screen.width,Screen.height);
	Rect size= new Rect(0,0,1024,2048);
	Vector2 tilt = new Vector2 (0f, 0f);

	public Image curPage;
	// Use this for initialization
	void Start(){
		
		place = 0;
		object[] pageHolder = (Resources.LoadAll ("SelectionPages"));
		pages = new Texture2D[pageHolder.Length];
		for(int i = 0; i<pageHolder.Length; i++) {
			pages[i] = (Texture2D)(pageHolder[i]);
			//Debug.Log ("Page " + i + " copied");
			//Debug.Log ("page pixel height " + pages [i].height);
		}
		curPage.sprite = Sprite.Create(pages [place], size, tilt);
	}

	void FixedUpdate () {
		if (Input.GetMouseButtonDown (0)) 
			NextPage ();
		XRSettings.enabled = false;
		Screen.orientation = ScreenOrientation.Portrait;
	}

	public void NextPage(){
		//Debug.Log ("next page happening");
		//Vector2 point = Input.GetTouch(0).position;
		//Touch t1 = Input.GetTouch (0);
		Vector3 point = Input.mousePosition;
		Debug.Log (point);
		if (point.y < 80)
			SceneManager.LoadScene ("Sizing - Copy");
		else if (point.x > 114) {
			place++;
			if (place == pages.Length)
				place = 0;
		} else {
			place--;
			if (place == -1)
				place = pages.Length - 1;
		}
			
		curPage.sprite = Sprite.Create (pages [place], size, tilt);


	}
		}
