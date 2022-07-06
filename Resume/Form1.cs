using System.Text.Json;
namespace Resume
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            string filename = "resumeinfo.json";
            string jsonstring = File.ReadAllText(filename);
            Resume resume = JsonSerializer.Deserialize<Resume>(jsonstring)!;

            MessageBox.Show(resume.firstname);
            //MessageBox.Show($"TemperatureCelsius: {weatherForecast.TemperatureCelsius}");
            //MessageBox.Show($"Summary: {weatherForecast.Summary}");


        }
    }
    public class Resume
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }


    }
}