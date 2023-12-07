
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    [SerializeField] private Image _resultImage;
    [SerializeField] private Button _button;

    private SceneController _scene;

    private void Start()
    {
        _scene = GetComponent<SceneController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("MissionComplate");
            _resultImage.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown(GlobalStringVariors.Enter))
        {
            _scene.LoadNextScene();
        }
    }
}
