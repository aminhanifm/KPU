using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SegmentNyoblos : MonoBehaviour, ISegment
{
    public LevelHandler _levelHandler;
    public CardsHandler _cardHandler;

    public CoblosContainer coblosContainer;

    private int CurrentIdxCalon;

    [Inject]
    public void Construct(
        LevelHandler levelHandler,
        CardsHandler cardsHandler)
    {
        _levelHandler = levelHandler;
        _cardHandler = cardsHandler;
    }

    public void Init()
    {
        Loading.Instance.doLoading();

        this.gameObject.SetActive(true);

        Action postLoad = () => { 
            Loading.Instance.endLoading();
            _cardHandler.gameObject.SetActive(true);
        };

        StartCoroutine(SceneChanger.ChangeScene("Nyoblos", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, postLoad));

        CardEventHandler.current.onSelectCard += HandleSelectedCardWithId;
        CardEventHandler.current.onDoneSelectCalon += HandleNextSelection;
    }

    void ISegment.Update()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {   
        LevelHandler.GameStates.moveAllowed = true;
        Loading.Instance.endLoading();
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CardEventHandler.current.onSelectCard -= HandleSelectedCardWithId;
        CardEventHandler.current.onDoneSelectCalon -= HandleNextSelection;
    }

    private void HandleSelectedCardWithId(int id)
    {
        Debug.Log("SAYA NEKAN " + id);

        CurrentIdxCalon = id;

        Action action = () =>
        {
            CardEventHandler.current.DoneSelectCard();
            _cardHandler.DestroyCardAt(id);
        };
        _cardHandler.HideCardsFromScene(action);
    }

    private void HandleNextSelection(int calonId)
    {
        if(_cardHandler.CardLeft > 0)
        {
            LevelHandler.GameStates.playerSelects[CurrentIdxCalon] = calonId;
            Debug.Log(LevelHandler.GameStates.playerSelects);
            _cardHandler.ShowCardsToScene();
        }
        else
        {
            Loading.Instance.doLoading();
            Action action = () =>
            {
                Exit();
            };
            StartCoroutine(SceneChanger.UnloadCurrentScene(action));
        }
    }

}
