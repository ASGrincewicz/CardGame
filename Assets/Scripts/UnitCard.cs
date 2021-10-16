using UnityEngine;
/// <summary>
/// Add this only after adding the CardBase to your card object.
/// Use this for: Boss, Creature, and Enemy types.
/// </summary>
[System.Serializable]
public partial struct UnitCard
{
    [Range(0, 50)]
    public int attackPower;
    [Range(0, 100)]
    public int hitPoints;
    public UnitCardType unitCardType;

    public UnitCard(int attackPower, int hitPoints, UnitCardType type)
    {
        this.attackPower = attackPower;
        this.hitPoints = hitPoints;
        this.unitCardType = type;
    }
}
