using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using PhotoEditor.SpotFilters;
using PhotoEditor.AdvancedFilters.EmbossingCore;

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
            int intensity = (299 * color.R + 587 * color.G + 114 * color.B + 500) / 1000;
            return clamp(intensity, 0, 255);
        }

        public static Color getCorrectColor(int alpha, int R, int G, int B) {
            return Color.FromArgb(clamp(alpha),
                                  clamp(R),
                                  clamp(G),
                                  clamp(B));
        }

        protected abstract Color calculateNewPixelColor(Bitmap source_image, int x, int y);

        public virtual Bitmap processImage(Bitmap source_image, BackgroundWorker worker) {
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

        class GrayWorldFilter : SpotFilter {

            protected float average_R, average_G, average_B;
            protected float average;

            public GrayWorldFilter() {

            }

            protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
                Color source_color = source_image.GetPixel(x, y);

                Color result_color = getCorrectColor(255,
                                                     (int)(source_color.R * average / average_R),
                                                     (int)(source_color.G * average / average_G),
                                                     (int)(source_color.B * average / average_B));
                return result_color;
            }

            public override Bitmap processImage(Bitmap source_image, BackgroundWorker worker) {
                Bitmap result_image = new Bitmap(source_image.Width, source_image.Height);

                int sum_R = 0;
                int sum_G = 0;
                int sum_B = 0;

                for (int i = 0; i < source_image.Width; i++) {
                    worker.ReportProgress(50 * i / result_image.Width);
                    for (int j = 0; j < source_image.Height; j++) {
                        Color current_pixel = source_image.GetPixel(i, j);
                        sum_R += current_pixel.R;
                        sum_G += current_pixel.G;
                        sum_B += current_pixel.B;
                    }
                }

                int total = source_image.Width * source_image.Height;

                average_R = (float)sum_R / (float)total;
                average_G = (float)sum_G / (float)total;
                average_B = (float)sum_B / (float)total;

                average = (average_R + average_G + average_B) / (float)3;

                for (int i = 0; i < source_image.Width; i++) {
                    worker.ReportProgress(50 + 50 * i / result_image.Width);
                    for (int j = 0; j < source_image.Height; j++) {
                        result_image.SetPixel(i, j, calculateNewPixelColor(source_image, i, j));
                    }
                }

                return result_image;
            }
        }

        class AutolevelsFilter: SpotFilter {

            protected int min_R, min_G, min_B;
            protected int max_R, max_G, max_B;

            public AutolevelsFilter() {

            }

            protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
                Color source_color = source_image.GetPixel(x, y);

                int new_R = (int)((float)255 * (source_color.R - min_R) / (max_R - min_R));
                int new_G = (int)((float)255 * (source_color.G - min_G) / (max_G - min_G));
                int new_B = (int)((float)255 * (source_color.B - min_B) / (max_B - min_B));
                 

                Color result_color = getCorrectColor(255,
                                                     new_R,
                                                     new_G,
                                                     new_B);
                return result_color;
            }

            public override Bitmap processImage(Bitmap source_image, BackgroundWorker worker) {
                Bitmap result_image = new Bitmap(source_image.Width, source_image.Height);

                min_R = 255; min_G = 255; min_B = 255;
                max_R = 0; max_G = 0; max_B = 0;

                for (int i = 0; i < source_image.Width; i++) {
                    worker.ReportProgress(50 * i / result_image.Width);
                    for (int j = 0; j < source_image.Height; j++) {
                        Color current_pixel = source_image.GetPixel(i, j);
                        min_R = Math.Min(current_pixel.R, min_R);
                        min_G = Math.Min(current_pixel.G, min_G);
                        min_B = Math.Min(current_pixel.B, min_B);

                        max_R = Math.Max(current_pixel.R, max_R);
                        max_G = Math.Max(current_pixel.G, max_G);
                        max_B = Math.Max(current_pixel.B, max_B);
                    }
                }

                for (int i = 0; i < source_image.Width; i++) {
                    worker.ReportProgress(50 + 50 * i / result_image.Width);
                    for (int j = 0; j < source_image.Height; j++) {
                        result_image.SetPixel(i, j, calculateNewPixelColor(source_image, i, j));
                    }
                }

                return result_image;
            }
        }

        class PerfectReflectorFilter: SpotFilter {

            protected int max_R, max_G, max_B;

            public PerfectReflectorFilter() {

            }

            protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
                Color source_color = source_image.GetPixel(x, y);

                int new_R = (int)((float)255 * source_color.R / max_R);
                int new_G = (int)((float)255 * source_color.G / max_G);
                int new_B = (int)((float)255 * source_color.B / max_B);


                Color result_color = getCorrectColor(255,
                                                     new_R,
                                                     new_G,
                                                     new_B);
                return result_color;
            }

            public override Bitmap processImage(Bitmap source_image, BackgroundWorker worker) {
                Bitmap result_image = new Bitmap(source_image.Width, source_image.Height);

                max_R = 0; max_G = 0; max_B = 0;

                for (int i = 0; i < source_image.Width; i++) {
                    worker.ReportProgress(50 * i / result_image.Width);
                    for (int j = 0; j < source_image.Height; j++) {
                        Color current_pixel = source_image.GetPixel(i, j);
                        max_R = Math.Max(current_pixel.R, max_R);
                        max_G = Math.Max(current_pixel.G, max_G);
                        max_B = Math.Max(current_pixel.B, max_B);
                    }
                }

                for (int i = 0; i < source_image.Width; i++) {
                    worker.ReportProgress(50 + 50 * i / result_image.Width);
                    for (int j = 0; j < source_image.Height; j++) {
                        result_image.SetPixel(i, j, calculateNewPixelColor(source_image, i, j));
                    }
                }

                return result_image;
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
                    result_R += kernel_coefficient * neighbor_color.R;
                    result_G += kernel_coefficient * neighbor_color.G;
                    result_B += kernel_coefficient * neighbor_color.B;
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

            public MotionBlurFilter(int radius = 1) {

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

    abstract class AdvancedFilter : Filter {
        protected Filter[] filters;

        protected override Color calculateNewPixelColor(Bitmap source_image, int x, int y) {
            Color source_color = source_image.GetPixel(x, y);
            return Color.Black;
        }

        public override Bitmap processImage(Bitmap source_image, BackgroundWorker worker) {
            Bitmap result_image = new Bitmap(source_image.Width, source_image.Height);
            result_image = source_image;

            for (int i = 0; i < filters.Length; i++) {
                worker.ReportProgress(100 * i / filters.Length);
                result_image = filters[i].processImage(result_image, worker);
            }

            return result_image;
        }

    }

    namespace AdvancedFilters {

        namespace EmbossingCore {
            class EmbrossingCoreFilter1: MatrixFilter {
                public EmbrossingCoreFilter1() {
                    kernel_width = 3;
                    kernel_height = 3;

                    kernel = new float[kernel_width, kernel_height];

                    for (int i = 0; i < 3; i++) {
                        for (int j = 0; j < 3; j++) {
                            kernel[i, j] = 0;
                        }
                    }

                    kernel[0, 1] = 1;
                    kernel[1, 0] = -1;
                    kernel[1, 2] = 1;
                    kernel[2, 1] = -1;

                    base_dx = -1;
                    base_dy = -1;
                }
            }
        }

        class EmbossingFilter: AdvancedFilter {
            public EmbossingFilter() {
                filters = new Filter[] {
                    new EmbrossingCoreFilter1(),
                    new BrightnessFilter(100),
                    new GrayScaleFilter(),
                };
            }
        }
    }
}