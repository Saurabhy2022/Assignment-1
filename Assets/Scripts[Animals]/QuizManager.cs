using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalQuizManager : MonoBehaviour
{
    public List<AnimalData> animals; // List of animals
    public GameObject redBucket, blueBucket; // two buckets
    public Text headingText;
    public Text redbucketText;
    public Text bluebucketText;
    private System.Random random = new System.Random();
    public Text incorrectAnimalsText;
    private int remainCards;
    private int score;
    public Text scoreText;
    public GameObject scorePanel;


    public GameObject finalScreenPanel;
    private List<string> incorrectAnimals = new List<string>();

    public enum QuizCategory { Flying, Insect, Diet, Social, Reproduction }
    private QuizCategory currentCategory;

    private void Start()
    {
        remainCards = animals.Count;
        if (scorePanel != null)
        {
            scorePanel.SetActive(false);
            
        }
        if (finalScreenPanel != null)
        {
            finalScreenPanel.SetActive(false);
        }
        StartQuiz();
    }

    public void StartQuiz()
    {
        currentCategory = (QuizCategory)random.Next(0, 5);
        Debug.Log("Sorting animals by: " + currentCategory);

        UpdateUI();

    }

    private void UpdateUI()
    {

        switch (currentCategory)
        {
            case QuizCategory.Flying:
                headingText.text = "Sort animals into Flying or Non-Flying.";
                redbucketText.text = "Flying";
                bluebucketText.text = "NonFlying";
                Debug.Log("Sort animals into Flying or Non-Flying.");
                break;
            case QuizCategory.Insect:
                headingText.text = "Sort animals into Insect or Non-Insect.";
                redbucketText.text = "Inscect";
                bluebucketText.text = "NonInscet";
                Debug.Log("Sort animals into Insect or Non-Insect.");
                break;
            case QuizCategory.Diet:
                redbucketText.text = "Omnivorous";
                bluebucketText.text = "Herbivorous";
                headingText.text = "Sort animals into Omnivorous or Herbivorous.";
                Debug.Log("Sort animals into Omnivorous or Herbivorous.");
                break;
            case QuizCategory.Social:
                redbucketText.text = "Group";
                bluebucketText.text = "Solo";
                headingText.text = "Sort animals into Lives in Group or Solo.";
                Debug.Log("Sort animals into Lives in Group or Solo.");
                break;
            case QuizCategory.Reproduction:
                redbucketText.text = "LaysEgges";
                bluebucketText.text = "GivesBirth";
                headingText.text = "Sort animals into Lays Eggs or Gives Birth.";
                Debug.Log("Sort animals into Lays Eggs or Gives Birth.");
                break;
        }
    }

    public void EvaluateAnimal(AnimalData animal, GameObject selectedBucket)
    {
        bool isCorrect = false;

        Debug.Log("Evaluating: " + animal.animalName + " placed in " + selectedBucket.name);

        switch (currentCategory)
        {
            case QuizCategory.Flying:

                Debug.Log("Category: Flying, Animal Flying Category: " + animal.flyingCategory);

                isCorrect = (selectedBucket == redBucket && animal.flyingCategory == FlyingCategory.Flying) ||
                            (selectedBucket == blueBucket && animal.flyingCategory == FlyingCategory.NonFlying);
                break;

            case QuizCategory.Insect:

                Debug.Log("Category: Insect, Animal Insect Category: " + animal.insectCategory);

                isCorrect = (selectedBucket == redBucket && animal.insectCategory == InsectCategory.Insect) ||
                            (selectedBucket == blueBucket && animal.insectCategory == InsectCategory.NonInsect);
                break;

            case QuizCategory.Diet:

                Debug.Log("Category: Diet, Animal Diet Category: " + animal.dietCategory);

                isCorrect = (selectedBucket == redBucket && animal.dietCategory == DietCategory.Omnivorous) ||
                            (selectedBucket == blueBucket && animal.dietCategory == DietCategory.Herbivorous);
                break;

            case QuizCategory.Social:

                Debug.Log("Category: Social, Animal Social Category: " + animal.socialCategory);

                isCorrect = (selectedBucket == redBucket && animal.socialCategory == SocialCategory.Group) ||
                            (selectedBucket == blueBucket && animal.socialCategory == SocialCategory.Solo);
                break;

            case QuizCategory.Reproduction:

                Debug.Log("Category: Reproduction, Animal Reproduction Category: " + animal.reproductionCategory);

                isCorrect = (selectedBucket == redBucket && animal.reproductionCategory == ReproductionCategory.LaysEggs) ||
                            (selectedBucket == blueBucket && animal.reproductionCategory == ReproductionCategory.GivesBirth);
                break;
        }

        if (isCorrect)
        {
            score += 1;
            
            Debug.Log(animal.animalName + " placed correctly!");
        }
        else
        {
 
            Debug.Log(animal.animalName + " placed incorrectly!");
            incorrectAnimals.Add(animal.animalName);
        }
        UpdateScore();

        
        remainCards--;

       
        if (remainCards <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over!");

        if (scorePanel != null)
        {
            scorePanel.SetActive(true);
        }

        // Display the names of incorrectly placed animals
        if (incorrectAnimals.Count > 0)
        {
            incorrectAnimalsText.text = "Incorrectly placed animals:\n" + string.Join("\n", incorrectAnimals);
        }
        else
        {
            incorrectAnimalsText.text = "All animals placed correctly!";
        }
    }

    private void UpdateScore()
    {
        if(scoreText != null)
        {
            scoreText.text = "score:" + score;
        }
    }

    public void incorrectObjects()
    {
        finalScreenPanel.SetActive(true);
    }



}
