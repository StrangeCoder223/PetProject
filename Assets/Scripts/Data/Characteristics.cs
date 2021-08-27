using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics : ScriptableObject
{
    [field: SerializeField]
    public float Speed { get; private set; }

    [field: SerializeField]
    public float Health { get; set; }
}
