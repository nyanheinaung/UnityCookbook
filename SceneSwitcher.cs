using System.Collections;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene(string sceneName)
	{
		//find and read difference between LoadLevel and LoadScene(might need SceneManager)
		Application.LoadLevel(sceneName);
	}
}
