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
            if (buildingType != null && CanSpawnBuilding(buildingType, UtilsClass.GetMouseWorldPosition()))
            {
                Vector3 mousePosWorld = UtilsClass.GetMouseWorldPosition();
                Instantiate(buildingType.prefab, mousePosWorld, Quaternion.identity);
            }

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

    private bool CanSpawnBuilding(BuildingTypeSO buildingType, Vector3 position)
    {
        BoxCollider2D boxCollider2D = buildingType.prefab.GetComponent<BoxCollider2D>();

        Collider2D[] colliderArray = Physics2D.OverlapBoxAll((Vector2)position + boxCollider2D.offset, boxCollider2D.size, 0);


        bool isAreaClear = colliderArray.Length == 0;

        if (!isAreaClear) { return false; }

        colliderArray = Physics2D.OverlapCircleAll(position, buildingType.minConstructionRadius);

        foreach (Collider2D collider in colliderArray)
        {
            if (collider.TryGetComponent(out BuildingTypeHolder buildingTypeHolder))
            {
                if (buildingTypeHolder.buildingType == buildingType)
                {
                    return false;
                }
            }
        }

        float maxConstructionRadius = 25;
        colliderArray = Physics2D.OverlapCircleAll(position, maxConstructionRadius);

        foreach (Collider2D collider in colliderArray)
        {
            if (collider.TryGetComponent(out BuildingTypeHolder buildingTypeHolder))
            {
                return true;
            }
        }

        return false;
    }
}
