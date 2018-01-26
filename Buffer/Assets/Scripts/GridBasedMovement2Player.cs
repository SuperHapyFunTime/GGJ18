using UnityEngine;
using System.Collections;

public class GridBasedMovement2Player : MonoBehaviour {

	float speed = 50.0f;
    bool changepos;
    Vector3 pos;
	Vector3 oldpos;
    Vector3 maxLeftPos;
    Vector3 maxRightPos;
	Transform tr;

	// Use this for initialization
	void Start () 
	{
        maxLeftPos = new Vector3(-5, 0, 0);
        maxRightPos = new Vector3(5, 0, 0);
        pos = transform.position;
		tr = transform;
		oldpos = transform.position;
	}

    // Update is called once per frame
    void Update() {
        PlayerMovement();
    }
   
    void PlayerMovement() {

        if (pos.x != maxRightPos.x) {
            if (Input.GetKey(KeyCode.RightArrow) && tr.position == pos) {
                Debug.Log(pos);
                pos += new Vector3(5, 0, 0);
                oldpos = transform.position;
            }

        }

        if (pos.x != maxLeftPos.x) {
            if (Input.GetKey(KeyCode.LeftArrow) && tr.position == pos) {
                pos += new Vector3(-5, 0, 0);
                oldpos = transform.position;

            }
        }

        if (changepos) {
            pos = oldpos;
            changepos = false;
        }
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
		
	}
    

