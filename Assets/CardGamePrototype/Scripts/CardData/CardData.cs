using UnityEngine;

public abstract class CardData : ScriptableObject
{
    [SerializeField] protected CardBase _cardBase = new CardBase();
    public CardBase Card_base { get => _cardBase; set => _cardBase = value; }

    protected virtual void OnValidate()
    {
        var modifiedCardName = _cardBase.cardName.Replace(" ", "_");
        name = $"{_cardBase.cardNumber}_{modifiedCardName}";
    }
}
