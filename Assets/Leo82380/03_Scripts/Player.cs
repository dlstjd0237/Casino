using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 3f) return;
        if (Input.GetMouseButtonDown(0))
        {
            transform.Translate(Vector3.right * (0.01f * _speed));
        }
    }
}
