using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _boostForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _startPosition = transform.position;

        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = Vector3.zero;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = new Vector3(_speed, _boostForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
    }
}
