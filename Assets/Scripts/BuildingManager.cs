using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance { get; private set; }
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

            Vector3 mousePosWorld = GetMouseWorldPosition();
            Instantiate(buildingType.prefab, mousePosWorld, Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mousePosInPx = Mouse.current.position.ReadValue();
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosInPx);
        mousePosWorld.z = 0;

        return mousePosWorld;
    }

    public void SetSelectedBuilding(BuildingTypeSO buildingType)
    {
        this.buildingType = buildingType;
    }

    public BuildingTypeSO GetSelectedBuilding()
    {
        return this.buildingType;
    }
}
