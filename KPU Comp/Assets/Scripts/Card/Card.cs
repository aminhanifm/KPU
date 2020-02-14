using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;


public class Card : MonoBehaviour, IPointerClickHandler
{
    public int id { get; set;}
    private GameObject hidden;
    private Image hiddenImage;
    private float initialY;
    Sequence sequence;

    [Inject]
    public MasukKotakManager masukKotakManager;

    [Inject]
    public void Construct(
        MasukKotakManager masukKotakManager)
    {
        Debug.Log("ASEKK");
        this.masukKotakManager = masukKotakManager;
    }

    private void Start()
    {

        hidden = gameObject.transform.Find("Hidden").gameObject;
        hiddenImage = hidden.GetComponent<Image>();
        sequence = DOTween.Sequence();
        initialY = transform.localPosition.y;
        reset();
    }

    public void ShowCard()
    {
        sequence.Append(hiddenImage.DOFade(0, 0.4f))
            .Join(hidden.transform.DOScale(1.2f, 0.4f));
        sequence.Play();
    }

    public void setImage(Sprite sprite)
    {
        gameObject.transform.Find("CardImage").GetComponent<Image>().sprite = sprite;
    }

    public void HideCard()
    {
        sequence.Append(hiddenImage.DOFade(1, 0.4f))
            .Join(hidden.transform.DOScale(1f, 0.4f));
        sequence.Play();
    }

    public void HideCardFromScene()
    {
        sequence.Append(this.GetComponent<CanvasGroup>().DOFade(0, 0.7f))
            .Join(this.transform.DOLocalMoveY( initialY - 200f, 0.7f));
        sequence.Play();
    }

    public void ShowCardToScene()
    {
        sequence.Append(this.GetComponent<CanvasGroup>().DOFade(1, 0.7f))
            .Join(this.transform.DOLocalMoveY(initialY, 0.6f));
        sequence.Play();
    }

    public void reset()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.transform.localPosition += new Vector3(0, initialY - 200f, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("saya menekan tombol " + id);

        CardEventHandler.current.SelectCard(id);
        //masukKotakManager.CompareSelectedCard(id);
    }

    public class Factory : PlaceholderFactory<Card> 
    { 
    }
}
