// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class ScrollWheelManager : MonoBehaviour
// {
//     public Interactable interactable;
//
//     public List<Sprite> ModelForms;
//     public List<Sprite> PlayerForms;
//
//     public List<SpriteRenderer> ModelsSprites;
//     public List<SpriteRenderer> ActualSprites;
//
//     public List<ScrollWheel> ScrollWheel;
//     public void StartWheeling()
//     {
//         foreach (var modelSprite in ModelsSprites)
//         {
//             modelSprite.sprite = ModelForms[Random.Range(0, 9)];
//         }
//
//     }
//
//     private void Update()
//     {
//         for (int i = 0; i < ScrollWheel.Count; i++)
//         {
//             ActualSprites[i].sprite = PlayerForms[(int)ScrollWheel[i].value];
//         }
//     }
//
//     private void Start()
//     {
//         StartWheeling();
//     }
// }
