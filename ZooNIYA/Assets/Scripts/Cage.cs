using System;
using UnityEngine;
using static Enums;

public class Cage : MonoBehaviour
{

    //public Action CagePurchased;

    private const int _basePrice = 100;
    [SerializeField] private CageBuyUI _buyUI;
    [SerializeField] private CageCore _core;
    [SerializeField] private AnimalContainer _animalContainer;
    [SerializeField] private ImprovementContainer _improvementlContainer;

    private CageState _state = CageState.NotPurchased;
    private int _price = 0;
    private int _id;

/*    public Cage(int price, int id) 
    {
        _id = id;
        _price = id * _basePrice;
        _buyUI.SetPrice(_price);
        _price = price;
        _state = CageState.NotPurchased;
    }*/

    private void Awake()
    {
       if (_price == 0) { SetPrice(1); }
    }

    public int GetPrice()
    {
        return _price;
    }

    public int GetID()
    {
        return _id;
    }

    public void InitCage(int id)
    {
        _id = id;
        _price = id * _basePrice;
        _buyUI.SetPrice(_price);
    }


    private void SetPrice(int cageCount)
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

    public void onMarketButtonClick()
    {

    }

}
