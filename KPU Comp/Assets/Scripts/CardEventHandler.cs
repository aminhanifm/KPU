using UnityEngine;

public class CardEventHandler : MonoBehaviour
{
    public delegate void Action();
    public delegate void CardSelectedAction(int id);
    public static CardEventHandler current;

    public event Action onIncorrectAnswer;
    public event Action oncorrectAnswer;

    public event CardSelectedAction onSelectCard;
    public event Action onDoneSelectCard;

    public event CardSelectedAction onDoneSelectCalon;

    private void Awake()
    {
        current = this;
    }

    public void IncorrectAnswer()
    {
        onIncorrectAnswer?.Invoke();
    }

    public void correctAnswer()
    {
        oncorrectAnswer?.Invoke();
    }

    public void SelectCard(int id)
    {
        onSelectCard?.Invoke(id);

        //onSelectCard?.Invoke(int id);
    }

    public void DoneSelectCard()
    {
        onDoneSelectCard?.Invoke();
    }

    public void DoneSelectCalon(int idCalon)
    {
        onDoneSelectCalon?.Invoke(idCalon);
    }
}
