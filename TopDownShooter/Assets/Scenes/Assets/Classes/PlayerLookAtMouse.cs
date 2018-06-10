using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAtMouse : MonoBehaviour {



	void Update () {

		if(Manager.instance.pauseText.activeInHierarchy == false)
		{
			Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
			float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		}
	}
}
