using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseDoor : MonoBehaviour {
    public string NameOfScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rabbit>() != null)
        {
            SceneManager.LoadScene(NameOfScene);
        }
    }
}
