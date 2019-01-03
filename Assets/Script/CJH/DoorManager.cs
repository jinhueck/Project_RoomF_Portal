using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

    private Animator DoorAni;
    private bool check;

	// Use this for initialization
	void Start ()
    {
        DoorAni = GetComponent<Animator>();
        check = false;
	}
	
	public void OpenDoor()
    {
        if (check == false)
        {
            DoorAni.SetBool("Open", true);
            for (int i = 0; i < 3; i++)
            {
                GameObject.Find("Line").transform.GetChild(i).GetComponent<MeshRenderer>().
                    material.color = Color.yellow;
            }
            check = true;
        }
        else if (check == true)
        {
            DoorAni.SetBool("Open", false);
            for (int i = 0; i < 3; i++)
            {
                GameObject.Find("Line").transform.GetChild(i).GetComponent<MeshRenderer>().
                    material.color = Color.white;
            }
            check = false;
        }
    }
}
