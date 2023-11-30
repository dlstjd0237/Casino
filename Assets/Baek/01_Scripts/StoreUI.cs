using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class StoreUI : MonoBehaviour
{
    [SerializeField] private VisualTreeAsset _item;
    [SerializeField] private List<StoreItemSO> _itemSOList;
    private UIDocument _doc;
    private VisualElement _root;
    private VisualElement _contain;
    private Dictionary<StoreItemSO, Label> _label = new();
    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _root = _doc.rootVisualElement;
        _contain = _root.Q<VisualElement>("unity-content-container");
        for (int i = 0; i < _itemSOList.Count; i++)
        {
            AddItem(_itemSOList[i],i);
        }
    }

    private void AddItem(StoreItemSO SO, int count)
    {
        var template = _item.Instantiate().Q<VisualElement>();

        template.Q<Button>("use-btn").clicked += SO.UseBtnEvent;
        template.Q<Button>("buy-btn").clicked += SO.BuyBtnEvent;
        _label.Add(SO,template.Q<Label>("price-label"));
        _contain.Add(template);
    }

}
