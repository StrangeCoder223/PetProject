using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "Data/Characteristics")]
public class Characteristics : ScriptableObject
{
    [field: SerializeField]
    public float Speed { get; private set; }

    [field: SerializeField]
    public float AccelerationFactor { get; private set; }

    [field: SerializeField]
    public float MaxSpeed { get; private set; }

    [field: SerializeField]
    public float Health { get; set; }
}
