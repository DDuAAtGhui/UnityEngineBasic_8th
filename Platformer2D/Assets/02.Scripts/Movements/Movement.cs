using System;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public bool isMovable;
    public bool isDirectionChangeable;

    public const int DIRECTION_RIGHT = 1;
    public const int DIRECTION_LEFT = -1;
    public int direction
    {
        get => _direction;
        set
        {
            if (isDirectionChangeable == false)
                return;

            if (_direction == value)
                return;

            if (value < 0)
            {
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                _direction = DIRECTION_LEFT;
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
                _direction = DIRECTION_RIGHT;
            }
            onDirectionChanged?.Invoke(_direction);
        }
    }

    private int _direction;
    public event Action<int> onDirectionChanged;

    public float horizontal
    {
        get => _horizontal;
        set
        {
            if (isMovable == false)
                return;

            if (_horizontal == value)
                return;

            _horizontal = value;
            //onHorizontalChanged(value); // ����ȣ�� - ��ϵ� �Լ��� ȣ���Ҷ����� ���ڸ� ��������
            //onHorizontalChanged.Invoke(value); // ����ȣ�� - Invoke�� �Ű������� ���� ���� ��.. ��ϵ��Լ����� Invoke �� �Ű������� ������
            onHorizontalChanged?.Invoke(value); // null üũ ������ - null �̸� (��ϵ��Լ� ������) ȣ�� x 
        }
    }
    [SerializeField] private float _horizontal;
    public event Action<float> onHorizontalChanged;
    private Rigidbody2D _rigidbody;
    private Vector2 _move;
    [SerializeField] private float _speed = 1.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (isMovable)
        {
            _move = new Vector2(horizontal, 0.0f);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.position += _move * _speed * Time.fixedDeltaTime;
    }
}
