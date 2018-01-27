using UnityEngine;
using System.Collections;

public class AnimateSpritesSimply : MonoBehaviour 
{
    SpriteRenderer sprites;
    public int current = 0;
    public Sprite[] frames;
    public float framesPS = 1;
    float lastFPS;

    float count= 0;
    float length = 100000000000;
    
    void Start () 
    {
        lastFPS = framesPS;

        length = 1 / (float)framesPS;
        sprites = GetComponent<SpriteRenderer>();

        if (current >= frames.Length)
            current = 0;

        sprites.sprite = frames[current];
	}

	void Update ()
    {
        if(lastFPS != framesPS)
        {
            lastFPS = framesPS;
            length = 1 / (float)framesPS;
        }

        count += Time.deltaTime;
        if(count > length)
        {
            count -= length;
            current++;

            if (current >= frames.Length)
                current = 0;

            sprites.sprite = frames[current];
        }
	}
}
