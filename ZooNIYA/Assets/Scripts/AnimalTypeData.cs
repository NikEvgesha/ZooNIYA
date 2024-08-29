using UnityEngine;
using static Enums;

[CreateAssetMenu(menuName = "ZooScripts/AnimalTypeData")]
public class AnimalTypeData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _basePrice;
    [SerializeField] private Area _area;
}
