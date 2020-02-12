using UnityEngine;

public class InputState
{
    public float XAxis { get; set; }
    public float YAxis { get; set; }
    public Vector2 CurrentDirection => new Vector2(XAxis, YAxis);

    public bool available => (XAxis!=0 || YAxis!=0);
    public bool Collect { get; set; }
    public bool Search { get; set; }

    public bool Interact { get; set; }


    public void Reset()
    {
        XAxis = 0;
        YAxis = 0;
        Collect = false;
        Search = false;
    }
}
