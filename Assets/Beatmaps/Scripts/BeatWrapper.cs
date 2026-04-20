using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeatWrapper
{
    // This is necessary to write the map to a file.
    // Ignore it completely, we don't need to worry about it.
    public List<Beat> beats;

    public BeatWrapper(List<Beat> beats)
    {
        this.beats = beats;
    }
}
