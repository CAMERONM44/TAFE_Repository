using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopJayExample : MonoBehaviour
{
    public int[] numbers = new int[10] { 0,1,2,3,4,5,6,7,8,9};


    void Start()
    {
        int[] holdOnToNumbersAsWeLoop = new int[numbers.Length];

        for(int i = 0; i < numbers.Length; i++) 
        {
            holdOnToNumbersAsWeLoop[i] = numbers[numbers.Length - (1 + i)];
        }
        numbers = holdOnToNumbersAsWeLoop;
    }

   
}
