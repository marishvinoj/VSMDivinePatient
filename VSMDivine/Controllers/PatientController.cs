using VSMDivine.Api.Models;
using VSMDivine.Application.Interfaces;
using VSMDivine.Core.Entities;
using VSMDivine.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Cors;

namespace VSMDivine.Controllers
{
    [Route("[controller]")]
    [EnableCors("OpenCORSPolicy")]
    public class PatientController : Controller
    {
        #region ===[ Private Members ]=============================================================

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region ===[ Constructor ]=================================================================

        /// <summary>
        /// Initialize PatientController by injecting an object type of IUnitOfWork
        /// </summary>
        public PatientController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region ===[ Public Methods ]==============================================================

        [HttpGet("GetPatientList")]
        public async Task<ApiResponse<List<Patient>>> GetAll(int pageSize = 10, int pageNumber = 1)
        {
            var apiResponse = new ApiResponse<List<Patient>>();

            try
            {
                Log.Information($"Start Time {DateTime.Now}");
                var data = await _unitOfWork.Patients.GetAllAsync(pageSize, pageNumber);
                Log.Information($"End Time {DateTime.Now}");
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "SQL Exception:");
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "Exception:");
            }

            return apiResponse;
        }

        [HttpGet("GetPatientById")]
        public async Task<ApiResponse<Patient>> GetById(int Id)
        {

            var apiResponse = new ApiResponse<Patient>();

            try
            {
                var data = await _unitOfWork.Patients.GetByIdAsync(Id);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "SQL Exception:");
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "Exception:");
            }

            return apiResponse;
        }

        [HttpPost("AddPatient")]
        public async Task<ApiResponse<string>> Add([FromBody] Patient Patient)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Patients.AddAsync(Patient);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "SQL Exception:");
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "Exception:");
            }

            return apiResponse;
        }

        [HttpPut("UpdatePatient")]
        public async Task<ApiResponse<string>> Update([FromBody] Patient Patient)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Patients.UpdateAsync(Patient);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "SQL Exception:");
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "Exception:");
            }

            return apiResponse;
        }

        [HttpDelete]
        public async Task<ApiResponse<string>> Delete(int id)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Patients.DeleteAsync(id);
                apiResponse.Success = true;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "SQL Exception:");
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                Log.Error(ex, "Exception:");
            }

            return apiResponse;
        }

        #endregion
    }

}
