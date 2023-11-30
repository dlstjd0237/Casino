using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/StoreItemSO")]
public class StoreItemSO : ScriptableObject
{
    [SerializeField] private string _itemName; public string ItemName => _itemName;
    [SerializeField] private int _price; public int Price => _price;
    [SerializeField] private int _amount; public int Amount => _amount;
    [SerializeField] private Sprite _image;public Sprite Image => _image;

    public void UseBtnEvent()
    {
        if (_price > 0)
        {
            --_amount;
        }
    }
    public void BuyBtnEvent()
    {
        if (_price <= CasinoGameManager.Instance.Coin)
        {
            CasinoGameManager.Instance.Coin -= _price;
            _amount++;
        }
    }
}
