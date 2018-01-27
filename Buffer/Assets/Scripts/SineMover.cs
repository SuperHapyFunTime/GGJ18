using UnityEngine;
using System.Collections;

public class SineMover : MonoBehaviour
{
    bool running = false;
    public bool loop = true;
    public bool playOnStart = true;

	public Vector3 positionOffset;
	Vector3 startPosition;

	public Vector3 scaleOffset;
	Vector3 startScale;

	public Vector3 angleOffset;
	Vector3 startAngle;

	public float timeToMove =1 ;

    float moveCount;

	void Start () 
	{
        moveCount = Mathf.PI * -0.5f * timeToMove;  //This ensures it starts at its start position. Math!!

        //take your starting positions;
		startPosition = transform.position;
		startScale = transform.localScale;
		startAngle = transform.eulerAngles;

        if (playOnStart)
            running = true;
	}

    public void StartMove()
    {
        moveCount = -0.5f * Mathf.PI * timeToMove;
        running = true;
    }

	void Update () 
	{
        if (!running)
            return;

        moveCount += Time.deltaTime;

        float _moveAmount = Mathf.Sin(moveCount / timeToMove);
        //get how much from the start to move

        _moveAmount += 1;
        _moveAmount /= 2;
        //Make sure you don't get any minus values^^)

        if (moveCount / timeToMove > 1.5f * Mathf.PI && !loop)
        {
            running = false;
            moveCount = -0.5f * Mathf.PI * timeToMove;
        }

		transform.position = startPosition + (_moveAmount * positionOffset);
		transform.eulerAngles = startAngle + (_moveAmount * angleOffset);
		transform.localScale = startScale + (_moveAmount * scaleOffset);
	}
}
