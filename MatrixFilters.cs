using Core;
using PhotoEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixFilters {

    // ----== <Filters> ==----

    class BlurFilter : MatrixFilter {

        protected override string name => "Blur";

        public BlurFilter(Dictionary<string, object> parameters) : this(
            (int)parameters["Radius"]
        ) { }

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

        public BlurFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {
                    new FilterParameter("Radius", typeof(int), 1, 1, 10),
                };
        }
    }

    class MotionBlurFilter : MatrixFilter {

        protected override string name => "MotionBlur";

        public MotionBlurFilter(Dictionary<string, object> parameters) : this(
            (int)parameters["Radius"]
        ) { }

        public MotionBlurFilter(int radius = 1) {

            kernel_width = radius * 2 + 1;
            kernel_height = radius * 2 + 1;

            kernel = new float[kernel_width, kernel_height];

            for (int x = 0; x < radius * 2 + 1; x++) {
                kernel[x, x] = (float)1 / kernel_width;
            }

            base_dx = -radius;
            base_dy = -radius;
        }

        public MotionBlurFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {
                    new FilterParameter("Radius", typeof(int), 1, 1, 10),
                };
        }

    }

    class MedianFilter : MatrixFilter {

        protected override string name => "Median";

        public MedianFilter(Dictionary<string, object> parameters) : this(
            (int)parameters["Radius"]
        ) { }

        public MedianFilter(int radius = 1) {

            kernel_width = radius * 2 + 1;
            kernel_height = radius * 2 + 1;

            base_dx = -radius;
            base_dy = -radius;
        }

        public MedianFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {
                    new FilterParameter("Radius", typeof(int), 1, 1, 10),
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

        protected override string name => "Gaussian";

        public GaussianFilter(Dictionary<string, object> parameters) : this(
            (int)parameters["Radius"],
            (float)parameters["Sigma"]
        ) { }

        public GaussianFilter(int radius = 3, float sigma = 2) {

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

        public GaussianFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {
                    new FilterParameter("Radius", typeof(int), 1, 1, 10),
                    new FilterParameter("Sigma", typeof(float), 2, 0.1, 100.0),
            };
        }
    }

    class ExpansionFilter : MatrixFilter {

        protected override string name => "Expansion";

        public ExpansionFilter(Dictionary<string, object> parameters) : this(

        ) { }

        public ExpansionFilter() {

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

        public override List<FilterParameter> getFilterParameters() {
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

    class ErosionFilter : MatrixFilter {

        protected override string name => "Erosion";

        public ErosionFilter(Dictionary<string, object> parameters) : this(

        ) { }

        public ErosionFilter() {

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

        public override List<FilterParameter> getFilterParameters() {
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

        protected override string name => "Sharpness";

        public SharpnessFilter(Dictionary<string, object> parameters) : this(
            (float)parameters["Sharpness Strength"]
        ) { }

        public SharpnessFilter(float sharpness_strength = 1) {

            kernel_width = 3;
            kernel_height = 3;

            kernel = new float[,] {
                    {  0 * sharpness_strength, -1 * sharpness_strength,  0 * sharpness_strength },
                    { -1 * sharpness_strength,  5 * sharpness_strength, -1 * sharpness_strength },
                    {  0 * sharpness_strength, -1 * sharpness_strength,  0 * sharpness_strength }
                };

            base_dx = -1;
            base_dy = -1;
        }

        public SharpnessFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {
                    new FilterParameter("Sharpness Strength", typeof(float), 1, 0.1, 10.0),
            };
        }
    }
}
