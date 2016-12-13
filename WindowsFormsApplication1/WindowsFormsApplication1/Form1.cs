using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // webBrowser1.Navigate("http://ist.rit.edu/api/map");
        }
        #region getRestData - Returns the requested API information as a string
        private string getRestData(string url)
        {
            string baseUri = "http://ist.rit.edu/api";

            // connect to the API
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUri + url);
            try
            {
                WebResponse response = request.GetResponse();

                using (System.IO.Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException we)
            {
                // Something goes wrong, get the error response, then do something with it
                WebResponse err = we.Response;
                using (Stream responseStream = err.GetResponseStream())
                {
                    StreamReader r = new StreamReader(responseStream, Encoding.UTF8);
                    string errorText = r.ReadToEnd();
                    // display or log error
                    Console.WriteLine(errorText);
                }
                throw;
            }
        } // end getRestData
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/footer/");

            // need a way to get the JSON form into an About object
            Footer footer = JToken.Parse(jsonAbout).ToObject<Footer>();
            //adding click for links part
            socialPresence.Text = "\"" + footer.social.tweet + "\" - by - " + footer.social.by;
            //adding click for facebook
            facebook.Links.Add(0,8,footer.social.facebook);
            facebook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            //adding click for twitter
            twitter.Links.Add(0, 8, footer.social.twitter);
            twitter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            //adding click for application link
            applynow.Links.Add(0, 9, footer.quickLinks[0].href);
            applynow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            //adding click for about the site link
            abtsite.Links.Add(0, 15, footer.quickLinks[1].href);
            abtsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            //adding click for the link abt supporting ist
            supportIST.Links.Add(0, 11, footer.quickLinks[2].href);
            supportIST.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            //adding click for lab hours link
            labhrs.Links.Add(0, 9, footer.quickLinks[3].href);
            labhrs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
        }

        void link_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //marking the link as visited
            //facebook.Links[facebook.Links.IndexOf(e.Link)].Visited = true;
            //display the link requested based on the click
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void about_Enter(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/about/");

            // need a way to get the JSON form into an About object
            About about = JToken.Parse(jsonAbout).ToObject<About>();

            // start displaying the About object information on the screen
            title.Text = about.title;
            description.Text = about.description;
            quote.Text = about.quote;
            quoteAuthor.Text = about.quoteAuthor;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //on click of the browser
        }

        private void map_Enter(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://ist.rit.edu/api/map");
            webBrowser1.Navigate("http://ist.rit.edu/api/map");
        }

        private void citconcentrations_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void citdescription_Click(object sender, EventArgs e)
        {

        }

        private void graduate_Enter(object sender, EventArgs e)
        {
            
           
        }

        private void undergraduate_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl2_Enter(object sender, EventArgs e)
        {
            
        }

        private void degrees_Enter(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/degrees/");

            // need a way to get the JSON form into an About object
            Degree degrees = JToken.Parse(jsonAbout).ToObject<Degree>();
            //add each undergraduate degree to the page in a loop
            foreach (Undergraduate ug in degrees.undergraduate)
            {
                //adding the degree details for wmc
                if (ug.degreeName == "wmc")
                {
                    wmctitle.Text = ug.title;
                    wmcdescription.Text = ug.description;
                    wmcconcentrations.DataSource = ug.concentrations;
                    wmcconcentrations.ClearSelected();
                }
                //adding the degree details for hcc
                else if (ug.degreeName == "hcc")
                {
                    hcctitle.Text = ug.title;
                    hccdescription.Text = ug.description;
                    hccconcentrations.DataSource = ug.concentrations;
                    hccconcentrations.ClearSelected();
                }
                //adding the degree details for cit
                else
                {
                    cittitle.Text = ug.title;
                    citdescription.Text = ug.description;
                    citconcentrations.DataSource = ug.concentrations;
                    citconcentrations.ClearSelected();
                }
            }

            foreach (Graduate grad in degrees.graduate)
            {
                //adding the degree details for ist
                if (grad.degreeName == "ist")
                {
                    isttitle.Text = grad.title;
                    istdescription.Text = grad.description;
                    istconcentrations.DataSource = grad.concentrations;
                    istconcentrations.ClearSelected();
                }
                //adding the degree details for hci
                else if (grad.degreeName == "hci")
                {
                    hcititle.Text = grad.title;
                    hcidescription.Text = grad.description;
                    hciconcentrations.DataSource = grad.concentrations;
                    hciconcentrations.ClearSelected();
                }
                //adding the degree details for nsa
                else if (grad.degreeName == "nsa")
                {
                    nsatitle.Text = grad.title;
                    nsadescription.Text = grad.description;
                    nsaconcentrations.DataSource = grad.concentrations;
                    nsaconcentrations.ClearSelected();
                }
                //adding the details of the certifications available
                else
                {
                    certdegreeName.Text = grad.degreeName;
                    availableCertificates.DataSource = grad.availableCertificates;
                    availableCertificates.ClearSelected();
                }
            }
        }//end of degree

        private void minors_Enter(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/minors/");

            // need a way to get the JSON form into a Minor object
            Minor minor = JToken.Parse(jsonAbout).ToObject<Minor>();

            // start displaying the About object information on the screen
            foreach(UgMinor umin in minor.UgMinors)
            {
                //adding the degree details for DBDDI
                if (umin.name.StartsWith("DBDDI"))
                {
                    DBDDI.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugcourses.ClearSelected();
                    ugadvisor.Text = umin.note;
                }
                //adding the degree details for GIS
                else if (umin.name.StartsWith("GIS"))
                {
                    GIS.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                }
                //adding the degree details for MEDINFO
                else if (umin.name.StartsWith("MEDINFO"))
                {
                    MEDINFO.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                }
                //adding the degree details for MDDEV
                else if (umin.name.StartsWith("MDDEV"))
                {
                    MDDEV.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                }
                //adding the degree details for MDEV
                else if (umin.name.StartsWith("MDEV"))
                {
                    MDEV.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                }
                //adding the degree details for NETSYS
                else if (umin.name.StartsWith("NETSYS"))
                {
                    NETSYS.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                }
                //adding the degree details for WEBDD
                else if (umin.name.StartsWith("WEBDD"))
                {
                    WEBDD.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                }
                //adding the degree details for WEBD
                else
                {
                    WEBD.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                }
            }
        }//end of minor

        private void GIS_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/minors/");

            // need a way to get the JSON form into a Minor object
            Minor minor = JToken.Parse(jsonAbout).ToObject<Minor>();

            // start displaying the About object information on the screen
            foreach (UgMinor umin in minor.UgMinors)
            {   //adding the degree details for GIS
                if (umin.name.StartsWith("GIS"))
                {
                    GIS.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                    ugcourses.ClearSelected();
                }                
            }
        }//end of onclick

        private void DBDDI_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/minors/");

            // need a way to get the JSON form into a Minor object
            Minor minor = JToken.Parse(jsonAbout).ToObject<Minor>();

            // start displaying the About object information on the screen
            foreach (UgMinor umin in minor.UgMinors)
            {
                //adding the degree details for DBDDI
                if (umin.name.StartsWith("DBDDI"))
                {
                    DBDDI.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                    ugcourses.ClearSelected();
                }
            }
        }//end of onclick

        private void MEDINFO_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/minors/");

            // need a way to get the JSON form into a Minor object
            Minor minor = JToken.Parse(jsonAbout).ToObject<Minor>();

            // start displaying the About object information on the screen
            foreach (UgMinor umin in minor.UgMinors)
            {
                //adding the degree details for MEDINFO
                if (umin.name.StartsWith("MEDINFO"))
                {
                    MEDINFO.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                    ugcourses.ClearSelected();
                }
            }
        }//end of onclick

        private void MDDEV_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/minors/");

            // need a way to get the JSON form into a Minor object
            Minor minor = JToken.Parse(jsonAbout).ToObject<Minor>();

            // start displaying the About object information on the screen
            foreach (UgMinor umin in minor.UgMinors)
            {
                //adding the degree details for MDDEV
                if (umin.name.StartsWith("MDDEV"))
                {
                    MDDEV.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                    ugcourses.ClearSelected();
                }
            }
        }//end of onclick

        private void MDEV_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/minors/");

            // need a way to get the JSON form into a Minor object
            Minor minor = JToken.Parse(jsonAbout).ToObject<Minor>();

            // start displaying the About object information on the screen
            foreach (UgMinor umin in minor.UgMinors)
            {
                //adding the degree details for MDEV
                if (umin.name.StartsWith("MDEV"))
                {
                    MDEV.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                    ugcourses.ClearSelected();
                }
            }
        }//end of onclick

        private void NETSYS_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/minors/");

            // need a way to get the JSON form into a Minor object
            Minor minor = JToken.Parse(jsonAbout).ToObject<Minor>();

            // start displaying the About object information on the screen
            foreach (UgMinor umin in minor.UgMinors)
            {
                //adding the degree details for NETSYS
                if (umin.name.StartsWith("NETSYS"))
                {
                    NETSYS.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                    ugcourses.ClearSelected();
                }
            }
        }//end of onclick

        private void WEBDD_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/minors/");

            // need a way to get the JSON form into a Minor object
            Minor minor = JToken.Parse(jsonAbout).ToObject<Minor>();

            // start displaying the About object information on the screen
            foreach (UgMinor umin in minor.UgMinors)
            {
                if (umin.name.StartsWith("WEBDD"))
                {
                    //adding the degree details for WEBDD
                    WEBDD.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                    ugcourses.ClearSelected();
                }
            }
        }//end of onlcick

        private void WEBD_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/minors/");

            // need a way to get the JSON form into a Minor object
            Minor minor = JToken.Parse(jsonAbout).ToObject<Minor>();

            // start displaying the About object information on the screen
            foreach (UgMinor umin in minor.UgMinors)
            {
                //adding the degree details for WEBD
                if (umin.name.StartsWith("WEBD"))
                {
                    WEBD.Text = umin.name;
                    ugtitle.Text = umin.title;
                    ugdescription.Text = umin.description;
                    ugcourses.DataSource = umin.courses;
                    ugadvisor.Text = umin.note;
                    ugcourses.ClearSelected();
                }
            }
        }//end of onclick

        private void ugdescription_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void faculty_Enter(object sender, EventArgs e)
        {
           
            
        }

        private void people_Enter(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/people/");

            // need a way to get the JSON form into a Minor object
            People ppl = JToken.Parse(jsonAbout).ToObject<People>();

            ppltitle.Text = ppl.title;
            pplsubTitle.Text = ppl.subTitle;

            //faculty display settings
            facultyTable.Controls.Clear();
            facultyTable.ColumnStyles.Clear();
            facultyTable.RowStyles.Clear();
            facultyTable.RowCount = 10;
            facultyTable.ColumnCount = 8;
            facultyTable.AutoSize = true;
           // facultyTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            facultyTable.MaximumSize = tabControl3.MaximumSize;
            facultyTable.AutoScrollPosition = new Point(0, facultyTable.VerticalScroll.Maximum);
            facultyTable.AutoScroll = true;
            facultyTable.Margin = new Padding(10);
            int s = ppl.faculty.Count();
            int k = 0;
            //adding the details of faculty to the picture box and add it to the tableLayoutPanel
            for (int i = 0; i < facultyTable.RowCount && k < s; i++)
            {
                facultyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, (80 / facultyTable.RowCount)));
                for (int j = 0; j < facultyTable.ColumnCount && k<s; j++)
                {                 
                    facultyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, (80 / facultyTable.ColumnCount)));
                    PictureBox pic = new PictureBox();
                    pic.Size = new Size(150, 150);
                    pic.Dock = DockStyle.Fill;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Load(ppl.faculty[k].imagePath);
                    pic.Name = ppl.faculty[k].username;
                    pic.MouseClick += facTable_Click;
                    facultyTable.Controls.Add(pic, j, i);
                    k++;
                }
            }

            //staff display
            staffTable.Controls.Clear();
            staffTable.ColumnStyles.Clear();
            staffTable.RowStyles.Clear();
            staffTable.RowCount = 5;
            staffTable.ColumnCount = 8;
            staffTable.AutoSize = true;
            // facultyTable.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            staffTable.MaximumSize = tabControl3.MaximumSize;
            staffTable.AutoScrollPosition = new Point(0, facultyTable.VerticalScroll.Maximum);
            staffTable.AutoScroll = true;
            staffTable.Margin = new Padding(10);
            int staffsize = ppl.staff.Count();
            int k1 = 0;
            //adding the details of staff to the picture box and add it to the tableLayoutPanel
            for (int i = 0; i < staffTable.RowCount && k1 < staffsize; i++)
            {
                staffTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, (40 / staffTable.RowCount)));
                for (int j = 0; j < staffTable.ColumnCount && k1 < staffsize; j++)
                {
                    staffTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, (40 / staffTable.ColumnCount)));
                    PictureBox pic = new PictureBox();
                    pic.Size = new Size(150, 150);
                    pic.Dock = DockStyle.Fill;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Load(ppl.staff[k1].imagePath);
                    pic.Name = ppl.staff[k1].username;
                    pic.MouseClick += staffTable_Click;
                    staffTable.Controls.Add(pic, j, i);
                    k1++;
                }
            }
        }//end of people

        void facTable_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            // get About information
            string jsonAbout = getRestData("/people/");

            Label l = new Label();
            l.AutoSize = true;

            // need a way to get the JSON form into a people object
            People fac = JToken.Parse(jsonAbout).ToObject<People>();
            int count = fac.faculty.Count();
            Faculty facVal = new Faculty();
            for (int i = 0; i < count; i++)
            {
                //getting details of each faculty according to the click
                String uname = fac.faculty[i].username;
                if (String.Compare(pic.Name, uname) == 0)
                {
                    facVal = fac.faculty[i];
                }
                else
                {
                    l.Text = fac.faculty[i].username;
                }
            }
            //setting details of each faculty according to the click
            l.Text = facVal.name + "\n"+ facVal.title + "\n"+ facVal.interestArea + "\n"+ facVal.office + "\n"+ facVal.website + "\n"+ facVal.phone + "\n"+ facVal.email;
            PeopleForm pform = new PeopleForm();
            pform.Controls.Add(l);
            pform.ShowDialog();
        }//end of faculty

        void staffTable_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;

            // get About information
            string jsonAbout = getRestData("/people/");

            Label l = new Label();
            l.AutoSize = true;

            // need a way to get the JSON form into a people object
            People fac = JToken.Parse(jsonAbout).ToObject<People>();
            int count = fac.staff.Count();
            Staff staffVal = new Staff();
            for (int i = 0; i < count; i++)
            {
                //getting details of each staff according to the click
                String uname = fac.staff[i].username;
                if (String.Compare(pic.Name, uname) == 0)
                {
                    staffVal = fac.staff[i];
                }
                else
                {
                    l.Text = fac.staff[i].username;
                }
            }
            //setting details of each staff according to the click
            l.Text = staffVal.name + "\n" + staffVal.title + "\n" + "\n" + staffVal.office + "\n" + staffVal.website + "\n" + staffVal.phone + "\n" + staffVal.email;
            PeopleForm pform = new PeopleForm();
            pform.Controls.Add(l);
            pform.ShowDialog();
        }//end of staff

        private void employment_Enter(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/employment/");

            // need a way to get the JSON form into a Employment object
            Employment emp = JToken.Parse(jsonAbout).ToObject<Employment>();
            //getting details of each employment 
            emptitle.Text = emp.introduction.title;
            contentemptitle.Text = emp.introduction.content[0].title;
            contEmpdescription.Text = emp.introduction.content[0].description;
            //getting statistics values from Employment object
            statisticsVal1.Text = emp.degreeStatistics.statistics[0].value + "\n" + emp.degreeStatistics.statistics[0].description;
            statisticsVal2.Text = emp.degreeStatistics.statistics[1].value + "\n" + emp.degreeStatistics.statistics[1].description;
            statisticsVal3.Text = emp.degreeStatistics.statistics[2].value + "\n" + emp.degreeStatistics.statistics[2].description;
            statisticsVal4.Text = emp.degreeStatistics.statistics[3].value + "\n" + emp.degreeStatistics.statistics[3].description;
            //getting coop and emp values from Employment object
            contCoopdescription.Text = emp.introduction.content[1].description;
            contentcooptitle.Text = emp.introduction.content[1].title;
            //getting employer and career values from Employment object
            employerNames.DataSource = emp.employers.employerNames;
            careerNames.DataSource = emp.careers.careerNames;
            employerNames.ClearSelected();
            careerNames.ClearSelected();
            //getting table values from Employment object
            coopTabletitle.Text = emp.coopTable.title+"\n(click here to see the co-op table)";
            employmentTable.Text = emp.employmentTable.title + "\n(click here to see the employment table)";
        }//end of employment

        private void research_Enter(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/research/");

            // need a way to get the JSON form into a Research object
            Research research = JToken.Parse(jsonAbout).ToObject<Research>();
            int i = 0;
            //adding dynamic button to the page
            Button[] button = new Button[15];
            rtext.Text = research.byInterestArea[0].citations[0]+"\n";
            //adding area of interest citation
            for (int p=1; p< research.byInterestArea[0].citations.Count(); p++)
            {
                rtext.Text += research.byInterestArea[0].citations[p] + "\n";
            }
            ftext.Text = research.byFaculty[0].citations[0] + "\n";
            //adding interest citation for faculty
            for (int p = 1; p < research.byFaculty[0].citations.Count(); p++)
            {
                ftext.Text += research.byInterestArea[0].citations[p] + "\n";
            }
            //button for each area
            foreach (ByInterestArea ar in research.byInterestArea)
            {
                button[i] = new Button();
                button[i].Location = new Point(10, 35*i);
                button[i].Size = new Size(272, 35);
                button[i].Name = ar.areaName;
                button[i].Text = ar.areaName;
                button[i].Click += buttonArea_click;
                i++;                              
            }
            areapanel.Controls.AddRange(button);

            //research by faculty
            Button[] buttonfac = new Button[40];
            i = 0;
            int j = 0;
            //adding button for each faculty study
            foreach (ByFaculty ar in research.byFaculty)
            {
                buttonfac[i] = new Button();                
                buttonfac[i].Size = new Size(272, 40);
                buttonfac[i].Name = ar.username;
                buttonfac[i].Text = ar.facultyName;
                buttonfac[i].Click += buttonFac_click;
                if (i > 10)
                {
                    buttonfac[i].Location = new Point(10, 40 * j);
                    facultyPanel2.Controls.Add(buttonfac[i]);
                    j++;
                }
                else
                {
                    buttonfac[i].Location = new Point(10, 40 * i);
                    facultyPanel.Controls.Add(buttonfac[i]);
                }                
                i++;
            }
        }//end of research

        void buttonFac_click(object obj, EventArgs e)
        {
            //getting parent button
            Button b = (Button)obj;
            // get About information
            string jsonAbout = getRestData("/research/");

            // need a way to get the JSON form into a Research object
            Research res = JToken.Parse(jsonAbout).ToObject<Research>();
            int count = res.byFaculty.Count();
            ByFaculty facVal = new ByFaculty();
            for (int i=0; i<count; i++)
            {                
                String uname = res.byFaculty[i].username;               
                if (String.Compare(b.Name, uname) == 0)
                {
                    facVal = res.byFaculty[i];
                }
                else
                {
                    ftext.Text = res.byFaculty[i].username;
                }
            }
            //adding citation according to click
            ftext.Text = facVal.citations[0] + "\n"; ;
            for (int j = 0; j < res.byFaculty[j].citations.Count(); j++)
            {
                ftext.Text += res.byFaculty[j].citations[0] + "\n"; ;
            }

        }//end of onclick

        void buttonArea_click(object obj, EventArgs e)
        {
            //getting parent button
            Button b = (Button)obj;
            // get About information
            string jsonAbout = getRestData("/research/");

            // need a way to get the JSON form into a Research object
            Research res = JToken.Parse(jsonAbout).ToObject<Research>();
            int count = res.byInterestArea.Count();
            ByInterestArea intVal = new ByInterestArea();
            for (int i = 0; i < count; i++)
            {
                String uname = res.byInterestArea[i].areaName;
                if (String.Compare(b.Name, uname) == 0)
                {
                    intVal = res.byInterestArea[i];
                }
                else
                {
                    rtext.Text = res.byInterestArea[i].areaName;
                }
            }
            //adding citation on buttonclick
            rtext.Text = intVal.citations[0] + "\n"; 
            for (int j = 0; j < res.byInterestArea[j].citations.Count(); j++)
            {
                rtext.Text += res.byInterestArea[j].citations[0] + "\n"; ;
            }
        }//end of onclick

        private void news_Enter(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/news/");

            // need a way to get the JSON form into a News object
            News news = JToken.Parse(jsonAbout).ToObject<News>();

            Label newsLabel = new Label();
            newsLabel.AutoSize = true;
            int yr = news.year.Count();
            //getting each kind of news from API
            for(int i=0; i<yr; i++)
            {
                newsLabel.Text += news.year[i].date + "        " + news.year[i].title + "\n" + news.year[i].description+"\n\n";
            }
            int qtr = news.quarter.Count();
            for (int i = 0; i < qtr; i++)
            {
                newsLabel.Text += news.quarter[i].date + "\t" + news.quarter[i].title + "\n" + news.quarter[i].description + "\n\n";
            }
            int mnth = news.month.Count();
            for (int i = 0; i < mnth; i++)
            {
                newsLabel.Text += news.month[i].date + "        " + news.month[i].title + "\n" + news.month[i].description + "\n\n";
            }
            int oldr = news.older.Count();
            for (int i = 0; i < oldr; i++)
            {
                newsLabel.Text += news.older[i].date + "        " + news.older[i].title + "\n" + news.older[i].description + "\n\n";
            }
            //adding news to the panel
            newsPanel.Controls.Add(newsLabel);
        }//end of news

        private void resourses_Enter(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/resources/");

            // need a way to get the JSON form into a Resources object
            Resources resources = JToken.Parse(jsonAbout).ToObject<Resources>();
            //getting resource details from API
            retitle.Text = resources.title;
            resubtitle.Text = resources.subTitle;
            studyAbroad.Text = resources.studyAbroad.title;
            studyAbroad.Click += studyAbroad_Click;
            studentServices.Text = resources.studentServices.title;
            studentServices.Click += studentServices_Click;
            tutorsAndLabInformation.Text = resources.tutorsAndLabInformation.title;
            tutorsAndLabInformation.Click += tutorsAndLabInformation_Click;
            studentAmbassadors.Text = resources.studentAmbassadors.title;
            studentAmbassadors.Click += studentAmbassadors_Click;
            formsRit.Text = "Click to download Forms";
            formsRit.Click += formsRit_Click;
            coopEnrollment.Text = resources.coopEnrollment.title;
            coopEnrollment.Click += coopEnrollment_Click;
        }//end of resources

        void studyAbroad_Click(Object obj, EventArgs e)
        {         
            // get About information
            string jsonAbout = getRestData("/resources/");

            // need a way to get the JSON form into a Resources object
            Resources std = JToken.Parse(jsonAbout).ToObject<Resources>();
            resources res = new resources();
            Label l = new Label();
            //l.AutoSize = true;
            //adding study detials
            l.Width = res.resourcePanel.Width;
            l.Height = res.resourcePanel.Height;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Text = std.studyAbroad.title + "\n\n"+std.studyAbroad.description+"\n\n\n"+std.studyAbroad.places[0].nameOfPlace+": "+std.studyAbroad.places[0].description+"\n\n\n";
            l.Text += std.studyAbroad.places[1].nameOfPlace + ": " + std.studyAbroad.places[1].description + "\n";
            res.resourcePanel.Controls.Add(l);
            res.ShowDialog();
        }//end of onclick

        void studentServices_Click(Object obj, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/resources/");

            // need a way to get the JSON form into a Resources object
            Resources std = JToken.Parse(jsonAbout).ToObject<Resources>();
            resources res = new resources();
            Label l = new Label();
            l.AutoSize = true;
            //l.Width = res.resourcePanel.Width;
            //l.Height = res.resourcePanel.Height;
            //adding student services detials
            l.TextAlign = ContentAlignment.TopLeft;
            l.Text = std.studentServices.title + "\n\n" + std.studentServices.academicAdvisors.title + "\n" + std.studentServices.academicAdvisors.description + "\n\n";
            l.Text += std.studentServices.academicAdvisors.faq.title + ": " + std.studentServices.academicAdvisors.faq.contentHref+ "\n\n\n";
            l.Text += std.studentServices.professonalAdvisors.title;
            l.Text += "\n\n"+ std.studentServices.professonalAdvisors.advisorInformation[0].name+"\n"+ std.studentServices.professonalAdvisors.advisorInformation[0].department+"\n"+ std.studentServices.professonalAdvisors.advisorInformation[0].email+"\n\n";
            l.Text += std.studentServices.professonalAdvisors.advisorInformation[1].name + "\n" + std.studentServices.professonalAdvisors.advisorInformation[1].department + "\n" + std.studentServices.professonalAdvisors.advisorInformation[1].email + "\n\n";
            l.Text += std.studentServices.professonalAdvisors.advisorInformation[2].name + "\n" + std.studentServices.professonalAdvisors.advisorInformation[2].department + "\n" + std.studentServices.professonalAdvisors.advisorInformation[2].email + "\n\n";
            l.Text += std.studentServices.facultyAdvisors.title + "\n" + std.studentServices.facultyAdvisors.description + "\n\n";
            //for(int i=0; i< std.studentServices.facultyAdvisors+)
            res.resourcePanel.Controls.Add(l);
            res.ShowDialog();
        }//end of onclick

        void tutorsAndLabInformation_Click(Object obj, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/resources/");

            // need a way to get the JSON form into a Resources object
            Resources std = JToken.Parse(jsonAbout).ToObject<Resources>();
            resources res = new resources();
            Label l = new Label();
            l.AutoSize = true;
            //l.Width = res.resourcePanel.Width;
            //l.Height = res.resourcePanel.Height;
            l.TextAlign = ContentAlignment.TopLeft;
            l.Text = std.tutorsAndLabInformation.title + "\n\n" + std.tutorsAndLabInformation.description + "\n\n" + std.tutorsAndLabInformation.tutoringLabHoursLink + "\n\n";
            res.resourcePanel.Controls.Add(l);
            res.ShowDialog();
        }//end of onclick

        void studentAmbassadors_Click(Object obj, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/resources/");

            // need a way to get the JSON form into a Resources object
            Resources std = JToken.Parse(jsonAbout).ToObject<Resources>();
            resources res = new resources();
            Label l = new Label();
            l.AutoSize = true;
            //l.Width = res.resourcePanel.Width;
            //l.Height = res.resourcePanel.Height;
            l.TextAlign = ContentAlignment.TopLeft;
            l.Text = std.studentAmbassadors.title + "\n\n";
            for(int i=0; i < std.studentAmbassadors.subSectionContent.Count(); i++)
            {
                l.Text += "\n" + std.studentAmbassadors.subSectionContent[i].title + "\n" + std.studentAmbassadors.subSectionContent[i].description + "\n\n";
            }
            l.Text += "\n\n\nLink: " + std.studentAmbassadors.applicationFormLink + "\n" + std.studentAmbassadors.note;
            res.resourcePanel.Controls.Add(l);
            res.ShowDialog();
        }//end of onlcick

        void formsRit_Click(Object obj, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/resources/");

            // need a way to get the JSON form into a Resources object
            Resources std = JToken.Parse(jsonAbout).ToObject<Resources>();
            resources res = new resources();
            //adding lable for graduate forms
            Label l = new Label();
            l.AutoSize = true;
            l.TextAlign = ContentAlignment.TopLeft;
            l.Text = "Graduate Forms\n\n";
            //add the label to the form
            res.resourcePanel.Controls.Add(l);
            //adding all the graduate form links to the displayed form names in a loop
            for (int i = 0; i < std.forms.graduateForms.Count(); i++)
            {
                LinkLabel ll = new LinkLabel();
                ll.Location = new Point(125, i*30);
                ll.AutoSize = true;
                ll.Text = std.forms.graduateForms[i].formName + "\n";
                ll.Links.Add(0, ll.Text.Count(), "www.ist.rit.edu/" + std.forms.graduateForms[i].href);
                ll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
                res.resourcePanel.Controls.Add(ll);
            }
            //adding lable for undergraduate forms
            Label ugl = new Label();
            ugl.AutoSize = true;
            ugl.TextAlign = ContentAlignment.TopLeft;
            ugl.Text = "UnderGraduate Forms\n\n";
            ugl.Location = new Point(0, 8 * 30);
            //add the label to the form
            res.resourcePanel.Controls.Add(ugl);
            //adding all the undergraduate form links to the displayed form names in a loop
            for (int i = 0; i < std.forms.undergraduateForms.Count(); i++)
            {
                LinkLabel ll = new LinkLabel();
                ll.Location = new Point(125, i+8 * 30);
                ll.AutoSize = true;
                ll.Text = std.forms.undergraduateForms[i].formName + "\n";
                ll.Links.Add(0, ll.Text.Count(), "www.ist.rit.edu/" + std.forms.undergraduateForms[i].href);
                ll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
                res.resourcePanel.Controls.Add(ll);

            }
            //showing the form to display on click
            res.ShowDialog();
        }//end of onclick

        void coopEnrollment_Click(Object obj, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/resources/");

            // need a way to get the JSON form into a Resources object
            Resources std = JToken.Parse(jsonAbout).ToObject<Resources>();
            resources res = new resources();
            Label l = new Label();
            l.AutoSize = true;
            //l.Width = res.resourcePanel.Width;
            //l.Height = res.resourcePanel.Height;
            l.TextAlign = ContentAlignment.TopLeft;
            l.Text = std.coopEnrollment.title+"\n\n";
            //adding table
            for (int i = 0; i < std.coopEnrollment.enrollmentInformationContent.Count(); i++)
            {
                l.Text += std.coopEnrollment.enrollmentInformationContent[i].title + "\n " + std.coopEnrollment.enrollmentInformationContent[i].description + "\n\n";

            }
            l.Text += std.coopEnrollment.RITJobZoneGuidelink;
            res.resourcePanel.Controls.Add(l);
            res.ShowDialog();
        }//end of onclick

        private void coopTabletitle_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/employment/");

            // need a way to get the JSON form into a Employment object
            Employment emp = JToken.Parse(jsonAbout).ToObject<Employment>();
            coopTable cooptable = new coopTable();
            for (var i = 0; i < emp.coopTable.coopInformation.Count; i++)
            {
                cooptable.coopdatagrid.Rows.Add();
                cooptable.coopdatagrid.Rows[i].Cells[0].Value = emp.coopTable.coopInformation[i].employer;
                cooptable.coopdatagrid.Rows[i].Cells[1].Value = emp.coopTable.coopInformation[i].degree;
                cooptable.coopdatagrid.Rows[i].Cells[2].Value = emp.coopTable.coopInformation[i].city;
                cooptable.coopdatagrid.Rows[i].Cells[3].Value = emp.coopTable.coopInformation[i].term;
            }
            //adding table form onclick
            cooptable.ShowDialog();
        }//end of onclcik

        private void employmentTable_Click(object sender, EventArgs e)
        {
            // get About information
            string jsonAbout = getRestData("/employment/");

            // need a way to get the JSON form into a Employment object
            Employment emp = JToken.Parse(jsonAbout).ToObject<Employment>();
            empTable emptable = new empTable();
            //adding emp table
            for (var i = 0; i < emp.employmentTable.professionalEmploymentInformation.Count(); i++)
            {
                emptable.empdatagrid.Rows.Add();
                emptable.empdatagrid.Rows[i].Cells[0].Value = emp.employmentTable.professionalEmploymentInformation[i].employer;
                emptable.empdatagrid.Rows[i].Cells[1].Value = emp.employmentTable.professionalEmploymentInformation[i].degree;
                emptable.empdatagrid.Rows[i].Cells[2].Value = emp.employmentTable.professionalEmploymentInformation[i].city;
                emptable.empdatagrid.Rows[i].Cells[3].Value = emp.employmentTable.professionalEmploymentInformation[i].title;
                emptable.empdatagrid.Rows[i].Cells[4].Value = emp.employmentTable.professionalEmploymentInformation[i].startDate;
            }
            //display table panel
            emptable.ShowDialog();
        }//end of onclcik

        private void quoteAuthor_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
