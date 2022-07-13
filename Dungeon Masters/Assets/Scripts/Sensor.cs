using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{

    public List<GameObject> detectedObjects { get; set; }

    protected void Awake()
    {
        detectedObjects = new List<GameObject>();
    }

    protected void AddObjectToDetectedList(Collider other)
    {
        //If the object is not already in the list
        GameObject o = other.gameObject;
        if (!detectedObjects.Contains(o))
        {
            //Add it to the list
            detectedObjects.Add(o);
        }
        
    }
    protected void RemoveObjectFromDetectedList(Collider other)
    {
        detectedObjects.Remove(other.gameObject);
    }

    //Triggers
    private void OnTriggerEnter(Collider other)
    {
        AddObjectToDetectedList(other);
        TriggerEnterActions(other);
    }
    private void OnTriggerExit(Collider other)
    {
        RemoveObjectFromDetectedList(other);
        TriggerExitActions(other);
    }

    //To be overridden in child classes
    protected void TriggerEnterActions(Collider other)
    {

    }
    //To be overridden in child classes
    protected void TriggerExitActions(Collider other)
    {

    }

}
