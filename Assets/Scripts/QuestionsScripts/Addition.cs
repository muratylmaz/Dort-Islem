using UnityEngine;

namespace QuestionsScripts
{
    public class Addition : OperationBase
    {
        public override OperationBase MakeTheOperation()
        {
            number1 = Random.Range(1, 51);
            number2 = Random.Range(1, 51);
        
            answer = number1 + number2;
        
            return this;
        }
        
        public override string GetQuestion()
        {
            return number1 + " + " + number2 + " = ?";
        }
    }
}
