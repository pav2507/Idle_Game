using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int scoreIncrement = 1;
    public int upgradeCost = 10;
    public TextMeshProUGUI scoreText;
    public Button upgradeButton;

    // Variable pour indiquer si le score doit augmenter avec le clic du bouton
    private bool increaseWithClick = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RiseScore());
    }

    private void Update()
    {
        scoreText.text = "" + score.ToString();
    }

    // Coroutine pour incrémenter le score chaque seconde
    IEnumerator RiseScore()
    {
        while (true)
        {
            score += scoreIncrement;

            // Si increaseWithClick est vrai, augmenter le score avec le clic du bouton
            if (increaseWithClick)
            {
                score++;
                increaseWithClick = false; // Réinitialiser pour éviter une augmentation continue
            }
            yield return new WaitForSeconds(1);
        }
    }

    // Méthode appelée lorsque le bouton est cliqué
    public void IncreaseScoreOnClick()
    {
        // Activer l'augmentation du score avec le clic du bouton
        scoreText.text = "" + score.ToString();
        score += scoreIncrement; 
    }

    public void IncreaseIncrement(int amount)
    {
        scoreIncrement += amount;
        score -= upgradeCost;
    }

    public void SetCost(int newCost)
    {
        upgradeCost = newCost;
    }

    public void MultiplyCost(float costMultiplier)
    {
        upgradeCost = (int)(costMultiplier * upgradeCost);
    }
}