using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using PhotoEditor.SpotFilters;
using System.Windows.Forms.Design;
using PhotoEditor;
using Core;

namespace PhotoEditor {
    public class FilterParameter {
        public string param_name { get; }
        public Type param_type { get; }
        public object default_value { get; }
        public object min_value { get; } // [
        public object max_value { get; } // ]

        public FilterParameter(string param_name, Type param_type, object default_value, object min_value, object max_value) {
            this.param_name = param_name;
            this.param_type = param_type;
            this.default_value = default_value;
            this.min_value = min_value;
            this.max_value = max_value;
        }
    }

    abstract class Filter {

        protected static string name;

        public static string getName() {
            return name;
        }

        public static int clamp(int value, int min = 0, int max = 255) { // [min, max]
            if (value < min) {
                return min;
            }
            if (value > max) {
                return max;
            }
            return value;
        }

        public static float clamp(float value, float min = 0, float max = 255) { // [min, max]
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

        public static float getIntensity(RawColor color) {
            float intensity = 0.299f * color.R + 0.587f * color.G + 0.114f * color.B;
            return intensity;
        }

        protected abstract RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y);

        public virtual RawColor[,] processImageRaw(RawColor[,] source_image, BackgroundWorker worker) {
            int width = source_image.GetLength(0);
            int height = source_image.GetLength(1);

            RawColor[,] result_image = new RawColor[width, height];

            for (int i = 0; i < width; i++) {
                worker.ReportProgress(100 * i / width);
                for (int j = 0; j < height; j++) {
                    result_image[i, j] = calculateNewPixelColor(source_image, i, j);
                }
            }

            return result_image;
        }

        public virtual Bitmap processImage(Bitmap source_image, BackgroundWorker worker) {
            RawColor[,] temp_image = RawColor.BitmapToArray(source_image);
            temp_image = processImageRaw(temp_image, worker);
            return RawColor.ArrayToBitmap(temp_image);
        }
    }

    abstract class SpotFilter: Filter {

    }

    namespace SpotFilters {

        class InversionFilter : SpotFilter {

            public InversionFilter(Dictionary<string, object> parameters) {
                name = "Inversion";
            }

            public InversionFilter() {
                name = "Inversion";
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                RawColor source_color = source_image[x, y];

                RawColor result_color = new RawColor(source_color.A,
                                                     255 - source_color.R,
                                                     255 - source_color.G,
                                                     255 - source_color.B);
                return result_color;
            }
        }

        class GrayScaleFilter : SpotFilter {

            public GrayScaleFilter(Dictionary<string, object> parameters) {
                name = "GrayScale";
            }

            public GrayScaleFilter() {
                name = "GrayScale";
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                RawColor source_color = source_image[x, y];

                float intensity = getIntensity(source_color);

                RawColor result_color = new RawColor(source_color.A,
                                                     intensity,
                                                     intensity,
                                                     intensity);
                return result_color;
            }
        }

        class SepiaFilter: SpotFilter {

            protected int sepia_strength;

            public SepiaFilter(Dictionary<string, object> parameters) {
                name = "Sepia";

                this.sepia_strength = (int)parameters["Sepia Strength"];
            }

            public SepiaFilter(int sepia_strength = 20) {
                name = "Sepia";

                this.sepia_strength = sepia_strength;
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {
                    new FilterParameter("Sepia Strength", typeof(int), 20, -255, 255)
                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                RawColor source_color = source_image[x, y];

                float intensity = getIntensity(source_color);

                RawColor result_color = new RawColor(source_color.A,
                                                     intensity + 2 * sepia_strength,
                                                     intensity + sepia_strength / 2,
                                                     intensity - sepia_strength);
                return result_color;
            }
        }

        class BrightnessFilter: SpotFilter {

            protected int brightness_delta;

            public BrightnessFilter(Dictionary<string, object> parameters) {
                name = "Brightness";

                this.brightness_delta = (int)parameters["Brightness Delta"];
            }

            public BrightnessFilter(int brightness_delta = 20) {
                name = "Brightness";

                this.brightness_delta = brightness_delta;
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {
                    new FilterParameter("Brightness Delta", typeof(int), 20, -255, 255)
                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                RawColor source_color = source_image[x, y];

                RawColor result_color = new RawColor(source_color.A,
                                                     source_color.R + brightness_delta,
                                                     source_color.G + brightness_delta,
                                                     source_color.B + brightness_delta);
                return result_color;
            }
        }

