using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

	public GameObject linePrefab;

	public GameObject normLine;
	public GameObject boostLine;
	public GameObject bounceLine;

	public GameObject canvas;

	Line activeLine;


	public void Start()
	{
		linePrefab = normLine;
	}
	void Update()
	{

		if(canvas.activeInHierarchy == false){
			if(Input.GetMouseButtonDown(0))
			{
				GameObject lineGO = Instantiate(linePrefab);
				activeLine = lineGO.GetComponent<Line>();
			}

			if(Input.GetMouseButtonUp(0))
			{
				activeLine = null;
			}

			if(activeLine != null)
			{
				Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				activeLine.UpdateLine(mousePos);
			}
		}
	}

	public void BoostLine()
	{
		linePrefab = boostLine;
	}

	public void BounceLine()
	{
		linePrefab = bounceLine;
	}
}
