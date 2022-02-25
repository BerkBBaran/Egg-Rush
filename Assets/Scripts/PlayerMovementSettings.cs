using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MovementSettings", menuName = "Player/New Movement Settings")]
public class PlayerMovementSettings : ScriptableObject
{
    [SerializeField] private float _movementSpeed = 0.15f;
    public float MovementSpeed => _movementSpeed;

}
