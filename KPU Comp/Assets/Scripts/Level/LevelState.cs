using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState
{
    public enum State
    {
        antri,
        coblos,
        masukinkertas,
        tinta,
        selesai
    }

    public List<Calon> Calons { get; set; }
    public State state { get; private set; }

}