        class ShiftFilter : SpotFilter {

            protected int dx, dy;

            public ShiftFilter(Dictionary<string, object> parameters) {
                name = "Shift";

                this.dx = -(int)parameters["X offset"];
                this.dy = (int)parameters["Y offset"];
            }

            public ShiftFilter(int dx = 0, int dy = 0) {
                name = "Shift";

                this.dx = -dx;
                this.dy = dy;
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {
                    new FilterParameter("X offset", typeof(int), 0, int.MinValue, int.MaxValue),
                    new FilterParameter("Y offset", typeof(int), 0, int.MinValue, int.MaxValue)
                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                int width = source_image.GetLength(0);
                int height = source_image.GetLength(1);

                RawColor result_color;

                if (0 <= x + dx && x + dx < width && 0 <= y + dy && y + dy < height) {
                    result_color = source_image[x + dx, y + dy];
                }
                else {
                    result_color = new RawColor(0, 0, 0, 0);
                }

                return result_color;
            }
        }

        class GrayWorldFilter : SpotFilter {

            protected float average_R, average_G, average_B;
            protected float average;

            public GrayWorldFilter(Dictionary<string, object> parameters) {
                name = "GrayWorld";
            }

            public GrayWorldFilter() {
                name = "GrayWorld";
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }


            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                RawColor source_color = source_image[x, y];

                RawColor result_color = new RawColor(source_color.A,
                                                    (source_color.R * average / average_R),
                                                    (source_color.G * average / average_G),
                                                    (source_color.B * average / average_B));
                return result_color;
            }

            public override RawColor[,] processImageRaw(RawColor[,] source_image, BackgroundWorker worker) {
                int width = source_image.GetLength(0);
                int height = source_image.GetLength(1);

                float sum_R = 0;
                float sum_G = 0;
                float sum_B = 0;

                for (int i = 0; i < width; i++) {
                    worker.ReportProgress(50 * i / width);
                    for (int j = 0; j < height; j++) {
                        RawColor current_color = source_image[i, j];

                        sum_R += current_color.R;
                        sum_G += current_color.G;
                        sum_B += current_color.B;
                    }
                }

                int total = width * height;

                average_R = sum_R / total;
                average_G = sum_G / total;
                average_B = sum_B / total;

                average = (average_R + average_G + average_B) / 3;

                RawColor[,] result_image = new RawColor[width, height];

                for (int i = 0; i < width; i++) {
                    worker.ReportProgress(50 + 50 * i / width);
                    for (int j = 0; j < height; j++) {
                        result_image[i, j] = calculateNewPixelColor(source_image, i, j);
                    }
                }

                return result_image;
            }
        }

        class AutolevelsFilter: SpotFilter {

            protected float min_R, min_G, min_B;
            protected float max_R, max_G, max_B;

            public AutolevelsFilter(Dictionary<string, object> parameters) {
                name = "Autolevels";
            }

            public AutolevelsFilter() {
                name = "Autolevels";
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                RawColor source_color = source_image[x, y];

                float new_R = (255.0f * (source_color.R - min_R) / (max_R - min_R));
                float new_G = (255.0f * (source_color.G - min_G) / (max_G - min_G));
                float new_B = (255.0f * (source_color.B - min_B) / (max_B - min_B));
                 

                RawColor result_color = new RawColor(source_color.A,
                                                     new_R,
                                                     new_G,
                                                     new_B);
                return result_color;
            }

            public override RawColor[,] processImageRaw(RawColor[,] source_image, BackgroundWorker worker) {
                int width = source_image.GetLength(0);
                int height = source_image.GetLength(1);

                RawColor[,] result_image = new RawColor[width, height];

                min_R = 255; min_G = 255; min_B = 255;
                max_R = 0; max_G = 0; max_B = 0;

                for (int i = 0; i < width; i++) {
                    worker.ReportProgress(50 * i / width);
                    for (int j = 0; j < height; j++) {
                        RawColor current_color = source_image[i, j];

                        min_R = Math.Min(current_color.R, min_R);
                        min_G = Math.Min(current_color.G, min_G);
                        min_B = Math.Min(current_color.B, min_B);

                        max_R = Math.Max(current_color.R, max_R);
                        max_G = Math.Max(current_color.G, max_G);
                        max_B = Math.Max(current_color.B, max_B);
                    }
                }

                for (int i = 0; i < width; i++) {
                    worker.ReportProgress(50 + 50 * i / width);
                    for (int j = 0; j < height; j++) {
                        result_image[i, j] = calculateNewPixelColor(source_image, i, j);
                    }
                }

                return result_image;
            }
        }

