using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covariant4App
{
    class Program
    {
        static void Main(string[] args)
        {
            var bears = new Stack<Bear>();
            var camel = new Stack<Camel>();
            IMoveable<Animal> animal = new Stack<Animal>();

            bears.Push();
            bears.Pop();
            IPoppable<Animal> animals1 = bears;
            IPushable<Animal> animals2 = camel;
            //IMoveable<Bear> bears1 = animal;
            IMoveable<Bear> bears1 = animal;
            animals1.Pop();
            animals2.Push();
            bears1.Move(new Bear());
        }


    }
    public interface IPoppable<out T> { T Pop(); }
    public interface IMoveable<in T> { void Move(T obj); }
    public interface IPushable<out T> { void Push(); }
    class Animal { }

    class Bear : Animal { }

    class Camel : Animal { }
    /// <summary>
    /// 1
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T> : IPoppable<T>, IPushable<T>, IMoveable<T>
    {
        int position;
        T[] data = new T[100];

        public void Move(T obj)
        {
            throw new NotImplementedException();
        }
        public T Pop() => data[--position];

        public void Push()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// 2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //public class Stack<T>
    //{
    //    int position;
    //    T[] data = new T[100];
    //    public void Push(T obj) => data[position++] = obj;
    //    public T Pop() => data[--position];
    //}

}
