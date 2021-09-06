using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "Data/Characteristics")]
public class Characteristics : ScriptableObject
{
    [field: SerializeField]
    public float Speed { get; private set; }

    [field: SerializeField]
    public float Health { get; private set; }

    [field: SerializeField]
    public float JumpForce { get; private set; }

    [field: SerializeField]
    public float GroundDistance { get; private set; }

    [field: SerializeField]
    public float GravityForce { get; private set; }
}
