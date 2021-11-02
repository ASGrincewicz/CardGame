using System.Collections.Generic;
[System.Serializable]
public struct Deck
{
    public string deckName;
    public List<CardData> deckList;

    public Deck(string deckName)
    {
        this.deckName = deckName;
        deckList = new List<CardData>();
    }
}