using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
[CustomEditor(typeof(Enemy))]
#endif

public class NormalGhost : Enemy
{
    override protected void Start()
    {
        base.Start();
    }

    override protected void Update()
    {
        base.Update();
    }

    public override void Damage(int damage)
    {
        hp -= damage;
    }

    public override void Down()
    {
        base.Down();
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
