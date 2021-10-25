using UnityEngine;

[System.Serializable]
public struct ActionCard
{
    [Range(0, 2)]
    public int actionCost;

    public ActionCard(int actionCost)
    {
        this.actionCost = actionCost;
    }
}