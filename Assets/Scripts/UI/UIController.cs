using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public MeshRenderer[] walls;
    public GameObject inGamePanel;
    public GameObject mainMenuPanel;
    public GameObject menuBox;
    public GameObject player;
    public Text score;
    public Text highScore;
    public GameObject gameOverPanel;
    public Material[] playerMaterials;
    public SkinnedMeshRenderer playerRenderer;
    public SkinnedMeshRenderer menuPlayerRenderer;
    public GameObject customizePanel;
    public TrailRenderer trail;
   

    
    

    void Start()
    {
        inGamePanel.SetActive(false);
        foreach (var objects in walls)
        {
            objects.enabled = false;
        }

        playerRenderer.material = playerMaterials[PlayerPrefs.GetInt("PlayerColor")];
        menuPlayerRenderer.material = playerMaterials[PlayerPrefs.GetInt("PlayerColor")];
        customizePanel.SetActive(false);


        if (PlayerPrefs.GetInt("PlayerColor") == 0)
        {
            trail.startColor = Color.red;
        }else if (PlayerPrefs.GetInt("PlayerColor") == 1)
        {
            trail.startColor = Color.yellow;
            
        }
        else if (PlayerPrefs.GetInt("PlayerColor") == 2)
        {
            trail.startColor = Color.cyan;
        }


    }
    void Update()
    {
        if (mainMenuPanel.activeInHierarchy)
        {
            UIBoxRotateAnimation();
        }

        if (gameOverPanel.activeInHierarchy)
        {
            inGamePanel.SetActive(false);
            score.text = PlayerPrefs.GetInt("currentScore").ToString();
            highScore.text = PlayerPrefs.GetInt("highScore").ToString();
        }
     

        
    }

   public void PlayButton()
    {
        mainMenuPanel.SetActive(false);
        inGamePanel.SetActive(true);
        menuBox.SetActive(false);

        foreach (var objects in walls)
        {
            objects.enabled = true;
        }
        
    }

   public void MenuButton()
   {
       mainMenuPanel.SetActive(true);
       inGamePanel.SetActive(false);
       menuBox.SetActive(true);
       foreach (var objects in walls)
       {
           objects.enabled = false;
       }

       player.transform.position = new Vector3(0, .9f, 0);
       customizePanel.SetActive(false);

   }

   public void UIBoxRotateAnimation()
   {
       menuBox.transform.Rotate(.5f,.5f,.5f * Time.deltaTime);
   }

   public void TryAgainButton()
   {
       SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
   }

 

   public void ChangePlayerColor()
   {
       if (PlayerPrefs.GetInt("PlayerColor") == 0)
       {
           playerRenderer.material = playerMaterials[1];
           menuPlayerRenderer.material = playerMaterials[1];
           trail.startColor = Color.yellow;

           PlayerPrefs.SetInt("PlayerColor",1);
       }
       else if (PlayerPrefs.GetInt("PlayerColor") == 1)
       {
           playerRenderer.material = playerMaterials[2];
           menuPlayerRenderer.material = playerMaterials[2];
           PlayerPrefs.SetInt("PlayerColor",2);
           trail.startColor = Color.cyan;
       }
       else if (PlayerPrefs.GetInt("PlayerColor") == 2)
       {
           playerRenderer.material = playerMaterials[0];
           menuPlayerRenderer.material = playerMaterials[0];
           PlayerPrefs.SetInt("PlayerColor",0);
           trail.startColor = Color.red;
           
       }
   }

   public void CustomizeButton()
   {
       customizePanel.SetActive(true);
       mainMenuPanel.SetActive(false);
       menuBox.SetActive(false);
   }

 
}
