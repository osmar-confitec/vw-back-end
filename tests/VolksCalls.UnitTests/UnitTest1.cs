using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using VolksCalls.Domain.Models.Archive;
using VolksCalls.Infra.CrossCutting;
using VolksCalls.Infra.CrossCutting.Documents;
using Xunit;

namespace VolksCalls.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            //Extension

           var res =   ".blob".Replace(".", "").GetEnumToName<Extension>(Extension.noextension);

            //            var keyvalue = "{'versaoword':'sasa','ipmaquina':'saas','temexcel':'Sim'}";

            //var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(keyvalue);


            // var excelFiles = new ExcelDocument(@"C:\Users\ogvieira\Desktop\VolksIntegração\Carga APP_service desk.xlsx");


            //  var exfile =  excelFiles.ReadExcelFileInLine();
            Assert.True(true);

        }
    }
}
