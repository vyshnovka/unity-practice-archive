using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnvironmentMovementScriptableObject", menuName = "ScriptableObjects/EnvironmentMovementScriptableObject")]

public class EnvironmentMovementScriptable : ScriptableObject
{
    [SerializeField]
    public float movementSpeed = 1f;
}