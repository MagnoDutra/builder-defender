using UnityEngine;

[CreateAssetMenu(fileName = "BuildingTypeSO", menuName = "Scriptable Objects/BuildingTypeSO")]
public class BuildingTypeSO : ScriptableObject
{
  public string towerName;
  public Transform prefab;
  public Sprite sprite;
  public ResourceGeneratorData resourceGeneratorData;
  public float minConstructionRadius;
}
