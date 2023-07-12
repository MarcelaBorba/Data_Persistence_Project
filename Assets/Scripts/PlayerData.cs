using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    
    //Static class for save the current player data
    public static PlayerData Instance;
    
    private string namePlayer;

    private int bestScore;
    private string bestPlayer;


    private void Awake() {
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadRanking();
    }

    
    public void SetNamePlayer(string name){
        namePlayer = name;
    }

    public string GetNamePlayer(){
        return namePlayer;
    }


    public string GetBestScoreName(){
        return bestPlayer;;
    }

    public void SetBestScoreName(string name){
        bestPlayer = name;
    }

    public void SetBestScore(int score){
        SalvarJson(score, namePlayer);
        
    }

    public int GetBestScore(){
        return bestScore;
    }


    
    [System.Serializable]
    class SaveData{
        public int score;
        public string name;
    }

    public void LoadRanking(){
        //using System.IO;
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if(File.Exists(path)){ //se o arquivo existir, será lido
            string dadosJson = File.ReadAllText(path);
            SaveData dados = JsonUtility.FromJson<SaveData>(dadosJson);
            bestPlayer = dados.name;
            bestScore = dados.score;

        }else{ //se não existir, será criado.
            SalvarJson(0, "T");
        }        
    }

    public void SalvarJson(int score, string name){
        string path = Application.persistentDataPath + "/savefile.json";
        SaveData dadosNewJson = new SaveData();
        dadosNewJson.name = name;
        dadosNewJson.score = score;
        string dadosJson = JsonUtility.ToJson(dadosNewJson);
        File.WriteAllText(path, dadosJson);
        bestPlayer = name;
        bestScore = score;
    }
}
