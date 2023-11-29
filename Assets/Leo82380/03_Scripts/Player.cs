using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private float timer;
    private Animator _animator;
    private static readonly int IsRun = Animator.StringToHash("isRun");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 3f) return;
        _animator.SetBool(IsRun, true);
        if (Input.GetMouseButtonDown(0))
        {
            transform.Translate(Vector3.right * (0.015f * _speed));
        }
    }
}
