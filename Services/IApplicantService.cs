﻿using Recruitment.Models;

namespace Recruitment.Services
{
    public interface IApplicantService
    {
        Task<List<Applicant>> GetAllApplicants();

    }
}
