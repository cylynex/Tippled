using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoadNextLevel : MonoBehaviour
{

	public float autoLoadNextLevelAfter;

	// Use this for initialization
	void Start()
	{
		Invoke("LoadNextLevel", autoLoadNextLevelAfter);
	}

	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
