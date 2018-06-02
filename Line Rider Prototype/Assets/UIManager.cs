using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


	public GameObject ui;
	public GameObject openUIText;
	public GameObject spaceToPlay;

	void Start () 
	{
		ui.SetActive(false);
	}
	

	void Update () 
	{
		UIUpdate();
	}

	void UIUpdate()
	{
		if(Input.GetButtonDown("Esc"))
		{
			if(ui.activeInHierarchy == false)
			{
				ui.SetActive(true);
				openUIText.SetActive(false);
			}
			else
			{
				ui.SetActive(false);
				openUIText.SetActive(true);
			}
		}
	}
	public void SpaceToPlay()
	{
		spaceToPlay.SetActive(false);

	}
}
