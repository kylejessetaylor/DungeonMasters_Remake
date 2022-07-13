using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSensor : Sensor
{
    protected GameObject parentObject;

    public bool isEmpty { get; private set; }

 /*   /// <summary>
    /// FOR TESTING ONLY - REMOVE IN PUBLIC RELEASE
    /// </summary>
    protected new void Awake()
    {
        detectedObjects = new List<GameObject>();
        isEmpty = true;
    }*/


    // Enables Parent Object
    void Start()
    {
        parentObject = this.gameObject.transform.parent.gameObject;
    }


    protected new void TriggerEnterActions(Collider other)
    {
        isEmpty = false;
    }
    protected new void TriggerExitActions(Collider other)
    {
        if (detectedObjects.Count == 0)
        {
            isEmpty = true;
        }
    }
}
