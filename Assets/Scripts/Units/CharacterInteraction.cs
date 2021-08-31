using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterInteraction : MonoBehaviour
{
    private Character _character;

    private void OnEnable()
    {
        _character = GetComponent<Character>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Weapon weapon))
        {
            _character.Inventory.AddWeapon(weapon);
        }
    }
}
