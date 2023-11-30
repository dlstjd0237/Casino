using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    Animator _animator;
    private static readonly int IsRun = Animator.StringToHash("isRun");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(IsRun, false);
    }

    private void Start()
    {
        StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        yield return new WaitForSeconds(3f);
        _animator.SetBool(IsRun, true);
        Debug.Log(Difficulty.Instance.DifficultyType);
        switch (Difficulty.Instance.DifficultyType)
        {
            case DifficultyType.Easy:
                _speed = 0.4f;
                break;
            case DifficultyType.Normal:
                _speed = .5f;
                break;
            case DifficultyType.Hard:
                _speed = .7f;
                break;
            
        }

        while (true)
        {
            transform.Translate(Vector3.right * (_speed * Time.deltaTime));
            yield return null;
        }
    }
}
