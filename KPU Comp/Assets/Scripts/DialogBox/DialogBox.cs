using UnityEngine;
using DG.Tweening;
using TMPro;

public class DialogBox : MonoBehaviour
{
    public GameObject dialogBox;
    private TMP_Text _text;
    private float Yintial;
    public float duration = 0.3f;

    void Start()
    {
        _text= dialogBox.GetComponentInChildren<TMP_Text>();

        Vector3 tmp = dialogBox.GetComponent<RectTransform>().anchoredPosition;
        Yintial = tmp.y;

        dialogBox.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }

    public void ShowDialog(string text)
    {
        _text.SetText(text);
        dialogBox.GetComponent<RectTransform>().DOAnchorPosY(Yintial, duration);
    }

    public void HideDialog()
    {
        dialogBox.GetComponent<RectTransform>().DOAnchorPosY(0, duration);
    }

}
