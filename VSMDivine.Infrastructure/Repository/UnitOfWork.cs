using VSMDivine.Application.Interfaces;

namespace VSMDivine.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IContactRepository contactRepository, IPatientRepository patientRepository)
        {
            Contacts = contactRepository;
            Patients = patientRepository;
        }

        public IContactRepository Contacts { get; set; }
        public IPatientRepository Patients { get; set; }
    }
}
