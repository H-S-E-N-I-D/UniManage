using UniManage.Models;

namespace UniManage.Repository
{
    public interface IAcademicYearRepository
    {
        AcademicYear AddNewAcademicYear(AcademicYear academicYear);
        AcademicYear UpdateAcademicYear(AcademicYear academicYear);
        List<AcademicYear> GetAllAcademicYears();
        AcademicYear GetAcademicYearById(long id);
        AcademicYear GetAcademicYearByGuid(string guid);  
        bool DeleteAcademicYear(long id);               
    }
}