using UnityEngine;
using System;

[Serializable]
public class WeaponColorColorDictionary : SerializableDictionary<WeaponColor, Color> {}

[Serializable]
public class WeaponTypeSpriteDictionary : SerializableDictionary<WeaponType, Sprite> {}

[Serializable]
public class RaritySpriteDictionary : SerializableDictionary<Rarity, Sprite> {}

public class AssetManager : MonoBehaviour {

    static AssetManager instance;

    void Awake()
    {
        instance = this;
    }

    public static Color GetWeaponColor(WeaponColor color)
    {
        return instance.colorDict[color];
    }

    public static Sprite GetWeaponSprite(WeaponType type)
    {
        return instance.typeSpriteDict[type];
    }

    public static Sprite GetRaritySprite(Rarity rarity)
    {
        return instance.raritySpriteDict[rarity];
    }

    public WeaponColorColorDictionary colorDict;
    
    public WeaponTypeSpriteDictionary typeSpriteDict;
    
    public RaritySpriteDictionary raritySpriteDict;
}