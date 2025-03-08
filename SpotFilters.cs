using PhotoEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotFilters {

    class InversionFilter : SpotFilter {

        protected override string name => "Inversion";

        public InversionFilter(Dictionary<string, object> parameters) : this(

        ) { }

        public InversionFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
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

        protected override string name => "GrayScale";

        public GrayScaleFilter(Dictionary<string, object> parameters) : this(

        ) { }

        public GrayScaleFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
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

    class SepiaFilter : SpotFilter {

        protected override string name => "Sepia";

        protected int sepia_strength;

        public SepiaFilter(Dictionary<string, object> parameters) : this(
            (int)parameters["Sepia Strength"]
        ) { }

        public SepiaFilter(int sepia_strength = 20) {
            this.sepia_strength = sepia_strength;
        }

        public SepiaFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
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

    class BrightnessFilter : SpotFilter {

        protected override string name => "Brightness";

        protected int brightness_delta;

        public BrightnessFilter(Dictionary<string, object> parameters) : this(
            (int)parameters["Brightness Delta"]
        ) { }

        public BrightnessFilter(int brightness_delta = 20) {

            this.brightness_delta = brightness_delta;
        }

        public BrightnessFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
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

        protected override string name => "Shift";

        protected int dx, dy;

        public ShiftFilter(Dictionary<string, object> parameters) : this(
            (int)parameters["X offset"],
            (int)parameters["Y offset"]
        ) { }

        public ShiftFilter(int dx = 0, int dy = 0) {
            this.dx = -dx;
            this.dy = dy;
        }

        public ShiftFilter() {

        }
        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {
                    new FilterParameter("X offset", typeof(int), 0, -10000, 10000),
                    new FilterParameter("Y offset", typeof(int), 0, -10000, 10000)
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

        protected override string name => "GrayWorld";

        protected float average_R, average_G, average_B;
        protected float average;

        public GrayWorldFilter(Dictionary<string, object> parameters) : this(

        ) { }

        public GrayWorldFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {

            };
        }


        protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
            RawColor source_color = source_image[x, y];

            RawColor result_color = new RawColor(source_color.A,
                                                 source_color.R * average / average_R,
                                                 source_color.G * average / average_G,
                                                 source_color.B * average / average_B);
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

            average_R = Math.Max(sum_R, 1) / total;
            average_G = Math.Max(sum_G, 1) / total;
            average_B = Math.Max(sum_B, 1) / total;

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

    class AutolevelsFilter : SpotFilter {

        protected override string name => "Autolevels";

        protected float min_R, min_G, min_B;
        protected float max_R, max_G, max_B;

        public AutolevelsFilter(Dictionary<string, object> parameters) : this(

        ) { }

        public AutolevelsFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {

            };
        }

        protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
            RawColor source_color = source_image[x, y];

            float new_R = (255.0f * (source_color.R - min_R) / Math.Max(1, (max_R - min_R)));
            float new_G = (255.0f * (source_color.G - min_G) / Math.Max(1, (max_G - min_G)));
            float new_B = (255.0f * (source_color.B - min_B) / Math.Max(1, (max_B - min_B)));


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

    class PerfectReflectorFilter : SpotFilter {

        protected override string name => "PerfectReflector";

        protected int max_R, max_G, max_B;

        public PerfectReflectorFilter(Dictionary<string, object> parameters) : this(

        ) { }

        public PerfectReflectorFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {

            };
        }

        protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
            RawColor source_color = source_image[x, y];

            int new_R = (int)(255 * source_color.R / Math.Max(1, max_R));
            int new_G = (int)(255 * source_color.G / Math.Max(1, max_G));
            int new_B = (int)(255 * source_color.B / Math.Max(1, max_B));


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

    class ColorShiftFilter : SpotFilter {
        protected override string name => "ColorShift";

        protected int dA, dR, dG, dB;

        public ColorShiftFilter(Dictionary<string, object> parameters) : this(
            (int)parameters["dA"],
            (int)parameters["dR"],
            (int)parameters["dG"],
            (int)parameters["dB"]
        ) { }

        public ColorShiftFilter(int dA = 0, int dR = 0, int dG = 0, int dB = 0) {
            this.dA = dA;
            this.dR = dR;
            this.dG = dG;
            this.dB = dB;
        }

        public ColorShiftFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {
                new FilterParameter("dA", typeof(int), 0, -255, 255),
                new FilterParameter("dR", typeof(int), 0, -255, 255),
                new FilterParameter("dG", typeof(int), 0, -255, 255),
                new FilterParameter("dB", typeof(int), 0, -255, 255)
            };
        }

        protected override RawColor calculateNewPixelColor(RawColor[,] source_image, int x, int y) {
            RawColor result_color = source_image[x, y];

            result_color.A += dA;
            result_color.R += dR;
            result_color.G += dG;
            result_color.B += dB;

            return result_color;
        }
    }

    class __RangeCorrectionFilter : SpotFilter {

        protected override string name => "RangeCorrection";

        public __RangeCorrectionFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
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
}
