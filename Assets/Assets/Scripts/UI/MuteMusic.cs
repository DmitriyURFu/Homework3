using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    [SerializeField] private AudioSource AudioSource;
    public void MusicOff()
    {
        if (AudioSource.volume > 0)
        {
            AudioSource.volume = 0f;
        }
        else
        {
            AudioSource.volume = 0.001f;
        }
    }
}
