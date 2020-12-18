using System;

namespace RecursionAlgorithms
{
    public static class Algorithms
    {
        /*ПОДМНОЖЕСТВА*/
        // Пример применения алгоритма.
        // Из исходного множества, нужно найти поднможества, удовлетворяющие некоторым свойствам. Например,
        // нужно разделить украденные из музея ценности на две кучки, равные по цене.
        /// <summary>
        /// Разбиваем множество на всевозможные подмножества
        /// </summary>
        /// <param name="subset">Исходное множество</param>
        /// <param name="position">Позиция, которую рассматриваем в данный момент</param>
        public static void MakeSubsets(bool[] subset, int position)
        {
            if (position == subset.Length)
            {
                foreach (var e in subset)
                    Console.Write(e ? 1 : 0);
                Console.WriteLine();
                return;
            }
            subset[position] = true;
            MakeSubsets(subset, position + 1);
            subset[position] = false;
            MakeSubsets(subset, position + 1);
        }

        /*ПЕРЕСТАНОВКИ*/
        // Пример применения алгоритма.
        // Нужно найти перестановку, удовлетворяющую определенному свойству. Например,
        // задача Комивояжора, нужно найти последовательность городов, чтобы расстояние оказалось минимальным.
        /// <summary>
        /// Находим всевозможные перестановки элементов исходного множества
        /// </summary>
        /// <param name="permutation">Исходное множество</param>
        /// <param name="position">Позиция, которую рассматриваем в данный момент</param>
        public static void MakePermutation(int[] permutation, int position)
        {
            if(position == permutation.Length)
            {
                foreach (var e in permutation)
                    Console.Write(e + " ");
                Console.WriteLine();
                return;
            }
            for(int i = 0; i<permutation.Length; i++)
            {
                bool found = false;
                for(int j = 0; j<position; j++)
                {
                    if(permutation[j] == i)
                    {
                        found = true;
                        break;
                    }
                }
                if (found) continue;

                permutation[position] = i;
                MakePermutation(permutation, position + 1);
            }
        }

        /*РАЗМЕЩЕНИЯ*/
        // Пример применения алгоритма.
        // Нужно найти размещения трех яблок в пяти корзинах.
        /// <summary>
        /// Находим всевозможные размещения данных элементов в исходном множестве
        /// </summary>
        /// <param name="combination">Исходное множество</param>
        /// <param name="elementsLeft">Элементы, которые нужно разместить</param>
        /// <param name="position">Позиция, которую рассматриваем в данный момент</param>
        public static void MakeCombinations(bool[] combination, int elementsLeft, int position)
        {

            if (elementsLeft == 0)
            {
                for (int i = position; i < combination.Length; i++)
                    combination[i] = false;
                foreach (var c in combination)
                    Console.Write((c ? 1 : 0) + " ");
                Console.WriteLine();
                return;
            }
            if (position == combination.Length)
                return;

            combination[position] = false;
            MakeCombinations(combination, elementsLeft, position + 1);
            combination[position] = true;
            MakeCombinations(combination, elementsLeft - 1, position + 1);
        }
    }
}
