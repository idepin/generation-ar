using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktoHomeManager : MonoBehaviour {

	public bool Backtohome = false;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
