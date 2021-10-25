using UnityEngine;

[CreateAssetMenu(menuName = "Card/Character", fileName = "newCharacterCard.asset")]
public class CharacterCardData : CardData
{
    [SerializeField] private CharacterCard _characterCard = new CharacterCard();
    public CharacterCard Character_card { get => _characterCard; set => _characterCard = value; }

    protected override void OnValidate()
    {
        base.OnValidate();
        _cardBase.cardType = CardType.Character;
    }
}
