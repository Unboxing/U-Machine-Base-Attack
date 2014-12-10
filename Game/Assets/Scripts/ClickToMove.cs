﻿using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour
{
	public float speed;
	public CharacterController controller;
	private Vector3 position;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
		if(Input.GetMouseButton(0))
		{
			//Locate where the player clicked on the terrain
			locatePosition();
		}
		
		//Move the player to the position
		moveToPosition();
	}
	
	void locatePosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, 1000))
		{
			position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			Debug.Log (position);
		}
	}

	void moveToPosition(){

		if(Vector3.Distance(transform.position, position)>1)
		{
			Quaternion newRotation = Quaternion.LookRotation(position-transform.position, Vector3.forward);
			
			newRotation.x = 0f;
			newRotation.z = 0f;
			
			transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
			controller.SimpleMove(transform.forward * speed);

				}
	}

}