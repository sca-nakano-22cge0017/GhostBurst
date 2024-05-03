using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int atk = 100;
    public int hp = 100;
    [HideInInspector] public int lateHp = 100;
    [HideInInspector] public GameManager gameManager;

    virtual protected void Start()
    {
        lateHp = hp;
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    virtual protected void Update()
    {
        if(lateHp != hp)
        {
            lateHp = hp;
        }

        if(hp <= 0) Down();
    }

    public virtual void Damage(int damage)
    {
        hp -= damage;
    }

    public virtual void Down()
    {
        gameManager.KillScore++;
        gameManager.KillScore_ForFever++;

        Destroy(this.gameObject);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Damage(atk);
        }
    }
}
