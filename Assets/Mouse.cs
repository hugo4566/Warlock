﻿using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
	
	private Quaternion _lookRotation;
	private Vector3 _direction;
	private Vector3 finalPosition;
	private float _speed = 15.0f;
	private float _speedRotation = 15.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 40, Color.yellow);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit)){
			if(Input.GetMouseButtonDown(1)){
				finalPosition = hit.point;
				finalPosition.Set(finalPosition.x,transform.position.y,finalPosition.z);
			}
		}
		if(finalPosition != Vector3.zero){
			//find the vector pointing from our position to the target
			_direction = (finalPosition - transform.position).normalized;
			//create the rotation we need to be in to look at the target
			_lookRotation = Quaternion.LookRotation(_direction);
			//rotate us over time according to speed until we are in the required rotation
			transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * _speedRotation);
			
			transform.position = Vector3.Lerp(transform.position, finalPosition, 1/(50.0f*(Vector3.Distance(transform.position, finalPosition)))*_speed);
			if(transform.position == finalPosition){
				finalPosition = Vector3.zero;
			}
		}
	}
}