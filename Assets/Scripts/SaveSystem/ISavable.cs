using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISavable
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    public Vector3 Scale { get; set; }

    public void Initialize();
}
