using UnityEngine;

namespace QuestionsScripts
{
    public class Extraction : OperationBase
    {
        public override OperationBase MakeTheOperation()
        {
            number2 = Random.Range(1, 51);
            number1 = Random.Range(number2, 101);

            answer = number1 - number2;

            return this;
        }

        public override string GetQuestion()
        {
            return number1 + " - " + number2 + " = ?";
        }
    }
}
