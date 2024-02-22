using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using StarterAssets;
using System;
using Unity.Burst.CompilerServices;

public class GameManager : MonoBehaviour
{
    public GameObject RaftCamera, PlayerCamera;
    public StarterAssetsInputs Player;
    public GameObject RaftMan;
    public RaftController RaftController;
    public Image FadePanel;
    public GameObject PaperPanel;
    public TextMeshProUGUI PaperText;
    public GameObject MainMenuPanel;
    public GameObject MainmenuCamera;
    public GameObject PausePanel;
    bool _startrandom=false;
    public List<String> Hints;
    public List<String> Talks;
    public bool PaperOpen;
    bool ifgamestart;
    public GameObject Environment;
    public AudioSource ClickSound;
    private void Start()
    {
        OpenMainMenu();
    }
    public void InstantiateIsland(Transform T,GameObject Temp)
    {
        GameObject g = Instantiate(Environment,T);
        g.transform.localPosition = Vector3.zero;
        g.transform.localRotation = Quaternion.identity;
        g.transform.parent = null;
        Destroy(Temp);
    }
    void OpenMainMenu()
    {
        Player.SetCursorState(false);
        Player.enabled = false;
        FadeInOut(0);
        MainmenuCamera.SetActive(true);
        MainMenuPanel.SetActive(true);
        RaftController.alignToWaves.AllowByonce = true;
    }

    public void PauseGame()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        PausePanel.SetActive(true);
        Player.SetCursorState(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Player.GetComponent<FirstPersonController>().enabled = true;
        PausePanel.SetActive(false);
        Player.SetCursorState(true);
        Time.timeScale = 1f;
        ClickSound.Play();
    }
    public void StartGame()
    {
        ifgamestart = true;
        Player.SetCursorState(true);
        Player.enabled = true;
        MainMenuPanel.SetActive(false);
        MainmenuCamera.SetActive(false);
        PlayerCamera.SetActive(true);
        ClickSound.Play();
    }

    public void QuitGame()
    {
        FadeInOut(1);
        StartCoroutine(Quit_Delay());
        ClickSound.Play();
    }
    IEnumerator Quit_Delay()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }

    public void FadeInOut(int val)
    {
        FadePanel.DOFade(val,0.5f).SetUpdate(true);
    }

    public void OpenPaperPanel()
    {
        PaperPanel.SetActive(true);
        PaperOpen = true;
        Player.enabled = false;
        if(Hints.Count>0)
        {
            if (_startrandom)
            {
                int r = UnityEngine.Random.Range(0, Hints.Count);
                PaperText.text = Hints[r].ToString();
                Hints.Remove(Hints[r]);
            }
            else
            {
                PaperText.text = Hints[0].ToString();
                Hints.Remove(Hints[0]);
                _startrandom = true;
            }
        }
        else
        {
            int r = UnityEngine.Random.Range(0, Talks.Count);
            PaperText.text = Talks[r].ToString();
        }
    }
    public void  ClosePaper()
    {
        PaperOpen = false;
        Player.enabled = true;
        PaperPanel.SetActive(false);
    }
    private void Update()
    {
        if(PaperOpen)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {
                ClosePaper();
            }
        }
        if(ifgamestart)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
    }
    public void EnableRaft()
    {
        PlayerCamera.SetActive(false);
        RaftCamera.SetActive(true);
        RaftController.enabled = true;
        RaftMan.SetActive(true);
        Player.enabled = false;
        Player.gameObject.SetActive(false);
        //RaftController.alignToWaves.AllowByonce = false;
    }
    public void DisableRaft()
    {
        PlayerCamera.SetActive(true);
        RaftCamera.SetActive(false);
        RaftController.enabled = false;
        RaftMan.SetActive(false);
        Player.enabled = true;
        Player.gameObject.SetActive(true);
        Player.transform.position = RaftController.RaftOffset.position;
        Player.transform.rotation = RaftController.RaftOffset.rotation;
        //RaftController.alignToWaves.AllowByonce = true;
    }
}
