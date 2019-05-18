using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Beat
{
    public DateTime time { get; set; } = DateTime.Now;

    //public type (single beat or hold)
}
public class LaneManager : MonoBehaviour
{
    private int score = 0; //TODO scoreManager variable to handle global score
                           // Start is called before the first frame update

    private DateTime time = DateTime.Now; //TODO time manager to sync global time

    private List<Beat> beats;

    private List<Beat> loadedBeats;
    void Start()
    {
        beats = new List<Beat>();
        loadedBeats = new List<Beat>();

        //hardcode beat
        Beat beat1 = new Beat();
        DateTime newDate = DateTime.ParseExact("5:502", "s:fff", new CultureInfo("en-US"));
        beat1.time = newDate;
        beats.Add(beat1);
    }

    // Update is called once per frame
    void Update()
    {
        print("time: " + DateTime.Now);

        while (beats.Count > 0 && beats[0].time.Subtract(DateTime.Now).Milliseconds < 5000)
        {

            var topBeat = beats[0];
            beats.Remove(topBeat);

            loadedBeats.Add(topBeat);

            print("loaded top beat");
        }

        foreach(var loadedBeat in loadedBeats)
        {
            var timeRemaining = beats[0].time.Subtract(DateTime.Now);

            if (timeRemaining.Milliseconds < 0)
            {
                //beat already passed, do point subtraction here
                loadedBeats.Remove(loadedBeat);
            } else
            {
                print("time remaining: " + timeRemaining.Milliseconds);
            }

        }
    }
}
