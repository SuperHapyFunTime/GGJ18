using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float lerpSpeed;
    float playerJumpDist;
    Vector3 playerCurrentPos;
	Vector3 playerPreviousPos;
    Vector3 maxLeftPos;
    Vector3 maxRightPos;
	Transform tr;

	// Use this for initialization
	void Start () 
	{
        maxLeftPos = new Vector3(0, -5, 0);
        maxRightPos = new Vector3(0, 5, 0);
        lerpSpeed = 50.0f;
        playerJumpDist = 5;
        playerCurrentPos = transform.position;
		tr = transform;
		playerPreviousPos = transform.position;
	}

    // Update is called once per frame
    void Update() {
        playerMovement();
    }
   
    void playerMovement() {

        if (playerCurrentPos.y != maxRightPos.y) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && tr.position == playerCurrentPos) {
                playerCurrentPos += new Vector3(0, 5, 0);
                playerPreviousPos = transform.position;
            }

        }

        if (playerCurrentPos.y != maxLeftPos.y) {
            if (Input.GetKeyDown(KeyCode.DownArrow) && tr.position == playerCurrentPos) {
                playerCurrentPos += new Vector3(0, -5, 0);
                playerPreviousPos = transform.position;

            }
        }
        transform.position = Vector3.MoveTowards(transform.position, playerCurrentPos, Time.deltaTime * lerpSpeed);
    }
		
	}
    

