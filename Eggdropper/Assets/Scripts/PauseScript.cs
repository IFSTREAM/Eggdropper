using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour 
{	
	void Update () 
	{
     	if (Input.GetKeyDown(KeyCode.P)) 
     	{
    		Time.timeScale = 0;
        }

        //Add Toggleablity
	}
}