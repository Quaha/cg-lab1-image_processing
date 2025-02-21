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
                worker.ReportProgress(100 * i / result_image.Width);
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

            public InvertFilter() {

            }

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

            public GrayScaleFilter() {

            }

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

            protected int sepia_strength;

            public SepiaFilter(int sepia_strength = 20) {
                this.sepia_strength = sepia_strength;
            }

            protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
                Color source_color = source_image.GetPixel(x, y);

                int intensity = getIntensity(source_color);

                Color result_color = getCorrectColor(255,
                                                     intensity + 2 * sepia_strength,
                                                     intensity + sepia_strength / 2,
                                                     intensity - sepia_strength);
                return result_color;
            }
        }

        class BrightnessFilter: SpotFilter {

            protected int brightness_delta;

            public BrightnessFilter(int brightness_delta = 20) {
                this.brightness_delta = brightness_delta;
            }

            protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
                Color source_color = source_image.GetPixel(x, y);
                Color result_color = getCorrectColor(255,
                                                     source_color.R + brightness_delta,
                                                     source_color.G + brightness_delta,
                                                     source_color.B + brightness_delta);
                return result_color;
            }
        }

        class ShiftFilter : SpotFilter {

            protected int dx, dy;

            public ShiftFilter(int dx = -50, int dy = 50) {
                this.dx = -dx;
                this.dy = dy;
            }

            protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
                if (0 <= x + dx && x + dx < source_image.Width && 0 <= y + dy && y + dy < source_image.Height) {
                    return source_image.GetPixel(x + dx, y + dy);
                }
                return Color.Black;
            }
        }
    }

    abstract class MatrixFilter: Filter {
        protected float[,] kernel = null;
        protected int kernel_width, kernel_height;
        protected int base_dx, base_dy; // Смещение левого верхнего угла ядра относительно текущего пикселя

        protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
            float result_R = 0;
            float result_G = 0;
            float result_B = 0;

            for (int dx = 0; dx < kernel_width; dx++) {
                for (int dy = 0; dy < kernel_height; dy++) {

                    int nx = clamp(x + base_dx + dx, 0, source_image.Width - 1);
                    int ny = clamp(y + base_dy + dy, 0, source_image.Height - 1);

                    Color neighbor_color = source_image.GetPixel(nx, ny);
                    float kernel_coefficient = kernel[dx, dy];
                    result_R += neighbor_color.R * kernel_coefficient;
                    result_G += neighbor_color.G * kernel_coefficient;
                    result_B += neighbor_color.B * kernel_coefficient;
                }
            }

            return getCorrectColor(255, (int)result_R, (int)result_G, (int)result_B);
        }
    }

    namespace MatrixFilters {
        class BlurFilter : MatrixFilter {

            public BlurFilter(int radius = 1) {

                kernel_width = radius * 2 + 1;
                kernel_height = radius * 2 + 1;

                kernel = new float[kernel_width, kernel_height];

                for (int x = 0; x < kernel_width; x++) {
                    for (int y = 0; y < kernel_height; y++) {
                        kernel[x, y] = (float)1 / (kernel_width * kernel_height);
                    }
                }

                base_dx = -radius;
                base_dy = -radius;
            }
        }

        class MotionBlurFilter : MatrixFilter {

            public MotionBlurFilter(int radius = 4) {

                kernel_width = radius * 2 + 1;
                kernel_height = radius * 2 + 1;

                kernel = new float[kernel_width, kernel_height];

                for (int x = 0; x < kernel_width; x++) {
                    kernel[x, x] = (float)1 / kernel_width ;
                }

                base_dx = -radius;
                base_dy = -radius;
            }
        }
    }

    abstract class AdvansedFilter : Filter {

    }

    namespace AdvansedFilters {

    }
}