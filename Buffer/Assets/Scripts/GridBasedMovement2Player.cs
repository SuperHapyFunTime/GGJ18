using UnityEngine;
using System.Collections;

public class GridBasedMovement2Player : MonoBehaviour {

	float speed = 2.0f;
	Vector3 pos;
	Vector3 oldpos;
	Transform tr;
	bool changepos;
	public AudioClip Bump;

	// Use this for initialization
	void Start () 
	{
		pos = transform.position;
		tr = transform;
		oldpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.RightArrow) && tr.position == pos)
		{
			pos += Vector3.right;
			oldpos = transform.position;


		}
		else if (Input.GetKey(KeyCode.LeftArrow) && tr.position == pos)
		{
			pos += Vector3.left;
			oldpos = transform.position;

		}
		else if (Input.GetKey(KeyCode.UpArrow) && tr.position == pos)
		{
			pos += Vector3.up;
			oldpos = transform.position;

		}
		else if (Input.GetKey(KeyCode.DownArrow) && tr.position == pos)
		{
			pos += Vector3.down;
			oldpos = transform.position;

		}

		if (changepos) {
			pos = oldpos;
			changepos = false;
		}


		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
	}
	void OnCollisionEnter()
	{
		GetComponent<AudioSource>().Play ();
		changepos = true;
		//Debug.Log ("YAY");
	}
}
