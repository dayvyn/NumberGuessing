using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuessNumber : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text attemptsLeftText;
    int attemptsLeft = 3;
    [SerializeField] TMP_InputField numberGuesser;
    int randomNum;
    bool needNumber = false;
    string input;
    bool canGuess = true;
    [SerializeField] GameObject restart;


    void Start()
    {
        randomNum = Random.Range(1, 11);
        attemptsLeftText.text = "You have " + attemptsLeft + " attempts left!";

    }

    // Update is called once per frame
    void Update()
    {

        if (needNumber)
        {
            ButtonSet();
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            TypeInInput();
        }

    }

    public void Guess()
    {
        if (int.Parse(input) == randomNum)
        {
            attemptsLeftText.text = "Congratulations! Your guess was correct!";
            needNumber = true;
            canGuess = false;
        }
        else if (int.Parse(input) != randomNum && attemptsLeft != 1)
        {
            attemptsLeft -= 1;
            attemptsLeftText.text = "You have " + attemptsLeft + " attempts left!";
        }
        else
        {
            attemptsLeftText.text = "Sorry! Your number was " + randomNum + ".";
            needNumber = true;
            canGuess = false;
        }

    }
    public void TypeInInput()
    {
        if (int.Parse(numberGuesser.text) == 0)
        {
            attemptsLeftText.text = "Sorry! Zero does not count as an option.";
        }
        else if (numberGuesser.text.Length >= 3 && canGuess)
        {
            attemptsLeftText.text = "Sorry! Your number was too big, try again!";
        }
        else if (numberGuesser.text.Length < 0 && canGuess)
        {
            attemptsLeftText.text = "Sorry! Your number was too small, try again!";
        }
        else if (numberGuesser.text.Length > 0 && canGuess)
        {
            input = numberGuesser.text;
            numberGuesser.text = "";
            Guess();
        }
    }
    void ButtonSet()
    {
        restart.SetActive(true);
    }
    public void RestartGame()
    {
        randomNum = Random.Range(1, 11);
        needNumber = false;
        attemptsLeft = 3;
        attemptsLeftText.text = "You have " + attemptsLeft + " attempts left!";
        canGuess = true;
        restart.SetActive(false);
    }
}
