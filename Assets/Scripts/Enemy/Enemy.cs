using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator enemyAnimator;
    public int hp = 2;
    private int basehp = 2;

    public void EnemyHpFunction()
    {
        
        if (hp != basehp)
        {
            enemyAnimator.SetBool("IsHit", true);
            basehp = hp;
        }

        if (hp <= 0)
        {
            enemyAnimator.SetBool("IsDead", true);
        }
    }
}
