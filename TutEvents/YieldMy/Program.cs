using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace YieldMy{
    class Program{
        static void Main(string[] args)
        {
            /*IEnumerable collection = (new UserCollectionY()).Power();
            foreach (var el in collection)
                Console.WriteLine(el);*/
            UserCollectionReflector collection = new UserCollectionReflector();
            foreach (Element el in collection)
                 Console.WriteLine("{0} {1} {2}", el.Field, el.Field1, el.Field2);
            Console.ReadLine();
        }
    }
    class UserCollection : IEnumerable, IEnumerator{
        int position = -1;
        Element[] elementsArray = null;
        public UserCollection(){
            elementsArray = new Element[4];
            elementsArray[0] = new Element("A", 1, 10);
            elementsArray[1] = new Element("B", 2, 20);
            elementsArray[2] = new Element("C", 3, 30);
            elementsArray[3] = new Element("D", 4, 40);
        }
        public IEnumerator GetEnumerator(){
            return this as IEnumerator;
        }
        public bool MoveNext(){
            while(position < elementsArray.Length-1){
                position++;
                return true;
            }
            position = -1;
            return false; 
        }
        public object Current{
            get { return elementsArray[position];}
        }
        public void Reset() { throw new NotImplementedException(); }
    }
    class UserCollectionY {
        public IEnumerable Power(){
            yield return "hello world!";
            //return new YieldHide();
        }
    }
    class UserCollectionZ : IEnumerable {
        int position = -1;
        Element[] elementsArray = null;
        public UserCollectionZ(){
            elementsArray = new Element[] { new Element("A", 1, 10), new Element("B", 2, 20), new Element("C", 3, 30)};
        }
        public IEnumerator GetEnumerator() {
            while (true) {
                if (position < elementsArray.Length - 1) {
                    position++;
                    yield return elementsArray[position];
                } else {
                    position = -1;
                    yield break;
                }
            }
        }
    }

    class UserCollectionReflector : IEnumerable {
        private Element[] elementsArray = null;
        private int position = -1;
        public UserCollectionReflector() {
            this.elementsArray = new Element[] { new Element("A", 1, 10),
                new Element("B", 2, 20), new Element("C", 3, 30)};
        }
        public IEnumerator GetEnumerator() {
            ClassGetEnumerator instance = new ClassGetEnumerator(0);
            instance.collection = this;
            return instance;
        }

        // Nested Types
        private sealed class ClassGetEnumerator : IEnumerator<object>, IDisposable, IEnumerator {
            private int state;
            private object current;
            public UserCollectionReflector collection;

            public ClassGetEnumerator(int state) {
                this.state = state;
            }
            public bool MoveNext() {
                switch (this.state) {
                    case 0:
                        this.state = -1; break;
                    case 1:
                        this.state = -1; break;
                    default:
                        return false;
                }
                if (this.collection.position < (this.collection.elementsArray.Length - 1)) {
                    this.collection.position++;
                    this.current = this.collection.elementsArray[this.collection.position];
                    this.state = 1;
                    return true;
                }
                this.collection.position = -1;
                return false;
            }
            void IEnumerator.Reset() { throw new NotSupportedException(); }
            void IDisposable.Dispose() { }
            // Properties
            object IEnumerator<object>.Current { get { return this.current; } }
            object IEnumerator.Current { get { return this.current; } }
        }
    }




}
