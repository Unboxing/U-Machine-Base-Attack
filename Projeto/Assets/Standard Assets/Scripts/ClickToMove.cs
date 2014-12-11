using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour
{
	public float speed;
	public CharacterController controller;
	private Vector3 position;


	public AnimationClip run;
	public AnimationClip idle;

	public static bool attack;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
				if (!attack) {
						if (Input.GetMouseButton (0)) {
								//Locate where the player clicked on the terrain
								locatePosition ();
						}
		
						//Move the player to the position
						moveToPosition ();
				}
		else {

		}
		}
	
	void locatePosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, 1000))
		{
			if(hit.collider.tag!= "Player"){
			position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			}
		}
	}

	void moveToPosition(){
		//GameObject se movendo
		if (Vector3.Distance (transform.position, position) > 1) {
						Quaternion newRotation = Quaternion.LookRotation (position - transform.position, Vector3.forward);
						newRotation.x = 0f;
						newRotation.z = 0f;
						transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 10);
						controller.SimpleMove (transform.forward * speed);
						animation.CrossFade(run.name);
				}
		//GameObject nao se movendo
		else
		{
			animation.CrossFade (idle.name);
		}
	}

}