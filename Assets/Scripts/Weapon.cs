public class Weapon {
    public WeaponColor color;
    public WeaponType type;
    public Rarity rarity;
    public string name {
        get {
            return color.ToString() + " " + type.ToString();
        }
    }
    public int power;
    public int tier;

    public int GetBasesWeaponPower()
    {
        int basePower = 30 + power * 10;
        float rarityMultiplier = 1;

        if (rarity == Rarity.COMMON)
        {
            rarityMultiplier = 1;
        }
        if (rarity == Rarity.UNCOMMON)
        {
            rarityMultiplier = 1.2f;
        }
        if (rarity == Rarity.RARE)
        {
            rarityMultiplier = 1.4f;
        }
        if (rarity == Rarity.LEGENDARY)
        {
            rarityMultiplier = 1.6f;
        }

        float tierPower = 1 + (tier - 1) * 0.5f;

        return (int)(basePower * rarityMultiplier * tierPower);
    }
}