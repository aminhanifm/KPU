using UnityEngine;

public class MasukKotakManager: MonoBehaviour
{
    public int curr_box = -1;

    public void CompareSelectedCard(int card_idx)
    {
        if (card_idx == curr_box)
        {
            CardEventHandler.current.correctAnswer();
        }
        CardEventHandler.current.IncorrectAnswer();
    }
}
