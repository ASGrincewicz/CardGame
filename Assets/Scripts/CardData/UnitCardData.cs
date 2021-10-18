using UnityEngine;

[CreateAssetMenu(menuName = "Card/Unit", fileName = "newUnitCard.asset")]
public class UnitCardData : CardData
{
    [SerializeField] private UnitCard _unitCard = new UnitCard();
    public UnitCard Unit_card { get => _unitCard; set => _unitCard = value; }

}
