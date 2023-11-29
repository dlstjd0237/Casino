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
        switch (Difficulty.Instance.DifficultyType)
        {
            case DifficultyType.Easy:
                _speed = 0.5f;
                break;
            case DifficultyType.Normal:
                _speed = 1f;
                break;
            case DifficultyType.Hard:
                _speed = 1.5f;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        while (true)
        {
            transform.Translate(Vector3.right * (_speed * Time.deltaTime));
            yield return null;
        }
    }
}