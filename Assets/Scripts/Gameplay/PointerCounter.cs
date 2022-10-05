using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerCounter : Singleton<PointerCounter>
{
    private int points = 0;
    public int Points => points;

    public void StartGame()
    {
        Clear();
    }

    public void AddPoint()
    {
        points++;
    }

    public void Clear()
    {
        points = 0;
    }
}
