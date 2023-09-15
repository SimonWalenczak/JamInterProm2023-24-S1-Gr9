// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
//
// public class ScrollWheelManager : MonoBehaviour
// {
//     public Interactable interactable;
//     public TextMeshPro displayText;
//     public List<int> ActualNumber;
//     public List<Scrollbar> ScrollWheel;
//     public Image imageToUpdate;
//     public Sprite[] sprites;
//     public GameObject ButtonScreenRotating;
//
//     private int targetValue;
//     private int nbSuccess;
//     private bool isLaunching;
//
//     private void Update()
//     {
//         if (GameManager.instance.desactivSystem)
//         {
//             foreach (var scrollwheel in ScrollWheel)
//             {
//                 scrollwheel.interactable = false;
//             }
//         }
//         else
//         {
//             foreach (var scrollwheel in ScrollWheel)
//             {
//                 scrollwheel.interactable = true;
//             }
//         }
//
//         nbSuccess = 0;
//
//         for (int i = 0; i < ScrollWheel.Count; i++)
//         {
//             int scrollValue = Mathf.Clamp(Mathf.RoundToInt(ScrollWheel[i].value * 9), 0, 9);
//             displayText.text = " : " + scrollValue;
//             ActualNumber[i] = scrollValue;
//
//             if (scrollValue < sprites.Length)
//             {
//                 imageToUpdate.sprite = sprites[scrollValue];
//                 ButtonScreenRotating.transform.Rotate(new Vector3(0f, 0f, 10));
//             }
//
//             if (scrollValue == targetValue)
//             {
//                 nbSuccess++;
//             }
//         }
//
//         if (nbSuccess == ScrollWheel.Count)
//         {
//             isLaunching = false;
//             StartWheeling();
//             interactable.ResetScreen();
//         }
//     }
//
//     public void StartWheeling()
//     {
//         targetValue = Random.Range(0, 10);
//     }
//
//     private void Start()
//     {
//         interactable = GetComponent<Interactable>();
//         StartWheeling();
//     }
// }
