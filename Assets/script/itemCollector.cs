using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class itemCollector : MonoBehaviour
{
    private int Kiwi = 0;

    [SerializeField] private TextMeshProUGUI CollectableText;
    [SerializeField] private AudioSource CollectSFX;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            CollectSFX.Play();
            Destroy(collision.gameObject);
            Kiwi++;
            // Debug.Log("Kiwi: " + Kiwi);
            CollectableText.text = "Fruit: " + Kiwi;
        }
    }

}
