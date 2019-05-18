using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AudioLoadManager: MonoBehaviour
{
    internal static IEnumerator GetAudioClip(string uri, System.Action<AudioClip> callback, AudioType audioType = AudioType.OGGVORBIS)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(uri, audioType))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);

                callback(myClip);
            }
        }
    }
}
