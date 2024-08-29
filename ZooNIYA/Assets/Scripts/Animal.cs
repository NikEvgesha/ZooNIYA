using UnityEngine;
using static Enums;

public class Animal : MonoBehaviour
{
    [SerializeField] private AnimalTypeData _typeData;
    [SerializeField] private Gender _gender;
    [SerializeField] private Age _age;
    [SerializeField] private Cage _cage; // for action subscription
    
    private AnimalStatus _status;

    private void Start()
    {
        
    }



    private void Update()
    {
        
    }

    
}
