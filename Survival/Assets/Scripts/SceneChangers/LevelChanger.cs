using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int levelToLoad;

    public Vector3 position;
    public VectorValue playerStorage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerStorage.initialValue = position;
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
