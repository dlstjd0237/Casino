using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/CardListSO")]
public class CardListSO : ScriptableObject
{
    public List<GameObject> CardList;
}
