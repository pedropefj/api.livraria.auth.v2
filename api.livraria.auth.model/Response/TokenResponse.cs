using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.livraria.auth.model.Util;
using Swashbuckle.AspNetCore.Examples;

namespace api.livraria.auth.model.Response
{
    public class TokenResponse
    {
        public string created { get; set; }
        public string expiration { get; set; }
        public string accessToken { get; set; }
        public long? IdUSuario { get; set; }
    }

    public class TokenResponseModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new TokenResponse
            {
                accessToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InBlZHJvLnBlZmpAaG90bWFpbC5jb20iLCJuYmYiOjE1Mzg1MDM3OTAsImV4cCI6MTUzODUwNDk5MCwiaWF0IjoxNTM4NTAzNzkwfQ.FEX0LwFbjHD7v0HniYvCamFzjo9-oiE6MVfH9sriefup3hLfKjp1e8dIoIpKtIi58V7PVrXcmiJl7tCpuUSI4d1076ITa-DRAr7Zjtw8EaEf-CRMomlCtM7SGUwFzsTglwV-gmeAxepF-cEk2OKWPPxcx8npD3isj4GoEd7fZXsnklXZOkryIguzYzjg9yaKwHpHLE7Nu8z2rXZHwN2d9RdOHKlFtXus4PSGoP81xwlarOsmBMrHlPe2KKUdKzq_v2JYpuYvmZmC6n85tAG6hbNncV6JOzUQvy1zw15rqe8d1IkQfmtOFaxe8La-ErY9dLZIvTg97WGEDfuPxBsJXA",
                created = "2018-10-02 18:09:50",
                expiration = "2018-10-02 18:29:50",
                IdUSuario = 1
            };

        }
    }

    public class TokenResponse200 : IExamplesProvider
    {
        public object GetExamples()
        {
            List<string> listaCodigos = new List<string> {"M0007" };
            var retorno = ExemplosUtil.ListarMensagens(listaCodigos, HttpStatusCode.BadRequest);
            return retorno;
        }
    }
}
