using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour {
    float[] sliderPositionX = { -15.7f, -10f, -5f };
    public int arrayCount = 0;
    float sliderSpeed = 5f;
    bool sliderUpdatePosition = false;
    bool resetSliderPosition = false;
    public RageMeter rageMeter;
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
        if (arrayCount == 2)
            return;
        arrayCount++;
        sliderUpdatePosition = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rageMeter.DealRage(0.4f);
            arrayCount = 0;
            resetSliderPosition = true;
        }
    }
}
