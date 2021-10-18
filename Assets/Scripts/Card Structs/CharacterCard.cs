using UnityEngine;
/// <summary>
/// Add this only after adding the CardBase to your card object.
/// Use this only for Character types.
/// </summary>
[System.Serializable]
public struct CharacterCard
{
    [Range(0, 50)]
    public int attackPower;
    [Range(0, 99)]
    public int hitPoints;
    [Range(0, 5)]
    public int upgradeSlots;

    public CharacterCard(int attackPower, int hitPoints, int upgradeSlots)
    {
        this.attackPower = attackPower;
        this.hitPoints = hitPoints;
        this.upgradeSlots = upgradeSlots;
    }
}
