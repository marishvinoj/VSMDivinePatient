namespace VSMDivine.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IContactRepository Contacts { get; }
        IPatientRepository Patients { get; }
    }
}
