using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletdestroy : MonoBehaviour
{
    public float timeRemaining = 2;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else{
            Object.Destroy(this.gameObject);
        }
    }
}
