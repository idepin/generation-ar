using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

	public int changetoscene;
	public GameObject loadingscreen;
	public Slider slider;
	// Use this for initialization
	void Start () {
		
	}
	public void Changescenevalue(int value){
		changetoscene = value;
	}
	public void LoadLevel(){
		StartCoroutine (LoadAsynchrounously (changetoscene));
	}

	IEnumerator LoadAsynchrounously(int sceneIndex){
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		loadingscreen.SetActive (true);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			Debug.Log (progress);
			slider.value = progress;
			yield return null;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
