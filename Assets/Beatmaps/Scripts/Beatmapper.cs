using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Beatmapper : MonoBehaviour
{
    // List of all recorded beats in the song
    public List<Beat> beats;

    // Data for managing the audio
    public AudioSource source;
    public bool started;
    public bool paused;
    public bool locked;

    // UI for labels in Unity
    public TMP_Text playingLabel;
    public TMP_Text playbackTimeLabel;
    public TMP_InputField filenameInput;
    public GameObject beatListContent;
    public GameObject beatTextBoxPrefab;
    public ScrollRect scrollRect;
    public bool scrollToBottom;

    void Update()
    {
        // scroll to bottom of list when new items are added on next frame
        if (scrollToBottom)
        {
            scrollRect.normalizedPosition = new Vector2(0, 0);
            scrollToBottom = false;
        }

        // Pause and play controls
        if (Input.GetKeyDown(KeyCode.Space) && !locked)
        {
            if (!started)
            {
                source.Play();
                started = true;
                paused = false;
                playingLabel.text = "Song is playing.";
            }
            else if (!paused)
            {
                source.Pause();
                paused = true;
                playingLabel.text = "Song is not playing.";
            }
            else
            {
                source.UnPause();
                paused = false;
                playingLabel.text = "Song is playing.";
            }
        }

        // Updating the timestamp
        playbackTimeLabel.text = source.time + " - " + source.clip.length + " seconds";

        // Storing key presses
        if (started && !paused && !locked)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Beat beat = new Beat { time = source.time, input = "Up" };
                beats.Add(beat);
                GameObject newBeat = Instantiate(beatTextBoxPrefab, beatListContent.transform);
                newBeat.GetComponent<TMP_Text>().text = beat.time + " - " + beat.input;
                // scroll to bottom on next frame
                scrollToBottom = true;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Beat beat = new Beat { time = source.time, input = "Left" };
                beats.Add(beat);
                GameObject newBeat = Instantiate(beatTextBoxPrefab, beatListContent.transform);
                newBeat.GetComponent<TMP_Text>().text = beat.time + " - " + beat.input;
                // scroll to bottom
                scrollToBottom = true;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Beat beat = new Beat { time = source.time, input = "Down" };
                beats.Add(beat);
                GameObject newBeat = Instantiate(beatTextBoxPrefab, beatListContent.transform);
                newBeat.GetComponent<TMP_Text>().text = beat.time + " - " + beat.input;
                // scroll to bottom
                scrollToBottom = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Beat beat = new Beat { time = source.time, input = "Right" };
                beats.Add(beat);
                GameObject newBeat = Instantiate(beatTextBoxPrefab, beatListContent.transform);
                newBeat.GetComponent<TMP_Text>().text = beat.time + " - " + beat.input;
                // scroll to bottom
                scrollToBottom = true;
            }
        }

        // Saving the key presses to a file
        if (Input.GetKeyDown(KeyCode.Return))
        {
            BeatWrapper wrapper = new BeatWrapper(beats);
            string json = JsonUtility.ToJson(wrapper, true);

            Debug.Log(json);

            string path = "Assets/Resources/" + filenameInput.text + ".json";
            if (filenameInput.text.Length == 0)
            {
                path = "Assets/Resources/untitled.json";
            }
            File.WriteAllText(path, json);
        }
    }

    // disable playback if the input text box is selected
    public void ForcePauseSong()
    {
        locked = true;

        source.Pause();
        paused = true;
        playingLabel.text = "Song is not playing.";
    }

    public void ForceUnPauseSong()
    {
        locked = false;
    }
}
