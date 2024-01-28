using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void StartGame()
    {
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        animator.SetBool("wave", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
