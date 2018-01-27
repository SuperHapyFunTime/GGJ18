using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    // Use this for initialization
    public float currentXPos;
    public float endYpos= -5f;
    public float speed=0.01f;
	void Start () {
        currentXPos = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.left * Time.deltaTime*speed;
        currentXPos = this.transform.position.x;
        CheckY();
    }
    //Destroys The object onces it pasts out of the game
    public void CheckY()
    {
        if (currentXPos < endYpos)
            Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
