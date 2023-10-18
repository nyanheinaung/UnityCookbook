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

	public void MoveOneUp()
	{
		 
		int currentSiblingDepth = panelUI.GetSiblingIndex();
		panelUI.SetSiblingIndex(currentSiblingDepth + 1);
		print(currentSiblingDepth);
	}

	public void MoveOneDown()
	{
		int currentSiblingDepth = panelUI.GetSiblingIndex();
		panelUI.SetSiblingIndex(Mathf.Max(0, currentSiblingDepth - 1));
		print(currentSiblingDepth);
	}
}


