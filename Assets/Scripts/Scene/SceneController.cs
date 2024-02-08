using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Image _imagesMenu;

    public PlayerMovement PlayerMove;
    public PlayerShoot Shoot;

    private int _indexScene = 1;

    private void Start()
    {
        PlayerMove = GetComponent<PlayerMovement>();
        Shoot = GetComponent<PlayerShoot>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _imagesMenu.gameObject.SetActive(true);
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _indexScene);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Contunie()
    {
        _imagesMenu.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
