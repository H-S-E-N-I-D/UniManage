using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniManage.Models
{
    /// <summary>
    /// Maps to the <c>student_profiles</c> table.
    /// Inherits shared identity fields from <see cref="UserProfile"/>.
    /// </summary>
    [Table("student_profiles")]
    public class StudentProfile : UserProfile
    {
        /// <summary>
        /// Unique student registration / index number.
        /// </summary>
        [MaxLength(20)]
        public string? RegistrationNumber { get; set; }

        /// <summary>
        /// Date of birth.
        /// </summary>
        public DateOnly? Dob { get; set; }

        /// <summary>
        /// National Identity Card number.
        /// </summary>
        [MaxLength(20)]
        public string? Nic { get; set; }

        public Gender? Gender { get; set; }
    }

    /// <summary>
    /// Mirrors the <c>gender</c> enum defined in the database.
    /// </summary>
    public enum Gender
    {
        MALE,
        FEMALE
    }
}
