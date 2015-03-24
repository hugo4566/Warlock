using UnityEngine;
using System.Collections;
using Model;

public class HomingSpell : MonoBehaviour {

	public Vector3 forward { get; set;}
	public GameObject target { get; set;}
	public Vector3 spellPosition { get; set;}
	public SpellModel spellModel { get; set;}

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody> ().AddForce (forward * 300);

		// Find enemies within reach
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
		float shorter = -1f;
		foreach(GameObject go in gameObjects){
			float distance = Vector3.Distance(go.transform.position,spellPosition);
			if(shorter == -1f || shorter > distance){
				shorter = distance;
				target = go;
			}
		}
		Destroy(gameObject,spellModel.spellDuration);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation((target.transform.position-transform.position).normalized), Time.deltaTime);
		transform.position = Vector3.Lerp (transform.position, target.transform.position, 1 / (50.0f * (Vector3.Distance (transform.position, target.transform.position))) * 10.0f);
	}

	void OnCollisionEnter (Collision collisionInfo){
		if (collisionInfo.gameObject.tag == "Enemy") {
			PlayerStats ps= collisionInfo.gameObject.GetComponent<PlayerStats>();
			ps.hp -= spellModel.dmg;
			if(ps.hp <=0)
				Destroy(collisionInfo.gameObject);
			Debug.Log (ps.namePlayer + "  : " + ps.hp);
			if(collisionInfo.gameObject != null){
				Vector3 direction = -(transform.position - collisionInfo.transform.position).normalized;
				Vector3 forceVector = direction*(spellModel.dmg/(ps.hp/100));
				collisionInfo.rigidbody.AddForce(forceVector,ForceMode.Impulse);
			}
			Destroy(gameObject);
		}
	}
}
