using UnityEngine;
using System.Collections;

public class SafeFloor : MonoBehaviour {
		
	private float timer;
	private float interval = 5.0f;

	// Use this for initialization
	void Start () {
		timer = Time.time + interval;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timer) {
			transform.localScale = new Vector3(transform.localScale.x/2,transform.localScale.y/2,transform.localScale.z);
			timer = Time.time + interval;
		}
	}
}
