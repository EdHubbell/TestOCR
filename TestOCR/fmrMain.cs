using System.Text;
using Newtonsoft.Json.Linq;
using OpenCvSharp;
using Local_OpenCvSharp.Extensions;
using Sdcb.PaddleInference;
using Sdcb.PaddleOCR.Models.Local;
using Sdcb.PaddleOCR.Models;
using Sdcb.PaddleOCR;
using Sdcb.RotationDetector;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace TestOCR
{
    public partial class fmrMain : Form
    {

        static readonly string API_URL = "http://localhost:8081/ocr";
        string imagePath = "";
        string outputImagePath = "";

        public fmrMain()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await PostTest2();
        }

        public async Task PostTest()
        {
            var httpClient = new HttpClient();

            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string image_data = Convert.ToBase64String(imageBytes);

            var payload = new JObject { { "image", image_data } };
            var content = new StringContent(payload.ToString(), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(API_URL, content);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject jsonResponse = JObject.Parse(responseBody);

            string base64Image = jsonResponse["result"]["image"].ToString();
            byte[] outputImageBytes = Convert.FromBase64String(base64Image);


            File.WriteAllBytes(outputImagePath, outputImageBytes);
            Console.WriteLine($"Output image saved at {outputImagePath}");
            Console.WriteLine("\nDetected texts:");
            Console.WriteLine(jsonResponse["result"]["texts"].ToString());

            txtResults.Text = jsonResponse["result"]["texts"][0]["text"].ToString();
            txtScore.Text = jsonResponse["result"]["texts"][0]["score"].ToString();

            imageBox.Image = Bitmap.FromFile(outputImagePath);
        }

        public async Task PostTest2()
        {
            FullOcrModel model = LocalFullModels.EnglishV4;

            byte[] sampleImageData;
            //string sampleImageUrl = @"https://www.tp-link.com.cn/content/images2017/gallery/4288_1920.jpg";
            //using (HttpClient http = new HttpClient())
            //{
            //    Console.WriteLine("Download sample image from: " + sampleImageUrl);
            //    await http.GetByteArrayAsync(sampleImageUrl);
            //}

            //sampleImageData = File.ReadAllBytes(imagePath);

            using (PaddleOcrAll all = new PaddleOcrAll(model, PaddleDevice.Mkldnn())
            {
                AllowRotateDetection = true,
                Enable180Classification = false,
            })
            {
                // Load local file by following code:
                Mat src = Cv2.ImRead(imagePath);
                //                using (Mat src = Cv2.ImDecode(sampleImageData, ImreadModes.Color))


                // If the images really have too much resolution, you can do something like this.
                // It speeds up the OCR process considerably. 
                Cv2.Resize(src, src, new OpenCvSharp.Size(src.Width * .05, src.Height * .05));

                Cv2.CvtColor(src, src, ColorConversionCodes.BGRA2GRAY);
                //Cv2.Threshold(src, src, 50, 255, ThresholdTypes.Otsu);

                //if (cbxRotationDetection.Checked)
                //{
                //    using PaddleRotationDetector detector = new PaddleRotationDetector(RotationDetectionModel.EmbeddedDefault);
                //    {
                //        // If you want to detect the rotation of the image, you can use the following code.
                //        // In testing, this code is not very reliable. It wouldn't detect the correct rotation of the image.
                //        // It was so bad that it'd probably be better to rotate the image 4x and just find the OCR with the 
                //        // highest score.
                //        RotationResult r = detector.Run(src);

                //        //// Rotate the image based on the detected rotation
                //        //switch (r.Rotation)
                //        //{
                //        //    case RotationDegree._90:
                //        //        src = src.Rotate(90);
                //        //        break;
                //        //    case RotationDegree._180:
                //        //        src = src.Rotate(180);
                //        //        break;
                //        //    case RotationDegree._270:
                //        //        src = src.Rotate(90);
                //        //        break;
                //        //}
                //        Console.WriteLine(r.Rotation);
                //    }
                //}


                //// Set the image to be the resized image
                imageBox.Image = src.ToBitmap();


                // This will start to fail with a message that says System.MissingFieldException (having to do with OpenCvSharp.Size.Zero)
                // if you install the OpenCVSharp4Extensions package V 4.10.0.20241108.
                PaddleOcrResult result = all.Run(src);

                Console.WriteLine("Detected all texts: \n" + result.Text);

                if (result.Regions.Count() == 1)
                {
                    PaddleOcrResultRegion region = result.Regions[0];
                    txtResults.Text = region.Text;
                    txtScore.Text = region.Score.ToString("0.0000");
                }

                foreach (PaddleOcrResultRegion region in result.Regions)
                {
                    Console.WriteLine($"Text: {region.Text}, Score: {region.Score}, RectCenter: {region.Rect.Center}, RectSize:    {region.Rect.Size}, Angle: {region.Rect.Angle}");
                }
            }

        }



        private void btnSelectFile_Click(object sender, EventArgs e)
        {

            ClearOutput();

            // Use file selection dialog to select jpg image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG files (*.jpg)|*.jpg";
            openFileDialog.InitialDirectory = "c:/Users/ed/Downloads";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                txtImagePath.Text = imagePath;
                outputImagePath = Path.Combine(Path.GetDirectoryName(imagePath), string.Format("output_{0}.jpg", DateTime.Now.ToString("yyMMdd_HHmmss")));

                // Show the selected image in the picture box
                imageBox.Image  = Bitmap.FromFile(imagePath);
            }

        }

        private void ClearOutput()
        {
            txtResults.Text = "";
            txtScore.Text = "";
        }
    }
}
