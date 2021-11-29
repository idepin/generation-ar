using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ZamanNext : MonoBehaviour {

	public PlayableDirector TimelineNext;
	public GameObject diri;
	public GameObject rakaevent;

	bool udah = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (diri.activeInHierarchy) {
			if (udah == false) {
				TimelineNext.Play ();
				rakaevent.GetComponent<RAKA_AREventManager>().Skip ();
			}
		}
	}
}
