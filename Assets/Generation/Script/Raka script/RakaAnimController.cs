using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RakaAnimController : MonoBehaviour {

	public Animator RakaAnimator;
	// Use this for initialization
	void Start () {
		RakaAnimator.SetBool ("mulai", true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
