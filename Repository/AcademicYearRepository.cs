using Microsoft.EntityFrameworkCore;
using UniManage.Data;
using UniManage.Models;

namespace UniManage.Repository
{
    public class AcademicYearRepository : IAcademicYearRepository
    {
        private readonly AppDbContext _dbContext;

        public AcademicYearRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public AcademicYear AddNewAcademicYear(AcademicYear academicYear)
        {
            ArgumentNullException.ThrowIfNull(academicYear);

            academicYear.Guid = System.Guid.NewGuid().ToString();

            _dbContext.AcademicYears.Add(academicYear);
            _dbContext.SaveChanges();

            return academicYear;
        }

        public AcademicYear UpdateAcademicYear(AcademicYear academicYear)
        {
            ArgumentNullException.ThrowIfNull(academicYear);

            var existing = _dbContext.AcademicYears.Find(academicYear.Id)
                ?? throw new KeyNotFoundException($"Academic Year with ID {academicYear.Id} was not found.");

            existing.YearLabel = academicYear.YearLabel;
            existing.StartDate = academicYear.StartDate;
            existing.EndDate = academicYear.EndDate;
            existing.IsActive = academicYear.IsActive;

            _dbContext.SaveChanges();

            return existing;
        }

        public List<AcademicYear> GetAllAcademicYears()
        {
            return _dbContext.AcademicYears.Where(x => x.IsActive == true)
                .AsNoTracking()
                .ToList();
        }

        public AcademicYear GetAcademicYearById(long id)
        {
            return _dbContext.AcademicYears
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id)
                ?? throw new KeyNotFoundException($"AcademicYear with ID {id} was not found.");
        }

        public AcademicYear GetAcademicYearByGuid(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentException("GUID must not be null or empty.", nameof(guid));

            return _dbContext.AcademicYears
                .AsNoTracking()
                .FirstOrDefault(c => c.Guid == guid)
                ?? throw new KeyNotFoundException($"AcademicYear with GUID '{guid}' was not found.");
        }

        public bool DeleteAcademicYear(long id)
        {
            var academicYear = _dbContext.AcademicYears.Find(id);

            if (academicYear is null)
                return false;

            _dbContext.AcademicYears.Remove(academicYear);
            _dbContext.SaveChanges();

            return true;
        }
    }
}