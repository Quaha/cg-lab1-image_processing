using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace PhotoEditor {
    abstract class Filter {
        public static int clamp(int value, int min = 0, int max = 255) { // [min, max]
            if (value < min) {
                return min;
            }
            if (value > max) {
                return max;
            }
            return value;
        }

        public static int getIntensity(Color color) {
            int intensity = (299 * color.R + 587 * color.G + 114 * color.B) / 1000;
            return intensity;
        }

        public static Color getCorrectColor(int alpha, int R, int G, int B) {
            return Color.FromArgb(clamp(alpha),
                                  clamp(R),
                                  clamp(G),
                                  clamp(B));
        }

        protected abstract Color calculateNewPixelColor(Bitmap source_image, int x, int y);

        public Bitmap processImage(Bitmap source_image, BackgroundWorker worker) {
            Bitmap result_image = new Bitmap(source_image.Width, source_image.Height);

            for (int i = 0; i < source_image.Width; i++) {
                worker.ReportProgress((int)(((float)i/ result_image.Width * 100)));
                for (int j = 0; j < source_image.Height; j++) {
                    result_image.SetPixel(i, j, calculateNewPixelColor(source_image, i, j));
                }
            }

            return result_image;
        }
    }

    abstract class SpotFilter: Filter {

    }

    namespace SpotFilters {
        class InvertFilter : SpotFilter {
            protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
                Color source_color = source_image.GetPixel(x, y);
                    
                Color result_color = getCorrectColor(255,
                                                     255 - source_color.R,
                                                     255 - source_color.G,
                                                     255 - source_color.B);
                return result_color;
            }
        }

        class GrayScaleFilter : SpotFilter {
            protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
                Color source_color = source_image.GetPixel(x, y);

                int intensity = getIntensity(source_color);

                Color result_color = getCorrectColor(255,
                                                     intensity,
                                                     intensity,
                                                     intensity);
                return result_color;
            }
        }

        class SepiaFilter: SpotFilter {
            protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
                Color source_color = source_image.GetPixel(x, y);

                int intensity = getIntensity(source_color);
                int k = 20;

                Color result_color = getCorrectColor(255,
                                                     intensity + 2 * k,
                                                     intensity + k / 2,
                                                     intensity - k);
                return result_color;
            }
        }
    }

    abstract class MatrixFilter: Filter {
        
    }

    namespace MatrixFilters {

    }
}