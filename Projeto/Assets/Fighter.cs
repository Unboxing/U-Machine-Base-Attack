using UnityEngine;
using System.Collections;

public class Fighter : MonoBehaviour {

	public GameObject opponent;
	public AnimationClip attack;
	public int damage;
	public double impactTime;
	public bool impacted;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
			animation.Play (attack.name);		
			ClickToMove.attack = true;

			if(opponent!=null)
			{
			transform.LookAt(opponent.transform.position);
		}
	}
		if (!animation.IsPlaying (attack.name)) 
	{
			ClickToMove.attack = false;	
			impacted = false;
		}

		impact ();
	}
	void impact()
	{
		if (opponent!=null&&animation.IsPlaying(attack.name)&&!impacted) 
		{
			if((animation[attack.name].time>animation[attack.name].length*impactTime))
			{
				opponent.GetComponent<Mob>().getHit(damage);
				impacted = true;
			}
	}
}
}