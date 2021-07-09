using System;

namespace Exercises
{
    /*
        Modify the field declarations of the Bicycle class so that:
        The value of the private static field wheelCount cannot be modified after declaration.
        The value of the private field owner cannot be modified after it has been initialized in the constructor.
    */
    public class Bicycle
    {
        /*
         *  1- uma constante não pode ser alterada após ser definida - statica por padrão
         *  2- readonly não pode ser modificado após ser definido pelo construtor.
         */
        const int wheelCount = 2;
        private readonly string owner;

        public Bicycle(string owner)
        {
            this.owner = owner;
        }
    }
}