        class PerfectReflectorFilter: SpotFilter {

            protected int max_R, max_G, max_B;

            public PerfectReflectorFilter(Dictionary<string, object> parameters) {
                name = "PerfectReflector";
            }

            public PerfectReflectorFilter() {
                name = "PerfectReflector";
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                RawColor source_color = source_image[x, y];

                int new_R = (int)(255 * source_color.R / max_R);
                int new_G = (int)(255 * source_color.G / max_G);
                int new_B = (int)(255 * source_color.B / max_B);


                RawColor result_color = new RawColor(source_color.A,
                                                     new_R,
                                                     new_G,
                                                     new_B);
                return result_color;
            }

            public override RawColor[,] processImageRaw(RawColor[,] source_image, BackgroundWorker worker) {
                int width = source_image.GetLength(0);
                int height = source_image.GetLength(1);

                RawColor[,] result_image = new RawColor[width, height];

                max_R = 0; max_G = 0; max_B = 0;

                for (int i = 0; i < width; i++) {
                    worker.ReportProgress(50 * i / width);
                    for (int j = 0; j < height; j++) {
                        RawColor current_color = source_image[i, j];

                        max_R = Math.Max((int)current_color.R, max_R);
                        max_G = Math.Max((int)current_color.G, max_G);
                        max_B = Math.Max((int)current_color.B, max_B);
                    }
                }

                for (int i = 0; i < width; i++) {
                    worker.ReportProgress(50 + 50 * i / width);
                    for (int j = 0; j < height; j++) {
                        result_image[i, j] = calculateNewPixelColor(source_image, i, j);
                    }
                }

                return result_image;
            }
        }
    }

    abstract class MatrixFilter: Filter {
        protected float[,] kernel = null;
        protected int kernel_width, kernel_height;
        protected int base_dx, base_dy; // Offset of the upper-left corner of the kernel relative to the current pixel

        protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {

            RawColor source_color = source_image[x, y];

            float result_R = 0;
            float result_G = 0;
            float result_B = 0;

            int width = source_image.GetLength(0);
            int height = source_image.GetLength(1);

            for (int dx = 0; dx < kernel_width; dx++) {
                for (int dy = 0; dy < kernel_height; dy++) {

                    int nx = clamp(x + base_dx + dx, 0, width - 1);
                    int ny = clamp(y + base_dy + dy, 0, height - 1);

                    RawColor neighbor_color = source_image[nx, ny];

                    float kernel_coefficient = kernel[dx, dy];
                    result_R += kernel_coefficient * neighbor_color.R;
                    result_G += kernel_coefficient * neighbor_color.G;
                    result_B += kernel_coefficient * neighbor_color.B;
                }
            }

            RawColor result_color = new RawColor(source_color.A,
                                                 result_R,
                                                 result_G,
                                                 result_B);

            return result_color;
        }
    }

    namespace MatrixFilters {
        class BlurFilter : MatrixFilter {

            public BlurFilter(int radius = 1) {
                name = "Blur";

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

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {
                    new FilterParameter("Radius", typeof(int), 1, 0, 10),
                };
            }
        }

        class MotionBlurFilter : MatrixFilter {

            public MotionBlurFilter(int radius = 1) {
                name = "MotionBlur";

                kernel_width = radius * 2 + 1;
                kernel_height = radius * 2 + 1;

                kernel = new float[kernel_width, kernel_height];

                for (int x = 0; x < radius * 2 + 1; x++) {
                    kernel[x, x] = (float)1 / kernel_width ;
                }

                base_dx = -radius;
                base_dy = -radius;
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {
                    new FilterParameter("Radius", typeof(int), 1, 0, 10),
                };
            }

        }

        class MedianFilter : MatrixFilter {

