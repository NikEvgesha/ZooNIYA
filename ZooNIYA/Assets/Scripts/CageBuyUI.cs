using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CageBuyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priceText;
    void Start()
    {
        _priceText = transform.GetComponentInChildren<TextMeshProUGUI>();

    }

    public void SetPrice(int price)
    {
        _priceText.text = "$ " + price.ToString();
    }
}
