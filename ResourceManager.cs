using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourceManager : MonoBehaviour
{
    // Enables prefabs to access ResourceManager, but can't change anything
    public static ResourceManager Instance { get; private set; }

    // Creates an event that essentially transmits something when a script is "listening"
    public event EventHandler OnResourceAmountChanged;

    // Creates a dictionary to store the amount of each resource the player has
    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;


    // Using Awake() instead of Start() because the ResourceTypeSO Dictionary does not depend on any external references, loading before Start()
    private void Awake()
    {
        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();

        // Load the ResourceTypeListSO scriptable object (find it by name)
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        // Initialize all ResourceTypeSO scriptable objects in list to amount 0 (Wood = 0, Stone = 0, Gold = 0, etc.)
        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0;
        }

        TestLogResourceAmountDictionary();
    }

    private void Update()
    {
        // Press A to manually add 2 to the resource in the first spot of resourceTypeList (Wood in this case)
        if (Input.GetKeyDown(KeyCode.A))
        {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeList.list[0], 2);
            TestLogResourceAmountDictionary();
        }
    }

    // Prints current resource amounts to console every tick
    private void TestLogResourceAmountDictionary()
    {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
        }
    }

    // Adds resources to the passed type, by the passed amount
    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;
        
        // Transmits the resource change to whatever is listening. ?.Invoke will prevent everything after from running if null, or nothing is listening
        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);

        TestLogResourceAmountDictionary();
    }

    // Displays the current amount of the passed resourceType
    public int GetResourceAmount(ResourceTypeSO resourceType)
    {
        return resourceAmountDictionary[resourceType];
    }
}
