using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongLoader : MonoBehaviour
{
    public string beatmapFilename;
    private BeatWrapper beatWrapper;
    public List<Beat> beats;
    public AudioSource songAudio;

    private bool started;

    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(beatmapFilename);
        string json = jsonFile.text;
        beatWrapper = JsonUtility.FromJson<BeatWrapper>(json);
        beats = beatWrapper.beats;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            songAudio.Play();
            started = true;

            Debug.Log("Started playing the song!");
        }

        if (started)
        {
            // get the current timestamp in the song
            float currentTime = songAudio.time;

            // look at the next beat in the list
            Beat nextBeat = beats[0];

            // display the beat as soon as the time stamp passes
            if (currentTime > nextBeat.time)
            {
                // do something with the beat
                Debug.Log(nextBeat.input);

                // remove the beat from the list
                beats.RemoveAt(0);
            }
        }
    }
}
