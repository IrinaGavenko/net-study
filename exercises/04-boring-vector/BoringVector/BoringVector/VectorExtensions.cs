﻿using System;
namespace BoringVector
{
    /*
        Здесь тебе нужно написать класс с методами-расширениями структуры Vector:
            - IsZero: проверяет, является ли вектор нулевым, т.е. его координаты близки к нулю (в эпсилон окрестности). За эпсилон здесь и далее берем 1e-6.
            - Normalize: нормализует вектор
            - GetAngleBetween: возвращает угол между двумя векторами в радианах. Примечание: нулевой вектор сонаправлен любому другому.
            - GetRelation: возвращает значение перечесления VectorRelation(General, Parallel, Orthogonal) - отношение между двумя векторами("общий случай", параллельны, перпендикулярны). Перечисление задавать тоже тебе)
    */

    /// <summary>
    /// Класс расширения структуры <see cref="Vector"/>, реализующий дополнительные операции
    /// </summary>
    class VectorExtensions
    {
        /// <summary>
        /// Проверяет, является ли вектор нулевым
        /// </summary>
        /// <param name="v">Вектор, <see cref="Vector"/></param>
        /// <param name="eps">Допустимый радиус погрешности с центром в нуле, <see cref="double"/></param>
        /// <returns>Ответ: является ли вектор нулевым или нет, <see cref="bool"/></returns>
        public static bool IsZero(Vector v, double eps = 1e-6)
        {
            return v.X<eps && v.Y<eps;
        }
        ///_____________________________________________________________________________________
 
        /// <summary>
        /// Нормализует вектор
        /// </summary>
        /// <param name="v">Начальный вектор, <see cref="Vector"/></param>
        /// <returns>Нормированный вектор, <see cref="Vector"/></returns>
        public static Vector Normalize(Vector v)
        {
            return new Vector(v.X / v.SquareLength(), v.Y / v.SquareLength());
        }
        ///_______________________________________________________________________________________
 
        /// <summary>
        /// Высчитывает угол между двумя векторами (в радианах)
        /// </summary>
        /// <param name="v1">Первый вектор, <see cref="Vector"/></param>
        /// <param name="v2">Второй вектор, <see cref="Vector"/></param>
        /// <returns>Угол между векторами в радианах, <see cref="double"/></returns>
        public static double GetAngleBetween(Vector v1, Vector v2)
        {
            return Math.Acos(v1.CrossProduct(v2));
        }
        ///______________________________________________________________________________________
        
        /// <summary>
        /// Возможные отношения между двумя векторами
        /// </summary>
        public enum VectorRelation
        {
            General, // общий случай
            Parallel, // параллельны
            Orthogonal // перпендикулярны
        }
        ///________________________________________________________________________________________

        /// <summary>
        /// Показывает отношение между двумя векторами
        /// </summary>
        /// <param name="v1">Первый вектор, <see cref="Vector"/></param>
        /// <param name="v2">Второй вектор, <see cref="Vector"/></param>
        /// <param name="eps">Допустимый радиус погрешности, <see cref="double"/></param>
        /// <returns>Ответ: как соотностся вектора <see cref="VectorRelation"/></returns>
        public static VectorRelation GetRelation(Vector v1, Vector v2, double eps = 1e-6)
        {
            if (Math.Abs(GetAngleBetween(v1, v2) - Math.PI / 2) < eps)
            {
                return VectorRelation.Orthogonal;
            }

            if (GetAngleBetween(v1, v2) < eps)
            {
                return VectorRelation.Parallel;
            }

            return VectorRelation.General;
        }
    }
}
