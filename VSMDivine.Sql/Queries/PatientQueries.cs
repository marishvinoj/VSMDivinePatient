using System.Diagnostics.CodeAnalysis;

namespace VSMDivine.Sql.Queries
{
    [ExcludeFromCodeCoverage]
	public static class PatientQueries
    {
		public static string AllPatientWithPagination => "EXEC GetPatientsByPage @PageSize, @PageNumber";

		public static string AllPatient => "SELECT * FROM [Patient]";


        public static string PatientById => "SELECT * FROM [Patient] (NOLOCK) WHERE [Id] = @Id";

		public static string AddPatient =>
            @"INSERT INTO [Patient] ([PatientName],[Gender],[MobileNumber],[EmailId],[DOB],[Address],
				[Pincode],[CreatedDate],[CreatedBy],[ModifiedDate],[ModifiedBy],[IsActive]) 
				VALUES (@PatientName,@Gender,@MobileNumber,@EmailId,@DOB,@Address,
				@Pincode,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy,@IsActive)";

		public static string UpdatePatient =>
            @"UPDATE [Patient] 
            SET [PatientName] = @PatientName,
				[Gender] = @Gender,
				[MobileNumber] = @MobileNumber,
				[EmailId] = @EmailId,
				[DOB] = @DOB,
				[Address] = @Address,
				[Pincode] = @Pincode,
				[CreatedDate] = @CreatedDate,
				[CreatedBy] = @CreatedBy,
				[ModifiedDate] = @ModifiedDate,
				[ModifiedBy] = @ModifiedBy,
				[IsActive] = @IsActive
            WHERE [Id] = @Id";

		public static string DeletePatient => "DELETE FROM [Patient] WHERE [Id] = @Id";
	}
}
