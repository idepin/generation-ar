using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChooser : MonoBehaviour {

	public Toggle toggleShow;
	public Toggle toggleShow2;
	public GameObject ChooseLang;
	public GameObject ENflag;
	public GameObject IDflag;
	public Dropdown langDropdown;
	GameObject bth;
	// Use this for initialization
	void Start () {
		bth = GameObject.Find ("bth");
		if (PlayerPrefs.HasKey ("showatstartup")) {
			if (PlayerPrefs.GetInt ("showatstartup") == 1) {
				if (bth.GetComponent<BacktoHomeManager>().Backtohome == true) {
					ChooseLang.SetActive (false);
				} else {
					ChooseLang.SetActive (true);
				}

			} else {
				ChooseLang.SetActive (false);
			}
		}
	}
	public void ChooseLanguage(int language){
		switch (language) {
		case 1:
			PlayerPrefs.SetInt ("lang_ID", 0);
			PlayerPrefs.Save ();
			break;
		case 2:
			PlayerPrefs.SetInt ("lang_ID", 1);
			PlayerPrefs.Save ();
			break;
		}
	}
	public void CheckDropdownLanguage(){
		if (PlayerPrefs.HasKey ("lang_ID")) {
			if (PlayerPrefs.GetInt ("lang_ID") == 1) {
				langDropdown.value = 1;
			} else {
				langDropdown.value = 0;
			}
		}
	}
	public void CheckToggleStartup(){
		if (PlayerPrefs.HasKey ("showatstartup")) {
			if (PlayerPrefs.GetInt ("showatstartup") == 1) {
				toggleShow2.isOn = true;
			} else {
				toggleShow2.isOn = false;
			}
		}
	}
	public void ChooseLanguageDropdown(){
		if (langDropdown.value == 0) {
			ChooseLanguage (1);
			ENflag.SetActive (true);
			IDflag.SetActive (false);
		} else {
			ChooseLanguage (2);
			ENflag.SetActive (false);
			IDflag.SetActive (true);
		}
	}
	public void ShowatStartup(){
		if (toggleShow.isOn == true) {
			PlayerPrefs.SetInt ("showatstartup", 1);
			PlayerPrefs.Save ();
		} else {
			PlayerPrefs.SetInt ("showatstartup", 0);
			PlayerPrefs.Save ();
		}
	}
	public void ShowatStartup2(){
		if (toggleShow2.isOn == true) {
			PlayerPrefs.SetInt ("showatstartup", 1);
			PlayerPrefs.Save ();
		} else {
			PlayerPrefs.SetInt ("showatstartup", 0);
			PlayerPrefs.Save ();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
