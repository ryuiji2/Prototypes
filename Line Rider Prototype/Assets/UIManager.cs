using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


	public GameObject ui;
	public GameObject openUIText;
	public GameObject spaceToPlay;
    public GameObject resetButton;

    public GameObject player;
    Vector2 resetPos;
    public List<GameObject> lineList;
    public Rigidbody2D rb;

	void Start () 
	{
		ui.SetActive(false);
        resetPos = player.transform.position;
        rb = player.GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        UIUpdate();
        if (Input.GetButtonDown("Start"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            SpaceToPlay();
        }
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

    public void ResetPlayer()
    {
        player.transform.position = resetPos;
        player.transform.eulerAngles = new Vector3(0, 0, 0);
        rb.bodyType = RigidbodyType2D.Static;
        spaceToPlay.SetActive(true);
    }

    public void ResetAll()
    {

        ResetPlayer();


        for (int i = 0; i < lineList.Count; i++)
        {
            Destroy(lineList[i]);
        }
    }

    public void ResetNormal()
    {
        for (int j = 0; j < lineList.Count; j++)
        {
            if(lineList[j] != null && lineList[j].tag == "Normal")
            {
                Destroy(lineList[j]);
            }
        }
    }

    public void ResetBoost()
    {
        for (int ii = 0; ii < lineList.Count; ii++)
        {
            if (lineList[ii] != null && lineList[ii].tag == "Boost")
            {
                Destroy(lineList[ii]);
            }
        }
    }

    public void ResetBouncy()
    {
        for (int jj = 0; jj < lineList.Count; jj++)
        {
            if (lineList[jj] != null && lineList[jj].tag == "Bouncy")
            {
                Destroy(lineList[jj]);
            }
        }
    }

    void RemoveNull()
    {
        for(int jk = 0; jk < lineList.Count; jk++)
        {
            if (lineList[jk] == null)
            {
                lineList.Remove(lineList[jk]);
            }
        }
    }
}
