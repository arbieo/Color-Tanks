using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemController : MonoBehaviour
{
    public TMP_Text nameText;
    public Image weaponIcon;
    public Image rarityIcon;
    public TMP_Text rarityText;
    public PowerBar weaponPower;

    Weapon _weapon;

    public Weapon weapon {
        get {
            return _weapon;
        }
        set {
            _weapon = value;
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {   
        nameText.text = _weapon.name;
        weaponPower.SetPower(weapon.power);
        weaponIcon.sprite = AssetManager.GetWeaponSprite(_weapon.type);
        weaponIcon.color = AssetManager.GetWeaponColor(_weapon.color);
        rarityIcon.sprite = AssetManager.GetRaritySprite(_weapon.rarity);
        rarityText.text = _weapon.rarity.ToString();
    }

    public void BuyItem()
    {
        LoadoutController.instance.BuyWeapon(weapon);
        ShopController.instance.RefreshShop();
    }
}