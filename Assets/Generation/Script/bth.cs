using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bth : MonoBehaviour {

	GameObject gbth;
	// Use this for initialization
	void Start () {
		gbth = GameObject.Find ("bth");
	}
	public void BackToHome(){
		gbth.GetComponent<BacktoHomeManager> ().Backtohome = true;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
