using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Common;
using Recruitment.Dtos;
using Recruitment.Enums;
using Recruitment.Models;
using Recruitment.Security;
using Recruitment.Services;
using System.Text.Json;

namespace Recruitment.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [ApiKeyAuth]
    public class ErpController : ControllerBase
    {
        private readonly IRecruitmentService _recruitmentService;
        private readonly IApplicantService _applicantService;
        private readonly ISetupKeyValueService _setupKeyValueService;
        public ErpController(IRecruitmentService recruitmentService,
            ISetupKeyValueService setupKeyValueService,
            IApplicantService applicantService)
        {
            _recruitmentService = recruitmentService;
            _setupKeyValueService = setupKeyValueService;
            _applicantService = applicantService;
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePositions([FromBody] List<string> jsonData)
        {
            List<RecruitmentDto> Dtos = new();
            jsonData.ForEach(c => { Dtos.Add(JsonSerializer.Deserialize<RecruitmentDto>(c)); });
            await _recruitmentService.HandleRecruitmentsSentFromErp(Dtos);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSetup([FromBody] List<string> jsonData)
        {
            List<SetupKeyValueDto> Dtos = new();
            jsonData.ForEach(c => { Dtos.Add(JsonSerializer.Deserialize<SetupKeyValueDto>(c)); });
            await _setupKeyValueService.HandleSetup(Dtos);
            return Ok();
        }
        [HttpGet]
        [ApiKeyAuth]

        public async Task<IActionResult> GetApplicants()
        {

            return Ok(await _applicantService.GetAllApplicants());
        }
        [HttpPost]
        public async Task<IActionResult> ChangeSentToErp([FromBody] List<decimal> Ids)
        {
            await _applicantService.ChangeSentToErp(Ids);
            return Ok();
        }
    }
}
