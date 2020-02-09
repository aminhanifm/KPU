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
    }

    public void ShowCard()
    {
        sequence.Append(hiddenImage.DOFade(0, 0.4f))
            .Join(hidden.transform.DOScale(1.2f, 0.4f));
        sequence.Play();
    }

    public void HideCard()
    {
        sequence.Append(hiddenImage.DOFade(1, 0.4f))
            .Join(hidden.transform.DOScale(1f, 0.4f));
        sequence.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("saya menekan tombol " + id);
        masukKotakManager.CompareSelectedCard(id);
        ShowCard();
    }

    public class Factory : PlaceholderFactory<Card> 
    { 
    }
}
