using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
	public void LoadMainScene()
	{
		SceneManager.LoadScene(1);
	}
}
