using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class KeypadPassword : MonoBehaviour
{
    public TMP_Text codeDisplay;
    public GameObject incorrect;
    public GameObject correct;
    public Material green;
    public Material red;
    public Material black;
    public int requiredPassword;

    private string[] numbersEntered = { "-", "-", "-", "-" };
    private int finalPassword = 0;
    private int numbersPressed = 0;
    private bool solved = false;

    private void Start()
    {
        codeDisplay.text = "----";
    }

    public void appendToCode(int btnValue)
    {
        if (!solved)
        {
            switch (numbersPressed)
            {
                case 0:
                    updateText(0, btnValue);
                    break;
                case 1:
                    updateText(1, btnValue);
                    break;
                case 2:
                    updateText(2, btnValue);
                    break;
                case 3:
                    updateText(3, btnValue);
                    determineAccess();
                    break;
                case 4:
                    resetInput();
                    updateText(0, btnValue);
                    break;
            }
        }
    }

    private void updateText(int digit, int btnValue)
    {
        numbersEntered[digit] = btnValue.ToString();
        codeDisplay.text = numbersEntered[0] + numbersEntered[1] + numbersEntered[2] + numbersEntered[3];
        numbersPressed++;
    }

    private void determineAccess()
    {
        finalPassword = Convert.ToInt32(codeDisplay.text);
        if (finalPassword == requiredPassword)
        {
            correct.GetComponent<MeshRenderer>().material = green;
            solved = true;
        }
        else
            incorrect.GetComponent<MeshRenderer>().material = red;
    }

    private void resetInput()
    {
        for (int i = 0; i <= 3; i++)
            numbersEntered[i] = "-";

        numbersPressed = 0;
        codeDisplay.text = "----";
        incorrect.GetComponent<MeshRenderer>().material = black;
    }
}
