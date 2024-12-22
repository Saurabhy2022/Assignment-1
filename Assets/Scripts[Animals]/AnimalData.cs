using UnityEngine;

[CreateAssetMenu(fileName = "NewAnimalData", menuName = "Animal Data", order = 51)]
public class AnimalData : ScriptableObject
{
    public string animalName;
    public FlyingCategory flyingCategory;
    public InsectCategory insectCategory;
    public DietCategory dietCategory;
    public SocialCategory socialCategory;
    public ReproductionCategory reproductionCategory;
}

// Enum for flying ability
public enum FlyingCategory { Flying, NonFlying }

// Enum for insect classification
public enum InsectCategory { Insect, NonInsect }

// Enum for diet classification
public enum DietCategory { Omnivorous, Herbivorous }

// Enum for social behavior classification
public enum SocialCategory { Group, Solo }

// Enum for reproduction type classification
public enum ReproductionCategory { LaysEggs, GivesBirth }
