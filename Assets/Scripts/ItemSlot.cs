using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    Weapon _weapon;

    public Image weaponImage;
    public Image rarityIcon;
    public PowerBar powerBar;
    public GameObject weaponDisplay;
    public GameObject nextDisplay;
    public CanvasGroup slotGroup;

    bool isActive = false;
    bool isNext = false;

    public void Start()
    {
        UpdateDisplay();
    }

    public Weapon weapon {
        get {
            return _weapon;
        }
        set {
            _weapon = value;
            UpdateDisplay();
        }
    }

    void SetActive(bool active, bool isNext)
    {
        this.isActive = active;
        this.isNext = isNext;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        weaponDisplay.SetActive(weapon != null);
        slotGroup.alpha = isActive ? 1 : 0;
        nextDisplay.SetActive(isNext);

        powerBar.SetPower(weapon.power);
        weaponImage.sprite = AssetManager.GetWeaponSprite(_weapon.type);
        weaponImage.color = AssetManager.GetWeaponColor(_weapon.color);
        rarityIcon.sprite = AssetManager.GetRaritySprite(_weapon.rarity);
    }
}