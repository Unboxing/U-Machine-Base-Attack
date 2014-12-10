using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {


	public float speed;
	public float range;

	public CharacterController controller;
	public Transform player;

	public AnimationClip run;
	public AnimationClip idle;

	private int health;
	// Use this for initialization
	void Start () {
		health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if(!inRange()){
		chase ();
		}
		else{
			animation.CrossFade(idle.name);
		}
		Debug.Log (health);
	}

	bool inRange(){
		if (Vector3.Distance (transform.position, player.position)< range) {
			return true;		
		}
		else{
			return false;
		}
	}

	public void getHit(int damage)
	{
		health = health - damage;
		if (health < 0)
		{
			health = 0;
		}
	}

	void chase(){
		transform.LookAt (player.position);
		controller.SimpleMove (transform.forward * speed);
		animation.CrossFade (run.name);
	}

	void OnMouseOver()
	{
		player.GetComponent<Fighter> ().opponent = gameObject;
	}
}
