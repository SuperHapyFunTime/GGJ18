using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsYou : MonoBehaviour {

    // Use this for initialization
    public float currentYPos;
    public float endYpos= -5f;
    public float speed=0.01f;
	void Start () {
        currentYPos = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.down * Time.deltaTime*speed;
        currentYPos = this.transform.position.y;
        CheckY();
    }
    //Destroys The object onces it pasts out of the game
    public void CheckY()
    {
        if (currentYPos < endYpos)
            Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
