using VSMDivine.Api.Models;
using VSMDivine.Application.Interfaces;
using VSMDivine.Core.Entities;
using VSMDivine.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace VSMDivine.Api.Controllers
{
    public class ContactController : BaseApiController
    {
        #region ===[ Private Members ]=============================================================

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region ===[ Constructor ]=================================================================

        /// <summary>
        /// Initialize ContactController by injecting an object type of IUnitOfWork
        /// </summary>
        public ContactController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #endregion

        #region ===[ Public Methods ]==============================================================

        [HttpGet]
        public async Task<ApiResponse<List<Contact>>> GetAll()
        {
            var apiResponse = new ApiResponse<List<Contact>>();

            try
            {
                var data = await _unitOfWork.Contacts.GetAllAsync();
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

        [HttpGet("{id}")]
        public async Task<ApiResponse<Contact>> GetById(int id)
        {

            var apiResponse = new ApiResponse<Contact>();

            try
            {
                var data = await _unitOfWork.Contacts.GetByIdAsync(id);
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

        [HttpPost]
        public async Task<ApiResponse<string>> Add(Contact contact)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Contacts.AddAsync(contact);
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

        [HttpPut]
        public async Task<ApiResponse<string>> Update(Contact contact)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                var data = await _unitOfWork.Contacts.UpdateAsync(contact);
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
                var data = await _unitOfWork.Contacts.DeleteAsync(id);
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
