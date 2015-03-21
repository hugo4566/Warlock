using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

	private float _rangeSpell = 10.0f;
	public GameObject _prefab;
	private float _cooldown = 1.5f;
	private float timeStamp;
	private GameObject _uiGo;
	private Vector3 spellPosition;

	// Use this for initialization
	void Start () {
		GameObject[] uis = GameObject.FindGameObjectsWithTag ("UI");
		foreach (GameObject go in uis) {
			if (go.name == "cooldown") {
				_uiGo = go;
				_uiGo.SetActive (false);
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = transform.TransformDirection (Vector3.forward);
		Ray raySpell = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(raySpell.origin, raySpell.direction * 40, Color.blue);
		RaycastHit hit;
		GameObject flame = null;
		if (Input.GetKeyDown (KeyCode.Q) && timeStamp <= Time.time) {
			if (Physics.Raycast (raySpell, out hit)) {
				spellPosition = hit.point;
				spellPosition.Set (spellPosition.x, transform.position.y, spellPosition.z);
			}

			// Create spell, addForce, activate icon and cooldown
			flame = (GameObject)Instantiate (_prefab, transform.position + forward, Quaternion.identity);
			flame.GetComponent<Rigidbody> ().AddForce (forward * 300);
			_uiGo.SetActive (true);
			timeStamp = Time.time + _cooldown;
		}else if (timeStamp <= Time.time) {
			_uiGo.SetActive (false);
		}
	}
}