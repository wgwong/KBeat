using System.Collections;
using UnityEngine;
using DSPLib;

public class BeatMapManager : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource audioSource;

    void Start()
    {
        // --------------------

        //TODO need to pass in gameobject that we attach the audiosource to, for now, just make it a component of the beatmapmanager gameobject
        audioSource = gameObject.AddComponent<AudioSource>();

        string tracksSuffix = "/Tracks";
        string artistSuffix = "/ArianaGrande";
        string songSuffix = "/everytime/everytime.ogg";
        string filePath = "file://" + Application.dataPath + tracksSuffix + artistSuffix + songSuffix;

        LoadAudioClip(filePath);
    }

    void analyzeAudioClip(AudioClip clip)
    {
        int numChannels = clip.channels;
        int numTotalSamples = clip.samples;
        float clipLength = clip.length;
        int sampleRate = clip.frequency;

        float[] retrievedSamples = new float[numTotalSamples * numChannels];

        clip.GetData(retrievedSamples, 0);
    }

    void playAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;

        audioSource.Play();
    }

    void LoadAudioClip(string location)
    {
        StartCoroutine(AudioLoadManager.GetAudioClip(location, (audioClip) => {
            if (audioClip != null)
            {
                playAudioClip(audioClip);
            }
        }));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
