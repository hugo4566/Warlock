using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public string namePlayer { get; set;}
	public float hp { get; set;} 

	// Use this for initialization
	void Start () {
		namePlayer = "Sphere";
		hp = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
