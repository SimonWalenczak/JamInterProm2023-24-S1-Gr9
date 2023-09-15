using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollWheelManager : MonoBehaviour
{
    public Interactable interactable;

    public List<Sprite> ModelForms;
    public List<Sprite> PlayerForms;

    public List<SpriteRenderer> ModelsNumber;
    public List<int> ActualNumber;

    public List<Scrollbar> ScrollWheel;

    private int nbSuccess;
    private bool isLaunching;

    public void StartWheeling()
    {
        foreach (var modelSprite in ModelsNumber)
        {
            modelSprite.sprite = ModelForms[Random.Range(0, 9)];
        }

    }

    private void Update()
    {
        if (GameManager.instance.desactivSystem)
        {
            foreach (var scrollwheel in ScrollWheel)
            {
                scrollwheel.interactable = false;
            }
        }
        else
        {
            foreach (var scrollwheel in ScrollWheel)
            {
                scrollwheel.interactable = true;
            }
        }
        for (int i = 0; i < ScrollWheel.Count; i++)
        {
            int scrollValue = Mathf.Clamp(Mathf.RoundToInt(ScrollWheel[i].value * 9), 0, 9);
            ActualNumber[i] = scrollValue;
        }

        for (int i = 0; i < ScrollWheel.Count; i++)
        {
            if (ModelsNumber[i].sprite == PlayerForms[ActualNumber[i]])
            {
                nbSuccess++;
            }
        }

        if (nbSuccess == 1)
        {
            isLaunching = false;
            StartWheeling();
            interactable.ResetScreen();
        }

        nbSuccess = 0;
    }

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        StartWheeling();
    }
}
