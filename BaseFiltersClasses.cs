using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms.Design;

using PhotoEditor;
using SpotFilters;
using MatrixFilters;
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

        protected abstract string name { get; }
        public string getName() {
            return name;
        }
        public abstract List<FilterParameter> getFilterParameters();

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

    abstract class AdvancedFilter : Filter {
        protected Filter[] filters;

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
}