using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<ResourceTypeSO, int> resourcesAmountDict;

    private void Awake()
    {
        resourcesAmountDict = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourcesAmountDict[resourceType] = 0;
        }

        TestLogResourceAmountDictionary();
    }

    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeList.list[0], 2);
            TestLogResourceAmountDictionary();
        }
    }

    public void TestLogResourceAmountDictionary()
    {
        foreach (ResourceTypeSO resourceType in resourcesAmountDict.Keys)
        {
            Debug.Log($"{resourceType.resourceName}: {resourcesAmountDict[resourceType]}");
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourcesAmountDict[resourceType] += amount;
    }
}
