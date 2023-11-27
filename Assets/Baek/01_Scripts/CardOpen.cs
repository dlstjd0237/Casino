using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CardOpen : MonoBehaviour
{
    public Card CardInFo;
    private void Awake()
    {
        Invoke(nameof(OpenCard),2);
    }

    public void OpenCard()
    {
        transform.DORotate(new Vector3(0, 180, 0), 2);
    }
}
