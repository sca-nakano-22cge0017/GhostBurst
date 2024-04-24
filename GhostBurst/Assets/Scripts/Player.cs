using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    Rigidbody rb;

    bool isForward = false, isBack = false, isLeft = false, isRight = false, isJump = false;

    // �ڒn����p
    Ray ray;
    float rayDis = 0.5f;
    RaycastHit hit;
    Vector3 rayPos;
    bool isGround = false;

    private void OnEnable()
    {
        // InputAction�̗L����
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    private void Start()
    {
        if(GetComponent<Rigidbody>() is var r) rb = r;
    }

    void Update()
    {
        LandCheck();
        MoveInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// ����
    /// </summary>
    private void MoveInput()
    {
        // �O�㍶�E�ړ�
        if (_playerInput.Move.Forward.IsPressed()) isForward = true;
        else isForward = false;

        if (_playerInput.Move.Back.IsPressed()) isBack = true;
        else isBack = false;

        if (_playerInput.Move.Left.IsPressed()) isLeft = true;
        else isLeft = false;

        if (_playerInput.Move.Right.IsPressed()) isRight = true;
        else isRight = false;

        // �W�����v
        if (_playerInput.Move.Jump.triggered && isGround) isJump = true;
        if (!_playerInput.Move.Jump.IsPressed()) isJump = false;
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    void Move()
    {
        float currentSpeed = speed - rb.velocity.magnitude;

        // �O�㍶�E�ړ�
        if (isForward) rb.AddForce(Vector3.forward * currentSpeed);

        if (isBack) rb.AddForce(Vector3.back * currentSpeed);

        if (isLeft) rb.AddForce(Vector3.left * currentSpeed);

        if (isRight) rb.AddForce(Vector3.right * currentSpeed);

        // �W�����v
        if (_playerInput.Move.Jump.triggered) rb.AddForce(Vector3.up * jumpForce);
    }

    void LandCheck()
    {
        rayPos = transform.position + new Vector3(0, 0.5f, 0);
        ray = new Ray(rayPos, transform.up * -1);
        Debug.DrawRay(ray.origin, ray.direction * rayDis, Color.red);

        if(Physics.Raycast(ray, out hit, rayDis))
        {
            if(hit.collider.tag == "Ground")
            {
                isGround = true;
            }

            else isGround = false;
        }
    }
}
