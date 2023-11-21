using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private JsonReadWriteSystem _json;

    private void Start()
    {
        _json = GetComponent<JsonReadWriteSystem>();
    }

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

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveGame()
    {
        _json.SaveJson();
    }

    public void LoadSavedGame()
    {
        _json.LoadFromJson();
    }

    public void PlayMusic(AudioClip musicClip)
    {
        // Остановка текущей музыки
        StopMusic();

        // Создание и настройка аудиоисточника для воспроизведения музыки
        GameObject audioSourceObj = new GameObject("Music");
        AudioSource audioSource = audioSourceObj.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;

        // Воспроизведение музыки
        audioSource.Play();
    }

    public void StopMusic()
    {
        // Остановка текущей музыки, если она есть
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Stop();
            Destroy(audioSource.gameObject);
        }
    }
}
