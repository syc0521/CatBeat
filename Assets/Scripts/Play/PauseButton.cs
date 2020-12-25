﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public NoteController noteController;
    public GameObject canvas;
    public void OnContinuePressed()
    {
        NoteController.isPaused = false;
        noteController.source.Play();
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnEndPressed()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Select");
    }
}