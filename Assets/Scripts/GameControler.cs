using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public Text TextComponent;
    int NumberOfSpecialBlockAtTheBeginning;
    public bool IsPlaying = true;
    public string NextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        FixLighting();
        TextComponent.enabled = false;
        NumberOfSpecialBlockAtTheBeginning = CountBlocks(special: true);
        IsPlaying = true;

    }
    public void OnValidate()
    {
        FixLighting();
    }

    void FixLighting()
    {
        RenderSettings.ambientLight = Color.white;
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
    }

    public int CountBlocks(bool special)
    {
        return FindObjectsOfType<Block>().Count(block => block.Enabled && block.IsSpecial == special);
    }
    public void OnTriggerEnter(Collider other)
    {
        var block = other.GetComponent<Block>();
        if (block == null) return;
        block.Enabled = false;
        
        if (block.IsSpecial)
        {
            StartCoroutine(EndGameCouritne(won: false));
        }
        else if (CountBlocks(special: false) == 0)
        {
            StartCoroutine(EndGameCouritne(won: true));
        }
        Destroy(block.gameObject);
    }
    IEnumerator EndGameCouritne(bool won)
    {
        if (IsPlaying == false) yield break;
        TextComponent.enabled = true;
        IsPlaying = false;
        if (won)
        {
            for (int i = 5; i > 0;  i--)
            {
                TextComponent.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }
            if (NumberOfSpecialBlockAtTheBeginning != CountBlocks(special: true))
                won = false;
        }
        TextComponent.text = won ? "YOU WON" : "YOU LOST";
        yield return new WaitForSeconds(3f);
        if (string.IsNullOrEmpty(NextLevelName))
        {
            Debug.Log("GameOver");
            Application.Quit();
            
        }
        else
        {
            SceneManager.LoadScene(NextLevelName);
        }
    }
}
