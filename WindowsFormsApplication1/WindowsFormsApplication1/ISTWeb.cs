using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ISTWeb
    {
    }

    public class About
    {
        public string title { get; set; }
        public string description { get; set; }
        public string quote { get; set; }
        public string quoteAuthor { get; set; }
    }

    public class Undergraduate
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }
    }

    public class Graduate
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }
        public List<string> availableCertificates { get; set; }
    }

    public class Degree
    {
        public List<Undergraduate> undergraduate { get; set; }
        public List<Graduate> graduate { get; set; }
    }

    public class UgMinor
    {
        public string name { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> courses { get; set; }
        public string note { get; set; }
    }

    public class Minor
    {
        public List<UgMinor> UgMinors { get; set; }
    }


    public class Faculty
    {
        public string username { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public string imagePath { get; set; }
        public string title { get; set; }
        public string interestArea { get; set; }
        public string office { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
    }

    public class Staff
    {
        public string username { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public string imagePath { get; set; }
        public string title { get; set; }
        public string interestArea { get; set; }
        public string office { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
    }

    public class People
    {
        public string title { get; set; }
        public string subTitle { get; set; }
        public List<Faculty> faculty { get; set; }
        public List<Staff> staff { get; set; }
    }


    public class Content
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Introduction
    {
        public string title { get; set; }
        public List<Content> content { get; set; }
    }

    public class Statistic
    {
        public string value { get; set; }
        public string description { get; set; }
    }

    public class DegreeStatistics
    {
        public string title { get; set; }
        public List<Statistic> statistics { get; set; }
    }

    public class Employers
    {
        public string title { get; set; }
        public List<string> employerNames { get; set; }
    }

    public class Careers
    {
        public string title { get; set; }
        public List<string> careerNames { get; set; }
    }

    public class CoopInformation
    {
        public string employer { get; set; }
        public string degree { get; set; }
        public string city { get; set; }
        public string term { get; set; }
    }

    public class CoopTable
    {
        public string title { get; set; }
        public List<CoopInformation> coopInformation { get; set; }
    }

    public class ProfessionalEmploymentInformation
    {
        public string employer { get; set; }
        public string degree { get; set; }
        public string city { get; set; }
        public string title { get; set; }
        public string startDate { get; set; }
    }

    public class EmploymentTable
    {
        public string title { get; set; }
        public List<ProfessionalEmploymentInformation> professionalEmploymentInformation { get; set; }
    }

    public class Employment
    {
        public Introduction introduction { get; set; }
        public DegreeStatistics degreeStatistics { get; set; }
        public Employers employers { get; set; }
        public Careers careers { get; set; }
        public CoopTable coopTable { get; set; }
        public EmploymentTable employmentTable { get; set; }
    }


    public class ByInterestArea
    {
        public string areaName { get; set; }
        public List<string> citations { get; set; }
    }

    public class ByFaculty
    {
        public string facultyName { get; set; }
        public string username { get; set; }
        public List<string> citations { get; set; }
    }

    public class Research
    {
        public List<ByInterestArea> byInterestArea { get; set; }
        public List<ByFaculty> byFaculty { get; set; }
    }

    public class Year
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Quarter
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Month
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Older
    {
        public string date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }

    public class News
    {
        public List<Year> year { get; set; }
        public List<Quarter> quarter { get; set; }
        public List<Month> month { get; set; }
        public List<Older> older { get; set; }
    }

    public class Place
    {
        public string nameOfPlace { get; set; }
        public string description { get; set; }
    }

    public class StudyAbroad
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<Place> places { get; set; }
    }

    public class Faq
    {
        public string title { get; set; }
        public string contentHref { get; set; }
    }

    public class AcademicAdvisors
    {
        public string title { get; set; }
        public string description { get; set; }
        public Faq faq { get; set; }
    }

    public class AdvisorInformation
    {
        public string name { get; set; }
        public string department { get; set; }
        public string email { get; set; }
    }

    public class ProfessonalAdvisors
    {
        public string title { get; set; }
        public List<AdvisorInformation> advisorInformation { get; set; }
    }

    public class FacultyAdvisors
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class MinorAdvisorInformation
    {
        public string title { get; set; }
        public string advisor { get; set; }
        public string email { get; set; }
    }

    public class IstMinorAdvising
    {
        public string title { get; set; }
        public List<MinorAdvisorInformation> minorAdvisorInformation { get; set; }
    }

    public class StudentServices
    {
        public string title { get; set; }
        public AcademicAdvisors academicAdvisors { get; set; }
        public ProfessonalAdvisors professonalAdvisors { get; set; }
        public FacultyAdvisors facultyAdvisors { get; set; }
        public IstMinorAdvising istMinorAdvising { get; set; }
    }

    public class TutorsAndLabInformation
    {
        public string title { get; set; }
        public string description { get; set; }
        public string tutoringLabHoursLink { get; set; }
    }

    public class SubSectionContent
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class StudentAmbassadors
    {
        public string title { get; set; }
        public string ambassadorsImageSource { get; set; }
        public List<SubSectionContent> subSectionContent { get; set; }
        public string applicationFormLink { get; set; }
        public string note { get; set; }
    }

    public class GraduateForm
    {
        public string formName { get; set; }
        public string href { get; set; }
    }

    public class UndergraduateForm
    {
        public string formName { get; set; }
        public string href { get; set; }
    }

    public class Forms
    {
        public List<GraduateForm> graduateForms { get; set; }
        public List<UndergraduateForm> undergraduateForms { get; set; }
    }

    public class EnrollmentInformationContent
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class CoopEnrollment
    {
        public string title { get; set; }
        public List<EnrollmentInformationContent> enrollmentInformationContent { get; set; }
        public string RITJobZoneGuidelink { get; set; }
    }

    public class Resources
    {
        public string title { get; set; }
        public string subTitle { get; set; }
        public StudyAbroad studyAbroad { get; set; }
        public StudentServices studentServices { get; set; }
        public TutorsAndLabInformation tutorsAndLabInformation { get; set; }
        public StudentAmbassadors studentAmbassadors { get; set; }
        public Forms forms { get; set; }
        public CoopEnrollment coopEnrollment { get; set; }
    }


    public class Social
    {
        public string title { get; set; }
        public string tweet { get; set; }
        public string by { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
    }

    public class QuickLink
    {
        public string title { get; set; }
        public string href { get; set; }
    }

    public class Copyright
    {
        public string title { get; set; }
        public string html { get; set; }
    }

    public class Footer
    {
        public Social social { get; set; }
        public List<QuickLink> quickLinks { get; set; }
        public Copyright copyright { get; set; }
        public string news { get; set; }
    }

}
