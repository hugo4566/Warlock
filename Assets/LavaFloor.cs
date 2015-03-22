using UnityEngine;
using System.Collections;

public class LavaFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnCollisionStay(Collision collisionInfo) {
		if (collisionInfo.gameObject.name == "Sphere") {
			PlayerStats ps= collisionInfo.gameObject.GetComponent<PlayerStats>();
			ps.hp -= Time.deltaTime;
			if(ps.hp <=0)
				Destroy(collisionInfo.gameObject);
			Debug.Log (ps.namePlayer + "  : " + ps.hp);
		}
	}
}
