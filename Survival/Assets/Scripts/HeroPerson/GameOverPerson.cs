using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPerson : MonoBehaviour
{
    private PlayerMovement movement;

    public GameObject GameUI;
    public GameObject GameOverUI;
    public GameObject PauseUI;
    private Survival survival;
    [HideInInspector] public bool IsDie = false;

    private void Start()
    {
        survival = (Survival)FindObjectOfType(typeof(Survival));
        movement = (PlayerMovement)FindObjectOfType(typeof(PlayerMovement));
    }

    private void Update()
    {
        TakeDeath();
    }

    public void TakeDeath()
    {
        if (survival.Hunger == 0 || survival.Thirst == 0 || survival.currentHealth == 0)
        {
            IsDie = true;
            GameUI.SetActive(false);
            PauseUI.SetActive(false);
            GameOverUI.SetActive(true);
        }
        if(IsDie)
        {
            movement.moveSpeed = 0f;
        }
    }
}
