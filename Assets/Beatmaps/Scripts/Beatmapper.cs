using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Beatmapper : MonoBehaviour
{
    // List of all recorded beats in the song
    public List<Beat> beats;

    // Data for managing the audio
    public AudioSource source;
    public bool started;
    public bool paused;

    // UI for labels in Unity
    public TMP_Text playbackLabel;
    public TMP_InputField filenameInput;

    void Update()
    {
        // Pause and play controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!started)
            {
                source.Play();
                started = true;
            }
            else if (!paused)
            {
                source.Pause();
                paused = true;
            }
            else
            {
                source.UnPause();
                paused = false;
            }
        }

        // Updating the timestamp
        playbackLabel.text = source.time + " - " + source.clip.length;

        // Storing key presses
        if (started && !paused)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                beats.Add(new Beat { time = source.time, input = "Up" });
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                beats.Add(new Beat { time = source.time, input = "Left" });
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                beats.Add(new Beat { time = source.time, input = "Down" });
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                beats.Add(new Beat { time = source.time, input = "Right" });
            }
        }

        // Saving the key presses to a file
        if (Input.GetKeyDown(KeyCode.Return))
        {
            BeatWrapper wrapper = new BeatWrapper(beats);
            string json = JsonUtility.ToJson(wrapper, true);

            Debug.Log(json);

            string path = "Assets/Beatmaps/" + filenameInput.text + ".json";
            if (filenameInput.text.Length == 0)
            {
                path = "Assets/Beatmaps/untitled.json";
            }
            File.WriteAllText(path, json);
        }
    }
}
