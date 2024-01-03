using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finnish : MonoBehaviour
{
    private AudioSource finishsound;
    private bool levelcompleted = false;
    // Start is called before the first frame update
     private void Start()
    {
        finishsound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelcompleted)
        {
            finishsound.Play();
            levelcompleted = true;
            Invoke("Completelevel", 1f);
        }


    }

    private void Completelevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
