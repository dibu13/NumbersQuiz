using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	float timer;
	bool timerActive;
    bool tried;

    float waitTime;

    int actualNumber;
    int correctPoints;
    int failPoints;

    public GameObject numberPanel;
    public GameObject buttonsPanel;
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;
    public GameObject correctPointsText;
    public GameObject failPointsText;
    public Image timerCircle;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = 5.0f;
        timer = 0.0f;
        timerActive = false;
        correctPoints = 0;
        failPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Activate timer
        if(numberPanel.activeSelf && !timerActive)
        {
            timerActive = true;

            // Generate new random number
            actualNumber = Random.Range(0, 1001);
            numberPanel.GetComponentInChildren<Text>().text = NumberToText(actualNumber);

            // Fill options randomly
            int correctPos = Random.Range(0,3);
            int randomOption;

            if (correctPos == 0)
            {
                buttonA.GetComponentInChildren<Text>().text = actualNumber.ToString();
            }
            else
            {
                do
                {
                    randomOption = Random.Range(0, 1001);
                } while (randomOption == actualNumber);

                buttonA.GetComponentInChildren<Text>().text = randomOption.ToString();
            }

            if (correctPos == 1)
            {
                buttonB.GetComponentInChildren<Text>().text = actualNumber.ToString();
            }
            else
            {
                do
                {
                    randomOption = Random.Range(0, 1001);
                } while (randomOption == actualNumber || randomOption == int.Parse(buttonA.GetComponentInChildren<Text>().text));

                buttonB.GetComponentInChildren<Text>().text = randomOption.ToString();
            }

            if (correctPos == 2)
            {
                buttonC.GetComponentInChildren<Text>().text = actualNumber.ToString();
            }
            else
            {
                do
                {
                    randomOption = Random.Range(0, 1001);
                } while (randomOption == actualNumber || randomOption == int.Parse(buttonA.GetComponentInChildren<Text>().text) || randomOption == int.Parse(buttonB.GetComponentInChildren<Text>().text));

                buttonC.GetComponentInChildren<Text>().text = randomOption.ToString();
            }
        }

		// Update timer if is active
        if(timerActive)
		{
            timer += Time.deltaTime;
            timerCircle.fillAmount += 1 / waitTime * Time.deltaTime;
        }

        // TimeOut Actions
        if(timer >= waitTime)
        {
            timerActive = false;
            timer = 0.0f;
            timerCircle.fillAmount = 0;

            numberPanel.SetActive(false);
            buttonsPanel.SetActive(true);
        }


    }

    // Buttons actions
    public void OptionClicked(GameObject clicked)
    {
        if(int.Parse(clicked.GetComponentInChildren<Text>().text) == actualNumber)
        {
            correctPoints++;
            correctPointsText.GetComponent<Text>().text = correctPoints.ToString();
            NewNumber();
        }
        else
        {
            if (!tried)
            {
                clicked.SetActive(false);
                tried = true;
            }
            else
            {
                failPoints++;
                failPointsText.GetComponent<Text>().text = failPoints.ToString();
                NewNumber();
            }
        }
    }

    // Reset values
    public void NewNumber()
    {
        tried = false;
        buttonA.SetActive(true);
        buttonB.SetActive(true);
        buttonC.SetActive(true);
        buttonsPanel.SetActive(false);
        numberPanel.SetActive(true);
    }

    // Convert int number to string function
    private string NumberToText(int value)
    {
        string textNumber = "";

        if (value == 0) textNumber = "cero";
        else if (value == 1) textNumber = "uno";
        else if (value == 2) textNumber = "dos";
        else if (value == 3) textNumber = "tres";
        else if (value == 4) textNumber = "cuatro";
        else if (value == 5) textNumber = "cinco";
        else if (value == 6) textNumber = "seis";
        else if (value == 7) textNumber = "siete";
        else if (value == 8) textNumber = "ocho";
        else if (value == 9) textNumber = "nueve";
        else if (value == 10) textNumber = "diez";
        else if (value == 11) textNumber = "once";
        else if (value == 12) textNumber = "doce";
        else if (value == 13) textNumber = "trece";
        else if (value == 14) textNumber = "catorce";
        else if (value == 15) textNumber = "quince";
        else if (value == 16) textNumber = "dieciséis";
        else if (value < 20) textNumber = "dieci" + NumberToText(value - 10);
        else if (value == 20) textNumber = "veinte";
        else if (value == 22) textNumber = "veintidós";
        else if (value == 23) textNumber = "veintitrés";
        else if (value == 26) textNumber = "veintiséis";
        else if (value < 30) textNumber = "veinti" + NumberToText(value - 20);
        else if (value == 30) textNumber = "treinta";
        else if (value == 40) textNumber = "cuarenta";
        else if (value == 50) textNumber = "cincuenta";
        else if (value == 60) textNumber = "sesenta";
        else if (value == 70) textNumber = "setenta";
        else if (value == 80) textNumber = "ochenta";
        else if (value == 90) textNumber = "noventa";
        else if (value < 100) textNumber = NumberToText(value / 10 * 10) + " y " + NumberToText(value % 10);
        else if (value == 100) textNumber = "cien";
        else if (value < 200) textNumber = "ciento " + NumberToText(value - 100);
        else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) textNumber = NumberToText(value / 100) + "cientos";
        else if (value == 500) textNumber = "quinientos";
        else if (value == 700) textNumber = "setecientos";
        else if (value == 900) textNumber = "novecientos";
        else if (value < 1000) textNumber = NumberToText(value / 100 * 100) + " " + NumberToText(value % 100);
        else textNumber = "mil";

        return textNumber;
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
