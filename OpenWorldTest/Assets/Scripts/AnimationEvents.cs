using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public AI ai;

    public void Event_EnemyAttack()
    {
        ai.EnemyAttack();
    }
}
