using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO buildingType;


    private void Start()
    {
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
        buildingType = buildingTypeList.list[0];
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
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
}