            public MedianFilter(int radius = 1) {
                name = "Median";

                kernel_width = radius * 2 + 1;
                kernel_height = radius * 2 + 1;

                base_dx = -radius;
                base_dy = -radius;
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {
                    new FilterParameter("Radius", typeof(int), 1, 0, 10),
                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                int width = source_image.GetLength(0);
                int height = source_image.GetLength(1);

                RawColor source_color = source_image[x, y];

                float[] colors_R = new float[kernel_width * kernel_height];
                float[] colors_G = new float[kernel_width * kernel_height];
                float[] colors_B = new float[kernel_width * kernel_height];

                int p = 0;
                for (int dx = 0; dx < kernel_width; dx++) {
                    for (int dy = 0; dy < kernel_height; dy++) {

                        int nx = clamp(x + base_dx + dx, 0, width - 1);
                        int ny = clamp(y + base_dy + dy, 0, height - 1);

                        RawColor neighbor_color = source_image[nx, ny];

                        colors_R[p] = neighbor_color.R;
                        colors_G[p] = neighbor_color.G;
                        colors_B[p] = neighbor_color.B;

                        ++p;
                    }
                }

                float result_R = Algorithms.findOrderStatistic(colors_R, kernel_width * kernel_height / 2);
                float result_G = Algorithms.findOrderStatistic(colors_G, kernel_width * kernel_height / 2);
                float result_B = Algorithms.findOrderStatistic(colors_B, kernel_width * kernel_height / 2);

                RawColor result_color = new RawColor(source_color.A,
                                                     result_R,
                                                     result_G,
                                                     result_B);

                return result_color;
            }
        }

        class GaussianFilter : MatrixFilter {

            public GaussianFilter(int radius = 3, float sigma = 2) {
                name = "Gaussian";

                kernel_width = radius * 2 + 1;
                kernel_height = radius * 2 + 1;

                kernel = new float[kernel_width, kernel_height];

                float norm = 0;

                for (int i = 0; i < kernel_width; i++) {
                    for (int j = 0; j < kernel_height; j++) {

                        int di = Math.Abs(i - kernel_width / 2);
                        int dj = Math.Abs(i - kernel_width / 2);

                        kernel[i, j] = (float)(Math.Exp(-(di * di + dj * dj) / (2 * sigma * sigma)));
                        norm += kernel[i, j];
                    }
                }

                for (int i = 0; i < kernel_width; i++) {
                    for (int j = 0; j < kernel_height; j++) {
                        kernel[i, j] /= norm;
                    }
                }

                base_dx = -radius;
                base_dy = -radius;
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {
                    new FilterParameter("Radius", typeof(int), 1, 0, 10),
                    new FilterParameter("Sigma", typeof(int), 2, 1, 10),
                };
            }
        }

        class ExpansionFilter : MatrixFilter {

            public ExpansionFilter() {
                name = "Expansion";

                kernel_width = 3;
                kernel_height = 3;

                kernel = new float[,] {
                    { 0, 1, 0 },
                    { 1, 1, 1 },
                    { 0, 1, 0 }
                };

                base_dx = -1;
                base_dy = -1;
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {

                RawColor source_color = source_image[x, y];

                float result_R = 0;
                float result_G = 0;
                float result_B = 0;

                int width = source_image.GetLength(0);
                int height = source_image.GetLength(1);

                for (int dx = 0; dx < kernel_width; dx++) {
                    for (int dy = 0; dy < kernel_height; dy++) {

                        int nx = clamp(x + base_dx + dx, 0, width - 1);
                        int ny = clamp(y + base_dy + dy, 0, height - 1);

                        RawColor neighbor_color = source_image[nx, ny];
                        float kernel_coefficient = kernel[dx, dy];

                        if (kernel_coefficient > 0.5f) {
                            result_R = Math.Max(neighbor_color.R, result_R);
                            result_G = Math.Max(neighbor_color.G, result_G);
                            result_B = Math.Max(neighbor_color.B, result_B);
                        }
                    }
                }

                RawColor result_color = new RawColor(source_color.A,
                                                     result_R,
                                                     result_G,
                                                     result_B);

                return result_color;
            }
        }

        class NarrowingFilter : MatrixFilter {

            public NarrowingFilter() {
                name = "Narrowing";

                kernel_width = 3;
                kernel_height = 3;

                kernel = new float[,] {
                    { 0, 1, 0 },
                    { 1, 1, 1 },
                    { 0, 1, 0 }
                };

                base_dx = -1;
                base_dy = -1;
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {

                RawColor source_color = source_image[x, y];

                float result_R = 255;
                float result_G = 255;
                float result_B = 255;

                int width = source_image.GetLength(0);
                int height = source_image.GetLength(1);

                for (int dx = 0; dx < kernel_width; dx++) {
                    for (int dy = 0; dy < kernel_height; dy++) {

                        int nx = clamp(x + base_dx + dx, 0, width - 1);
                        int ny = clamp(y + base_dy + dy, 0, height - 1);

                        RawColor neighbor_color = source_image[nx, ny];
                        float kernel_coefficient = kernel[dx, dy];

                        if (kernel_coefficient > 0.5f) {
                            result_R = Math.Min(neighbor_color.R, result_R);
                            result_G = Math.Min(neighbor_color.G, result_G);
                            result_B = Math.Min(neighbor_color.B, result_B);
                        }
                    }
                }

                RawColor result_color = new RawColor(source_color.A,
                                                     result_R,
                                                     result_G,
                                                     result_B);

                return result_color;
            }

        }

