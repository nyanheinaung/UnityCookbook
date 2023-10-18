using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrangeActions : MonoBehaviour
{
	private RectTransform panelUI;

	void Start()
	{
		panelUI = GetComponent<RectTransform>();
	}

	public void SwitchToFront()
	{
		int currentSiblingDepth = panelUI.GetSiblingIndex();
		panelUI.SetSiblingIndex(currentSiblingDepth - 1);
	}
}


