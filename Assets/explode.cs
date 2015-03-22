﻿using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject,1.5f);
	}

	void OnCollisionEnter (Collision collisionInfo){
		if (collisionInfo.gameObject.name == "Sphere") {
			PlayerStats ps= collisionInfo.gameObject.GetComponent<PlayerStats>();
			ps.hp -= 10;
			if(ps.hp <=0)
				Destroy(collisionInfo.gameObject);
			Debug.Log (ps.namePlayer + "  : " + ps.hp);
			Vector3 forceVec = collisionInfo.rigidbody.velocity.normalized*(10f/(ps.hp/100));
			collisionInfo.rigidbody.AddForce(forceVec,ForceMode.Impulse);
			Destroy(gameObject);



		}
	}
}
