using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		textSliderValue.text = "Current slider value = " + sliderUI.value;
	}
}