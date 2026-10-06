using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private int totalCollectables;
    
    public TextMeshProUGUI counterText; 

    private void Awake() 
    {
        Instance = this;
    }

    void Start()
    {
        totalCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
        UpdateUI();
    }
    
    public void Registrar(GameObject collectable)
    {
        totalCollectables--; 
        UpdateUI();
        Destroy(collectable); 
        if (totalCollectables <= 0)
        {
            EndGame();
        }
    }

    private void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = "Remaining collectables: " + totalCollectables;
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene("PantallaVictoria");
    }
}