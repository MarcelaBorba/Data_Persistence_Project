using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuInicial : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI nomeInput;
    public string nomePlayer;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void StartMain(){
        SalvarNome();
        SceneManager.LoadScene("main");
    }

    public void SalvarNome(){
        if(nomeInput.text.Length == 1){ //nenhum name digitado
            PlayerData.Instance.SetNamePlayer("Player");
            return;
        }
        PlayerData.Instance.SetNamePlayer(nomeInput.text);        
    }

    public void Quit(){
        UnityEditor.EditorApplication.ExitPlaymode();
    }
}
