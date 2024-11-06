using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Common;
using Recruitment.Dtos;
using Recruitment.Enums;
using Recruitment.Models;
using Recruitment.Services;
using System.Text.Json;

namespace Recruitment.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ErpController : ControllerBase
    {
        private readonly IRecruitmentService _recruitmentService;
        private readonly IApplicantService _applicantService;
        private readonly ISetupKeyValueService _setupKeyValueService;
        public ErpController(IRecruitmentService recruitmentService)
        {
            _recruitmentService = recruitmentService;
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRecruitments([FromBody] List<string> jsonData)
        {
            List<RecruitmentDto> Dtos = new();
            jsonData.ForEach(c => { Dtos.Add(JsonSerializer.Deserialize<RecruitmentDto>(c)); });
            var ExistScheduleIds = await _recruitmentService.GetRecruitmentIds();

            foreach (var recruitment in Dtos)
            {
                if (ExistScheduleIds.Contains(recruitment.ErpDepartmentPositionID))
                {
                    switch (recruitment.EventType)
                    {
                        case EventType.Modified:
                            //await _recruitmentService.UpdateRecruitment(recruitment);
                            break;
                        case EventType.Deleted:
                            {
                                await _recruitmentService.DeleteRecruitment(recruitment.ErpDepartmentPositionID);
                                ExistScheduleIds.Remove(recruitment.ErpDepartmentPositionID);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if ( recruitment.EventType == EventType.Added)
                    {
                        //await _recruitmentService.CreateRecruitment(recruitment);
                        ExistScheduleIds.Add(recruitment.ErpDepartmentPositionID);
                    }
                }

            }
            return Ok();
        }
        //public async Task<IActionResult> UpdateKeyValues([FromBody] List<string> jsonData)
        //{
        //    List<KeyValue> Dtos = new();
        //    jsonData.ForEach(c => { Dtos.Add(JsonSerializer.Deserialize<KeyValue>(c)); });

        //    foreach (var recruitment in Dtos)
        //    {
        //        if()
        //        if (ExistScheduleIds.Contains(recruitment.ErpDepartmentPositionID))
        //        {
        //            switch (recruitment.EventType)
        //            {
        //                case EventType.Modified:
        //                    await _recruitmentService.UpdateRecruitment(recruitment);
        //                    break;
        //                case EventType.Deleted:
        //                    {
        //                        await _recruitmentService.DeleteRecruitment(recruitment.ErpDepartmentPositionID);
        //                        ExistScheduleIds.Remove(recruitment.ErpDepartmentPositionID);
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            if (recruitment.EventType == EventType.Added)
        //            {
        //                await _recruitmentService.CreateRecruitment(recruitment);
        //                //ExistScheduleIds.Add(recruitment.ErpDepartmentPositionID);
        //            }
        //        }

        //    }
        //    return Ok();
        //}
        [HttpGet]
        public async Task<IActionResult> GetApplicants()
        {

            return Ok(_applicantService.GetAllApplicants());
        }
        [HttpPost]
        public async Task<IActionResult> ChangeSentToErp([FromBody] List<decimal> Ids)
        {
            await _recruitmentService.ChangeSentToErp(Ids);
            return Ok();
        }
    }
}
