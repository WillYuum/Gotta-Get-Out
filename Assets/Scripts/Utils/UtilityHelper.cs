using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class UtilityHelper : MonoBehaviour
    {
        public static void ShuffleList<T>(List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                T tmp = list[i];
                int randIndex = Random.Range(0, list.Count);  //By replacing 'i' with 0, you might get a more randomized array.
                list[i] = list[randIndex];
                list[randIndex] = tmp;
            }
        }

        public static void ShuffleArray<T>(T[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                T tmp = array[i];
                int randIndex = Random.Range(0, array.Length);  //By replacing 'i' with 0, you might get a more randomized array.
                array[i] = array[randIndex];
                array[randIndex] = tmp;
            }
        }
    }
}