using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private BuildingTypeSO buildingType;
    private float timer;
    private float timerMax;


    private void Awake()
    {
        // Get resource collection timer from each building type
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;
        timerMax = buildingType.resourceGeneratorData.timerMax;
    }
    private void Update()
    {
        // Timer counts down per proper deltaTime
        timer -= Time.deltaTime;
        // When BuildingTypeSO prefab's set timerMax hits zero, add 1 of that resource and reset timer
        if (timer <= 0f)
        {
            timer += timerMax;
            ResourceManager.Instance.AddResource(buildingType.resourceGeneratorData.resourceType, 1);
        }
    }
}
