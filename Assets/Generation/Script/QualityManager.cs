using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QualityManager : MonoBehaviour {

	public Toggle toggle;
	public Toggle toggle2;
	public AudioSource audiofx;
	public FlareLayer flare;
	public List<GameObject> VFXobject = new List<GameObject>();
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("VFX")) {
			if (PlayerPrefs.GetInt ("VFX") == 0) {
				toggle.isOn = false;
				DisableVFX ();
			} else {
				toggle.isOn = true;
				EnableVFX ();
			}
		}
		if (PlayerPrefs.HasKey ("SFX")) {
			if (PlayerPrefs.GetInt ("SFX") == 0) {
				toggle2.isOn = false;
				DisableSFX ();
			} else {
				toggle2.isOn = true;
				EnableSFX ();
			}
		}
	}
	public void DisableVFX(){
		if (toggle.isOn == false) {
			PlayerPrefs.SetInt ("VFX", 0);
			PlayerPrefs.Save ();
			flare.enabled = false;
			for( int i = 0; i < VFXobject.Count; i++)
			{
				VFXobject[i].SetActive(false);
			}
		}

	}
	public void EnableVFX(){
		if (toggle.isOn == true) {
			PlayerPrefs.SetInt ("VFX", 1);
			PlayerPrefs.Save ();
			flare.enabled = true;
			for( int i = 0; i < VFXobject.Count; i++)
			{
				VFXobject[i].SetActive(true);
			}
		}

	}
	public void EnableSFX(){
		if (toggle2.isOn == true) {
			PlayerPrefs.SetInt ("SFX", 1);
			PlayerPrefs.Save ();
			audiofx.mute = false;
		}
	}
	public void DisableSFX(){
		if (toggle2.isOn == false) {
			PlayerPrefs.SetInt ("SFX", 0);
			PlayerPrefs.Save ();
			audiofx.mute = true;
		}
	}

	void Update () {
		
	}
}
