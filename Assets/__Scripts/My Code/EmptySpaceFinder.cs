using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpaceFinder : MonoBehaviour
{

    public Vector3 SpawnPoint;
    public bool EmptySpaceFound = true;

    public GameObject PlayerShip;
    public Collider[] hitColliders;

    private void Start()
    {
        SpawnPoint = new Vector3(0, 0, 0);
    }

    void Update()
    {
        // Only Try to Find Space if the spaceship has hit something
        if (!EmptySpaceFound)
        {
            FindEmptySpace();
            Debug.Log(SpawnPoint);
        }
    }

    public void FindEmptySpace()
    {
        Debug.Log("Locating");

        // Start Locating The Empty Space
        EmptySpaceFound = false;

        SpawnPoint = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-7.0f, 7.0f), 0);

        hitColliders = Physics.OverlapSphere(SpawnPoint, 4);

        // Nothing found in the hit box, empty space located, stop locating
        // 1 Because ScreenBounds will always be detected and should be ignored
        if (hitColliders.Length == 1)
        {
            EmptySpaceFound = true; // Stop locating in Update()
            PlayerShip.transform.position = SpawnPoint;
        }
    }

    

}
