using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    class Algorithms {

        public static void swap<T>(ref T a, ref T b) {
            T temp = a;
            a = b;
            b = temp;
        }

        public static float findOrderStatistic(float[] array, int k) { // QuickSelect

            float[] buffer = new float[array.Length];
            for (int i = 0; i < array.Length; i++) {
                buffer[i] = array[i];
            }

            int l = 0;
            int r = array.Length;

            Random random = new Random();

            while (r - l > 1) {

                int pos = random.Next(l, r);
                float x = buffer[pos];

                swap(ref buffer[pos], ref buffer[r - 1]);

                int l1 = l;
                int r1 = r - 1;

                while (l1 < r1) {
                    while (l1 < r1 && buffer[l1] < x) {
                        ++l1;
                    }

                    while (l1 < r1 && buffer[r1] >= x) {
                        --r1;
                    }

                    if (l1 < r1) {
                        swap(ref buffer[l1], ref buffer[r1]);
                    }
                }

                // l1 == r1 and buffer[l1] >= x

                if (k <= r1) {
                    r = r1 - 1;
                    continue;
                }

                int l2 = r1;
                int r2 = r - 1;

                while (l2 < r2) {

                    while (l2 < r2 && buffer[l2] == x) {
                        ++l2;
                    }

                    while (l2 < r2 && buffer[r2] > x) {
                        --r2;
                    }

                    if (l2 < r2) {
                        swap(ref buffer[l2], ref buffer[r2]);
                    }
                }

                // l1 == r1
                // if exists one or more elements: > x, then buffer[l1] > x
                // else buffer[l1] == x

                if (k <= r2) {
                    return x;
                }

                l = l2;
            }

            return buffer[l];
        }
    }

    class DataStructures {



    }
}
