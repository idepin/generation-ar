using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Perkenalan : MonoBehaviour {

	public PlayableDirector TimelinePerkenalan;
	public PlayableDirector TimelinePenjelasan;


	public PlayableDirector TimelinePerkenalan_indo;
	public PlayableDirector TimelinePenjelasan_indo;
	// Use this for initialization
	void Start () {
		
	}
	public void Skip(){
		TimelinePerkenalan.Stop ();
		TimelinePenjelasan.Play ();
	}

	public void Skip_indo(){
		TimelinePerkenalan_indo.Stop ();
		TimelinePenjelasan_indo.Play ();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
