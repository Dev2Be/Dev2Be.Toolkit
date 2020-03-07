using Dev2Be.Toolkit.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Dev2Be.Toolkit.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        /// Concatener une ou plusieurs liste dans une même <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="items">Listes d'objets à concatener dans une même <see cref="List{T}"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns></returns>
        public static List<T> Concat<T>(this List<T> list, params List<T>[] items)
        {            
            foreach (List<T> item in items)
            {
                if (item == null)
                    throw new ArgumentNullException();

                list.AddRange(item);
            }

            return list;
        }

        /// <summary>
        /// Retourner tous les élèments d'une liste sous forme de <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string Join<T>(this List<T> list) => list.Join(';');

        /// <summary>
        /// Retourner tous les élèments d'une liste sous forme de <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="separator">Le séparateur entre chaque objet.</param>
        /// <returns></returns>
        public static string Join<T>(this List<T> list, char separator)
        {
            string joinedList = "";

            list.ForEach(delegate (T item)
            {
                joinedList += item.ToString() + separator;
            });

            return joinedList.Trim(separator);
        }

        /// <summary>
        /// Supprimer le premier élément d'une liste et le retourner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T Shift<T>(this List<T> list)
        {
            T item = list[0];

            list.Remove(item);

            return item;
        }

        /// <summary>
        /// Supprimer le dernier élément d'une liste et le retourner.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T Pop<T>(this List<T> list)
        {
            T item = list[list.Count - 1];

            list.Remove(item);

            return item;
        }

        /// <summary>
        /// Récupère un objet aléatoire venant de la <see cref="List{T}"/>.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <return></returns>
		public static T GetRandomValue<T>(this IList<T> list) => list[new Random().Next(list.Count)];

        /// <summary>
        /// Mélangez une <see cref="List{T}"/> donnée en utilisant l'algorithme de Fisher-Yates.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = new Random().Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Permuter deux objets dans une <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="firstIndex">Le premier objet à permuter.</param>
        /// <param name="secondIndex">Le second objet à permuter</param>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public static void Swap<T>(this List<T> list, int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex > list.Count) throw new ArgumentOutOfRangeException("firstIndex");
            if (secondIndex < 0 || secondIndex > list.Count) throw new ArgumentOutOfRangeException("secondIndex");

            T item = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = item;
        }

        /// <summary>
        /// Permuter l'intégralité des objets d'une <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="flowDirection">Le sens de permutation de la <see cref="List{T}"/>.</param>
        /// <returns></returns>
        public static List<T> Permutate<T>(this List<T> list, FlowDirection flowDirection)
        {
            List<T> permutatedList = list;

            if (flowDirection == FlowDirection.LeftToRight)
                for (int i = list.Count - 1; i > 0; i--)
                    permutatedList.Swap((i - 1 < 0) ? list.Count - 1 : i - 1, i);
            else
                for (int i = 0; i < list.Count - 1; i++)
                    permutatedList.Swap(i, (i - 1 < 0) ? list.Count - 1 : i - 1);
            
            return permutatedList;          
        }

        /// <summary>
        /// Ajouter un objet à la fin de la <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item">Objet à rajouter à la fin de la <see cref="List{T}"/>.</param>
        /// <param name="addIfExists">Ajouter ou non l'objet en fonction de son existance dans la liste.</param>
        public static void Add<T>(this List<T> list, T item, bool addIfExists)
        {
            if (item == null) throw new ArgumentNullException("item");

            if (addIfExists)
                list.Add(item);
            else
                list.Add(item, new DefaultComparer<T>());
        }

        /// <summary>
        /// Ajouter un objet à la fin de la <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="item">Objet à rajouter à la fin de la <see cref="List{T}"/>.</param>
        /// <param name="comparer">Comparateur d'égalité à l'aide duquel comparer des valeurs.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Add<T>(this List<T> list, T item, IEqualityComparer<T> comparer)
        {
            if (item == null) throw new ArgumentNullException("item");

            if (comparer == null) throw new ArgumentNullException("comparer");

            if (!list.Contains(item, comparer))
                list.Add(item);
        }

        /// <summary>
        /// Ajoute les éléments de la collection spécifiée à la fin de la <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="items">Collection dont les éléments devraient être ajoutés à la fin de la <see cref="List{T}"/>.</param>
        /// <param name="addIfExists">Ajouter ou non l'objet en fonction de son existance dans la liste.</param>
        public static void AddRange<T>(this List<T> list, IEnumerable<T> items, bool addIfExists)
        {
            if (items == null) throw new ArgumentNullException("items");

            foreach (T item in items) 
                list.Add(item, addIfExists);
        }

        /// <summary>
        /// Ajoute les éléments de la collection spécifiée à la fin de la <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="items">Collection dont les éléments devraient être ajoutés à la fin de la <see cref="List{T}"/>.</param>
        /// <param name="comparer">Comparateur d'égalité à l'aide duquel comparer des valeurs.</param>
        public static void AddRange<T>(this List<T> list, IEnumerable<T> items, IEqualityComparer<T> comparer)
        {
            if (items == null) throw new ArgumentNullException("items");

            if (comparer == null) throw new ArgumentNullException("comparer");

            foreach (T item in items) 
                list.Add(item, comparer);
        }

        /// <summary>
        /// Ajoute les éléments de la collection spécifiée à la fin de la <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="addIfExists">Ajouter ou non l'objet en fonction de son existance dans la liste.</param>
        /// <param name="elements">Liste d'éléments qui devraient être ajoutés à la fin de la <see cref="List{T}"/>.</param>
        public static void AddRange<T>(this List<T> list, bool addIfExists, params T[] elements)
        {
            if (elements == null) throw new ArgumentNullException("elements");

            foreach (var element in elements) 
                list.Add(element, addIfExists);
        }

        /// <summary>
        /// Ajoute les éléments de la collection spécifiée à la fin de la <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="comparer">Comparateur d'égalité à l'aide duquel comparer des valeurs.</param>
        /// <param name="elements">Liste d'éléments qui devraient être ajoutés à la fin de la <see cref="List{T}"/>.</param>
        public static void AddRangeIfNotExists<T>(this List<T> list, IEqualityComparer<T> comparer, params T[] elements)
        {
            if (comparer == null) throw new ArgumentNullException("comparer");

            if (elements == null) throw new ArgumentNullException("elements");

            foreach (var element in elements) 
                list.Add(element, comparer);
        }
    }
}
