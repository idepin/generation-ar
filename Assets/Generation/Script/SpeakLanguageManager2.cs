using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpeakLanguageManager2 : MonoBehaviour {

	public PlayableDirector indoPerjelasanTimeline;
	public PlayableDirector engPenjelasanTimeline;
	public RAKA_EventManager2 eventman;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("lang_ID")) {
			if (PlayerPrefs.GetInt ("lang_ID") == 1) {
				eventman.SelectedTimeline = 2;
			} else {
				eventman.SelectedTimeline = 1;
			}
		} else {
			eventman.SelectedTimeline = 1;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
