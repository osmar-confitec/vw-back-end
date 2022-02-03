using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VolksCalls.Domain.Models.Calls.Dto;

namespace VolksCalls.Domain.Models.Calls.Request
{


    public enum WorkSchedule
    { 
        [Description("1º Turno")]
        FirstRound = 1,
        [Description("2º Turno")]
        SecondRound = 2,
        [Description("3º Turno")]
        ThirdShift = 3,
        [Description("Administrativo")]
        Administrator = 4
    }

    public enum Locality
    {
        [Description("Anchieta(São Bernardo do Campo)")]
        AnchietaSaoBernardoCampo = 1,
        [Description("CRT Belo Horizonte")]
        CRTBeloHorizonte = 2,
        [Description("CRT Goiania")]
        CRTGoiania = 3,
        [Description("CRT Joinville")]
        CRTJoinville = 4,
        [Description("CRT Porto Alegre")]
        CRTPortoAlegre = 5,
        [Description("CRT Recife")]
        CRTRecife = 6,
        [Description("CRT Rio de janeiro")]
        CRTRioJaneiro = 7,
        [Description("CRT São josé do Rio Preto")]
        CRTSaojoseRioPreto = 8,
        [Description("CT São Paulo(Academia Volkswagen)")]
        CTSaoPauloAcademiaVolkswagen = 9,
        [Description("FIS Competence Center(Água Verde/Curitiba)")]
        FISCompetenceCenterAguaVerdeCuritiba = 10,
        [Description("Jabaquara")]
        Jabaquara = 11,
        [Description("Jabaquara Carnaubeiras")]
        JabaquaraCarnaubeiras = 12,
        [Description("Porto de Paranaguá")]
        PortoParanagua = 13,
        [Description("Porto de Suape")]
        PortoSuape = 14,
        [Description("Regional Belo Horizonte")]
        RegionalBeloHorizonte = 15,
        [Description("Regional Brasilia")]
        RegionalBrasilia = 16,
        [Description("Regional Campinas")]
        RegionalCampinas = 17,
        [Description("Regional Curitiba")]
        RegionalCuritiba = 18,
        [Description("Regional Porto Alegre")]
        RegionalPortoAlegre = 19,
        [Description("Regional Recife")]
        RegionalRecife = 20,
        [Description("Regional Rio Claro")]
        RegionalRioClaro = 21,
        [Description("Regional Rio de janeiro Barra")]
        RegionalRiojaneiroBarra = 22,
        [Description("Regional Rio de janeiro Botafogo")]
        RegionalRiojaneiroBotafogo = 23,
        [Description("Regional Vila Mariana")]
        RegionalVilaMariana = 24,
        [Description("Resende")]
        Resende = 25,
        [Description("São Carlos")]
        SaoCarlos = 26,
        [Description("São josé dos Pinhais")]
        SaojosePinhais = 27,
        [Description("Taubaté")]
        Taubate = 28,
        [Description("Vinhedo")]
        Vinhedo = 29,
        [Description("WT Morumbi")]
        WTMorumbi = 30,
        [Description("CT Africa do Sul")]
        CTAfricaSul = 31
    }

    public enum Floor
    { 
        [Description("-1")]
         OneLess = 1,
        [Description("-2")]
         MinusTwo = 2,
        [Description("0")]
        Zero = 3,
        [Description("1")]
        One = 4,
        [Description("2")]
        Two = 5,
        [Description("3")]
        Three = 6,
        [Description("4")]
        Four = 7,
        [Description("5")]
        Five = 8,
        [Description("6")]
        Six = 9,
        [Description("7")]
        Seven = 10,
        [Description("8")]
        Eight = 11,
        [Description("9")]
        Nine = 12,
        [Description("10")]
        Ten = 13,
        [Description("11")]
        Eleven = 14,
        [Description("12")]
        Twelve = 15,
        [Description("13")]
        Thirteen = 16,
        [Description("14")]
        Fourteen = 17,
        [Description("15")]
        Fifteen = 18,
        [Description("16")]
        Sixteen = 19,
        [Description("17")]
        Seventeen = 20,
        [Description("18")]
        Eighteen = 21,
        [Description("19")]
        Nineteen = 22,
        [Description("Mezanino")]
        Mezzanine = 23,
        [Description("Porão")]
        Basement = 24,
        [Description("Subsolo")]
        Underground = 25,
        [Description("Térreo")]
        GroundFloor = 26



    }

