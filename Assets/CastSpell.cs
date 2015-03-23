using UnityEngine;
using System.Collections;
using Model;

public class CastSpell : MonoBehaviour {
	
	private float timeStamp;
	private GameObject _uiGo;
	private Vector3 spellPosition;

	private Quaternion _lookRotation;
	private Vector3 _direction;
	private float _speedRotation = 100.0f;

	// Use this for initialization
	void Start () {
		GetCooldownIcon ();
	}
	
	// Update is called once per frame
	void Update () {

		// If the is KeyPressed and is off Cooldown
		// Rotate player and cast spell at mouse direction
		if ((Input.GetKeyDown (KeyCode.Q) || Input.GetKeyDown (KeyCode.W)) && timeStamp <= Time.time) {
			SpellModel spell = null;
			if(Input.GetKeyDown (KeyCode.Q))
				spell = new Model.SpellModel("fire",1.5f,"MyFlare");
			if(Input.GetKeyDown (KeyCode.W))
				spell = new Model.SpellModel("teleport",3.0f,null);

			MousePosition ();

			RotateToPoint ();

			CreateSpell (spell);

		}else if (timeStamp <= Time.time) {
			_uiGo.SetActive (false);
		}

	}

	void GetCooldownIcon ()
	{
		//	Find cooldown icon - UI
		GameObject[] uis = GameObject.FindGameObjectsWithTag ("UI");
		foreach (GameObject go in uis) {
			if (go.name == "cooldown") {
				_uiGo = go;
				_uiGo.SetActive (false);
				break;
			}
		}
	}

	void MousePosition ()
	{
		Ray raySpell = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (raySpell.origin, raySpell.direction * 40, Color.blue);
		RaycastHit hit;
		//	Get position of the mouse
		if (Physics.Raycast (raySpell, out hit)) {
			spellPosition = hit.point;
			spellPosition.Set (spellPosition.x, transform.position.y, spellPosition.z);
		}
	}

	void RotateToPoint ()
	{
		//	find the vector pointing from our position to the target
		_direction = (spellPosition - transform.position).normalized;
		//	create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation (_direction);
		//	rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp (transform.rotation, _lookRotation, Time.deltaTime * _speedRotation);
	}

	void CreateSpell (SpellModel spell)
	{
		ActivateSpell (spell);
		// Activate icon of cooldown
		_uiGo.SetActive (true);
		// Set cooldown
		timeStamp = Time.time + spell.cooldown;
	}

	void ActivateSpell (SpellModel spell)
	{
		Vector3 forward = transform.TransformDirection (Vector3.forward);
		if (spell.spellName == "fire") {
			//	Load spell particle from folder "Resources" 
			GameObject flame = (GameObject)Instantiate (Resources.Load (spell.particlePath, typeof(GameObject)), transform.position + forward, Quaternion.identity);
			flame.GetComponent<Rigidbody> ().AddForce (forward * 300);
		}
		if (spell.spellName == "teleport") {
			transform.position = spellPosition;
			GameObject go = GameObject.FindWithTag("Enemy");
			float distance = Vector3.Distance(go.transform.position,transform.position);
			if(distance <= 4.0f){
				Vector3 spellDir = (go.transform.position - transform.position).normalized;
				go.GetComponent<Rigidbody> ().AddForce (spellDir * 300);
			}
		}
	}
}