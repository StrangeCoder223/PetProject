using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Weapon CurrentWeapon { get; set; }

    private List<Weapon> _weapons = new List<Weapon>();

    private KeyBinder _binder;

    private Weapon _previousWeapon;

    private int _currentIndex;

    private void OnEnable()
    {
        _binder = KeyBinder.instance;
        _binder.ScrolledUp += NextWeapon;
        _binder.ScrolledDown += PreviousWeapon;
        _binder.Dropped += DropWeapon;
        _currentIndex = 0;
    }

    private void OnDisable()
    {
        _binder.ScrolledUp -= NextWeapon;
        _binder.ScrolledDown -= PreviousWeapon;
        _binder.Dropped -= DropWeapon;
    }

    public void AddWeapon(Weapon weapon)
    {
        
    }

    private void DropWeapon()
    {
        if (CurrentWeapon.GetType() != typeof(MeleeWeapon))
        {
            GameObject dropped = Instantiate(CurrentWeapon.DropPrefab, transform.position, Quaternion.identity);
            dropped.GetComponent<Rigidbody>().AddForce(transform.forward * 5f);
        }
    }

    private void ChangeWeapon(int index)
    {
        CurrentWeapon = _weapons[index];
        _previousWeapon.gameObject.SetActive(false);
        CurrentWeapon.gameObject.SetActive(true);
    }

    private void NextWeapon()
    {
        _previousWeapon = _weapons[_currentIndex];
        _currentIndex++;
        if (_currentIndex == _weapons.Count-1)
        {
            _currentIndex = 0;
        }
        ChangeWeapon(_currentIndex);
    }

    private void PreviousWeapon()
    {
        _previousWeapon = _weapons[_currentIndex];
        _currentIndex--;
        if (_currentIndex < 0)
        {
            _currentIndex = _weapons.Count-1;
        }
        ChangeWeapon(_currentIndex);
    }
}
