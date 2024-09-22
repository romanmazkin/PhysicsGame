using UnityEngine;

public class Mover : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    [SerializeField] private float _moveForce;
    [SerializeField] private float _jumpForce;

    private float _nullForce = 0;
    private float _resultJumpForce;
    private float _resultMoveForce;

    private Rigidbody _rigidBody;

    private float _deadZone = 0.05f;
    private float _xInput;
    private float _yInput;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw(HorizontalAxis);
        _yInput = Input.GetAxisRaw(VerticalAxis);

        Jump();
    }

    private void FixedUpdate()
    {
        Move(_xInput, Vector3.forward);

        Move(_yInput, Vector3.left);
    }

    private void OnCollisionExit(Collision collision)
    {
        SetForces(_nullForce);
    }

    private void OnCollisionStay(Collision collision)
    {
        SetForces(_jumpForce, _moveForce);
    }

    private void Move(float inputValue, Vector3 direction)
    {
        if (Mathf.Abs(inputValue) > _deadZone)
        {
            _rigidBody.AddForce(direction * _resultMoveForce * inputValue, ForceMode.Force);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector3.up * _resultJumpForce, ForceMode.Impulse);
        }
    }

    private void SetForces(float nullForce)
    {
        _resultJumpForce = nullForce;
        _resultMoveForce = nullForce;
    }

    private void SetForces(float jumpForce, float moveForce)
    {
        _resultJumpForce = jumpForce;
        _resultMoveForce = moveForce;
    }
}
