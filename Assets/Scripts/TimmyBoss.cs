//timmy the bossss

using TMPro;
using UnityEngine;

public class TimmyBoss : Enemy
{
    // Timmy screams random stuff each turn
    // random stuff i generated using Chat
    private static readonly string[] timmyQuotes = {
        "HONK HONK HONK",
        "YOUR CODE WILL NEVER COMPILE",
        "I HAVE 167 TOKENS AND I'M NOT AFRAID TO USE THEM",
        "QUACK QUACK YOUR CODEBASE IS WHACK",
        "I EAT SEMICOLONS FOR BREAKFAST",
        "SEGFAULT THIS, NERD",
        "HAVE YOU TRIED TURNING IT OFF AND NEVER ON AGAIN?",
        "YOUR GIT HISTORY IS A WAR CRIME",
        "I AM THE MERGE CONFLICT",
        "TABS OR SPACES? NEITHER. ONLY PAIN.",
    };

    private TextMeshProUGUI speech;

    protected virtual void Awake()
    {
        speech = GetComponentInChildren<TextMeshProUGUI>();
    }

    public string GetRandomQuote()
    {
        return timmyQuotes[Random.Range(0, timmyQuotes.Length)];
    }

    public new void TakeAction(GameManager manager)
    {
        base.TakeAction(manager);
        speech.text = GetRandomQuote();
    }
}
