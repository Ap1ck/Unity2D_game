using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    [SerializeField] private Image _resultImage;
    [SerializeField] private Button _button;
    [SerializeField] private LayerMask _layerMask;

    private SceneController _scene;

    private void Start()
    {
        _scene = GetComponent<SceneController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _layerMask = collision.gameObject.layer;

        if (collision)
        {
            _resultImage.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown(GlobalStringVariors.Enter))
        {
            _scene.LoadNextScene();
        }
    }
}
