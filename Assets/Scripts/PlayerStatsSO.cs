using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stats", menuName = "stat")]
public class PlayerStatsSO : ScriptableObject
{
    public float movementSpeed;
    public float attackDamage;
    public float health;
}
