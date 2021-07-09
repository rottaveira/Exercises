using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq; 

namespace Exercises
{
    public class Platformer
    { 
        public static void Run()
        {
            var p = new Platformer();

            p.TestSmall((tiles, position) => new PlatformerFast(tiles, position));
            p.TestSmall((tiles, position) => new PlatformerSlow(tiles, position));

            p.TestLarge((tiles, position) => new PlatformerSlow(tiles, position));
            p.TestLarge((tiles, position) => new PlatformerFast(tiles, position));
        }

        public void TestSmall(Func<int, int, IPlatformer> build)
        {
            IPlatformer platformer = build(6, 3);
            Debug.Assert(platformer.Position() == 3);

            platformer.JumpLeft();
            Debug.Assert(platformer.Position() == 1);

            platformer.JumpRight();
            Debug.Assert(platformer.Position() == 4);
        }

        public void TestLarge(Func<int, int, IPlatformer> build)
        {
            Console.WriteLine("Running large test...");

            const int tiles = 1000000;//int.MaxValue / 2;
            const int center = tiles / 2;

            IPlatformer platformer = build(tiles, center + 3);
            Debug.Assert(platformer.Position() == center + 3);

            var watch = Stopwatch.StartNew();

            platformer.JumpLeft();
            Debug.Assert(platformer.Position() == center + 1);

            platformer.JumpRight();
            Debug.Assert(platformer.Position() == center + 4);

            platformer.JumpRight();
            Debug.Assert(platformer.Position() == center + 6);

            platformer.JumpRight();
            Debug.Assert(platformer.Position() == center + 8);

            platformer.JumpLeft();
            Debug.Assert(platformer.Position() == center + 5);

            platformer.JumpLeft();
            Debug.Assert(platformer.Position() == center + 0);

            platformer.JumpRight();
            Debug.Assert(platformer.Position() == center + 7);

            platformer.JumpRight();
            Debug.Assert(platformer.Position() == center + 10);

            platformer.JumpRight();
            Debug.Assert(platformer.Position() == center + 12);

            platformer.JumpLeft();
            Debug.Assert(platformer.Position() == center + 9);

            Console.WriteLine($"{platformer.GetType().Name} completes in {watch.ElapsedMilliseconds} ms");
        }
    }
    public interface IPlatformer
    {
        void JumpLeft();

        void JumpRight();

        int Position();
    }
    public class PlatformerSlow : IPlatformer
    {
        private const int _stepsPerJump = 2;

        private int _currentPosition;

        private List<int> _remainingTiles;

        public PlatformerSlow(int numberOfTiles, int position)
        {
            _currentPosition = position;
            _remainingTiles = Enumerable.Range(0, numberOfTiles).ToList();
        }

        public void JumpLeft()
        {
            var index = _remainingTiles.IndexOf(_currentPosition);
            _remainingTiles.RemoveAt(index);
            _currentPosition = _remainingTiles[index - 2];
        }

        public void JumpRight()
        {
            var index = _remainingTiles.IndexOf(_currentPosition);
            _remainingTiles.RemoveAt(index);
            _currentPosition = _remainingTiles[index + 1];
        }

        public int Position()
        {
            return _currentPosition;
        }
    }

    public class PlatformerFast : IPlatformer
    {
        private const int _stepsPerJump = 2;

        private int _currentIndex;

        private List<int> _remainingTiles;

        public PlatformerFast(int numberOfTiles, int position)
        {
            _currentIndex = position;
            _remainingTiles = Enumerable.Range(0, numberOfTiles).ToList();
        }

        public void JumpLeft()
        {
            _remainingTiles.RemoveAt(_currentIndex);
            _currentIndex -= 2;
        }

        public void JumpRight()
        {
            _remainingTiles.RemoveAt(_currentIndex);
            _currentIndex += 1;
        }

        public int Position()
        {
            return _remainingTiles[_currentIndex];
        }
    }
}
