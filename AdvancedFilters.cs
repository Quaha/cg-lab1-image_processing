using PhotoEditor;
using SpotFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFilters {

    // ----== <Filters> ==----

    class EmbossingFilter : AdvancedFilter {

        protected override string name => "Embossing";

        protected class EmbossingCoreFilter1 : MatrixFilter {

            protected override string name => "EmbossingCoreFilter1";

            public EmbossingCoreFilter1() {

                kernel_width = 3;
                kernel_height = 3;

                kernel = new float[,] {
                        {  0,  1, 0 },
                        { -1,  0, 1 },
                        {  0, -1, 0 }
                    };

                base_dx = -1;
                base_dy = -1;
            }

            public override List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }
        }

        public EmbossingFilter(Dictionary<string, object> parameters) : this(
        ) { }

        public EmbossingFilter() {

            filters = new Filter[] {
                    new EmbossingCoreFilter1(),
                    new __RangeCorrectionFilter(),
                    new BrightnessFilter(100),
                    new GrayScaleFilter(),
                };
        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {

            };
        }
    }

    class PaperFilter : AdvancedFilter {

        protected override string name => "Paper";

        public PaperFilter(Dictionary<string, object> parameters) : this(
        ) { }

        public PaperFilter() {
            filters = new Filter[] {
                    new EmbossingFilter(),
                    new __RangeCorrectionFilter(),
                    new AutolevelsFilter(),
                    new __RangeCorrectionFilter(),
                    new InversionFilter(),
                };
        }

        public override List<FilterParameter> getFilterParameters() {
            return new List<FilterParameter> {

            };
        }
    }

    class SobelFilter : AdvancedFilter {

        protected override string name => "Sobel";

        protected class SobelCoreFilter1 : MatrixFilter {

            protected override string name => "SobelCoreFilter1";

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

            public override List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }
        }

        protected class SobelCoreFilter2 : MatrixFilter {

            protected override string name => "SobelCoreFilter2";

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

            public override List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }
        }

        public SobelFilter(Dictionary<string, object> parameters) : this(

        ) { }

        public SobelFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
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

        protected override string name => "Scharr";

        protected class ScharrCoreFilter1 : MatrixFilter {

            protected override string name => "ScharrCoreFilter1";

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

            public override List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }
        }

        protected class ScharrCoreFilter2 : MatrixFilter {

            protected override string name => "ScharrCoreFilter2";

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

            public override List<FilterParameter> getFilterParameters() {
                return new List<FilterParameter> {

                };
            }
        }

        public ScharrFilter(Dictionary<string, object> parameters) : this(

        ) { }

        public ScharrFilter() {

        }

        public override List<FilterParameter> getFilterParameters() {
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