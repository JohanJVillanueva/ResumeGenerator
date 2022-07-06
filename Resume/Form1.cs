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

            //MessageBox.Show(resume.phone);

            //Label Variable
            string Firstname = resume.firstname;
            string Lastname = resume.lastname;

            lblFirstName.Text = "First Name: " + resume.firstname;
            lblLastName.Text = "Last Name: " + resume.lastname;




        }
    }
    public class Resume
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string College { get; set; }

        public string CollegeGraduated { get; set; }
        public string HighSchoolGraduated { get; set; }
        public string award1 { get; set; }
        public string award2 { get; set; }
        public string award3 { get; set; }
        public string award4 { get; set; }
        public string award5 { get; set; }
        public string award6 { get; set; }
        public string award7 { get; set; }
        public string skill1 { get; set; }
        public string skill2 { get; set; }
        public string skill3 { get; set; }

        public string skill4 { get; set; }
        public string skill5 { get; set; }


    }
}