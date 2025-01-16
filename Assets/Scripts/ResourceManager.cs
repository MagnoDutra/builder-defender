using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    private Dictionary<ResourceTypeSO, int> resourcesAmountDict;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        resourcesAmountDict = new Dictionary<ResourceTypeSO, int>();

        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
        foreach (ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourcesAmountDict[resourceType] = 0;
        }

        TestLogResourceAmountDictionary();
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
        TestLogResourceAmountDictionary();
    }
}
