using UnityEngine.Playables;
using UnityEngine;
using System.Collections;

public class CutSceneController : MonoBehaviour
{
    public PlayableDirector CutsceneDirector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CutsceneDirector.Play();
            StartCoroutine(StartMusic());
        }
    }

    public IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(5f);
        AudioManager.Instance.PlayMusic("Boss");
    }
}
