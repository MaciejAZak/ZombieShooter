using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackingEvent : MonoBehaviour
{
    public void MakeAttack()
    {
        Debug.Log("Attack");
        transform.parent.GetComponent<EnemyAttack>().AttackHitEvent();
    }
}
