using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
            this.Visitations = new HashSet<Visitation>();
            this.Diagnoses = new HashSet<Diagnose>();
        }
        public int PatientId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

       // [EmailAddress]
        [Column(TypeName =("varchar(80)"))]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
        public ICollection<Visitation> Visitations { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

    }
}
/*	PatientId
	FirstName (up to 50 characters, unicode)
	LastName (up to 50 characters, unicode)
	Address (up to 250 characters, unicode)
	Email (up to 80 characters, not unicode)
	HasInsurance
*/