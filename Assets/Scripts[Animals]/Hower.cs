using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverDescription : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{
    public GameObject descriptionPanel; // Panel to show description
    public Text descriptionText; // UI Text element for the description
    public string animalDescription; // Animal description text

    void Start()
    {
        // Ensure the panel is hidden initially
        descriptionPanel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Show the panel and update the text when hovered
        descriptionText.text = animalDescription;
        descriptionPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide the panel when the pointer exits
        descriptionPanel.SetActive(false);
    }
}
