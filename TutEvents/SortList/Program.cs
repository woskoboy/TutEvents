using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortList {
    class Program {
        static void Main(string[] args) {
            List<Duck> ducks = new List<Duck> {
                new Duck(17, KindOfDuck.Mallard), new Duck(18, KindOfDuck.Muscovy),
                new Duck(14, KindOfDuck.Decoy), new Duck(11, KindOfDuck.Muscovy),
                new Duck(14, KindOfDuck.Mallard), new Duck(13, KindOfDuck.Decoy)
            };
            List<Bird> birds = new List<Bird> {
                new Bird() { Name = "Floyd" }, new Bird() { Name = "Pinguin" } };

            IEnumerable<Bird> upcastDuck = ducks;
            birds.AddRange(upcastDuck);
            foreach (Bird bird in birds)
                Console.WriteLine(bird);

            Console.WriteLine(new string('-',30));

            ducks.Sort();
            DuckByKind ducksByKind = new DuckByKind();
            ducks.Sort(ducksByKind);
            foreach (Duck duck in ducks)
                Console.WriteLine("{0} size {1}", duck.Kind, duck.Size);

            Console.ReadKey();
        }
    }
    enum KindOfDuck { Mallard, Muscovy, Decoy }

    /* Метод List.Sort() умеет сортировать объекты любого типа
     и классы, которые реализуют интерфейс IComparable<T> */
    class Duck : Bird, IComparable<Duck> {
        public int Size { get; private set; }
        public KindOfDuck Kind { get; private set; }
        public Duck(int size, KindOfDuck kind) {
            Size = size; Kind = kind;
        }
        public int CompareTo(Duck other) {
            if (this.Size < other.Size) return -1;
            else if (this.Size < other.Size) return 1;
            else return 0;
        }
        public override string ToString() {
            return Kind + " " + Size;
        }
    }

    /* IComparer<T> - интерфейс, позволяющий создать отдельный класс для
    сортировки составляющих объекта List<T>. 
    Реализуя интерфейс IComparer<T>, вы объясняете коллекции, каким способом нужно
    упорядочить ее содержимое. Задача выполняется средствами метода Compare(),
    который берет параметры двух объектов x и y и возвращает целое число */
    class DuckByKind : IComparer<Duck> {
        public int Compare(Duck x, Duck y) {
            if (x.Kind < y.Kind) return -1;
            else if (x.Kind < y.Kind) return 1;
            else return 0;
        }
    }

    class Bird {
        public string Name { get; set; }
        public override string ToString() {
            return Name;
        }
    }
}



