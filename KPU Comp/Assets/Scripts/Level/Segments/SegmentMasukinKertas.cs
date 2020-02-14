using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class SegmentMasukinKertas : MonoBehaviour, ISegment
{
    private CardsHandler _cardHandler;
    private DialogBox _dialogBox;

    private List<string> jenisKotak;

    int choosenKotakID;

    [Inject]
    public void Construct(
        CardsHandler cardsHandler,
        DialogBox dialogBox)
    {
        _cardHandler = cardsHandler;
        _dialogBox = dialogBox;
    }

    public void Start()
    {
        jenisKotak = new List<string> { 
            "Kotak calon Presiden",
            "Kotak calon DPD RI",
            "Kotak calon DPR RI",
            "Kotak calon DPRD Jatim",
            "Kotak calon DPR Surabaya"
        };
    }

    public void Init()
    {
        this.gameObject.SetActive(true);
        LevelHandler.GameStates.moveAllowed = false;
        choosenKotakID = LevelHandler.GameStates.kotakId;

        _cardHandler.gameObject.SetActive(true);

        _cardHandler.ShowCardsToScene();

        CardEventHandler.current.onSelectCard += HandleSelectedCardWithId;
        CardEventHandler.current.onDoneSelectCard += Exit;

        StartCoroutine(Randomize());
    }

    private void OnDisable()
    {
        CardEventHandler.current.onSelectCard -= HandleSelectedCardWithId;
        CardEventHandler.current.onDoneSelectCard -= Exit;
    }

    private IEnumerator Randomize()
    {
        _dialogBox.ShowDialog("Konsentrasi!");

        yield return new WaitForSeconds(2f);

        LevelHandler.GameStates.selectAllowed = false;

        _cardHandler.ShowAllCards();

        yield return new WaitForSeconds(4f);

        _dialogBox.HideDialog();

        _cardHandler.HideAllCards();

        yield return new WaitForSeconds(1f);

        _cardHandler.StartRandomize();

        yield return new WaitForSeconds(0.7f);

        _dialogBox.ShowDialog("Pilihlah kartu untuk "+ jenisKotak[choosenKotakID]);

        LevelHandler.GameStates.selectAllowed = true;
    }

    private void HandleSelectedCardWithId(int id)
    {
        if (!LevelHandler.GameStates.selectAllowed) return;

        Action action = () =>
        {
            CardEventHandler.current.DoneSelectCard();
            _cardHandler.DestroyCardAt(id);
        };

        if(id == choosenKotakID)
        {
            Debug.Log("show benar");
            _cardHandler.HideCardsFromScene(action);
        }
        else
            Debug.Log("show salah");
    }

    void ISegment.Update()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        _dialogBox.HideDialog();
        LevelHandler.GameStates.moveAllowed = true;
        this.gameObject.SetActive(false);
    }

}
