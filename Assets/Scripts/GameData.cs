using UnityEngine;
using System.Collections.Generic;

public class GameData : MonoBehaviour {

    public static GameData instance;

    public List<Weapon> weapons;

    public void Awake() {
        instance = this;
    }

    public void Start()
    {
        weapons = new List<Weapon>();

        foreach(WeaponType type in (WeaponType[]) WeaponType.GetValues(typeof(WeaponType)))
        {
            foreach(WeaponColor color in (WeaponColor[]) WeaponColor.GetValues(typeof(WeaponColor)))
            {
                Weapon newWeapon = new Weapon();
                newWeapon.color = color;
                newWeapon.type = type;
                newWeapon.tier = 1;
                newWeapon.power = 1;
                newWeapon.rarity = (Rarity)Random.Range(0, 4);
                weapons.Add(newWeapon);
            }
        }
    }
}

public enum WeaponColor {
    RED,
    ORANGE,
    YELLOW,
    GREEN,
    TEAL,
    MAGENTA
}

public enum WeaponType {
    MISSILES,
    LASER,
    FIGHTER,
    PLASMA,
    CANNON,
    ENGINE
}

public enum Rarity {
    COMMON,
    UNCOMMON,
    RARE,
    LEGENDARY
}