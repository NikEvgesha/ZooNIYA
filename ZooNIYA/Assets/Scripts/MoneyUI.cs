using TMPro;
using UnityEngine;


public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _moneyText;
    void Start()
    {
        _moneyText.text = MoneyManager.GetMoneyAmount().ToString();
    }

    private void OnEnable()
    {
        MoneyManager.moneyUpdate += updateMoneyUI;
    }

    private void OnDisable()
    {
        MoneyManager.moneyUpdate -= updateMoneyUI;
    }

    public void updateMoneyUI(int moneyAmount)
    {
        string text = moneyAmount.ToString();
        _moneyText.text = text;
    }
}
