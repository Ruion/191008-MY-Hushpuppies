﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventSequencer : MonoBehaviour {

    public UnityEvent[] events;
    public float[] delays;

    public bool isRealtime = true;

    public void Run()
    {
        StartCoroutine(ExecuteEvents());
    }

    IEnumerator ExecuteEvents()
    {
        for (int e = 0; e < events.Length; e++)
        {

           if(isRealtime) yield return new WaitForSecondsRealtime(delays[e]);

           else yield return new WaitForSeconds(delays[e]);

            events[e].Invoke();
        }

    }
}
