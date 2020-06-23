using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopController : MonoBehaviour 
{
    public static ShopController instance;

    public GameObject shopItemPrefab;

    List<ShopItemController> shopItems = new List<ShopItemController>();

    public GameObject shopItemContainer;

    public int shopOptions = 3;

    public void Awake() {
        instance = this;
    }

    public void Start()
    {
        RefreshShop();
    }

    Weapon GetRandomWeapon() {
        List<Weapon> tierWeapons = new List<Weapon>();
        int rarityNum = Random.Range(0, 15);
        Rarity chosenRarity;
        if (rarityNum == 0)
        {
            chosenRarity = Rarity.LEGENDARY;
        }
        else if (rarityNum <= 2)
        {
            chosenRarity = Rarity.RARE;
        }
        else if (rarityNum <= 6)
        {
            chosenRarity = Rarity.RARE;
        }
        else
        {
            chosenRarity = Rarity.COMMON;
        }
        HashSet<int> validPowers = new HashSet<int>();
        validPowers.Add(1);

        foreach(Weapon weapon in GameData.instance.weapons)
        {
            if (validPowers.Contains(weapon.power) && weapon.rarity == chosenRarity)
            {
                tierWeapons.Add(weapon);
            }
        }
        
        Debug.Log("Length: " + tierWeapons.Count);
        int tierIndex = Random.Range(0, tierWeapons.Count);
        Debug.Log(tierIndex);
        return tierWeapons[tierIndex];
    }

    public void RefreshShop()
    {
        foreach(ShopItemController shopItem in shopItems)
        {
            GameObject.Destroy(shopItem.gameObject);
        }
        shopItems.Clear();

        for (int i = 0 ;i < shopOptions; i++)
        {
            Weapon newWeapon = GetRandomWeapon();

            GameObject newShopItem = GameObject.Instantiate(shopItemPrefab, shopItemContainer.transform);
            ShopItemController shopItemController = newShopItem.GetComponent<ShopItemController>();
            shopItemController.weapon = newWeapon;
            shopItems.Add(shopItemController);
        }
    }
}
