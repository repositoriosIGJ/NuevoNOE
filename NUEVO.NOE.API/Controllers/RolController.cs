﻿using Microsoft.AspNetCore.Mvc;
using NUEVO.NOE.Business.Contrato;
using NUEVO.NOE.DTO;
using NUEVO.NOE.Model.Seguridad;

namespace NUEVO.NOE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolesBusiness _rolesBusiness;

        public RolController(IRolesBusiness rolesBusiness)
        {
            _rolesBusiness = rolesBusiness;
        }

        [HttpGet("GetAllRoles")]
        public async Task<ResponseDTO<List<RolDTO>>> GetAllRoles()
        {
            var rsp = await _rolesBusiness.GetRoles();

            return rsp;
        }

        [HttpGet("GetRolById")]
        public Task<ResponseDTO<RolDTO>> GetRolById(int id)
        {

            var rst = _rolesBusiness.GetRolById(id);

            return rst;
        }


        [HttpPost("AddRol")]
        public async Task<ResponseDTO<bool>> AddRol(RolDTO rolDTO)
        {
            var rst = await _rolesBusiness.AddRol(rolDTO);

            return rst;
        }

        [HttpPut("UpdateRol")]
        public async Task<ResponseDTO<RolDTO>> UpdateRol(RolDTO rolDTO)
        {
            var rst = await _rolesBusiness.UpdateRol(rolDTO);
            return rst;
        }

        [HttpDelete("DeleteRol")]
        public async Task<ResponseDTO<bool>> DeleteRol(int id)
        {
            var rst = await _rolesBusiness.DeleteRol(id);

            return rst;
        }


        [HttpGet("GetRolesNotAssignedToUser")]
        public async Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUser(int userId)
        {
            var rst = await _rolesBusiness.GetRolesNotAssignedToUser(userId);

            return rst;
        }

        [HttpGet("GetRolesAssignedToUser")]
        public async Task<ResponseDTO<List<RolDTO>>> GetRolesAssignedToUser(int userId)
        {
            var rst = await _rolesBusiness.GetRolesAssignedToUser(userId);
            return rst;
        }

        [HttpGet("GetRolesNotAssignedToUserByDepartamento/{userId}/{departamentoId}")]
        public async Task<ResponseDTO<List<RolDTO>>> GetRolesNotAssignedToUserByDpto(int userId, int departamentoId)
        {
            var rst = await _rolesBusiness.GetRolesNotAssignedToUserByDepartamento(userId, departamentoId);

            return rst;
        }
    }
}