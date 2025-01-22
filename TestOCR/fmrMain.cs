using System.Text;
using Newtonsoft.Json.Linq;

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
            await PostTest();
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

            pictureBox1.ImageLocation = outputImagePath;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            // Use file selection dialog to select jpg image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg)|*.jpg";
            openFileDialog.InitialDirectory = "c:/Users/ed/Downloads";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                txtImagePath.Text = imagePath;
                outputImagePath = Path.Combine(Path.GetDirectoryName(imagePath), string.Format("output_{0}.jpg", DateTime.Now.ToString("yyMMdd_HHmmss")));
            }

            // Show the selected image in the picture box
            pictureBox1.ImageLocation = imagePath;

            ClearOutput();

        }

        private void ClearOutput()
        {
            txtResults.Text = "";
            txtScore.Text = "";
        }
    }
}
