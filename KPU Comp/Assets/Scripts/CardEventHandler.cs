using UnityEngine;

public class CardEventHandler : MonoBehaviour
{
    public delegate void Action();
    public static CardEventHandler current;

    public event Action onIncorrectAnswer;
    public event Action oncorrectAnswer;

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
}
