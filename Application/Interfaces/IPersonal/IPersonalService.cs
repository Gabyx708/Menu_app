﻿using Application.Request;
using Application.Response;

namespace Application.Interfaces.IPersonal
{
    public interface IPersonalService
    {
        PersonalResponse GetPersonalById(Guid personalId);
        PersonalResponse UpdatePersonal(Guid personalId, PersonalRequest personal);
        List<PersonalResponse> GetAllPersonal();

        PersonalResponse createPersonal(PersonalRequest personalNuevo);
    }
}
