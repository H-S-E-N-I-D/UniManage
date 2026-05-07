using UniManage.Mappers;
using UniManage.Models;
using UniManage.Repository;

namespace UniManage.Services
{
    public class AcademicYearService : IAcademicYearService
    {
        private readonly IAcademicYearRepository _academicYearRepository;


        public AcademicYearService(IAcademicYearRepository academicYearRepository)
        {
            _academicYearRepository = academicYearRepository
                ?? throw new ArgumentNullException(nameof(academicYearRepository));
        }

        public AcademicYearVo AddNewAcademicYear(AcademicYearVo academicYearVo)
        {
            ArgumentNullException.ThrowIfNull(academicYearVo);

            try
            {
                var entity = AcademicYearMapper.ToEntity(academicYearVo);

                if (entity == null)
                    throw new InvalidOperationException("Academic Year mapping failed while creating a new AcademicYear.");

                var createdEntity = _academicYearRepository.AddNewAcademicYear(entity);

                if (createdEntity == null)
                    throw new InvalidOperationException("Academic Year creation failed. Repository returned null.");

                return AcademicYearMapper.ToVo(createdEntity);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while adding the Academic Year.", ex);
            }
        }


        public AcademicYearVo UpdateAcademicYear(AcademicYearVo academicYearVo)
        {
            ArgumentNullException.ThrowIfNull(academicYearVo);

            try
            {
                var existingEntity = _academicYearRepository.GetAcademicYearById(academicYearVo.Id);

                if (existingEntity == null)
                    throw new KeyNotFoundException($"Academic Year with ID '{academicYearVo.Id}' was not found.");

                AcademicYearMapper.ApplyUpdates(academicYearVo, existingEntity);

                var updatedEntity = _academicYearRepository.UpdateAcademicYear(existingEntity);

                if (updatedEntity == null)
                    throw new InvalidOperationException("Academic Year update failed. Repository returned null.");

                return AcademicYearMapper.ToVo(updatedEntity);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while updating Academic Year ID '{academicYearVo.Id}'.", ex);
            }
        }



        public List<AcademicYearVo> GetAllAcademicYears()
        {
            try
            {
                var AcademicYears = _academicYearRepository.GetAllAcademicYears();

                if (AcademicYears == null)
                    return new List<AcademicYearVo>();

                return AcademicYears
                    .Select(AcademicYearMapper.ToVo)
                    .Where(AcademicYear => AcademicYear != null)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while retrieving Academic Years.", ex);
            }
        }


        public AcademicYearVo GetAcademicYearById(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Academic Year ID must be greater than zero.", nameof(id));

            try
            {
                var AcademicYear = _academicYearRepository.GetAcademicYearById(id);

                if (AcademicYear == null)
                    throw new KeyNotFoundException($"Academic Year with ID '{id}' was not found.");

                return AcademicYearMapper.ToVo(AcademicYear);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while retrieving Academic Year ID '{id}'.", ex);
            }
        }

        public AcademicYearVo GetAcademicYearByGuid(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentException("Academic Year GUID must not be null or empty.", nameof(guid));

            try
            {
                var AcademicYear = _academicYearRepository.GetAcademicYearByGuid(guid);

                if (AcademicYear == null)
                    throw new KeyNotFoundException($"Academic Year with GUID '{guid}' was not found.");

                return AcademicYearMapper.ToVo(AcademicYear);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while retrieving Academic Year GUID '{guid}'.", ex);
            }
        }

        public bool DeleteAcademicYear(long id)
        {
            if (id <= 0)
                throw new ArgumentException("Academic Year ID must be greater than zero.", nameof(id));

            try
            {
                var existingAcademicYear = _academicYearRepository.GetAcademicYearById(id);

                if (existingAcademicYear == null)
                    throw new KeyNotFoundException($"Academic Year with ID '{id}' was not found.");

                return _academicYearRepository.DeleteAcademicYear(id);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while deleting Academic Year ID '{id}'.", ex);
            }
        }
    }
}