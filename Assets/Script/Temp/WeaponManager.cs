using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Arrow,
    Bullet,
    Missile,
    None
}

public class WeaponManager : MonoBehaviour
{
    // 접근점
    private IWeapon weapon;
    public GameObject Arrow;
    public GameObject Bullet;
    public GameObject Missile;
    private GameObject myWeapon;
    private WeaponType myWeaponType;


    // 무기 교환 가능하게...
    private void setWeaponType(WeaponType weaponType)
    {
        myWeaponType = weaponType;
        Component c = gameObject.GetComponent<IWeapon>() as Component;

        if (c != null)
        {
            Destroy(c);
        }

        switch (weaponType)
        {
            case WeaponType.Arrow:
                weapon = gameObject.AddComponent<Arrow>();
                myWeapon = Arrow;
                break;

            case WeaponType.Bullet:
                weapon = gameObject.AddComponent<Bullet>();
                myWeapon = Bullet;
                break;

            case WeaponType.Missile:
                weapon = gameObject.AddComponent<Missile>();
                myWeapon = Missile;
                break;

            default:
                weapon = gameObject.AddComponent<Bullet>();
                myWeapon = Bullet;
                break;
        }
    }

    public void ChangeBullet()
    {
        int num = (int)myWeaponType;
        num = (num + 1) % (int)WeaponType.None;
        setWeaponType((WeaponType)num);
    }


    private void Start()
    {
        setWeaponType(WeaponType.Bullet);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) { weapon.Shoot(myWeapon); }
        if (Input.GetMouseButtonDown(1)) { ChangeBullet(); }
    }
}
