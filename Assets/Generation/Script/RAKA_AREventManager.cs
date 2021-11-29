using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Playables;

public class RAKA_AREventManager : MonoBehaviour, ITrackableEventHandler {

	#region PRIVATE_MEMBER_VARIABLES

	public int Language;
	public GameObject objTerrain;
	//ENG
	public GameObject btnSkipIntro;
	public GameObject btnAgain;

	//IND
	public GameObject btnSkipIntro_indo;
	public GameObject btnAgain_indo;

	public int SelectedTimeline;
	public GameObject timeline_ID;
	public GameObject timeline_EN;

	public PlayableDirector timeline_perkenalan;
	public PlayableDirector timeline_penjelasan;
	public PlayableDirector timeline_perkenalan_indo;
	public PlayableDirector timeline_penjelasan_indo;
	public bool skipped = false;
	protected TrackableBehaviour mTrackableBehaviour;
	public void setLanguage(int index){
		Language = index;
	}
	public void Skip(){
		skipped = true;
	}
	#endregion // PRIVATE_MEMBER_VARIABLES

	#region UNTIY_MONOBEHAVIOUR_METHODS

	protected virtual void Start()
	{
		
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
	}

	#endregion // UNTIY_MONOBEHAVIOUR_METHODS

	#region PUBLIC_METHODS

	/// <summary>
	///     Implementation of the ITrackableEventHandler function called when the
	///     tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
			OnTrackingFound();
		}
		else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
			newStatus == TrackableBehaviour.Status.NOT_FOUND)
		{
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
			OnTrackingLost();
		}
		else
		{
			// For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
			// Vuforia is starting, but tracking has not been lost or found yet
			// Call OnTrackingLost() to hide the augmentations
			OnTrackingLost();
		}
	}

	#endregion // PUBLIC_METHODS

	#region PRIVATE_METHODS

	protected virtual void OnTrackingFound()
	{
		var rendererComponents = GetComponentsInChildren<Renderer>(true);
		var colliderComponents = GetComponentsInChildren<Collider>(true);
		var canvasComponents = GetComponentsInChildren<Canvas>(true);

		if (SelectedTimeline == 1) {
			timeline_EN.SetActive (true);
		} else {
			timeline_ID.SetActive (true);
		}
		timeline_perkenalan.Resume ();
		timeline_penjelasan.Resume ();
		timeline_perkenalan_indo.Resume ();
		timeline_penjelasan_indo.Resume ();

		if (Language == 1) {
			if (skipped == false) {
				if (timeline_penjelasan.gameObject.activeInHierarchy) {
					btnSkipIntro.SetActive (false);
					objTerrain.SetActive (true);
					btnAgain.SetActive (true);
				} else {
					btnSkipIntro.SetActive (true);
				}
			} else {
				btnAgain.SetActive (true);
				objTerrain.SetActive (true);
				btnSkipIntro.SetActive (false);
			}
		} else {
			if (skipped == false) {
				if (timeline_penjelasan_indo.gameObject.activeInHierarchy) {
					btnSkipIntro_indo.SetActive (false);
					objTerrain.SetActive (true);
					btnAgain_indo.SetActive (true);
				} else {
					btnSkipIntro_indo.SetActive (true);
				}
			} else {
				btnAgain_indo.SetActive (true);
				objTerrain.SetActive (true);
				btnSkipIntro_indo.SetActive (false);
			}
		}

		// Enable rendering:
		foreach (var component in rendererComponents)
			component.enabled = true;

		// Enable colliders:
		foreach (var component in colliderComponents)
			component.enabled = true;

		// Enable canvas':
		foreach (var component in canvasComponents)
			component.enabled = true;
	}


	protected virtual void OnTrackingLost()
	{
		var rendererComponents = GetComponentsInChildren<Renderer>(true);
		var colliderComponents = GetComponentsInChildren<Collider>(true);
		var canvasComponents = GetComponentsInChildren<Canvas>(true);

		timeline_perkenalan.Pause ();
		timeline_penjelasan.Pause ();
		timeline_perkenalan_indo.Pause ();
		timeline_penjelasan_indo.Pause ();
		if (Language == 1) {
			btnSkipIntro.SetActive (false);
			btnAgain.SetActive (false);
			objTerrain.SetActive (false);
		} else {
			btnSkipIntro_indo.SetActive (false);
			btnAgain_indo.SetActive (false);
			objTerrain.SetActive (false);
		}

		// Disable rendering:
		foreach (var component in rendererComponents)
			component.enabled = false;

		// Disable colliders:
		foreach (var component in colliderComponents)
			component.enabled = false;

		// Disable canvas':
		foreach (var component in canvasComponents)
			component.enabled = false;
	}

	#endregion // PRIVATE_METHODS
}
