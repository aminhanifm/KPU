using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
using System.Linq;

public class LevelHandler : MonoBehaviour
{
    private LevelState levelState;
    private PlayerModel _player;
    private List<States> sequences;
    [SerializeField] private List<GameObject> _segmentsObject;
    private List<ISegment> _segments;
    public ISegment[] _segments2;

    public LevelState.moreStates GameStates => (levelState._moreStates);

    [Inject]
    public void Construct(
        PlayerModel player,
        LevelState _levelState)
    {
        levelState = _levelState;
        _player = player;
    }

    private void Awake()
    {
        sequences = new List<States> {
            States.antri,
            States.coblos,
            States.masukinkertas,
            States.celup,
            States.selesai
        };
        _segments = new List<ISegment>();
        foreach (var segment in _segmentsObject)
        {
            _segments.Add(segment.GetComponent<ISegment>());
        }

        GameStates.reset();

        levelState.current = sequences[0];
        sequences.RemoveAt(0);
    }

    private void Update()
    {
        if (_player.TriggerItems.Collided && _player.Input.Interact)
        {
            Debug.Log("TESS");
            _player.TriggerItems.Items.Clear();
            SetNextState();
        }
    }

    public void SetNextState()
    {
        if (levelState.currentSegment != null)
            levelState.currentSegment.Exit();

        if (sequences.Count == 0) return;
        levelState.previous = levelState.current;
        levelState.current = sequences[0];
        sequences.RemoveAt(0);

        if (_segments.Count() > 0)
        {
            levelState.currentSegment = _segments[0];
            _segments.RemoveAt(0);
            levelState.currentSegment.Init();
        }
    }

    public bool CompareState(string name)
    {
        return levelState.Compare(name);
    }
}
