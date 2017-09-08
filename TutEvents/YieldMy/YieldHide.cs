using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldMy{
    class YieldHide : IEnumerable, IEnumerator{
        private string current = "Hello world";
        public IEnumerator GetEnumerator(){
            return this as IEnumerator;
        }
        public bool MoveNext(){
            return true;
        }
        public object Current{
            get{ return this.current;}
        }
        public void Reset(){ throw new NotImplementedException();}
    }
}
