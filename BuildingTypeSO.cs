using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates a menu asset that you can select when you create a new item in the Project folder
[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class BuildingTypeSO : ScriptableObject
{
    // User sets all of these fields in the Inspector for each object
    // Stores scriptable object name, prefab, and the resource it generates when placed
    public string nameString;
    public Transform prefab;
    public ResourceGeneratorData resourceGeneratorData;
}
