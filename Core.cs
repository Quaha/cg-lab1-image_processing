using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
    class Algorithms {

        public static float findOrderStatistic(float[] array, int k) {

            float[] buffer = new float[array.Length];
            for (int i = 0; i < array.Length; i++) {
                buffer[i] = array[i];
            }

            float[] lower_buffer = new float[array.Length];
            float[] upper_buffer = new float[array.Length];

            int s1, s2;
            int equal_cnt;

            upper_buffer = new float[array.Length];

            int l = 0;
            int r = array.Length;

            Random random = new Random();

            while (r - l > 1) {

                int p = random.Next(l, r);
                float x = buffer[p];

                s1 = 0;
                s2 = 0;

                equal_cnt = 0;

                for (int i = l; i < r; i++) {
                    if (buffer[i] < x) {
                        lower_buffer[s1++] = buffer[i];
                    }
                    else if (buffer[i] > x) {
                        upper_buffer[s2++] = buffer[i];
                    }
                    else {
                        equal_cnt++;
                    }
                }

                if (k < s1) {

                    l = 0;
                    r = s1;

                    for (int i = 0; i < s1; i++) {
                        buffer[i] = lower_buffer[i];
                    }

                }
                else if (k >= s1 + equal_cnt) {
                    l = s1 + equal_cnt;
                    r = s1 + equal_cnt + s2;

                    for (int i = 0; i < s2; i++) {
                        buffer[s1 + equal_cnt + i] = upper_buffer[i];
                    }

                    k -= s1 + equal_cnt;
                }
                else {
                    return x;
                }
            }

            return buffer[l];

        }
    }

    class DataStructures {



    }
}
