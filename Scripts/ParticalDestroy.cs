using UnityEngine;
using System.Collections;

public class ParticalDestroy : MonoBehaviour 
{
	// Destroy the partical
	void Start () 
	{
		Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
	}

	void Update () 
	{
	
	}
}
