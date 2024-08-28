using System;
using UnityEngine;

public class Cage : MonoBehaviour
{
    public enum CageState
    {
        Purchased,
        NotPurchased
    }

    //public Action CagePurchased;

    private const int _basePrice = 100;
    [SerializeField] private CageBuyUI _buyUI;
    [SerializeField] private CageCore _core;

    private CageState _state = CageState.NotPurchased;
    private int _price = 0;
    public Cage(int price) 
    {
        _price = price;
        _state = CageState.NotPurchased;
    }

    private void Awake()
    {
       if (_price == 0) { SetPrice(1); }
    }

    public int GetPrice()
    {
        return _price;
    }

    public void SetPrice(int cageCount)
    {
        _price = cageCount * _basePrice;
        _buyUI.SetPrice(_price);
    }

    public CageState GetState()
    {
        return _state;
    }

    public void onPurchase()
    {
        if (MoneyManager.RemoveMoney(_price))
        {
            _buyUI.gameObject.SetActive(false);
            _core.gameObject.SetActive(true);
            EventManager.CagePurchased?.Invoke();
        } else
        {
            // Что-то где-то подсветить
        }
        
    }

}
