using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoadNextLevel : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start() { 
		Invoke("LoadNextLevel", autoLoadNextLevelAfter);
	}

	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
