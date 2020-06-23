using UnityEngine;
using System.Collections.Generic;

public class LoadoutController : MonoBehaviour
{
    public List<ItemSlot> inventorySlots;
    public List<ItemSlot> equipmentSlots;

    public static LoadoutController instance;

    public int inventorySlotsOpen = 4;
    public int inventorySlotsMax = 18;

    public int equipmentSlotsOpen = 1;
    public int equipmentSlotsMax = 7;

    public void Awake()
    {
        instance = this;
    }

    public bool HasOpenSlot()
    {
        for (int i = 0; i<equipmentSlotsOpen; i++)
        {
            if (equipmentSlots[i].weapon == null)
            {
                return true;
            }
        }

        for (int i = 0; i<inventorySlotsOpen; i++)
        {
            if (inventorySlots[i].weapon == null)
            {
                return false;
            }
        }

        return false;
    }

    public bool HasCombination(Weapon newWeapon)
    {
        int combinationCount = 0;
        
        for (int i = 0; i<equipmentSlotsOpen; i++)
        {
            Weapon slotWeapon = equipmentSlots[i].weapon;
            if (newWeapon.type == slotWeapon.type && newWeapon.color == slotWeapon.color && newWeapon.tier == slotWeapon.tier)
            {
                combinationCount ++;
            }
        }

        for (int i = 0; i<inventorySlotsOpen; i++)
        {
            Weapon slotWeapon = inventorySlots[i].weapon;
            if (newWeapon.type == slotWeapon.type && newWeapon.color == slotWeapon.color && newWeapon.tier == slotWeapon.tier)
            {
                combinationCount ++;
            }
        }

        return combinationCount >= 2;
    }

    public void BuyWeapon(Weapon newWeapon) {
        while (HasCombination(newWeapon))
        {
            //remove other 2 weapons
            newWeapon.tier++;
        }

        for (int i = 0; i<equipmentSlotsOpen; i++)
        {
            if (equipmentSlots[i].weapon == null)
            {
                equipmentSlots[i].weapon = newWeapon;
                UpdateDisplay();
            }
        }

        for (int i = 0; i<inventorySlotsOpen; i++)
        {
            if (inventorySlots[i].weapon == null)
            {
                inventorySlots[i].weapon = newWeapon;
                UpdateDisplay();
            }
        }
    }

    public void UpdateDisplay()
    {

    }
}