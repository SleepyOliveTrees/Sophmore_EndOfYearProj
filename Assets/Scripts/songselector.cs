using UnityEngine;

public class SongSelector : MonoBehaviour
{
    public static SongSelector Instance;
    public Songs selectedSong;

   //Runs before any start method
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectedSong(Songs song)
    {
        selectedSong = song;
    }
}
