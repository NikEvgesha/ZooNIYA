using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums
{

    public enum CageState
    {
        Purchased,
        NotPurchased
    }
    public enum AnimalTypes
    {
        None,
        Rabbit,
        Fox,
        Bear,
    }

    public enum Area
    {
        Temperate,
        Tropical,
        Polar,
        Desert,
    }

    public enum Gender
    {
        Male,
        Female,
    }

    public enum Age
    {
        Baby,
        Mature,
        Elderly
    }

    public enum AnimalStatus
    {
        Idle,
        Eating,
        Walking,
        Sleeping
    }
}
