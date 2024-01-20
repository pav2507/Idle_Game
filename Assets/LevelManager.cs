using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Référence au score manager
    public Score scoreManager;
    public Image levelIndicator;

    // Ce qui se passe à chaque passage de niveau
    public UnityEvent[] levelUpEvents;

    // Ce qui permet de suivre l'avancée du niveau
    [HideInInspector] public int level = 0;
    private int maxLevel;

    // Methodes
    private void Start()
    {
        maxLevel = levelUpEvents.Length;
        levelIndicator.fillAmount = level / maxLevel;
    }

    private void Update()
    {
        if (scoreManager.score < scoreManager.upgradeCost) scoreManager.upgradeButton.interactable = false;
        else if (level >= maxLevel) scoreManager.upgradeButton.interactable = false;
        else scoreManager.upgradeButton.interactable = true;
    }

    public void Buy()
    {
        // On ne fait rien si on a déjà atteint le niveau max
        if (level >= maxLevel) return;

        level++;
        levelIndicator.fillAmount = (float)level / maxLevel;
        levelUpEvents[level - 1].Invoke();
    }
}