        class SharpnessFilter : MatrixFilter {

            public SharpnessFilter() {
                name = "Sharpness";

                kernel_width = 3;
                kernel_height = 3;

                kernel = new float[,] {
                    {  0, -1,  0 },
                    { -1,  5, -1 },
                    {  0, -1,  0 }
                };

                base_dx = -1;
                base_dy = -1;
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }
        }
    }

    abstract class AdvancedFilter : Filter {
        protected Filter[] filters;

        protected class RangeCorrectionFilter : SpotFilter {

            public RangeCorrectionFilter() {
                name = "RangeCorrectionFilter";
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }

            protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
                RawColor source_color = source_image[x, y];

                RawColor result_color = new RawColor(clamp(source_color.A),
                                                     clamp(source_color.R),
                                                     clamp(source_color.G),
                                                     clamp(source_color.B));
                return result_color;
            }
        }

        protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
            return new RawColor(0, 0, 0, 0);
        }

        public override RawColor[,] processImageRaw(RawColor[,] source_image, BackgroundWorker worker) {
            int width = source_image.GetLength(0);
            int height = source_image.GetLength(1);

            RawColor[,] result_image = new RawColor[width, height]; 
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    result_image[i, j] = source_image[i, j];
                }
            }

            for (int i = 0; i < filters.Length; i++) {
                result_image = filters[i].processImageRaw(result_image, worker);
            }

            return result_image;
        }
    }

    namespace AdvancedFilters {

        class EmbossingFilter: AdvancedFilter {

            protected class EmbossingCoreFilter1 : MatrixFilter {
                public EmbossingCoreFilter1() {

                    kernel_width = 3;
                    kernel_height = 3;

                    kernel = new float[, ] {
                        {  0,  1, 0 },
                        { -1,  0, 1 },
                        {  0, -1, 0 }
                    };

                    base_dx = -1;
                    base_dy = -1;
                }

                public static List<FilterParameter> getFilterParameters() {
                    return new List<FilterParameter> {

                    };
                }
            }

            public EmbossingFilter() {
                name = "Embossing";

                filters = new Filter[] {
                    new EmbossingCoreFilter1(),
                    new RangeCorrectionFilter(),
                    new BrightnessFilter(100),
                    new GrayScaleFilter(),
                };
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }
        }

        class PaperFilter : AdvancedFilter {

            public PaperFilter() {
                name = "Paper";

                filters = new Filter[] {
                    new EmbossingFilter(),
                    new RangeCorrectionFilter(),
                    new AutolevelsFilter(),
                    new RangeCorrectionFilter(),
                    new InversionFilter(),
                };
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }
        }

        class SobelFilter : AdvancedFilter {

            protected class SobelCoreFilter1 : MatrixFilter {

                public SobelCoreFilter1() {

                    kernel_width = 3;
                    kernel_height = 3;

                    kernel = new float[3, 3] {
                        {-1, -2, -1 },
                        { 0,  0,  0 },
                        { 1,  2,  1 }
                    };

                    base_dx = -1;
                    base_dy = -1;
                }

                public static List<FilterParameter> getFilterParameters() {
                    return new List<FilterParameter> {

                    };
                }
            }

            protected class SobelCoreFilter2 : MatrixFilter {

                public SobelCoreFilter2() {

                    kernel_width = 3;
                    kernel_height = 3;

                    kernel = new float[3, 3] {
                        { -1, 0, 1 },
                        { -2, 0, 2 },
                        { -1, 0, 1 }
                    };

                    base_dx = -1;
                    base_dy = -1;
                }

                public static List<FilterParameter> getFilterParameters() {
                    return new List<FilterParameter> {

                    };
                }
            }

            public SobelFilter() {
                name = "Sobel";
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }

