using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMenuAnimatorController : MonoBehaviour {

	public Animator LeftMenuAnim;
	public GameObject LeftMenu_object;
	// Use this for initialization
	void Start () {
		
	}
	public void OpenLeftMenu(){
		LeftMenuAnim.SetBool ("buka", true);
	}
	public void CloseLeftMenu(){
		LeftMenuAnim.SetBool ("buka", false);
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.V)) {
			OpenLeftMenu ();
		} else if (Input.GetKey (KeyCode.B)) {
			CloseLeftMenu ();
		}
	}
	public void DisableLeftMenu(){
		LeftMenu_object.gameObject.SetActive (false);
	}
}
