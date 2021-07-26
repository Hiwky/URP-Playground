[System.Serializable]
public struct SimpleChoice
{
    public int index;
    public string choiceText;

    public SimpleChoice(int index, string text) : this()
    {
        this.index = index;
        choiceText = text;
    }
}
