using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Weapon CurrentWeapon { get; set; }

    [SerializeField] private List<Weapon> weapons = new List<Weapon>();

    private Weapon _previousWeapon;

    private int _currentIndex;

    private void OnEnable()
    {
        _currentIndex = 0;
        UpdatePreviousWeapon();
        ChangeWeapon(weapons[_currentIndex]);
    }

    public void AddWeapon(Weapon weapon)
    {
        
    }

    public void DropWeapon()
    {
        if (CurrentWeapon.GetType() != typeof(MeleeWeapon))
        {
            GameObject dropped = Instantiate(CurrentWeapon.DropPrefab, transform.position, Quaternion.identity);
            dropped.GetComponent<Rigidbody>().AddForce(transform.forward * 5f);
        }
    }

    private void ChangeWeapon(Weapon newWeapon)
    {
        CurrentWeapon = newWeapon;
        _previousWeapon.gameObject.SetActive(false);
        CurrentWeapon.gameObject.SetActive(true);
    }

    public void NextWeapon()
    {
        UpdatePreviousWeapon();
        _currentIndex++;
        if (_currentIndex == weapons.Count-1)
        {
            _currentIndex = 0;
        }
        ChangeWeapon(weapons[_currentIndex]);
    }

    public void PreviousWeapon()
    {
        UpdatePreviousWeapon();
        _currentIndex--;
        if (_currentIndex < 0)
        {
            _currentIndex = weapons.Count-1;
        }
        ChangeWeapon(weapons[_currentIndex]);
    }

    private void UpdatePreviousWeapon()
    {
        _previousWeapon = weapons[_currentIndex];
    }
}
