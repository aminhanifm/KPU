using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState
{
    public LevelState.moreStates _moreStates;
    public LevelState(
        LevelState.moreStates moreStates)
    {
        _moreStates = moreStates;
    }

    public readonly Dictionary<States, string> stateMap = new Dictionary<States, string>
    {
        { States.antri, "antri"},
        { States.coblos, "coblos"},
        { States.masukinkertas, "masukinkertas"},
        { States.celup, "celup"},
        { States.selesai, "selesai"},
    };
    
    public States current { get; set; }
    public States previous { get; set; }

    public ISegment currentSegment { get; set; }

    public bool Compare(string name)
    {
        Debug.Log(stateMap[current] + " " + name);
        if (stateMap[current] != name)
            return false;
        return true;
    }

    public class moreStates
    {
        public bool moveAllowed { get; set; }

        public void reset()
        {
            moveAllowed = true;
        }
    }
}
