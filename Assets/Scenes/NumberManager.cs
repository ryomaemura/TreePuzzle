using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText1;
    [SerializeField] TextMeshProUGUI buttonText2;
    [SerializeField] TextMeshProUGUI buttonText3;
    [SerializeField] TextMeshProUGUI buttonText4;
    [SerializeField] TextMeshProUGUI buttonText5;
    [SerializeField] TextMeshProUGUI buttonText6;
    [SerializeField] TextMeshProUGUI buttonText7;
    TextMeshProUGUI[] buttonTexts;
    int[] numbers = {1, 2, 3, 4, 5, 6, 0};
    int[, ] relasionshipNumbers = {
        {0, 1, 1, 0, 0, 0, 0},
        {1, 0, 0, 1, 1, 0, 0},
        {1, 0, 0, 0, 0, 1, 1},
        {0, 1, 0, 0, 0, 0, 0},
        {0, 1, 0, 0, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 0},
        {0, 0, 1, 0, 0, 0, 0},
    };
    int temp = 0;
    int randomNumber1 = 0;
    int randomNumber2 = 0;

    // Start is called before the first frame update
    void Start() {
        buttonTexts = new TextMeshProUGUI[] {buttonText1, buttonText2, buttonText3, buttonText4, buttonText5, buttonText6, buttonText7};

        shuffleNumbers();
        setNumbers();
    }

    // Update is called once per frame
    void Update() {
    }

    public void clickButton(int number) {
        for (int i = 0; i < numbers.Length; i++) {
            if (relasionshipNumbers[number - 1, i] == 1 && numbers[i] == 0) {
                temp = numbers[number - 1];
                numbers[number - 1] = numbers[i];
                numbers[i] = temp;

                buttonTexts[number - 1].text = "";
                buttonTexts[i].text = numbers[i].ToString();
            }
        }
    }

    public void setNumbers() {
        for (int i = 0; i < numbers.Length; i++) {
            if (numbers[i] != 0) {
                buttonTexts[i].text = numbers[i].ToString();
            } else {
                buttonTexts[i].text = "";
            }
        }
    }

    public void shuffleNumbers() {
        for (int i = 0; i < 30; i++) {
            randomNumber1 = UnityEngine.Random.Range(0, numbers.Length);
            randomNumber2 = UnityEngine.Random.Range(0, numbers.Length);

            temp = numbers[randomNumber1];
            numbers[randomNumber1] = numbers[randomNumber2];
            numbers[randomNumber2] = temp;
        }
    }
}
