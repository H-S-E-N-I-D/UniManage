using UniManage.Models;

namespace UniManage.Services
{
    public interface IAcademicYearService
    {
        AcademicYearVo AddNewAcademicYear(AcademicYearVo academicYear);
        AcademicYearVo UpdateAcademicYear(AcademicYearVo academicYear);
        List<AcademicYearVo> GetAllAcademicYears();
        AcademicYearVo GetAcademicYearById(long id);
        AcademicYearVo GetAcademicYearByGuid(string guid);
        bool DeleteAcademicYear(long id);
    }
}
