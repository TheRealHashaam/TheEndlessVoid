using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour, IInteractable
{
    GameManager _gameManager;
    public GameObject Fire;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void Interact()
    {
        _gameManager.OpenPaperPanel();
        Fire.SetActive(false);
        Destroy(this.gameObject);
    }
}
