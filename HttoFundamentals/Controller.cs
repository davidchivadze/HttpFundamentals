using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HttoFundamentalsListener
{
    public static class Controller
    {
        public static ResponseListen ExecuteRequest(string Url)
        {
            var methodName = Url.Split('/');
            switch (methodName[methodName.Length - 2])
            {
                case "MyName":
                    return new ResponseListen() { ResponseText = GetMyName(), statusCode = HttpStatusCode.NotFound };
                    break;
                case "Information":
                    return new ResponseListen() { ResponseText = "1xx – Information", statusCode = HttpStatusCode.Continue };
                    break;
                case "Success":
                    return new ResponseListen() { ResponseText = "2xx – Success", statusCode = HttpStatusCode.OK };
                    break;

                case "Redirection":
                    return new ResponseListen() { ResponseText = "3xx – Redirection", statusCode = HttpStatusCode.Redirect };
                    break;

                case "ClientError":
                    return new ResponseListen() { ResponseText = "4xx – Client error", statusCode = HttpStatusCode.NotFound };
                    break;

                case "ServerError":
                    return new ResponseListen() { ResponseText = "5xx – Server error", statusCode = HttpStatusCode.InternalServerError };
                    break;
                case "MyNameByHeader":
                    return new ResponseListen() { Header="David",statusCode = HttpStatusCode.OK,ResponseText="" };
                    break;
                case "MyNameByCookies":
                    return new ResponseListen() { statusCode = HttpStatusCode.OK, Coockie = "David", ResponseText = "" };
                    break;
                default:
                    return new ResponseListen() { ResponseText = "Url Not Found!",statusCode=HttpStatusCode.NotFound};
                    break;
            }
        }
        private static string GetMyName()
        {
            return "David Chivadze";
        }
    }


    }
