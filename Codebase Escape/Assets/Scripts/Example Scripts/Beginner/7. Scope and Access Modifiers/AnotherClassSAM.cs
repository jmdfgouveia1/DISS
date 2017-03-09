using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherClassSAM {

    public int apples = 5;
    public int bananas = 10;


    private int stapler;
    private int sellotape;


    public void FruitMachine(int a, int b)
    {
        int answer;
        answer = a + b;
        Debug.Log("Fruit total: " + answer);
    }


    private void OfficeSort(int a, int b)
    {
        int answer;
        answer = a + b;
        Debug.Log("Office Supplies total: " + answer);
    }
}
