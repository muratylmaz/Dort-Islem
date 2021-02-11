using UnityEngine;

namespace QuestionsScripts
{
    public class Division : OperationBase
    {
        public override OperationBase MakeTheOperation()
        {
            number2 = Random.Range(2, 11);
            number1 = number2 * Random.Range(number2, (100 / number2) + 1);

            answer = number1 / number2;
        
            return this;
        }
        
        public override string GetQuestion()
        {
            return number1 + " / " + number2 + " = ?";
        }
    }
}
