using System.Text.Json;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using System.Text;

namespace Resume
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string filename = "resumeinfo.json";
            string jsonstring = File.ReadAllText(filename);
            Resume resume = JsonSerializer.Deserialize<Resume>(jsonstring)!;



            //Grabbing Data from Json, converting into a string variable
            //Basic Info
            string Firstname = resume.firstname;
            string Lastname = resume.lastname;
            string Email = resume.email;
            string Phone = resume.phone;
            string Websire = resume.website;
            
            //Adress
            string Address = resume.address;
            string PostalCode = resume.postalCode;
            string City = resume.city;
            string Region = resume.region;


            //Education
            string Collge = resume.College;
            string CollegeGraduated = resume.CollegeGraduated;
            string HighSchool = resume.HighSchool;
            string HighSchoolGraduated = resume.HighSchoolGraduated;

            //Awards
            string Award1 = resume.award1;
            string Award2 = resume.award2;
            string Award3 = resume.award3;
            string Award4 = resume.award4;
            string Award5 = resume.award5;
            string Award6 = resume.award6;
            string Award7 = resume.award7;
            

            //Skills
            string Skill1 = resume.skill1;
            string Skill2 = resume.skill2;
            string Skill3 = resume.skill3;
            string Skill4 = resume.skill4;
            string Skill5 = resume.skill5;


            //Setting Text on Labels

            //Basic Info
            lblFirstName.Text = "First Name: " + resume.firstname;
            lblLastName.Text = "Last Name: " + resume.lastname;
            lblEmail.Text = "Email: " + resume.email;
            lblPhone.Text = "Phone: " + resume.phone;
            lblWebsite.Text = "Website: " + resume.website;

            //Address
            lblAddres.Text = "Address: " + resume.address;
            lblPostalCode.Text = "Postal Code: " + resume.postalCode;
            lblCity.Text = "City: " + resume.city;
            lblRegion.Text = "Region: " + resume.region;

            //Education
            lblCollege.Text = "College: " + resume.College;
            lblCollegeGraduated.Text = "Year of Graduation: " + resume.CollegeGraduated;
            lblHighSchool.Text = "High School: " + resume.HighSchool;
            lblHighSchoolGraduated.Text = "Year of Graduation: " + resume.HighSchoolGraduated;

            //Awards
            lblAward1.Text = resume.award1;
            lblAward2.Text = resume.award2;
            lblAward3.Text = resume.award3;
            lblAward4.Text = resume.award4;
            lblAward5.Text = resume.award5;
            lblAward6.Text = resume.award6;
            lblAward7.Text = resume.award7;

            //Skills
            lblSkill1.Text = resume.skill1;
            lblSkill2.Text = resume.skill2;
            lblSkill3.Text = resume.skill3;
            lblSkill4.Text = resume.skill4;
            lblSkill5.Text = resume.skill5;


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
            public string HighSchool { get; set; }
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

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Get Info from JSON File

            string filename = "resumeinfo.json";
            string jsonstring = File.ReadAllText(filename);
            Resume resume = JsonSerializer.Deserialize<Resume>(jsonstring)!;



            //Grabbing Data from Json, converting into a string variable
            //Basic Info
            string Firstname = resume.firstname;
            string Lastname = resume.lastname;
            string Email = resume.email;
            string Phone = resume.phone;
            string Websire = resume.website;

            //Adress
            string Address = resume.address;
            string PostalCode = resume.postalCode;
            string City = resume.city;
            string Region = resume.region;


            //Education
            string Collge = resume.College;
            string CollegeGraduated = resume.CollegeGraduated;
            string HighSchool = resume.HighSchool;
            string HighSchoolGraduated = resume.HighSchoolGraduated;

            //Awards
            string Award1 = resume.award1;
            string Award2 = resume.award2;
            string Award3 = resume.award3;
            string Award4 = resume.award4;
            string Award5 = resume.award5;
            string Award6 = resume.award6;
            string Award7 = resume.award7;


            //Skills
            string Skill1 = resume.skill1;
            string Skill2 = resume.skill2;
            string Skill3 = resume.skill3;
            string Skill4 = resume.skill4;
            string Skill5 = resume.skill5;





            //End of Get Info from JSON

            string FirstName = lblFirstName.Text;
            string LastName = lblLastName.Text;
            FirstName = FirstName.Replace("First Name: ", "");
            FirstName = FirstName.ToUpper();
            LastName = LastName.Replace("Last Name: ", "");
            LastName = LastName.ToUpper();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = @"E:\Programming\Resume";
                sfd.FileName = LastName + "_" + FirstName + ".pdf";
                sfd.Filter = "PDF|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    
                    PdfDocument pdf = new PdfDocument();
                    pdf.Info.Title = "Resume";
                    PdfPage page = pdf.AddPage();

                    XGraphics graph = XGraphics.FromPdfPage(page);
                    XFont bigfont = new XFont("Rockwell", 18, XFontStyle.Regular);
                    XFont smallfont = new XFont("Times New Roman", 9, XFontStyle.Regular);

                    int marginleft = 30;


                    //bg color
                    graph.DrawRectangle(XBrushes.LightGray, 0, 0, page.Width.Point, page.Height.Point);
                    graph.DrawRectangle(XBrushes.LightSkyBlue, 0, 0, 200, page.Height.Point);

                    //bg

                    graph.DrawString("RESUME", bigfont, XBrushes.Black, new XRect(0, 20, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);

                    graph.DrawString(FirstName, smallfont, XBrushes.Black, new XRect(marginleft, 50, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);


                    graph.DrawString(LastName, smallfont, XBrushes.Black, new XRect(marginleft, 60, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Email, smallfont, XBrushes.Black, new XRect(marginleft, 100, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);










                    pdf.Save(sfd.FileName);
                }

            }

        }
    }
    
}