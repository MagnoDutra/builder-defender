using System;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    private GameObject spriteGO;

    void Awake()
    {
        spriteGO = transform.Find("Sprite").gameObject;
        spriteGO.SetActive(false);
    }

    private void Start()
    {
        BuildingManager.Instance.OnSelectBuilding += BuildingManager_OnSelectBuilding;
    }

    private void BuildingManager_OnSelectBuilding(object sender, BuildingManager.OnSelectBuildingEventArgs e)
    {
        if (e.buildingType == null)
        {
            Hide();
        }
        else
        {
            Show(e.buildingType.sprite);
        }
    }

    private void Update()
    {
        transform.position = UtilsClass.GetMouseWorldPosition();
    }



    private void Show(Sprite ghostSprite)
    {
        spriteGO.SetActive(true);
        spriteGO.GetComponent<SpriteRenderer>().sprite = ghostSprite;
    }

    private void Hide()
    {
        spriteGO.SetActive(false);
    }
}
