using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float moveSpeed = 5.0f;
	private float screenX = Screen.width;
	private float screenY = Screen.height;
	private bool follow = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;

		if (Input.GetKeyDown (KeyCode.P)) {
			follow = !follow;
		}

		if (follow) {
			Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
			Camera.main.transform.position = new Vector3 (playerPosition.x, Camera.main.transform.position.y, playerPosition.z);
		}

		if (Input.GetKey (KeyCode.UpArrow) || mouseY > screenY)
			Camera.main.transform.position += transform.up * moveSpeed * Time.deltaTime;
		if (Input.GetKey (KeyCode.DownArrow) || mouseY < 0)
			Camera.main.transform.position += -transform.up * moveSpeed * Time.deltaTime;
		if (Input.GetKey (KeyCode.RightArrow)|| mouseX+(screenX/100) >= screenX)
			Camera.main.transform.position += transform.right * moveSpeed * Time.deltaTime;
		if (Input.GetKey (KeyCode.LeftArrow) || mouseX<=0)
			Camera.main.transform.position += -transform.right * moveSpeed* Time.deltaTime;
	}
}
