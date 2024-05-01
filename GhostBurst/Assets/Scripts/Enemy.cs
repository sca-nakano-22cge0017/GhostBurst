using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;
    public int lateHp = 100;

    virtual protected void Start()
    {
        lateHp = hp;
    }

    virtual protected void Update()
    {
        if(lateHp != hp)
        {
            Debug.Log("Damage! " + hp);
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
        Destroy(this.gameObject);
    }
}
