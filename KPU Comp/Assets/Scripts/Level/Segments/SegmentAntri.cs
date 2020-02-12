using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SegmentAntri : MonoBehaviour, ISegment
{
    private LevelHandler _levelHandler;

    [Inject]
    public void Construct(
        LevelHandler levelHandler)
    {
        _levelHandler = levelHandler;
    }

    public void Init()
    {
        Loading.Instance.doLoading();

        this.gameObject.SetActive(true);

        _levelHandler.GameStates.moveAllowed = false;
        StartCoroutine(AnimateCutScene());
    }

    private IEnumerator AnimateCutScene()
    {
        yield return new WaitForSeconds(2f);

        Loading.Instance.doCutScene();

        yield return new WaitForSeconds(5f);

        Exit();
    }

    void ISegment.Update()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        Loading.Instance.endLoading();
        _levelHandler.GameStates.moveAllowed = true;
        this.gameObject.SetActive(false);
    }
}
