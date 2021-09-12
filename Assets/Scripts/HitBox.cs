using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public enum HitType
{
    Head,
    Body,
    Hand,
    Leg
}
public class HitBox : MonoBehaviour
{
    [SerializeField]
    private Unit unit;

    [field:SerializeField]
    public HitType HitType { get; private set; }

    public void ApplyHit(float damage)
    {
        unit.TakeDamage(damage);
    }
}
