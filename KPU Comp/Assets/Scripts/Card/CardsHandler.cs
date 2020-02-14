using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;
using System;

public class CardsHandler : MonoBehaviour
{
    [SerializeField] private float spacing = 50f;

    public Card.Factory cardFactory;

    public List<Sprite> images;

    [Inject]
    public void Construct(
        Card.Factory _cardFactory
        )
    {
        cardFactory = _cardFactory;
    }


    private float cardWidth;
    private List<GameObject> cards = new List<GameObject>();

    public int CardLeft => cards.Count;

    private Sequence currSequence;

    [Range (1f, 10f)]
    [SerializeField] private float timefactor = 2f;

    private void Awake()
    {
        CreateAllCards(5);
        RePositioningCards();
    }

    public void DestroyCardAt(int i)
    {
        foreach(var _card_ in cards)
        {
            if(_card_.GetComponent<Card>().id == i)
            {
                Destroy(_card_.gameObject);
                int at = cards.IndexOf(_card_);

                cards.RemoveAt(at);
                RePositioningCards();
                return;
            }
        }
        
    }

    private void CreateAllCards(int count) {
        for(int i=0; i<count; i++)
        {
            GameObject newCard = cardFactory.Create().gameObject;
            newCard.transform.SetParent(this.transform);
            newCard.GetComponent<Card>().id = i;
            newCard.GetComponent<Card>().setImage(images[i]);
            newCard.GetComponent<RectTransform>().localScale = Vector3.one;
            cards.Add(newCard);
        }
    }

    public void ShowAllCards()
    {
        foreach(var cardku in cards)
        {
            cardku.GetComponent<Card>().ShowCard();
        }
    }

    public void HideAllCards()
    {
        foreach (var cardku in cards)
        {
            cardku.GetComponent<Card>().HideCard();
        }
    }

    private void RePositioningCards()
    {
        int _count = cards.Count;
        if (_count == 0) return;

        cardWidth = cards[0].transform.GetChild(0).GetComponent<RectTransform>().rect.width;

        float _originX = -(cardWidth + spacing) * (_count-1)/2;
        Vector2 _position = new Vector2(_originX, 0);

        foreach (var _card in cards)
        {
            _card.GetComponent<RectTransform>().anchoredPosition = _position;
            _position += Vector2.right * (cardWidth+spacing);
        }
    }

    public void StartRandomize() {
        StartCoroutine(randomizePosition(3));
    }

    private IEnumerator randomizePosition(int loopnum) {
        if (cards.Count > 1) {
            int i = 0;
            while(i<loopnum)
            {
                int[] random = new int[] { UnityEngine.Random.Range(0, cards.Count - 1)
                    , UnityEngine.Random.Range(0, cards.Count - 1) };
                int from = random[0];
                int to = random[1] == from ? (from + 1) % cards.Count : random[1];

                Vector3 temp = cards[from].transform.position;
                moveCardAnimation(cards[from].transform, cards[to].transform.position);
                currSequence = moveCardAnimation(cards[to].transform, temp);

                while (!currSequence.IsComplete())
                    yield return null;

                i++;
            }
        }
    }

    private Sequence moveCardAnimation(Transform self, Vector3 to) {
        Sequence sequence = DOTween.Sequence().SetAutoKill(false);
        sequence.Append(self.DOScale(1.2f, 0.4f / timefactor))
            .Append(self.DOMoveX(to.x, 1/timefactor))
            .Append(self.DOScale(1f, 0.4f / timefactor));
        sequence.Play();
        return sequence;
    }

    public void HideCardsFromScene(Action action)
    {
        StartCoroutine(HideCardsFromScenePlay(action));
    }

    private IEnumerator HideCardsFromScenePlay(Action action)
    {
        float delay = 0.2f;
        foreach (var cardku in cards)
        {
            cardku.GetComponent<Card>().HideCardFromScene();
            yield return new WaitForSeconds(delay);
        }

        action();
    }

    public void ShowCardsToScene()
    {
        StartCoroutine(ShowCardsToScenePlay());
    }

    private IEnumerator ShowCardsToScenePlay()
    {
        //int tot = 0;
        //foreach (var cardku in cards)
        //{
        //    cardku.GetComponent<Card>().reset();
        //    tot++;
        //}

        //while (tot < cards.Count)
        //    yield return null;

        float delay = 0.2f;
        foreach (var cardku in cards)
        {
            cardku.GetComponent<Card>().ShowCardToScene();
            yield return new WaitForSeconds(delay);
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 50, 20), "tes button"))
        {
            print("You clicked the button!");
            ShowCardsToScene();
        }

        if (GUI.Button(new Rect(70, 10, 50, 20), "re position"))
        {
            print("You clicked the button!");
            Action action = () => { };
            HideCardsFromScene(action);
        }
    }

}
