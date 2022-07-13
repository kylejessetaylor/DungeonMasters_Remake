using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject wallAsset;

    public string floorTileTagName;
    private List<GameObject> placedFloorTiles = new List<GameObject>();
    public string wallTagName;
    private List<GameObject> placedWalls = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        PopulateFloorTileList();
        PopulateScene();
    }

    private void PopulateFloorTileList()
    {
        GameObject[] allPlacedFloors = GameObject.FindGameObjectsWithTag(floorTileTagName);
        foreach (GameObject g in allPlacedFloors)
        {
            AddFloorTileToList(g);
        }
    }

    private void PopulateScene()
    {
        CheckToPlaceWalls();
    }

    private void CheckToPlaceWalls()
    {
        List<Transform> locationsToPlaceWalls = new List<Transform>();

        //Gather list of transforms to place walls at
        foreach (GameObject floorPiece in placedFloorTiles)
        {
            //Gather List of Sensors
            List<GameObject> floorSensors = GetAllChildObjects(floorPiece);          

            //Check each sesor whether wall needs to be placed
            foreach (GameObject sensor in floorSensors)
            {
                FloorSensor s = sensor.GetComponent<FloorSensor>();
                //If nothing is there
                if (s.isEmpty)
                {
                    //Add to list of places to place walls
                    locationsToPlaceWalls.Add(sensor.transform);
                }
            }                     
        }

        //Place walls
        PlaceWalls(locationsToPlaceWalls);
    }

    private List<GameObject> GetAllChildObjects(GameObject parent)
    {
        List<GameObject> o = new List<GameObject>();
        Transform t = parent.transform;
        for (int i = 0; i < t.childCount; i++)
        {
            o.Add(t.GetChild(i).gameObject);
        }

        return o;
    }

    private void PlaceWalls(List<Transform> list)
    {
        foreach(Transform t in list)
        {
            PlaceWall(t);
        }
    }


    //Callable Function. Places one wall at specified location.
    public void PlaceWall(Transform t)
    {
        placedWalls.Add(Instantiate(wallAsset, new Vector3(t.position.x, t.position.y, t.position.z), t.localRotation));
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWallPlacements();
    }

    //Continually checks for floor tiles with empty sides. Placing & removing walls
    private void UpdateWallPlacements()
    {
        
    }

    
    public void AddFloorTileToList(GameObject floorTile)
    {
        placedFloorTiles.Add(floorTile);
    }
    public void RemoveFloorTileFromList(GameObject floorTile)
    {
        try{
            placedFloorTiles.Remove(floorTile);
        }catch (Exception){
            Debug.Log("Could not find floor tile to remove.");
        }
    }
}
