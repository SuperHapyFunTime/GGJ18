using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ShakeInfo
{
    public string name = "ExampleName";
    public Shaker shaker;
    public float duration = 0.7f;
    public float speed = 7;
    public float magnitude = 1;
    public bool doShake;
}


public class ShakeManager : MonoBehaviour 
{
    public List<ShakeInfo> shakes;
    public string currentKShake;

    public static ShakeManager instance;

	void Start ()
    {
        instance = this;

        if (currentKShake == "" && shakes.Count > 0)
            currentKShake = shakes[0].name;
	}

    public void Do(string name)
    {
        foreach(ShakeInfo _shake in shakes)
        {
            if(name == _shake.name)
            {
                Do( _shake.duration, _shake.speed, _shake.magnitude, _shake.shaker);
                return;
            }
        }

        Debug.Log("no shake found");
    }
	
    public void Do(float _duration, float _speed, float _magnitude, Shaker _shaker)
    {
        Shaker _thisShaker = _shaker;

        _thisShaker.duration = _duration;
        _thisShaker.speed = _speed;
        _thisShaker.magnitude = _magnitude;

        _thisShaker.PlayShake();
    }

	

	void Update ()
    {
        for (int i = 0; i < shakes.Count; i++)
        {
            if (shakes[i].doShake)
            {
                shakes[i].doShake = false;
                Do(shakes[i].name);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Do(currentKShake);
        }
	
	}
}
