using UnityEngine;
/// <summary>
/// All cards must start with this struct to define their stats.
/// </summary>
[System.Serializable]
public struct CardBase 
{
    [Range(0,3)]
    public int rarity;
    [Range(1,200)]
    public int cardNumber;
    public string cardName;
    [Multiline]
    public string cardText;
    public CardType cardType;
    public Sprite cardImage;

    

    public CardBase(int rarity, int cardNumber, string cardName, string cardText, CardType cardType, Sprite sprite)
    {
        this.rarity = rarity;
        this.cardNumber = cardNumber;
        this.cardName = cardName;
        this.cardText = cardText;
        this.cardType = cardType;
        this.cardImage = sprite;
    }
}
