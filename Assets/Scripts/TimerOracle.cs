using System;

using UnityEngine;
using System.Collections;

public class TimerOracle : MonoBehaviour {

    public float MatchTime = 60.0f;

    public event Action TimeOut;

	// Use this for initialization
	void Start ()
	{
	    TimeOut += OnTimeOut;
	}
	
	// Update is called once per frame
	void Update () {
        MatchTime -= Time.deltaTime;
	    if (MatchTime <= 0.0f && TimeOut != null)
	    {
	        TimeOut();
	    }
	}

    void OnTimeOut()
    {
        Application.LoadLevel("GameOver");
    }
}
