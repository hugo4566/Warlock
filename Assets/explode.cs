using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.name == "Sphere") {
			col.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.forward * 2,ForceMode.Impulse);
			Destroy(gameObject);
		}
	}
}
