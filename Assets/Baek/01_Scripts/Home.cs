using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class Home : MonoBehaviour
{
    [SerializeField] private List<HomeCardSO> _homeCardSOList;
    [SerializeField] private VisualTreeAsset _gameBox;
    private UIDocument _doc;
    private VisualElement _root;
    private VisualElement _cardContain;
    private Button _leftBtn, _rightBtn;
    private float _cardCotainLeft = 1;
    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _root = _doc.rootVisualElement;
        _cardContain = _root.Q<VisualElement>("games-box");
        _cardContain.style.width = 768 * _homeCardSOList.Count;
        _root.Q<Button>("right-btn").RegisterCallback<ClickEvent>(RightBtnClick);
        _root.Q<Button>("left-btn").RegisterCallback<ClickEvent>(LeftBtnClick);
        _root.Q<Button>("start-btn").RegisterCallback<ClickEvent>(SceneLoad);
        for (int i = 0; i < _homeCardSOList.Count; i++)
        {
            AddCard(_homeCardSOList[i]);
        }
    }

    private void SceneLoad(ClickEvent evt)
    {
        SceneManager.LoadScene(_homeCardSOList[(int)_cardCotainLeft].SceneName);
    }

    private void RightBtnClick(ClickEvent evt)
    {
        if (_cardCotainLeft != _homeCardSOList.Count - 1)
        {
            ++_cardCotainLeft;
            _cardContain.style.left = _cardCotainLeft * -768;

        }


    }

    private void LeftBtnClick(ClickEvent evt)
    {
        if (_cardCotainLeft != 0)
        {
            --_cardCotainLeft;

            _cardContain.style.left = _cardCotainLeft * -768;
        }



    }

    private void AddCard(HomeCardSO homeCardSO)
    {

        var template = _gameBox.Instantiate().Q<VisualElement>();

        template.Q<Label>("info-label").text = homeCardSO.GameInfo;
        template.Q<Label>("gamename-Label").text = homeCardSO.GameName;
        template.Q<VisualElement>("gameimage-box").style.backgroundImage = homeCardSO.Image.texture;
        _cardContain.Add(template);

    }
}
