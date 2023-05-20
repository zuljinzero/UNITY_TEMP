using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private Camera mainCamera;
    // Reference to BuildingTypeListSO scriptable object, that holds all building types
    private BuildingTypeListSO buildingTypeList;
    // Reference to BuildingTypeSO scriptable object
    private BuildingTypeSO buildingType;


    // Using Awake() to load ResourceTypeSO Dictionary because it does not depend on any external references, unlike Camera.Main within Start()
    private void Awake()
    {
        // Load the BuildingTypeListSO scriptable object (find it by name)
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        // And set it as the first building type in the list
        buildingType = buildingTypeList.list[0];
    }

    // Also using Start() because Camera.main can't be grabbed before runtime
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Spawn BuildingTypeSO scriptable object at GetMouseWorldPosition() at the same rotation as the object prefab (Quaternion.identity)
            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }

        // Pressing T or Y sets the buildingType, from the buildingTypeList dictionary[i], as the "selected" buildingType that will be placed when left click
        if (Input.GetKeyDown(KeyCode.T))
        {
            buildingType = buildingTypeList.list[0];
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            buildingType = buildingTypeList.list[1];
        }
    }

    // Get 2D position of mouse, sets z (or 3rd Vector) to 0, to prevent errors
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }
}