            public override RawColor[,] processImageRaw(RawColor[,] source_image, BackgroundWorker worker) {
                int width = source_image.GetLength(0);
                int height = source_image.GetLength(1);

                SobelCoreFilter1 filter1 = new SobelCoreFilter1();
                RawColor[,] temp_image1 = filter1.processImageRaw(source_image, worker);

                SobelCoreFilter2 filter2 = new SobelCoreFilter2();
                RawColor[,] temp_image2 = filter2.processImageRaw(source_image, worker);

                RawColor[,] result_image = new RawColor[width, height];

                for (int i = 0; i < width; i++) {
                    worker.ReportProgress(100 * i / width);
                    for (int j = 0; j < height; j++) {

                        RawColor temp_color1 = temp_image1[i, j];
                        RawColor temp_color2 = temp_image2[i, j];

                        float temp_R1 = temp_color1.R;
                        float temp_G1 = temp_color1.G;
                        float temp_B1 = temp_color1.B;

                        float temp_R2 = temp_color2.R;
                        float temp_G2 = temp_color2.G;
                        float temp_B2 = temp_color2.B;

                        float new_R = (int)Math.Sqrt(temp_R1 * temp_R1 + temp_R2 * temp_R2);
                        float new_G = (int)Math.Sqrt(temp_G1 * temp_G1 + temp_G2 * temp_G2);
                        float new_B = (int)Math.Sqrt(temp_B1 * temp_B1 + temp_B2 * temp_B2);

                        result_image[i, j] = new RawColor(255,
                                                          new_R,
                                                          new_G,
                                                          new_B);
                    }
                }
                return result_image;
            }
        }

        class ScharrFilter : AdvancedFilter {

            protected class ScharrCoreFilter1 : MatrixFilter {

                public ScharrCoreFilter1() {

                    kernel_width = 3;
                    kernel_height = 3;

                    kernel = new float[3, 3] {
                        { -3, -10, -3 },
                        {  0,   0,  0 },
                        {  3,  10,  3 }
                    };

                    base_dx = -1;
                    base_dy = -1;
                }

                public static List<FilterParameter> getFilterParameters() {
                    return new List<FilterParameter> {

                    };
                }
            }

            protected class ScharrCoreFilter2 : MatrixFilter {

                public ScharrCoreFilter2() {

                    kernel_width = 3;
                    kernel_height = 3;

                    kernel = new float[3, 3] {
                        {  -3, 0,  3 },
                        { -10, 0, 10 },
                        {  -3, 0,  3 }
                    };

                    base_dx = -1;
                    base_dy = -1;
                }

                public static List<FilterParameter> getFilterParameters() {
                    return new List<FilterParameter> {

                    };
                }
            }

            public ScharrFilter() {
                name = "Scharr";
            }

            public static List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }

            public override RawColor[,] processImageRaw(RawColor[,] source_image, BackgroundWorker worker) {
                int width = source_image.GetLength(0);
                int height = source_image.GetLength(1);

                ScharrCoreFilter1 filter1 = new ScharrCoreFilter1();
                RawColor[,] temp_image1 = filter1.processImageRaw(source_image, worker);

                ScharrCoreFilter2 filter2 = new ScharrCoreFilter2();
                RawColor[,] temp_image2 = filter2.processImageRaw(source_image, worker);

                RawColor[,] result_image = new RawColor[width, height];

                for (int i = 0; i < width; i++) {
                    worker.ReportProgress(100 * i / width);
                    for (int j = 0; j < height; j++) {

                        RawColor temp_color1 = temp_image1[i, j];
                        RawColor temp_color2 = temp_image2[i, j];

                        float temp_R1 = temp_color1.R;
                        float temp_G1 = temp_color1.G;
                        float temp_B1 = temp_color1.B;

                        float temp_R2 = temp_color2.R;
                        float temp_G2 = temp_color2.G;
                        float temp_B2 = temp_color2.B;

                        float new_R = (int)Math.Sqrt(temp_R1 * temp_R1 + temp_R2 * temp_R2);
                        float new_G = (int)Math.Sqrt(temp_G1 * temp_G1 + temp_G2 * temp_G2);
                        float new_B = (int)Math.Sqrt(temp_B1 * temp_B1 + temp_B2 * temp_B2);

                        result_image[i, j] = new RawColor(255,
                                                          new_R,
                                                          new_G,
                                                          new_B);
                    }
                }
                return result_image;
            }
        }
    }
}