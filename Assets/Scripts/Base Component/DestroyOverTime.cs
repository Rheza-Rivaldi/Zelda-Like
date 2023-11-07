using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifetimeCounter;

    void Awake()
    {
        Timer(lifetimeCounter);
    }

    private void Timer(float timeToLife) {
        //Debug.Log("count started");
        Destroy(this.gameObject, timeToLife);
    }
}
