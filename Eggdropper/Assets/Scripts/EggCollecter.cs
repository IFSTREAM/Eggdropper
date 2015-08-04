using UnityEngine;
using System.Collections;

public class EggCollecter : MonoBehaviour 
{
    PlayerScript myPlayerScript;
	public AudioClip eggCollect;
	
    void Awake()
    {
        myPlayerScript = transform.parent.GetComponent<PlayerScript>();
    }

	void OnTriggerEnter(Collider col)
    {
        GameObject Egg = col.gameObject;
        Destroy(Egg);

        myPlayerScript.theScore++; //Increase Score
		GetComponent<AudioSource>().PlayOneShot (eggCollect); //Egg Collect Sound
    }
}