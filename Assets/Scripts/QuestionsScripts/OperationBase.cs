using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OperationBase
{
    public int number1, number2, answer;

    public abstract OperationBase MakeTheOperation();

    public abstract string GetQuestion();

    public int GetAnswer()
    {
        return answer;
    }
}
