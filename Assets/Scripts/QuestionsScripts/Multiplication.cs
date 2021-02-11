using UnityEngine;

namespace QuestionsScripts
{
    public class Multiplication : OperationBase
    {
        public override OperationBase MakeTheOperation()
        {
            number1 = Random.Range(2, 11);
            number2 = Random.Range(2, 11);

            answer = number1 * number2;
        
            return this;
        }

        public override string GetQuestion()
        {
            return number1 + " x " + number2 + " = ?";
        }
    }
}
