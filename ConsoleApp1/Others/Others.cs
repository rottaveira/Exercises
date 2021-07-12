using System;

namespace Exercises
{
    /// <summary>
    /// Exemplo de delegate e action.
    /// Delegates de certo modo será um Alias para um méthodo.
    /// Action assim como o delegate é um Alias, mas só poderá ser instanciada para um methodo void.
    /// Invoke é uma palavra reservada do delegate,
    ///     pode ser utilizada para deixar claro a chamada, porem pode ser ocultado como nos outros exemplos demonstrados.
    /// </summary>
    public class Example1
    {
        private delegate int MyDelegate(int a, int b);
        private Action<int> _action;

        public Example1()
        {
            MyDelegate somar = Sum;
            _action = new Action<int>(s => Console.WriteLine($@"Action 1: #{s}"));
            _action(somar(1, 2));

            _action = new Action<int>(Imprimir);
            _action(somar(2, 2));

            Console.WriteLine($@"Utilizando Invoke: #{somar.Invoke(5, 5)}");
        }
         
        public int Sum(int a,int b)
        {
            return a + b;
        }

        private void Imprimir(int value)
        {
            Console.WriteLine($@"Action 2: #{value}");
        }

        public static void Run()
        {
            var example1 = new Example1();
        }
    }
}
