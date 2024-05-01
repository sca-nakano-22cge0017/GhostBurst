using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�e����
/// </summary>
public class Bullets : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector3 forward;
    public Vector3 BulletsForward { set { forward = value; } }

    [SerializeField] int atk;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Damage(atk);
        }

        //! �I�u�W�F�N�g�v�[��
        Destroy(this.gameObject);
    }
}
