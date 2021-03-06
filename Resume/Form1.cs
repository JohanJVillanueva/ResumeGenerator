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
            string Website = resume.website;
            
            //Adress
            string Address = resume.address;
            string PostalCode = resume.postalCode;
            string City = resume.city;
            string Region = resume.region;


            //Education
            string College = resume.College;
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
            string Website = resume.website;

            //Adress
            string Address = resume.address;
            string PostalCode = resume.postalCode;
            string City = resume.city;
            string Region = resume.region;


            //Education
            string College = resume.College;
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

                    //call fonts
                    XFont bigfont = new XFont("Gobold", 18, XFontStyle.Regular);
                    XFont smallfont = new XFont("Rockwell", 12, XFontStyle.Regular);
                    XFont titlefont = new XFont("Cocogoose", 35, XFontStyle.Regular);
                    
                    //Draw pens
                    XPen pen = new XPen(XColors.White, 20);
                    XPen linerleft = new XPen(XColors.Black, 1);;
                    XPen linerright = new XPen(XColors.DarkGray, 1) ;



                    //bg color

                    graph.DrawRoundedRectangle(XBrushes.LightSkyBlue, 0, 0, page.Width.Point, page.Height.Point, 30, 20);
                    graph.DrawRoundedRectangle(XBrushes.WhiteSmoke, 200, 50, page.Width.Point, page.Height.Point, 100, 100);

                    //bg border
                    graph.DrawRectangle(pen, 0, 0, page.Width.Point, page.Height.Point);



                    //Draw Resume in the top center of PDF
                    graph.DrawString("RESUME", bigfont, XBrushes.White, new XRect(0, 20, page.Width.Point-20, page.Height.Point-50), XStringFormats.TopRight);

                    //Makes a variable to define the margin for the left side and the starting y coordinate
                    int marginleft = 25;
                    int initialleft = 200;

                    //leftside of pdf
                    //Always add +15 when there is a new info

                    //grab 1x1 photo not included ng json file
                    string jpeg = @"E:\Programming\Resume\Resume\1x1.jpg";
                    XImage image = XImage.FromFile(jpeg);
                    graph.DrawImage(image, marginleft, 50, 150, 150);

                    
                    //First Name and Last Name Big
 
                    //Basic Info
                    graph.DrawString("Basic Info:", bigfont,  XBrushes.White, new XRect(marginleft, initialleft + 20, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("First Name: " + Firstname, smallfont, XBrushes.Black, new XRect(marginleft, initialleft+50, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString("Last Name: " + Lastname, smallfont, XBrushes.Black, new XRect(marginleft, initialleft+65, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Email, smallfont, XBrushes.Black, new XRect(marginleft, initialleft+80, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Website, smallfont, XBrushes.Black, new XRect(marginleft, initialleft+95, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Phone, smallfont, XBrushes.Black, new XRect(marginleft, initialleft+110, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);


                    //Line Separator
                    graph.DrawRectangle(linerleft, marginleft, initialleft + 130, 150, 1);

                    //Address
                    graph.DrawString("Address:", bigfont, XBrushes.White, new XRect(marginleft, initialleft+135, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Address, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 160, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(City, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 190, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Region, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 205, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(PostalCode, smallfont, XBrushes.Black, new XRect(marginleft, initialleft + 175, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //right side of PDF

                    int marginmiddle = 220;
                    int initialmiddle = 200;

                    //BIG First name and last name
                    graph.DrawString(Firstname, titlefont, XBrushes.Black, new XRect(marginmiddle, initialmiddle-110, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                    graph.DrawString(Lastname, titlefont, XBrushes.Black, new XRect(marginmiddle, initialmiddle-70, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //Line Separator
                    graph.DrawRectangle(linerright, marginmiddle, initialmiddle - 10, 350, 1);

                    //Education
                    graph.DrawString("Education:", bigfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(College, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 30, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(CollegeGraduated, smallfont, XBrushes.Black, new XRect(marginmiddle+25, initialmiddle + 45, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(HighSchool, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 60, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(HighSchoolGraduated, smallfont, XBrushes.Black, new XRect(marginmiddle+25, initialmiddle + 75, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //Awards

                    initialmiddle = initialmiddle + 100;

                    //Line Separator
                    graph.DrawRectangle(linerright, marginmiddle, initialmiddle - 5, 350, 1);

                    graph.DrawString("Awards:", bigfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Award1, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle +30, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Award2, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle +45, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Award3, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 60, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Award4, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 75, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Award5, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 90, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Award6, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 105, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Award7, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 120, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    //Skills

                    initialmiddle = initialmiddle + 150;
                    //Line Separator
                    graph.DrawRectangle(linerright, marginmiddle, initialmiddle - 5, 350, 1);

                    graph.DrawString("Skills:", bigfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill1, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 30, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill2, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 45, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill3, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 60, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill4, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 75, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                    graph.DrawString(Skill5, smallfont, XBrushes.Black, new XRect(marginmiddle, initialmiddle + 90, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);


                    pdf.Save(sfd.FileName);
                }

            }

        }
    }
    
}