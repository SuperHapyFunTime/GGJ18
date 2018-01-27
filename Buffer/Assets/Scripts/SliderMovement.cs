using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour {
    float[] sliderPositionX = { -15.7f, -10f, -5f };
    public int arrayCount = 0;
    float sliderSpeed = 2f;
    bool sliderUpdatePosition = false;
    public bool resetSliderPosition = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sliderUpdatePosition)
        {
            if (transform.position.x < sliderPositionX[arrayCount])
                transform.position += Vector3.right * Time.deltaTime * sliderSpeed;

            else if (transform.position.x > sliderPositionX[arrayCount] && resetSliderPosition)
            {
                transform.position += Vector3.left * Time.deltaTime * sliderSpeed;
            }
            else
                sliderUpdatePosition = false;
        }
    }
    public void UpdateSliderPosition()
    {
        arrayCount++;
        sliderUpdatePosition = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("test");
        if (collision.gameObject.tag == "Player")
        {
            arrayCount = 0;
            resetSliderPosition = true;
        }
    }
}
