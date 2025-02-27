using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEditor {

    public struct RawColor {
        public float A, R, G, B;

        public RawColor(float A, float R, float G, float B) {
            this.A = A;
            this.R = R;
            this.G = G;
            this.B = B;
        }

        public Color ToColor() {
            return Color.FromArgb(
                Filter.clamp((int)A),
                Filter.clamp((int)R),
                Filter.clamp((int)G),
                Filter.clamp((int)B)
            );
        }

        public static RawColor FromColor(Color c) {
            return new RawColor(c.A, c.R, c.G, c.B);
        }

        public static RawColor[,] BitmapToArray(Bitmap bitmap) {
            int width = bitmap.Width;
            int height = bitmap.Height;

            RawColor[,] array = new RawColor[width, height];

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    array[x, y] = FromColor(bitmap.GetPixel(x, y));
                }
            }
            return array;
        }

        public static Bitmap ArrayToBitmap(RawColor[,] array) {
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            Bitmap bitmap = new Bitmap(width, height);

            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    bitmap.SetPixel(x, y, array[x, y].ToColor());
                }
            }
            return bitmap;
        }

        public static void makeCorrect(RawColor[,] array) {
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    RawColor c = array[i, j];
                    array[i, j] = new RawColor(Filter.clamp(c.A),
                                                Filter.clamp(c.R),
                                                Filter.clamp(c.G),
                                                Filter.clamp(c.B));
                }
            }
        }
    }
}
