using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤー制御
/// </summary>
public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    Rigidbody rb;

    // 接地判定用
    bool isGround = false;

    [SerializeField] Gun gun;

    private void OnEnable()
    {
        // InputActionの有効化
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    private void Start()
    {
        if(GetComponent<Rigidbody>() is var r) rb = r;
    }

    void Update()
    {
        Jump();
        Fire();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    void Move()
    {
        // 前後左右移動
        if (_playerInput.Move.Forward.IsPressed())
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (_playerInput.Move.Back.IsPressed())
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (_playerInput.Move.Left.IsPressed())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (_playerInput.Move.Right.IsPressed())
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    void Jump()
    {
        if (_playerInput.Move.Jump.triggered && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    /// <summary>
    /// 銃を撃つ
    /// </summary>
    void Fire()
    {
        if(_playerInput.Move.Fire.triggered)
        {
            gun.Fire();
        }

        if (_playerInput.Move.Reroad.triggered)
        {
            gun.Reroad();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
