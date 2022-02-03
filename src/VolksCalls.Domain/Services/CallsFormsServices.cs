using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VolksCalls.Domain.Interfaces;
using VolksCalls.Domain.Models.CallForm;
using VolksCalls.Domain.Models.CallForm.Request;
using VolksCalls.Domain.Models.CallForm.Response;
using VolksCalls.Domain.Repository;
using VolksCalls.Infra.CrossCutting;

namespace VolksCalls.Domain.Services
{
    public class CallsFormsServices : BaseServiceEntity<CallFormDomain>, ICallsFormsServices
    {

        readonly IMapper _mapper;
        readonly ICallFormQuestionsServices _callFormQuestionsServices;
        public CallsFormsServices(ICallFormQuestionsServices callFormQuestionsServices, IUser user, ICallsFormsRepository iBaseRepository, IMapper mapper, LNotifications lNotifications)
            : base(iBaseRepository, user, lNotifications)
        {
            _mapper = mapper;
            _callFormQuestionsServices = callFormQuestionsServices;
        }

        public async Task<CallFormInsertResponse> CallFormInsertAsync(CallFormInsertRequest callFormInsertRequest)
        {
            ValidcallInsertRequest(callFormInsertRequest);
            if (_lNotifications.Any())
                return new CallFormInsertResponse();


            if (callFormInsertRequest.IsDefault)
            {
                var callFormDefault = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.IsDefault)).FirstOrDefault();
                if (callFormDefault != null)
                {
                    _lNotifications.Add(new Notification { Message = $" Atenção já existe um formulário com a opção padrão favor verifique o cadastro do form ${callFormDefault.Name}. " });
                    return new CallFormInsertResponse();
                }
            }
            var callForm = _mapper.Map<CallFormDomain>(callFormInsertRequest);
            SetInsertEntity(callForm);
            await AddAsync(callForm);
            var ret = _mapper.Map<CallFormInsertResponse>(callForm);
            foreach (var item in callFormInsertRequest.CallFormQuestions)
            {
                var respAdd = await _callFormQuestionsServices.CallFormQuestionsInsertAsync(item, callForm);
                if (_lNotifications.Any())
                    break;
                ret.callFormQuestionsInsertResponses.Add(respAdd);
            }
            return ret;
        }

        public async Task<CallFormUpdateResponse> CallFormUpdateAsync(CallFormUpdateRequest callFormUpdateRequest)
        {
            ValidcallUpdateRequest(callFormUpdateRequest);
            if (_lNotifications.Any())
                return new CallFormUpdateResponse();

            if (callFormUpdateRequest.IsDefault)
            {
                var callFormDefault = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.IsDefault && x.Id != callFormUpdateRequest.Id)).FirstOrDefault();
                if (callFormDefault != null)
                {
                    _lNotifications.Add(new Notification { Message = $" Atenção já existe um formulário com a opção padrão favor verifique o cadastro do form ${callFormDefault.Name}. " });
                    return new CallFormUpdateResponse();
                }
            }

            var callForm = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Id == callFormUpdateRequest.Id)).FirstOrDefault();
            if (callForm == null)
            {
                _lNotifications.Add(new Notification { Message = $" Atenção Formulário inexistente para o Id ${callFormUpdateRequest.Id} " });
                return new CallFormUpdateResponse();
            }

            SetUpdateEntity(callForm);
            callForm.IsDefault = callFormUpdateRequest.IsDefault;
            callForm.Name = callFormUpdateRequest.Name;
            callForm.CallFormType = callFormUpdateRequest.CallFormType;

            var QuestionsInsert = callFormUpdateRequest.CallFormQuestionsFormsDtos.Where(x => x.StateFormQuestions == Models.CallForm.Dto.StateFormQuestions.Insert).ToList();
            var QuestionsUpdate = callFormUpdateRequest.CallFormQuestionsFormsDtos.Where(x => x.StateFormQuestions == Models.CallForm.Dto.StateFormQuestions.Update).ToList();

            foreach (var item in QuestionsUpdate)
                await _callFormQuestionsServices.CallFormQuestionsUpdateAsync(item);

            foreach (var item in QuestionsInsert)
                await _callFormQuestionsServices.CallFormQuestionsInsertAsync(item, callForm);

            return _mapper.Map<CallFormUpdateResponse>(callForm);

        }

        bool KeyValid(string key)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9]*$");

            Match match = regex.Match(key);

            // Step 3: test for Success.
            return (match.Success);
                
        }

        bool LabelValid(string label)
        {
            return !string.IsNullOrEmpty(label);
        
        }

        void ValidcallUpdateRequest(CallFormUpdateRequest callFormInsertRequest)
        {
            if (!callFormInsertRequest.CallFormQuestionsFormsDtos.Any())
                _lNotifications.Add(new Notification { Message = $" Atenção é necessário ter perguntas para incluir um formulário. " });

            if (!Enum.IsDefined(typeof(CallFormType), callFormInsertRequest.CallFormType))
                _lNotifications.Add(new Notification { Message = $" Atenção é necessário passar o enumerador correto. " });

            foreach (var item in callFormInsertRequest.CallFormQuestionsFormsDtos)
            {
                GetErrorEntity(item.DropdownQuestionDto);
                foreach (var itemDrop in item.DropdownQuestionDto.DropDownQuestionOptionsDtos)
                {
                    GetErrorEntity(itemDrop);
                }
                GetErrorEntity(item);
            }

           
            var keysDuplicates = callFormInsertRequest.CallFormQuestionsFormsDtos.Select(x => x.Key).GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
            if (keysDuplicates != null && keysDuplicates.Any())
                _lNotifications.Add(new Notification { Message = $" Atenção existem chaves de perguntas duplicadas ${ string.Join(',', keysDuplicates)}. " });

            var OrdersDuplicates = callFormInsertRequest.CallFormQuestionsFormsDtos.Select(x => x.Order).GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
            if (OrdersDuplicates != null && OrdersDuplicates.Any())
                _lNotifications.Add(new Notification { Message = $" Atenção existem ordenações de perguntas duplicadas ${ string.Join(',', OrdersDuplicates)}. " });


        }

        void ValidcallInsertRequest(CallFormInsertRequest callFormInsertRequest)
        {
            if (!callFormInsertRequest.CallFormQuestions.Any())
                _lNotifications.Add(new Notification { Message = $" Atenção é necessário ter perguntas para incluir um formulário. " });

            if (!Enum.IsDefined(typeof(CallFormType), callFormInsertRequest.CallFormType))
                _lNotifications.Add(new Notification { Message = $" Atenção é necessário passar o enumerador correto. " });

            foreach (var item in callFormInsertRequest.CallFormQuestions)
            {
                GetErrorEntity(item.DropdownQuestionDto);
                foreach (var itemDrop in item.DropdownQuestionDto.DropDownQuestionOptionsDtos)
                {
                    GetErrorEntity(itemDrop);
                }
                GetErrorEntity(item);
            }

           var keysDuplicates = callFormInsertRequest.CallFormQuestions.Select(x => x.Key).GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
            if (keysDuplicates != null && keysDuplicates.Any())
                _lNotifications.Add(new Notification { Message = $" Atenção existem chaves de perguntas duplicadas ${ string.Join(',', keysDuplicates)}. " });

            var OrdersDuplicates = callFormInsertRequest.CallFormQuestions.Select(x => x.Order).GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key);
            if (OrdersDuplicates != null && OrdersDuplicates.Any())
                _lNotifications.Add(new Notification { Message = $" Atenção existem ordenações de perguntas duplicadas ${ string.Join(',', OrdersDuplicates)}. " });
        }

        public async Task<CallFormDeleteResponse> CallFormDeleteAsync(Guid id)
        {
            var callForm = (await _iBaseRepository._repositoryConsult.SearchAsync(x => x.Id == id)).FirstOrDefault();
            if (callForm == null)
            {
                _lNotifications.Add(new Notification { Message = $" Atenção Formulário inexistente para o Id ${id} " });
                return new CallFormDeleteResponse();
            }
            if (callForm.Active)
            {
                SetDeleteEntity(callForm);
            }
            else
            {
                SetUpdateEntity(callForm);
            }
           
            return new CallFormDeleteResponse();
        }
    }
}
