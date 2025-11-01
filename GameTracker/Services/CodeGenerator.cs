using GameTracker.Interfaces;
using System.Security.Cryptography;

namespace GameTracker.Services
{
    public class CodeGenerator : ICodeGenerator
    {
        public string GenerateConfirmationCode(Guid userID, int length = 5)
        {
            string result = string.Empty;
            string guid = userID.ToString("N");
            int day = DateTime.Now.DayOfYear;
            int digit;

            for (int i = 0; i < length; i++)
            {
                digit = Convert.ToInt32(guid[i].ToString(), 16);
                result += (digit * day).ToString()[0];
            }

            return result;
        }

        public string GenerateRecoveryCode(Guid userId)
        {
            int min = 100000;
            int max = 999999;
            int code = RandomNumberGenerator.GetInt32(min, max + 1);
            return code.ToString();
        }
    }
}

// GenerateConfirmationCode explication:
// Чет хуево по читаемости, но я даже хз как лучше сделать
// Лучше распишу, как метод работает:
/*
 * Получаем ID юзера, плюс длину кода
 * Преобразуем ID в строку без дефисов
 * Идем в цикл от 0 до длины кода
 * Там берем i-й символ от ID, преобразуем его из 16-ричной системы в 10-ричную, закидываем в digit
 * Умножаем digit на номер дня в году (от 1 до 366), преобразуем в строку и берем первый символ
 * Прибавляем этот символ к результату
 * Получаем в результате строку из цифр длиной length и возвращаем ее
 */
