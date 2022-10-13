using System.Collections;
using UnityEngine;
using TMPro;

namespace Chars.Tools
{
    public class Counter : MonoBehaviour
    {
        private float currentValue;
        public void SetCurrentValue(float value) => currentValue = value;
        public float GetValue() => currentValue;
        public void Add(float value, int multiplier = 1) => currentValue += value * multiplier;
        public void Substract(float value, int multiplier = 1, bool allowNegative = false) 
        {
            float aux = currentValue - value * multiplier;
            if (!allowNegative)
            {
                if(aux > 0)
                {
                    currentValue = aux;
                }
                else
                {
                    currentValue = 0;
                }
            }
            else
            {
                currentValue = aux;
            }
        }
    }
}