using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventorySlot CurrentSlot
    {
        get => _currentSlot;
        set
        {
            _currentSlot = value;
            ChangeSlot(_currentSlot);
        }
    }

    [SerializeField]
    private List<Weapon> weaponsPool = new List<Weapon>();

    [SerializeField]
    private List<InventorySlot> inventory = new List<InventorySlot>();

    private InventorySlot _currentSlot;

    [SerializeField]
    private int _weaponSlotIndex = 0;
    

    private void OnEnable()
    {
        Initialize();        
    }

    private void Initialize()
    {

        foreach (var slot in inventory)
        {
            slot.Index = inventory.IndexOf(slot);
        }

        CurrentSlot = inventory.Find(slot => slot.SlotType == WeaponType.Melee);
        Debug.Log(_currentSlot);
    }

    public void AddWeapon(Weapon weapon)
    {
        if (weapon.WeaponType != WeaponType.Melee)
        {
            var slot = inventory.Find(slot => slot.SlotType == weapon.WeaponType);
            if (slot.IsEmpty)
            {
                slot.Item = weapon;
                CurrentSlot = slot;
            }
            
        }
        
        else
        {
            throw new Exception("Оружие не относится к дополнительному или основному типу!");
        }

    }

    public void DropWeapon()
    {
        if (CurrentSlot.SlotType != WeaponType.Melee)
        {
            GameObject dropped = Instantiate(CurrentSlot.Item.DropPrefab, transform.position, Quaternion.identity);
            dropped.GetComponent<Rigidbody>().AddForce(transform.forward * 5f);
        }
    }

    private void ChangeSlot(InventorySlot activeSlot)
    {
        foreach (var weapon in weaponsPool)
        {
            weapon.gameObject.SetActive(false);
        }

        var changedWeapon = weaponsPool.Find(weapon => weapon.Name == activeSlot.Item.Name);
        _weaponSlotIndex = activeSlot.Index;
        changedWeapon.gameObject.SetActive(true);
    }

    public void NextSlot()
    {
        _weaponSlotIndex++;
        for (; _weaponSlotIndex >= 0; _weaponSlotIndex++)
        {
            
            if (_weaponSlotIndex > 2)
            {
                _weaponSlotIndex = 0;
            }

            if (!inventory[_weaponSlotIndex].IsEmpty)
            {
                CurrentSlot = inventory[_weaponSlotIndex];
                break;
            }
        }
        
        
    }

    public void PreviousSlot()
    {
        _weaponSlotIndex--;
        for (; _weaponSlotIndex <= inventory.Count; _weaponSlotIndex--)
        {
            if (_weaponSlotIndex < 0)
            {
                _weaponSlotIndex = inventory.Count-1;
            }

            if (!inventory[_weaponSlotIndex].IsEmpty)
            {
                CurrentSlot = inventory[_weaponSlotIndex];
                break;
                
            }
        }
    }
}
