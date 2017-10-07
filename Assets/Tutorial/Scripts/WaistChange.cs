using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaistChange : MonoBehaviour {

	public Text material;
	public Text drawsting;

	public int mod = 1;

	// Use this for initialization
	void Start(){
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void materialUp(){
		int x = int.Parse(material.text);
		x += mod;
		material.text = x.ToString();
	}

	public void materialDown(){
		int x = int.Parse(material.text);
		x -= mod;
		material.text = x.ToString();
	}

	public void drawstringUp(){
		int x = int.Parse(drawsting.text);
		x += mod;
		drawsting.text = x.ToString();
	}

	public void drawstringDown(){
		int x = int.Parse(drawsting.text);
		x -= mod;
		drawsting.text = x.ToString();
	}
}
