using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }

    public event EventHandler<OnSelectBuildingEventArgs> OnSelectBuilding;

    public class OnSelectBuildingEventArgs : EventArgs
    {
        public BuildingTypeSO buildingType;
    }

    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO buildingType;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && !EventSystem.current.IsPointerOverGameObject())
        {
            if (buildingType == null) { return; }

            Vector3 mousePosWorld = UtilsClass.GetMouseWorldPosition();
            Instantiate(buildingType.prefab, mousePosWorld, Quaternion.identity);
        }
    }

    public void SetSelectedBuilding(BuildingTypeSO buildingType)
    {
        this.buildingType = buildingType;
        OnSelectBuilding?.Invoke(this, new OnSelectBuildingEventArgs { buildingType = buildingType });
    }

    public BuildingTypeSO GetSelectedBuilding()
    {
        return this.buildingType;
    }
}
