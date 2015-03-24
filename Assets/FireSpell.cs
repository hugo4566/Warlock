using UnityEngine;
using System.Collections;
using Model;

public class FireSpell : MonoBehaviour {

	public Vector3 forward { get; set;}
	public SpellModel spellModel { get; set;}

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody> ().AddForce (forward * 300);
		Destroy(gameObject,spellModel.spellDuration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collisionInfo){
		if (collisionInfo.gameObject.tag == "Enemy") {
			PlayerStats ps= collisionInfo.gameObject.GetComponent<PlayerStats>();
			ps.hp -= spellModel.dmg;
			if(ps.hp <=0)
				Destroy(collisionInfo.gameObject);
			Debug.Log (ps.namePlayer + "  : " + ps.hp);
			if(collisionInfo.gameObject != null){
				Vector3 forceVector = collisionInfo.rigidbody.velocity.normalized*(spellModel.dmg/(ps.hp/100));
				collisionInfo.rigidbody.AddForce(forceVector,ForceMode.Impulse);
			}
			Destroy(gameObject);
		}
	}

}