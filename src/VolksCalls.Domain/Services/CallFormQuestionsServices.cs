using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.CallForm.Dto;
using VolksCalls.Domain.Models.CallForm.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Domain.Services
{
    public class CallFormQuestionsServices : BaseServiceEntity<CallFormQuestionsDomain>, ICallFormQuestionsServices
    {


        readonly IMapper _mapper;
        public CallFormQuestionsServices(IMapper mapper, IUser user, ICallFormQuestionsRepository callFormQuestionsRepository, LNotifications lNotifications) : base(callFormQuestionsRepository, user, lNotifications)
        {

            _mapper = mapper;
        }

        public async Task<CallFormQuestionsDeleteResponse> CallFormQuestionsDeleteAsync(Guid id)
        {
            var callForm = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Id == id)).FirstOrDefault();
            if (callForm == null)
            {
                _lNotifications.Add(new Notification { Message = $" Atenção Formulário inexistente para o Id ${id} " });
                return new CallFormQuestionsDeleteResponse();
            }
            if (callForm.Active)
            {
                SetDeleteEntity(callForm);
            }
            else
            {
                SetUpdateEntity(callForm);
            }

            return new CallFormQuestionsDeleteResponse();
        }

        public async Task<CallFormQuestionsInsertResponse> CallFormQuestionsInsertAsync(CallFormQuestionsDto callFormQuestionsDto, CallFormDomain callFormDomain)
        {
            var questionAdd = _mapper.Map<CallFormQuestionsDomain>(callFormQuestionsDto);
            SetInsertEntity(questionAdd);
            await AddAsync(questionAdd);
            callFormDomain.CallFormsQuestions.Add(questionAdd);
            return _mapper.Map<CallFormQuestionsInsertResponse>(questionAdd);
        }

        public async Task<CallFormQuestionsUpdateResponse> CallFormQuestionsUpdateAsync(CallFormQuestionsUpdateDto callFormQuestionsUpdateDto)
        {
            var questionUpdate =  (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Id.ToString() == callFormQuestionsUpdateDto.Id)).FirstOrDefault();

            if (questionUpdate == null)
            {
                _lNotifications.Add(new Notification { Message = $" Atenção pergunta não existe para atualizar ${callFormQuestionsUpdateDto.Id}  " });
                return new CallFormQuestionsUpdateResponse();
            }

            SetUpdateEntity(questionUpdate);
            questionUpdate.Key = callFormQuestionsUpdateDto.Key;
            questionUpdate.Label = callFormQuestionsUpdateDto.Label;
            questionUpdate.QuestionType = callFormQuestionsUpdateDto.QuestionType;
            questionUpdate.CallFormQuestionType = callFormQuestionsUpdateDto.CallFormQuestionType;
            questionUpdate.DropdownItens = JsonConvert.SerializeObject(callFormQuestionsUpdateDto.DropdownQuestionDto);
            questionUpdate.Order = callFormQuestionsUpdateDto.Order;
            questionUpdate.Required = callFormQuestionsUpdateDto.Required;
            return _mapper.Map<CallFormQuestionsUpdateResponse>(questionUpdate);
        }
    }
}
