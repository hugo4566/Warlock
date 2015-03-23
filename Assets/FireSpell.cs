using UnityEngine;
using System.Collections;

public class FireSpell : MonoBehaviour {

	public Vector3 forward { get; set;}

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody> ().AddForce (forward * 300);
		Destroy(gameObject,1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collisionInfo){
		if (collisionInfo.gameObject.tag == "Enemy") {
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