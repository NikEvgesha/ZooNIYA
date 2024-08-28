using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class ScreenContainer : MonoBehaviour
{
    public Action NewScreenAdd;

    private List<Screen> _screens;
    [SerializeField] private Screen _screenPrefab;
    void Start()
    {
        _screens = new List<Screen>();
        foreach (Screen screen in transform.GetComponentsInChildren<Screen>())
        {
            _screens.Add(screen);
        }
    }

    private void OnEnable()
    {
        EventManager.CagePurchased += addNewScreen;
    }

    public List<Transform> GetScreenList()
    {
       List<Transform> screenPoints = new List<Transform>();
        foreach (Screen screen in _screens)
        {
            screenPoints.Add(screen.transform);
        }
        return screenPoints;
    }

    private void addNewScreen()
    {
        Screen newScreen = Instantiate(_screenPrefab, transform.position, transform.rotation);
        if (newScreen == null) Debug.Log("Screen wasn't instantiated!");
        newScreen.transform.SetParent(this.transform);
        _screens.Add(newScreen);
        newScreen.GetComponentInChildren<Cage>().SetPrice(_screens.Count-1);
        NewScreenAdd?.Invoke();
    }


}
