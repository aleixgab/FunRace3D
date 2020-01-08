using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishRace : MonoBehaviour
{
    public GameObject UIObject;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = UIObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        text.text = "Winner: ";
        text.text += other.name;
        UIObject.SetActive(true);
    }

    public void RestartLevel()
    {
        Application.LoadLevel("MainScene");
    }
}
