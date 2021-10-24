using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{

    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;

    private GameObject spawnedObject;

    private Pose placementPose;
    private ARRaycastManager arRaycastManager;
    private bool placementPoseIsValid = false;


    private void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    private void Update()
    {
        if(spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SpawnObject();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementIndicator()
    {
        if(spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var raycastHitList = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, raycastHitList, TrackableType.Planes);

        placementPoseIsValid = raycastHitList.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = raycastHitList[0].pose;
        }
    }

    private void SpawnObject()
    {
        spawnedObject = Instantiate(arObjectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
    }
}
