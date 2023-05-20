using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates a menu asset that you can select when you create a new item in the Project folder
[CreateAssetMenu(menuName = "ScriptableObjects/ResourceTypeList")]
public class ResourceTypeListSO : ScriptableObject
{
    // User sets which objects go into this list from the Inspector
    public List<ResourceTypeSO> list;
}
