using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSlider : MonoBehaviour
{
    [SerializeField] private GameObject fruitPanel;
    private void OnMouseDown()
    {
        fruitPanel.SetActive(true);
    }
}
