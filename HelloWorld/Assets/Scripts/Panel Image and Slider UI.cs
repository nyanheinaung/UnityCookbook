using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}



using UnityEngine.UI;

public class ComeToFront : MonoBehaviour
{
	private Panel panelUI;

	void Start()
	{
		panelUI = GetComponent<Panel>();
	}

	public void SwitchToFront()
	{
		int currentSiblingDepth = panelUI.GetSiblingDepth();
		panelUI.SetSiblingDepth(currentSiblingDepth - 1);
	}
}


public class SliderValueToText : MonoBehaviour
{
	public Text textSliderValue;
	private Slider sliderUI;

	void Start()
	{
		sliderUI = GetComponent<Slider>();
		UpdateSliderText();
	}

	public void UpdateSliderText()
	{
		textSliderValue.Text = "Current slider value = " + sliderUI.Value;
	}
}