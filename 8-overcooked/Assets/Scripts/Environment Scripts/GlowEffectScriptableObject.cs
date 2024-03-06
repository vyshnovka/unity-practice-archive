using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlowEffect", menuName = "ScriptableObjects/GlowEffect")]

public class GlowEffectScriptableObject : ScriptableObject
{
    [SerializeField]
    public Material glow;
}
