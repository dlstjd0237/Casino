using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
public class StoreUI : MonoBehaviour
{
    [SerializeField] private List<StoreItemSO> _itemSOList;
    [SerializeField] private UnityEvent _buyEvent;
    private UIDocument _doc;
    private VisualElement _root;
    private VisualElement _contain;

    private VisualElement _iteml1;
    private VisualElement _iteml2;
    private VisualElement _iteml3;
    private VisualElement _iteml4;
    private VisualElement _iteml5;
    private VisualElement _iteml6;


    private Label _amount1;
    private Label _amount2;
    private Label _amount3;
    private Label _amount4;
    private Label _amount5;
    private Label _amount6;

    private Button _useBtn1;
    private Button _useBtn2;
    private Button _useBtn3;
    private Button _useBtn4;
    private Button _useBtn5;
    private Button _useBtn6;

    private Button _buyBtn1;
    private Button _buyBtn2;
    private Button _buyBtn3;
    private Button _buyBtn4;
    private Button _buyBtn5;
    private Button _buyBtn6;


    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _root = _doc.rootVisualElement;
        _contain = _root.Q<VisualElement>("unity-content-container");


        _iteml1 = _root.Q<VisualElement>("1");
        _iteml2 = _root.Q<VisualElement>("2");
        _iteml3 = _root.Q<VisualElement>("3");
        _iteml4 = _root.Q<VisualElement>("4");
        _iteml5 = _root.Q<VisualElement>("5");
        _iteml6 = _root.Q<VisualElement>("6");

        _amount1 = _iteml1.Q<Label>("amount");
        _amount2 = _iteml2.Q<Label>("amount");
        _amount3 = _iteml3.Q<Label>("amount");
        _amount4 = _iteml4.Q<Label>("amount");
        _amount5 = _iteml5.Q<Label>("amount");
        _amount6 = _iteml6.Q<Label>("amount");

        _useBtn1 = _iteml1.Q<Button>("use-btn");
        _useBtn2 = _iteml2.Q<Button>("use-btn");
        _useBtn3 = _iteml3.Q<Button>("use-btn");
        _useBtn4 = _iteml4.Q<Button>("use-btn");
        _useBtn5 = _iteml5.Q<Button>("use-btn");
        _useBtn6 = _iteml6.Q<Button>("use-btn");

        _useBtn1.clicked += Use1;
        _useBtn2.clicked += Use2;
        _useBtn3.clicked += Use3;
        _useBtn4.clicked += Use4;
        _useBtn5.clicked += Use5;
        _useBtn6.clicked += Use6;

        _buyBtn1 = _iteml1.Q<Button>("buy-btn");
        _buyBtn2 = _iteml2.Q<Button>("buy-btn");
        _buyBtn3 = _iteml3.Q<Button>("buy-btn");
        _buyBtn4 = _iteml4.Q<Button>("buy-btn");
        _buyBtn5 = _iteml5.Q<Button>("buy-btn");
        _buyBtn6 = _iteml6.Q<Button>("buy-btn");

        _buyBtn1.clicked += buy1;
        _buyBtn2.clicked += buy2;
        _buyBtn3.clicked += buy3;
        _buyBtn4.clicked += buy4;
        _buyBtn5.clicked += buy5;
        _buyBtn6.clicked += buy6;

    }

    private void buy6()
    {

        if (CasinoGameManager.Instance.Coin >= 200)
        {
            CasinoGameManager.Instance.Coin -= 200;
            CasinoGameManager.Instance._coinData.Amount6++;
            _amount6.text = CasinoGameManager.Instance._coinData.Amount6.ToString();
        }
        _buyEvent?.Invoke();
    }

    private void buy5()
    {
        if (CasinoGameManager.Instance.Coin >= 300)
        {
            CasinoGameManager.Instance.Coin -= 300;
            CasinoGameManager.Instance._coinData.Amount5++;
            _amount5.text = CasinoGameManager.Instance._coinData.Amount5.ToString();
        }
        _buyEvent?.Invoke();
    }

    private void buy4()
    {
        if (CasinoGameManager.Instance.Coin >= 500)
        {
            CasinoGameManager.Instance.Coin -= 500;
            CasinoGameManager.Instance._coinData.Amount4++;
            _amount4.text = CasinoGameManager.Instance._coinData.Amount4.ToString();
        }
        _buyEvent?.Invoke();
    }

    private void buy3()
    {
        if (CasinoGameManager.Instance.Coin >= 800)
        {
            CasinoGameManager.Instance.Coin -= 800;
            CasinoGameManager.Instance._coinData.Amount3++;
            _amount3.text = CasinoGameManager.Instance._coinData.Amount3.ToString();
        }
        _buyEvent?.Invoke();
    }

    private void buy2()
    {
        if (CasinoGameManager.Instance.Coin >= 600)
        {
            CasinoGameManager.Instance.Coin -= 600;
            CasinoGameManager.Instance._coinData.Amount2++;
            _amount2.text = CasinoGameManager.Instance._coinData.Amount2.ToString();
        }
        _buyEvent?.Invoke();
    }

    private void buy1()
    {
        if (CasinoGameManager.Instance.Coin >= 800)
        {
            CasinoGameManager.Instance.Coin -= 800;
            CasinoGameManager.Instance._coinData.Amount1++;
            _amount1.text = CasinoGameManager.Instance._coinData.Amount1.ToString();
        }
        _buyEvent?.Invoke();
    }

    private void Use6()
    {
        if (CasinoGameManager.Instance._coinData.Amount6 >= 1)
        {
            CasinoGameManager.Instance._coinData.Amount6 -= 1;
            _amount6.text = CasinoGameManager.Instance._coinData.Amount6.ToString();
        }
    }

    private void Use5()
    {
        if (CasinoGameManager.Instance._coinData.Amount6 >= 1)
        {
            CasinoGameManager.Instance._coinData.Amount6 -= 1;
            _amount5.text = CasinoGameManager.Instance._coinData.Amount5.ToString();
        }
    }

    private void Use4()
    {
        if (CasinoGameManager.Instance._coinData.Amount6 >= 1)
        {
            CasinoGameManager.Instance._coinData.Amount6 -= 1;
            _amount4.text = CasinoGameManager.Instance._coinData.Amount4.ToString();
        }
    }

    private void Use3()
    {
        if (CasinoGameManager.Instance._coinData.Amount6 >= 1)
        {
            CasinoGameManager.Instance._coinData.Amount6 -= 1;
            _amount3.text = CasinoGameManager.Instance._coinData.Amount3.ToString();
        }
    }

    private void Use2()
    {
        if (CasinoGameManager.Instance._coinData.Amount6 >= 1)
        {
            CasinoGameManager.Instance._coinData.Amount6 -= 1;
            _amount2.text = CasinoGameManager.Instance._coinData.Amount2.ToString();
        }
    }

    private void Use1()
    {
        if (CasinoGameManager.Instance._coinData.Amount6 >= 1)
        {
            CasinoGameManager.Instance._coinData.Amount6 -= 1;
            _amount1.text = CasinoGameManager.Instance._coinData.Amount1.ToString();
        }
    }




}
