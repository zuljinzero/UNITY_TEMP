using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates a menu asset that you can select when you create a new item in the Project folder
[CreateAssetMenu(menuName = "ScriptableObjects/ResourceType")]
public class ResourceTypeSO : ScriptableObject
{
    // User sets all of these fields in the Inspector for each object
    // Stores scriptable object name and which sprite to use
    public string nameString;
    public Sprite sprite;
}
