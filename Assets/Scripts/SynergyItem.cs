using UnityEngine;

public class SynergyItem : MonoBehaviour {
    public Sprite image;

    bool isType;

    WeaponType type;
    WeaponColor color;
    int power = 1;

    public void SetWeaponType(WeaponType newType, int newPower)
    {
        isType = true;
        type = newType;
        power = newPower;

        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        
    }
}