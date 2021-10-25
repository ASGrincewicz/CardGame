using UnityEngine;

[CreateAssetMenu(menuName = "Card/Action", fileName = "newActionCard.asset")]
public class ActionCardData : CardData
{
    [SerializeField] private ActionCard _actionCard = new ActionCard();
    public ActionCard Action_card { get => _actionCard; set => _actionCard = value; }
}