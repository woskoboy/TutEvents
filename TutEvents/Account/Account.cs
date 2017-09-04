using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    class Account
    {
        int _sum; // Переменная для хранения суммы
        int _percentage; // Переменная для хранения процента
        // Объявляем делегат
        public delegate void AccountStateHandler(string massage);
        // Создаем переменную делегата
        AccountStateHandler del;
        // Регистрируем делегат
        public void RegisterHandler(AccountStateHandler _del){
            del = _del;
        }
        public Account(int sum, int percentage){
            _sum = sum;
            _percentage = percentage;
        }
        public int CurrentSum{
            get { return _sum; }
        }
        public void Put(int sum){
            _sum += sum;
        }
        public void Withdraw(int sum){
            if (sum <= _sum){
                _sum -= sum;
                if (del != null)
                    del("Списано" + sum + "рублей");
            } else{
                if (del != null) del("Недостаточно денег");
            }
        }
        public int Percentage{
            get { return _percentage; }
        }
    }

}
