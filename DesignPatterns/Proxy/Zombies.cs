using System;
using System.Collections.Generic;

namespace DesignPatterns.Proxy
{
    public class Zombies
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Zombies(int size)
        {
            this.size = size;
            age = new Byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct ZombieProxy
        {
            private readonly Zombies zombies;
            private readonly int index;

            public ZombieProxy(Zombies zombies, int index){
                this.zombies = zombies;
                this.index = index;
            }

            public ref byte Age => ref zombies.age[index];
            public ref int X => ref zombies.x[index];
            public ref int Y => ref zombies.y[index];

        }

        public IEnumerator<ZombieProxy> GetEnumerator(){
            for (int pos = 0; pos < size; ++pos)
                yield return new ZombieProxy(this, pos);
        }
    }
}