    public enum Ala {
        [Description("01")]
        One = 1,
        [Description("02")]
        Two = 2,
        [Description("03")]
        Three = 3,
        [Description("04")]
        Four = 4,
        [Description("05")]
        Five = 5,
        [Description("05A")]
        FiveA = 51,
        [Description("6")]
        Six = 6,
        [Description("7")]
        Seven = 7,
        [Description("8")]
        Eight = 8,
        [Description("8A")]
        EightA = 81,
        [Description("8B")]
        EightB = 82,
        [Description("9")]
        Nine = 9,
        [Description("10")]
        Ten = 10,
        [Description("11")]
        Eleven = 11,
        [Description("12")]
        Twelve = 12,
        [Description("13")]
        Thirteen = 13,
        [Description("14")]
        Fourteen = 14,
        [Description("15")]
        Fifteen = 15,
        [Description("16")]
        Sixteen = 16,
        [Description("17")]
        Seventeen = 17,
        [Description("18")]
        Eighteen = 18,
        [Description("19")]
        Nineteen = 19,
        [Description("20")]
        Twenty = 20,
        [Description("21")]
        TwentyOne = 21,
        [Description("22")]
        TwentyTwo = 22,
        [Description("23")]
        TwentyThree = 23,
        [Description("24")]
        TwentyFour = 24,
        [Description("25")]
        TwentyFive = 25,
        [Description("26")]
        TwentySix = 26,
        [Description("27")]
        TwentySeven = 27,
        [Description("28")]
        TwentyEight = 28,
        [Description("29")]
        TwentyNine = 29,
        [Description("30")]
        Thirty = 30,
        [Description("31")]
        ThirtyOne = 31,
        [Description("32")]
        ThirtyTwo = 32,
        [Description("33")]
        ThirtyThree = 33,
        [Description("34")]
        ThirtyFour = 34,
        [Description("35")]
        ThirtyFive = 35,
        [Description("36")]
        ThirtySix = 36,
        [Description("37")]
        ThirtySeven = 37,
        [Description("38")]
        ThirtyEigth = 38,
        [Description("Outros")]
        Other = 39,
        [Description("Não se aplica")]
        NaoAplica = 40


    }

    public enum Side
    {

        [Description("Santo Amaro")]
        SantoAmaro = 1,

        [Description("Anchieta")]
        Anchieta = 2,

        [Description("Santos")]
        Santos = 3,
        [Description("São Paulo")]
        SaoPaulo = 4,
        [Description("Não se aplica")]
        NaoAplica = 5

    }

    public enum CollaboratorOf
    {

        [Description("Escritório")]
        Desk = 1,

        [Description("Produção")]
        Production = 2
    }


    public class CallsOpeningRequest
    {

        [StringLength(50, ErrorMessage = "O Email pode ter até 50 caracteres.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = " Atenção e-mail inválido")]
        public string Email { get; set; }

        public bool Vip { get; set; }


        [Required(ErrorMessage = " Atenção informe o HostName ")]
        [StringLength(200, ErrorMessage = " O HostName pode ter até 200 caracteres")]
        public string HostName { get; set; }

        [StringLength(200, ErrorMessage = " Atenção Name pode ter até 200 caracteres")]
        public string Name { get; set; }

        [StringLength(20, ErrorMessage = " Atenção Telefone pode ter até 20 caracteres")]
        public string Telephone { get; set; }

        [StringLength(20, ErrorMessage = " Atenção UserId pode ter até 20 caracteres")]
        public string UserId { get; set; }

        [StringLength(50, ErrorMessage = " Atenção Placa pode ter até 20 caracteres")]
        public string Plate { get; set; }

        [StringLength(20, ErrorMessage = " Atenção Telefone celular pode ter até 20 caracteres")]
        public string CellPhone { get; set; }


        [Required(ErrorMessage =" Atenção informe o horário de trabalho ")]
        public WorkSchedule WorkSchedule { get; set; }

        [Required(ErrorMessage = " Atenção informe o colaborador ")]
        public CollaboratorOf Collaborator { get; set; }


        [Required(ErrorMessage = " Atenção informe a localidade ")]
        public Locality Locality { get; set; }

        [StringLength(200, ErrorMessage = " Atenção referencia pode ter até 200 caracteres")]
        public string Reference { get; set; }

        [Required(ErrorMessage = " Atenção informe a ala ")]
        public Ala Ala { get; set; }


        [Required(ErrorMessage = " Atenção informe o andar ")]
        public Floor Floor { get; set; }

        [Required(ErrorMessage = " Atenção informe o lado ")]
        public Side Side { get; set; }

        [StringLength(50, ErrorMessage = " Atenção coluna pode ter até 50 caracteres")]
        public string Column { get; set; }

        [StringLength(200, ErrorMessage = " Atenção nome do contato pode ter até 200 caracteres")]
        public string NameContact { get; set; }

        [StringLength(20, ErrorMessage = " Atenção telefone do contato pode ter até 20 caracteres")]
        public string PhoneContact { get; set; }

        [StringLength(50, ErrorMessage = " Atenção email do contato pode ter até 50 caracteres")]
        [RegularExpression(@"(^$|^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(?:[a-zA-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)$)", ErrorMessage = "Atenção e-mail de contato inválido")]
        public string EmailContact { get; set; }

        [StringLength(200, ErrorMessage = " Atenção Titulo ter até 200 caracteres")]
        [Required(ErrorMessage = " Atenção informe o Titulo ")]
        public string Title { get; set; }

        [Required(ErrorMessage = " Atenção informe a Descrição ")]
        public string Description { get; set; }

        public Guid CategoryParentCI { get; set; }
        public IEnumerable<string> CategoriesSelectedCollection { get; set; }

        public IEnumerable<CallOpeningFilesDto> CallOpeningFiles { get; set; }

        public string CallFormId { get; set; }

        public string ResponseCallForm { get; set; }

        public CallsOpeningRequest()
        {
            CategoriesSelectedCollection = new List<string>();
            CallOpeningFiles = new List<CallOpeningFilesDto>();
        }
    }
}
