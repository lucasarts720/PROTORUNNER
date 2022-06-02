using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvlMgr : MonoBehaviour
{
    public Text timer;
    public Spawner spawner;
    public GameObject panel;
    float time;
    bool isPlaying;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        time = 0;
        isPlaying = true;
    }
    private void Update()
    {
        if (isPlaying == true)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void EndGame()
    {
        spawner.gameObject.SetActive(false);
        isPlaying = false;
        panel.gameObject.SetActive(true);
    }

    public void LoadLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Salio del juego");
    }
}
